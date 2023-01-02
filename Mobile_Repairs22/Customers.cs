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
    public partial class Customers : Form
    {
        functions Con;
        public Customers()
        {
            InitializeComponent();
            Con = new functions();
            ShowCustomers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void ShowCustomers()
        {
            string Query = " select * from CustomerTb1";
            CustomerList.DataSource = Con.GetData(Query);
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == " " || CustPhoneTb.Text == " " || CustAddressTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddressTb.Text;
                    string Query = " insert into CustomerTb1 values('{0}','{1}','{2}')";
                    Query = string.Format(Query, CName, CPhone, CAdd);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Added !!");
                    ShowCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;

        private void CustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustNameTb.Text = CustomerList.SelectedRows[0].Cells[1].Value.ToString();
            CustPhoneTb.Text = CustomerList.SelectedRows[0].Cells[2].Value.ToString();
            CustAddressTb.Text = CustomerList.SelectedRows[0].Cells[3].Value.ToString();
            if (CustNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomerList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == " " || CustPhoneTb.Text == " " || CustAddressTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddressTb.Text;
                    string Query = " Update CustomerTb1 set CustomerName = '{0}', CustomerPhone = '{1}', CustomerAddress = '{2}' where CustCode = {3} ";
                    Query = string.Format(Query, CName, CPhone, CAdd,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Update !!");
                    ShowCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Clear() 
        {
            CustNameTb.Text = " ";
             CustPhoneTb.Text = " ";
            CustAddressTb.Text = " ";
            Key = 0;

        }
        private void Delatebtn_Click(object sender, EventArgs e)
        {
            

                if (Key == 0)
            { 
                MessageBox.Show("Select a Customer !!!");
            }
            else
            {
                try
                {
                   
                    string Query = " delete from CustomerTb1 where CustCode = {0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Deleted !!");
                    ShowCustomers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Spares Obj = new Spares();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Repairs Obj = new Repairs();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }

    
}
