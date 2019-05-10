using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace final1._0
{
    public partial class Form1 : Form
    {
        private DR subsituteObject = new DR();
        private int key;
        byte[] encQuote;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEnkripto_Click(object sender, EventArgs e)
        {
            subsituteObject.GenerateKey();
            key = DR.key;
            string plaintexti = txtPlaintext.Text;
            encQuote = EncryptString(subsituteObject, plaintexti);

            txtCiphertext.Text = Convert.ToBase64String(encQuote);
            if (checkBox1.Checked)
            {
                textQelsi.Text = " " + key;
            }
        }

        private void btnDekripto_Click(object sender, EventArgs e)
        {
            string plaintexti = DecryptBytes(subsituteObject, encQuote);

            txtTextiDekriptuar.Text = plaintexti;
        }
        public static byte[] EncryptString(SymmetricAlgorithm symAlg, string inString)
        {
            byte[] inBlock = Encoding.ASCII.GetBytes(inString);
            ICryptoTransform xfrm = symAlg.CreateEncryptor();
            byte[] outBlock = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);

            return outBlock;
        }
        public static string DecryptBytes(SymmetricAlgorithm symAlg, byte[] inBytes)
        {
            ICryptoTransform xfrm = symAlg.CreateDecryptor();
            byte[] outBlock = xfrm.TransformFinalBlock(inBytes, 0, inBytes.Length);

            return Encoding.ASCII.GetString(outBlock);
        }
        class DR : SymmetricAlgorithm
        {
            public static int key;//symmetric key used for encryption and decryption
            public override int BlockSize { set => base.BlockSize = 8; }//mutator method to set block size of operation to 8 bits.
            public override byte[] Key { set => base.Key = BitConverter.GetBytes(key); }
            public override int KeySize { get => base.KeySize; set => base.KeySize = 64; }


            public override ICryptoTransform CreateEncryptor()
            {

                ETransform encrypt = new ETransform(key);

                return encrypt;
            }
            public override ICryptoTransform CreateDecryptor()
            {
                DTransform decrypt = new DTransform(key);
                return decrypt;
            }

            public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
            {
                ETransform encrypt = new ETransform(key);
                return encrypt;
            }

            public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
            {
                DTransform decrypt = new DTransform(key);
                return decrypt;
            }

            public override void GenerateKey()
            {
                DR.key = RandomKey();
            }

            public override void GenerateIV()
            {

            }
            public int RandomKey()
            {
                Random rnd = new Random();
                int[] array = new int[8];
                array[0] = rnd.Next(1, 9);
                int[] arraycopy = new int[8];
                arraycopy[0] = array[0];

                string numri = "" + array[0];
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
            }

            private bool isInArray(int[] arr, int nr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (nr == arr[i])
                        return true;

                }
                return false;
            }

        }
        class Program
        {


            public static byte[] EncryptString(SymmetricAlgorithm symAlg, string inString)
            {
                byte[] inBlock = Encoding.ASCII.GetBytes(inString);
                ICryptoTransform xfrm = symAlg.CreateEncryptor();
                byte[] outBlock = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);

                return outBlock;
            }

            public static string DecryptBytes(SymmetricAlgorithm symAlg, byte[] inBytes)
            {
                ICryptoTransform xfrm = symAlg.CreateDecryptor();
                byte[] outBlock = xfrm.TransformFinalBlock(inBytes, 0, inBytes.Length);

                return Encoding.ASCII.GetString(outBlock);
            }
            private static int[] Bits(byte c)//funksioni qe nxjerr si array te integerave prej 1 ose 0
            {
                int[] bit = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    bit[7 - i] = ((c >> i) & 0x01);
                }
                return bit;
            }


        }
        class ETransform : ICryptoTransform
        {
            public int InputBlockSize => 1;

            public int OutputBlockSize => 1;

            public bool CanTransformMultipleBlocks => false;

            public bool CanReuseTransform => false;

            private int key;
            public ETransform(int key)
            {
                this.key = key;
            }

            public void Dispose()
            {
                // This object will be cleaned up by the Dispose method.
                // Therefore, you should call GC.SupressFinalize to
                // take this object off the finalization queue
                // and prevent finalization code for this object
                // from executing a second time.
                GC.SuppressFinalize(this);
            }

            public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
            {
                int[] shifrat = digitArr(key);

                for (int i = inputOffset; i < inputCount; i++)
                {
                    int[] bitat = Bits(inputBuffer[i]);
                    int[] newbits = new int[8];
                    for (int j = 0; j < newbits.Length; j++)
                    {
                        newbits[j] = bitat[shifrat[j] - 1];

                    }
                    outputBuffer[outputOffset + i] = toByte(newbits);


                }
                return outputBuffer.Length;
            }

            public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
            {
                int[] shifrat = digitArr(key);
                byte[] outputBuffer = new byte[inputCount];
                for (int i = inputOffset; i < inputCount; i++)
                {
                    int[] bitat = Bits(inputBuffer[i]);
                    int[] newbits = new int[8];


                    for (int j = 0; j < newbits.Length; j++)
                    {

                        newbits[j] = bitat[shifrat[j] - 1];

                    }

                    outputBuffer[i] = toByte(newbits);


                }
                return outputBuffer;

            }
            private int[] Bits(byte c)//funksioni qe nxjerr si array te integerave prej 1 ose 0
            {
                int[] bit = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    bit[7 - i] = ((c >> i) & 0x01);
                }
                return bit;
            }
            private int[] digitArr(int n)
            {
                if (n == 0) return new int[1] { 0 };

                var digits = new List<int>();

                for (; n != 0; n /= 10)
                    digits.Add(n % 10);

                var arr = digits.ToArray();
                Array.Reverse(arr);
                return arr;
            }
            private byte toByte(int[] bitDigits)
            {
                int numri = 0;
                int k = 1;

                for (int i = 0; i < bitDigits.Length; i++)
                {
                    if (bitDigits[i] == 1)
                        numri += (int)Math.Pow(2, bitDigits.Length - k);
                    k++;


                }
                return (byte)numri;
            }


        }
        class DTransform : ICryptoTransform
        {
            public int InputBlockSize => 1;

            public int OutputBlockSize => 1;

            public bool CanTransformMultipleBlocks => false;

            public bool CanReuseTransform => false;
            private int key;
            public DTransform(int key)
            {
                this.key = key;
            }
            public void Dispose()
            {
                // This object will be cleaned up by the Dispose method.
                // Therefore, you should call GC.SupressFinalize to
                // take this object off the finalization queue
                // and prevent finalization code for this object
                // from executing a second time.
                GC.SuppressFinalize(this);
            }

            public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
            {
                int[] shifrat = digitArr(key);

                for (int i = inputOffset; i < inputCount; i++)
                {
                    int[] bitat = Bits(inputBuffer[i]);
                    int[] newbits = new int[8];
                    for (int j = 0; j < newbits.Length; j++)
                    {
                        newbits[shifrat[j] - 1] = bitat[j];
                    }
                    outputBuffer[outputOffset + i] = toByte(newbits);


                }
                return outputBuffer.Length;
            }

            public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
            {
                int[] shifrat = digitArr(key);
                byte[] outputBuffer = new byte[inputCount];
                for (int i = inputOffset; i < inputCount; i++)
                {
                    int[] bitat = Bits(inputBuffer[i]);
                    int[] newbits = new int[8];
                    for (int j = 0; j < newbits.Length; j++)
                    {
                        newbits[shifrat[j] - 1] = bitat[j];
                    }
                    outputBuffer[i] = toByte(newbits);


                }
                return outputBuffer;
            }
            private int[] Bits(byte c)//funksioni qe nxjerr si array te integerave prej 1 ose 0
            {
                int[] bit = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    bit[7 - i] = ((c >> i) & 0x01);
                }
                return bit;
            }
            private int[] digitArr(int n)
            {
                if (n == 0) return new int[1] { 0 };

                var digits = new List<int>();

                for (; n != 0; n /= 10)
                    digits.Add(n % 10);

                var arr = digits.ToArray();
                Array.Reverse(arr);
                return arr;
            }
            private byte toByte(int[] bitDigits)
            {
                int numri = 0;
                int k = 1;

                for (int i = 0; i < bitDigits.Length; i++)
                {
                    if (bitDigits[i] == 1)
                        numri += (int)Math.Pow(2, bitDigits.Length - k);
                    k++;


                }
                return (byte)numri;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textQelsi.Text = " " + key;
            }
        }
    }
}
