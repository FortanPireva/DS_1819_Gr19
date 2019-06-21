using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace UdpServer
{
    class Program
    {
        public static  DESCryptoServiceProvider des=new DESCryptoServiceProvider();

        private static byte[] desKey;
        private static byte[] desIv;
        public static string serverMessage;
        static void Main(string[] args)
        {

            X509Certificate2 cert = GetCertificateFromStore("CN=RootCA");
            if (cert == null)
            {
                Console.WriteLine("Certificate");
                Console.ReadLine();
            }

            Console.WriteLine(GenerateSalt());
            string emri = "Fortan";
            emri = emri.Substring(0, 1).ToUpper() + emri.Substring(1);
            Console.WriteLine(emri);

            while (true)
            {
                UDPServer udpserver = new UDPServer("127.0.0.1", 12000);
                Console.WriteLine("Serveri eshte i gatshem per kerkesa");
                //Merr absolute path per fajllin e certifikates se serverit
              

                while (true)
                {
                    byte[] receivedata = udpserver.Receive();
                    

                    string[] data = Encoding.UTF8.GetString(receivedata).Split('.');

                    for (int i = 0; i < data.Length; i++)
                    {
                        Console.WriteLine(data[i]+" Length= "+data[i].Length);

                    }
                    Console.WriteLine(data.Length);


                    int messageLength = data[2].Length;
                    
                    byte[] message =new byte[messageLength];
                        
                    int length = data[1].Length;
                    Console.WriteLine(length);
                   desKey = new byte[length];
                    
                    
                  
                    desKey = DecryptDataOaepSha1(cert,Convert.FromBase64String(data[1]));
                    int ivlength = data[0].Length;

                     desIv = new byte[ivlength];

                     desIv =Convert.FromBase64String(data[0]);
                    Console.WriteLine("Gjatesia e pranuar"+data.Length);
                    Console.WriteLine(Convert.ToBase64String(desKey));

                    byte[] decryptedMessage = DekriptoDes(data[2]);

                    Console.WriteLine(Convert.ToBase64String(decryptedMessage));

                 

                    
                    string[] tedhenat = Encoding.UTF8.GetString(decryptedMessage).Split(':');

                    Console.WriteLine(tedhenat.Length);
                    if (tedhenat.Length > 3)
                    {
                        if (handleRegistration(tedhenat))
                        {
                            serverMessage = "OK";
                        }


                        else
                        {
                            serverMessage = "Error";
                        }
                        udpserver.Send(Enkripto(serverMessage));
                    }
                    else
                    {
                        if (handleLogin(tedhenat))
                        {
                            serverMessage = "OK";
                        }
                        else
                        {
                            serverMessage = "Error";
                        }
                        udpserver.Send(Enkripto(serverMessage));

                    }




                }
            }
            
        }
        private static Boolean handleRegistration(string[] tedhenat)
        {
            DBConnect db = new DBConnect();
            string salt = GenerateSalt();
            string saltedpassword = getSaltedHash(salt, tedhenat[3]);
            byte[] passB = Encoding.UTF8.GetBytes(tedhenat[3]);
            for (int i = 0; i < passB.Length; i++)
            {
                Console.Write(passB[i]);

            }
            return db.Insert(tedhenat[0], tedhenat[1], tedhenat[2],salt,saltedpassword, tedhenat[4], int.Parse(tedhenat[5]));
          

        }
        private static Boolean handleLogin(string[] tedhenat)
        {
            DBConnect db = new DBConnect();
            List<string>[] list=db.Select(tedhenat[0]);

            string salt = list[4].ToArray()[0];
            Console.WriteLine("qiky sallti qity"+salt);
            string passi = tedhenat[1].Trim();
            Console.WriteLine("Passi i shkrum"+passi);
            byte[] passB = Encoding.UTF8.GetBytes(passi);
            for (int i = 0; i < passB.Length; i++)
            {
                Console.Write(passB[i]);

            }
            Console.WriteLine(passB.Length);
            byte[] krahasues = Encoding.UTF8.GetBytes("telegrafi");
            for (int i = 0; i < krahasues.Length; i++)
            {
                Console.Write(krahasues[i]);

            }
            string saltedHash = getSaltedHash(salt, passi);

            Console.WriteLine("Saltimi:" + saltedHash);
            Console.WriteLine("Saltimi:2 :" + getSaltedHash(salt, "telegrafi"));
            Console.WriteLine("Saltimi:3 :" + getSaltedHash(salt, "telegrafi"));

            if (saltedHash
                .Equals(list[5].ToArray()[0]))
            {
                return true;
            }
            else
            {
                return false;
            }



        }
        private static string getSaltedHash(string salt, string password)
        {
            string saltedPassword = password + salt;


            byte[] byteSaltedPassword = Encoding.UTF8.GetBytes(saltedPassword);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] byteSaltedHash = sha.ComputeHash(byteSaltedPassword);

            return Convert.ToBase64String(byteSaltedHash);

        }
        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider rncCsp = new RNGCryptoServiceProvider();
            byte[] salt = new byte[10];
            rncCsp.GetBytes(salt);

            return Convert.ToBase64String(salt);
        }
        public static byte[] DekriptoDes(string ciphertext)
        {
            des.Padding = PaddingMode.Zeros;
            des.Mode = CipherMode.CBC;
            des.Key = desKey;
            des.IV = desIv;


            byte[] byteCiphertexti =
                Convert.FromBase64String(ciphertext);
            MemoryStream ms = new MemoryStream(byteCiphertexti);
            CryptoStream cs =
                new CryptoStream(ms,
                des.CreateDecryptor(),
                CryptoStreamMode.Read);

            byte[] byteTextiDekriptuar = new byte[ms.Length];
            cs.Read(byteTextiDekriptuar, 0, byteTextiDekriptuar.Length);
            cs.Close();

            return byteTextiDekriptuar;

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
        public static string[] getUserParameters(string message,char delimiter)
        {
            string[] parts = message.Split(delimiter);
            return parts;
        }
       
        public static byte[] Enkripto(String plaintext)
        {
            des.Padding = PaddingMode.Zeros;
            des.Key=desKey;
            des.IV=desIv;


            byte[] bytePlaintexti = Encoding.UTF8.GetBytes(plaintext);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms,
                                des.CreateEncryptor(),
                                CryptoStreamMode.Write);
            cs.Write(bytePlaintexti, 0, bytePlaintexti.Length);
            cs.Close();

            byte[] byteCiphertexti = ms.ToArray();

            return byteCiphertexti;

        }

    }
    }
