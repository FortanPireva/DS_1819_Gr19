using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace UdpServer
{
    class Program
    {
        public static  DESCryptoServiceProvider des=new DESCryptoServiceProvider();

        private static byte[] desKey;
        private static byte[] desIv;
        static void Main(string[] args)
        {
            DBConnect db = new DBConnect();

            
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
                    byte[] receivedata = udpserver.SendandReceive(Encoding.UTF8.GetBytes("OK"));

                    string[] data = Encoding.UTF8.GetString(receivedata).Split('$');
                  

                    byte[] message = Encoding.UTF8.GetBytes(data[2]);
                        
                       int length = data[1].Length;
                    desKey = new byte[length];
                       desKey = Encoding.UTF8.GetBytes(data[1]);
                    desIv = Encoding.UTF8.GetBytes(data[0]);
                    string eDhena = dekriptoDes(message,desKey,desIv);
                    
                    string[] tedhenat = eDhena.Split(':');
                    for(int i = 0; i < tedhenat.Length; i++)
                    {
                        Console.WriteLine(tedhenat[i]);
                    }

                    string salt = GenerateSalt();
                    string saltedpassword = getSaltedHash(salt, tedhenat[3]);
                    db.Insert(tedhenat[0], tedhenat[1], tedhenat[2],salt,saltedpassword, tedhenat[4], int.Parse(tedhenat[5]));

                   
                }
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

            return Encoding.UTF8.GetString(salt);
        }
        private static string dekriptoDes(byte[] strFromClient,byte[] key,byte[] iv)
        {
            des.Padding = PaddingMode.Zeros;
            des.Mode = CipherMode.CBC;

            MemoryStream ms = new MemoryStream(strFromClient);
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key,iv), CryptoStreamMode.Read);
            byte[] byteFromClientDecrypted = new byte[ms.Length];
            cs.Read(byteFromClientDecrypted, 0, byteFromClientDecrypted.Length);
            cs.Close();
            ms.Close();

            string strFromClientDecrypted = Encoding.UTF8.GetString(byteFromClientDecrypted);
            return strFromClientDecrypted;

        }
        


    }
    }
