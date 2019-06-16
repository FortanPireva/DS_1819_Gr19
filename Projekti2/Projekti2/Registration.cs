using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

            if (emritxt.Text == "" || mbiemritxt.Text == "" || emailtxt.Text == "" || passwordtxt.Text == "" || kpasswordtxt.Text == "" || titullitxt.Text == ""
                || rrogatxt.Text == "")
            {
                string message = "All fields are required";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }
            else
            {

                DES des = new DES();


                string mesazhi = emritxt.Text + ":" + mbiemritxt.Text + ":" + emailtxt.Text + ":" + passwordtxt.Text + ":" + titullitxt.Text + ":" +rrogatxt.Text;
                byte[] encrytedData = des.Enkripto(mesazhi);



                byte[] IV = des.getIV();
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

                byte[] encryptedKey = RSAClass.RSAEncrypt(des.getKey(), rsa.ExportParameters(true), false);

                int newSize = IV.Length + encryptedKey.Length + encrytedData.Length;

                var ms = new MemoryStream(new byte[newSize], 0, newSize, true, true);
                ms.Write(IV, 0, IV.Length);
                ms.Write(encryptedKey, 0, encryptedKey.Length);
                ms.Write(encrytedData, 0, encrytedData.Length);
                byte[] data = ms.GetBuffer();

                byte[] receivedData = client.SendAndReceive(data);

                string receivedData1 = Encoding.ASCII.GetString(receivedData);

                mbiemritxt.Text = receivedData1;
            }       
        }
    }
}
