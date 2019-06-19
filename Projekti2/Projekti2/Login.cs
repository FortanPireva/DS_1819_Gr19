using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekti2
{
    
    public partial class Login : Form
    {
        
       UDPClient client;
        public Login()
        {
            InitializeComponent();
            client = new UDPClient("127.0.0.1", 12000);
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            Registration register = new Registration();
            register.Show();
            this.Hide();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            
        }
        private bool validatePass()
        {
            string pattern = "^[\\S*$]"; // no spaces
            if (passwordtxt.Text.Length > 6 && Regex.IsMatch(passwordtxt.Text, pattern))
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
    }
}
