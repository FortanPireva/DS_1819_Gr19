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

        private void btnregjistro_Click(object sender, EventArgs e)
        {
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


                string mesazhi = emritxt.Text + ":" + mbiemritxt.Text + ":" + emailtxt.Text + ":" + passwordtxt.Text + ":" + titullitxt.Text + ":" +rrogatxt.Text;
                byte[] encrytedData = des.Enkripto(mesazhi);
                
                byte[] IV = des.getIV();
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                RSAPKCS1KeyExchangeFormatter formater =new RSAPKCS1KeyExchangeFormatter(rsa);


            //    rsa.ImportCspBlob(UDPClient.getPublicKey());

              //  byte[] encryptedKey = RSAClass.RSAEncrypt(des.getKey(), rsa.ExportParameters(true), false);

                //int newSize = IV.Length + encryptedKey.Length + encrytedData.Length;

                //var ms = new MemoryStream(new byte[newSize], 0, newSize, true, true);
                //ms.Write(IV, 0, IV.Length);
                //ms.Write(encryptedKey, 0, encryptedKey.Length);
                //ms.Write(encrytedData, 0, encrytedData.Length);
                //byte[] data = ms.GetBuffer();

                string delimiter = "$";
                string fullmessageEncrypted = Encoding.UTF8.GetString(IV) + delimiter+Encoding.UTF8.GetString(des.getKey())+delimiter+Encoding.UTF8.GetString(encrytedData);
                byte[] receivedData = client.SendAndReceive(Encoding.UTF8.GetBytes(fullmessageEncrypted));

                string receivedData1 = Encoding.ASCII.GetString(receivedData);

                mbiemritxt.Text = receivedData1;
                MessageBox.Show("Registered successfully");
                Login login = new Login();
                this.Hide();
                login.Show();

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
                emritxt.Text = "";
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
                mbiemritxt.Text = "";
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
                titullitxt.Text = "";
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
                rrogatxt.Text = "";
                return true;
            }
        }

        private bool validatePass()
        {
            string pattern = "^[\\S*$]"; // no spaces
            if (passwordtxt.Text.Length > 4 && Regex.IsMatch(passwordtxt.Text, pattern) && passwordtxt.Text.Equals(kpasswordtxt.Text))
            {
                passwordtxt.Text = "";
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
                emailtxt.Text = "";
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
    }
}
