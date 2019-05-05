using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSProject
{
    public partial class Form1 : Form
    {
        public int key;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        static string Encrypt(string plaintext, int key)
        {
            string ciphertext = "";
            int[] shifrat = digitArr(key);

            for (int i = 0; i < plaintext.Length; i++)
            {
                int[] bitat = Bits(plaintext[i]);
                int[] newbits = new int[8];
                for (int j = 0; j < newbits.Length; j++)
                {
                    newbits[j] = bitat[shifrat[j] - 1];

                }
                char c = toChar(newbits);
                ciphertext += c;

            }

            return ciphertext;

        }
        static string Decrypt(string ciphertext, int key)
        {
            string plaintext = "";
            int[] shifrat = digitArr(key);

            for (int i = 0; i < ciphertext.Length; i++)
            {
                int[] bitat = Bits(ciphertext[i]);
                int[] newbits = new int[8];
                for (int j = 0; j < newbits.Length; j++)
                {
                    newbits[shifrat[j] - 1] = bitat[j];

                }
                char c = toChar(newbits);
                plaintext += c;

            }

            return plaintext;
        }
        static int[] Bits(char c)//funksioni qe nxjerr si array te integerave prej 1 ose 0
        {
            int[] bit = new int[8];
            for (int i = 0; i < 8; i++)
            {
                bit[7 - i] = ((c >> i) & 0x01);
            }
            return bit;
        }
        static int[] digitArr(int n)
        {
            if (n == 0) return new int[1] { 0 };

            var digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }
        static char toChar(int[] bitDigits)
        {
            int numri = 0;
            int k = 1;

            for (int i = 0; i < bitDigits.Length; i++)
            {
                if (bitDigits[i] == 1)
                    numri += (int)Math.Pow(2, bitDigits.Length - k);
                k++;


            }
            return (char)numri;
        }
        public int RandomKey()
        {
            Random rnd = new Random();
            int[] array = new int[8];
            array[0] = rnd.Next(1, 9);
            int[] arraycopy = new int[8];
            arraycopy[0] = array[0];

            string numri =""+array[0];
            for (int i = 1; i < 8; i++)
            {

                while (isInArray(arraycopy, array[i]))
                {
                    array[i] = rnd.Next(1, 9);

                }
                arraycopy[i] = array[i];
                numri += array[i];


            }
            key = Int32.Parse(numri);
            return key;

        bool isInArray(int[] arr, int nr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (nr == arr[i])
                    return true;

            }
            return false;
        }
    }

    private void button2_Click(object sender, EventArgs e)
        {

            byte[] byteArray = Convert.FromBase64String(txtCiphertexti.Text);
            string stringu =Encoding.Unicode.GetString(byteArray);
            string decryptedString = Decrypt(stringu,
              key);
            txtTextiDekriptuar.Text = decryptedString;

        }

        private void btnEnkripto_Click(object sender, EventArgs e)
        {
            string encryptedString = Encrypt(txtPlaintexti.Text, RandomKey());
            byte[] byteArray = Encoding.Unicode.GetBytes(encryptedString);
            txtCiphertexti.Text =Convert.ToBase64String(byteArray);
        }

        private void plainTextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCelesi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTextiDekriptuar_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

}