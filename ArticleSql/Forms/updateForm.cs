using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArticleSql
{
    public partial class updateForm : Form
    {
        public string idd;
        public updateForm()
        {
            InitializeComponent();
        }
        public void clearData()
        {
            txtdate.Text = "";
            txtDes.Text = "";
            txtPrix.Text = "";
            txtPromo.Text = "";
            txtQua.Text = "";
            txtRef.Text = "";
        }
       public MainForm mainf = new MainForm();
       private void button3_Click(object sender, EventArgs e)
        {
            if ( txtRef.Text != "")
            {
            Article a;
            
                bool p = false;
                if (txtPromo.Text == "0")
                    p = false;
                if (txtPromo.Text == "1")
                    p = true;
                if (String.IsNullOrEmpty(txtQua.Text))
                    a = new Article(int.Parse(idd),txtRef.Text, txtDes.Text, float.Parse(txtPrix.Text), 0, p, txtdate.Text);
                else if (String.IsNullOrEmpty(txtPrix.Text))
                    a = new Article(int.Parse(idd),txtRef.Text, txtDes.Text, 0, 0, p, txtdate.Text);
                else
                    a = new Article(int.Parse(idd),txtRef.Text, txtDes.Text, float.Parse(txtPrix.Text), Int32.Parse(txtQua.Text), p, txtdate.Text);

                if (DAL_Article.update(a) == 1)
                {

                    MessageBox.Show("Record Inserted Successfully");
                    this.Close();
                }
                else
                    MessageBox.Show("Reference already existed ");
                clearData();
                mainf.display();
                mainf.Show();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }  
        }
    }
}
