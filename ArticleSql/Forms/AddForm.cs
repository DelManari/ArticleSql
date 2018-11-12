using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ArticleSql
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }
        public MainForm mainf;
        public void clearData()
        {
            txtdate.Text = "";
            txtDes.Text = "";
            txtPrix.Text = "";
            txtPromo.Text = "";
            txtQua.Text = "";
            txtRef.Text = "";
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            Article a;

                if (txtRef.Text != "" && txtPrix.Text != "" && txtDes.Text != "")
                {
                    bool p = false;
                    if (txtPromo.Text == "0")
                        p = false;
                    if (txtPromo.Text == "1")
                        p = true;
                    if (String.IsNullOrEmpty(txtQua.Text))
                        a = new Article(txtRef.Text, txtDes.Text, float.Parse(txtPrix.Text), 0, p, txtdate.Text);
                    else
                        a = new Article(txtRef.Text, txtDes.Text, float.Parse(txtPrix.Text), Int32.Parse(txtQua.Text), p, txtdate.Text);

                    if (DAL_Article.insert(a) == 1)
                        MessageBox.Show("Record Inserted Successfully");
                    else
                        MessageBox.Show("error");
                    clearData();
                    this.Close();
                    mainf.Show();

                    mainf.display();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }

        }
    }
}
