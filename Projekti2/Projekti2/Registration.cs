using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Projekti2
{
    public partial class Registration : Form
    {
        UDPClient client;
        public Registration()
        {

            InitializeComponent();
            client = new UDPClient("127.0.0.1", 12000);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private static X509Certificate2 GetCertificateFromStore(string certName)
        {

            // Get the certificate store for the current user.
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            try
            {
                store.Open(OpenFlags.ReadOnly);

                // Place all certificates in an X509Certificate2Collection object.
                X509Certificate2Collection certCollection = store.Certificates;
                // If using a certificate with a trusted root you do not need to FindByTimeValid, instead:
                // currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, true);
                X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection signingCert = currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, false);
                if (signingCert.Count == 0)
                    return null;
                // Return the first certificate in the collection, has the right name and is current.
                return signingCert[0];
            }
            finally
            {
                store.Close();
            }

        }

        public static byte[] EncryptDataOaepSha1(X509Certificate2 cert, byte[] data)
        {
            // GetRSAPublicKey returns an object with an independent lifetime, so it should be
            // handled via a using statement.
            using (RSA rsa = cert.GetRSAPublicKey())
            {
                // OAEP allows for multiple hashing algorithms, what was formermly just "OAEP" is
                // now OAEP-SHA1.
                return rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA1);
            }
        }
        private void btnregjistro_Click(object sender, EventArgs e)
        {
             X509Certificate2 cert = GetCertificateFromStore("CN=RootCA");
            if (cert == null)
            {
                Console.WriteLine("Certificate 'CN=CERT_SIGN_TEST_CERT' not found.");
                Console.ReadLine();
            }
            string name = emritxt.Text.Trim();
            string mbiemri = mbiemritxt.Text.Trim();
            string email = emailtxt.Text.Trim();
            string title = titullitxt.Text.Trim();
            string salary = rrogatxt.Text.Trim();





            if (validate())
            {
               name = emritxt.Text.Trim();


              mbiemri = mbiemritxt.Text.Trim();


                DES des = new DES();


                string mesazhi = name + ":" + mbiemri + ":" + emailtxt.Text + ":" + passwordtxt.Text.Trim() + ":" + titullitxt.Text + ":" + rrogatxt.Text;
                Console.WriteLine(mesazhi);
                byte[] encrytedData = des.Enkripto(mesazhi);

                byte[] IV = des.getIV();
                byte[] key = des.getKey();


                byte[] encryptedKey = EncryptDataOaepSha1(cert, key);

                Console.WriteLine(encryptedKey.Length);
                Console.WriteLine(Convert.ToBase64String(encryptedKey));
              
                Console.WriteLine(Convert.ToBase64String(key));
                Console.WriteLine(Convert.ToBase64String(DecryptDataOaepSha1(cert, encryptedKey)));


                string delimiter = ".";
              string fullmessageEncrypted = Convert.ToBase64String(IV) + delimiter + Convert.ToBase64String(encryptedKey) + delimiter + Convert.ToBase64String(encrytedData);
          
           
            byte[] receivedData = client.SendAndReceive(Encoding.UTF8.GetBytes(fullmessageEncrypted));

            Console.WriteLine("qa qova :" + fullmessageEncrypted.Length);
                Console.WriteLine("IV:" + Convert.ToBase64String(IV));
                Console.WriteLine("Qelsi: " + Convert.ToBase64String(encryptedKey));
                Console.WriteLine("Mesazhi: " + Convert.ToBase64String(encrytedData));
                Console.WriteLine(Encoding.UTF8.GetString(des.Dekripto(Convert.ToBase64String(receivedData))));

                if (Encoding.UTF8.GetString(des.Dekripto(Convert.ToBase64String(receivedData))).Substring(0,2) == "OK")
                {
                    MessageBox.Show("Registered successfully");
                    Login login = new Login();
                    this.Hide();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Regjistrimi deshtoi");
                }
            }
            else
            {
                MessageBox.Show("Te dhenat jane shenuar gabim");
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {








        }
        //
        //validating methods
        //
        private bool validateName()
        {
            string pattern = "^[a-zA-Z]";
            if (Regex.IsMatch(emritxt.Text, pattern) && emritxt.Text.Length > 2)
            {
                
                return true;
            }
            else
            {
                emritxt.Text = "*Wrong input";
                return false;
            }
        }
        private bool validateSurname()
        {
            string pattern = "^[a-zA-Z]";
            if (Regex.IsMatch(mbiemritxt.Text, pattern) && mbiemritxt.Text.Length > 2)
            {
               
                return true;
            }
            else
            {
                mbiemritxt.Text = "*Wrong input";
                return false;
            }
        }
        private bool validateTitle()
        {
            string pattern = "^[a-zA-Z]";
            if (Regex.IsMatch(titullitxt.Text, pattern))
            {
                
                return true;
            }
            else
            {
                titullitxt.Text = "*Wrong input";
                return false;
            }
        }
        private bool validateSalary()
        {
            if (Double.Parse(rrogatxt.Text) == double.NaN)
            {
                rrogatxt.Text = "*Input a number!";
                return false;
            }
            else
            {
               
                return true;
            }
        }

        private bool validatePass()
        {
            string pattern = "^[\\S*$]"; // no spaces
            if (passwordtxt.Text.Length > 4 && Regex.IsMatch(passwordtxt.Text, pattern) && passwordtxt.Text.Equals(kpasswordtxt.Text))
            {
                
                return true;
            }
            else
            {
                passwordtxt.Text = "*Input more chars";
                return false;
            }
        }
        private bool validateEmail()
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (Regex.IsMatch(emailtxt.Text, pattern, RegexOptions.IgnoreCase))
            {
                
                return true;
            }
            else
            {
                emailtxt.Text = "* Wrong email";
                return false;
            }
        }
        private bool validate()
        {

            if (validateName() && validateSurname() && validateEmail() && validateTitle() && validateSalary()
                 && validatePass())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void titullitxt_TextChanged(object sender, EventArgs e)
        {

        }
        private static void EncryptFile(string inFile, RSACryptoServiceProvider rsaPublicKey)
        {
            
        }
        public static byte[] DecryptDataOaepSha1(X509Certificate2 cert, byte[] data)
        {
            // GetRSAPrivateKey returns an object with an independent lifetime, so it should be
            // handled via a using statement.
            using (RSA rsa = cert.GetRSAPrivateKey())
            {
                return rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA1);
            }
        }
    }
}
