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
    public partial class Spares : Form
    {
        functions Con;
        
        public Spares()
        {
            InitializeComponent();
            Con = new functions();
            ShowSpares();
        }
        private void ShowSpares()
        {
            string Query = " select * from SparesTb1";
            PartList.DataSource = Con.GetData(Query);
        }

        private void Clear()
        {
            PartNameTb.Text = " ";
            PartCostTb.Text = " ";
            
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == " " || PartCostTb.Text == " ")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    
                    
                    string Query = " insert into CustomerTb1 values('{0}','{1}',)";
                    Query = string.Format(Query, PName,Cost);
                    Con.SetData(Query);
                    MessageBox.Show("Spares Added !!");
                    ShowSpares();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;

        private void PartList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartNameTb.Text = PartList.SelectedRows[0].Cells[1].Value.ToString();
            PartCostTb.Text = PartList.SelectedRows[0].Cells[2].Value.ToString();
            if (PartNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PartList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == " " || PartCostTb.Text == " " )
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    string Query = " Update SpareTb1 set spname = '{0}', spcost = '{1}', where spcode = {2} ";
                    Query = string.Format(Query, PName,Cost, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Update !!");
                    ShowSpares();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    string Query = " delete from SpareTb1 where spcode = {0} ";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Deleted !!");
                    ShowSpares();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }
    }
    }


