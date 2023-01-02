using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Repairs22
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UNameTb.Text == " " || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!");

            }
            else if (UNameTb.Text == "Admin" || PasswordTb.Text == "Admin")
            {
                Repairs Obj = new Repairs();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Worng UserName Or Password !! ");
            }
        }
    }
}
