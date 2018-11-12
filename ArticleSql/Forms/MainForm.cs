using ArticleSql.Forms;
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
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            display();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        
        public void display()
        {
            if(DAL_Article.affiche() != null)
            {
                dataGridView1.DataSource = DAL_Article.affiche();
                dataGridView1.Columns["Id"].Visible = false;
            }

        }

        private void txtRech_TextChanged(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = null;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = DAL_Article.search(txtRech.Text);
        }
        public AddForm addf = new AddForm();

        private void ajouter_Click(object sender, EventArgs e)
        {
            addf = new AddForm();
            addf.mainf = this;
            addf.Show();
           // this.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
           updateForm uf = new updateForm();
            uf.mainf = this;
            uf.txtRef.Text = refid;
            uf.txtDes.Text = des;
            uf.txtPrix.Text = pri;
            uf.txtQua.Text = qua;
            uf.txtPromo.Text = pro;
            uf.txtdate.Text = date;
            uf.idd = IDb;
            this.Hide();
            uf.ShowDialog();
            uf.mainf.Update();
            this.Close();

        }
        string refid, des, pri, qua, pro, date, IDb;
      private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
      {
          IDb= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            refid = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
          des = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
          pri = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
          qua= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
         pro = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
         date = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
      }

      private void btnAdd_Click(object sender, EventArgs e)
      {
          if (!String.IsNullOrEmpty(refi))
          {

              if (DAL_Article.delete(int.Parse(refi)) == 1)
                  MessageBox.Show("Record Deleted Successfully!");
              else
                  MessageBox.Show("error");
              display();


          }
          else
          {
              MessageBox.Show("Please Select Record to Delete");
          }  
      }
      string refi;
      private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
      {
          refi = dataGridView1.SelectedCells[0].Value.ToString();
         // MessageBox.Show(refi);
      }
      public string rechPrix, rechPromo, rechQuantit;
      private void button1_Click(object sender, EventArgs e)
      {
          RechForm rechAv = new RechForm();
          this.Hide();
          rechAv.ShowDialog();
          rechAv.main = this;
            this.Close();

      }
      public void rechAvance()
      {
        
          dataGridView1.DataSource = null;
          dataGridView1.ReadOnly = true;
          dataGridView1.DataSource = DAL_Article.searchAv(rechPrix, rechQuantit, rechPromo);
      }
    }
}
