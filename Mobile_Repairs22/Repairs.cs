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
    public partial class Repairs : Form

    {
        functions Con;
        public Repairs()
        {
            InitializeComponent();
            Con = new functions();
            ShowRepairs();
            GetCustomer();
            GetSpare();

        }

        private void GetCost()
        {
            string Query = " select * from SpareTb where SpCode = {0}";
            Query = string.Format(Query, SpareCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                SpareCostTb.Text = dr["SpCode"].ToString();
            }
            MessageBox.Show("Hello");
        }
        private void GetCustomer()
        {
            string Query = " select * from CustomerTb1";
            CustCb.DisplayMember = Con.GetData(Query).Columns["CustName"].ToString();
            CustCb.ValueMember = Con.GetData(Query).Columns["CustCode"].ToString();
            CustCb.DataSource = Con.GetData(Query);
        }



        private void GetSpare()
        {
            string Query = " select * from SpareTb1";
            SpareCb.DisplayMember = Con.GetData(Query).Columns["SpName"].ToString();
            SpareCb.ValueMember = Con.GetData(Query).Columns["SpCode"].ToString();
            SpareCb.DataSource = Con.GetData(Query);
        }

        private void ShowRepairs()
        {
            string Query = "select * from Repairs";
            RepairsList.DataSource = Con.GetData(Query);
        }

        private void Repairs_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || PhoneTb.Text == " " || DNameTb.Text == "" || ModelTb.Text == " " || ProblemTb.Text == " " || SpareCb.SelectedIndex == -1 || SpareCostTb.Text == " " || TotalTb.Text == "") 
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string RDate = RepDateTb.Value.Date.ToString();
                    int Customer = Convert.ToInt32(CustCb.SelectedIndex.ToString());
                    string CPhone = PhoneTb.Text;
                    string DeviceName =DNameTb.Text;
                    string DeviceModel = ModelTb.Text;
                    string Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedIndex.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    int GrdTotal = Convert.ToInt32(SpareCostTb.Text) + Total;
                    string Query = " insert into CustomerTb1 values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
                    Query = string.Format(Query, RDate, Customer, CPhone,DeviceName,DeviceModel,Problem,Spare,GrdTotal);
                    Con.SetData(Query);
                    MessageBox.Show("Repair Added !!");
                    ShowRepairs();
                    //Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TotalTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void SpareCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCost();
        }

        private void DelateBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Rapair!!!");
            }
            else
            {
                try
                {
                    
                    string Query = " delete from RepairTb1 where RepCode = {0} ";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Repair Deleted !!");
                    ShowRepairs();
                    //Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;

        private void RepairsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Key = Convert.ToInt32(RepairsList.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }
    }
}
