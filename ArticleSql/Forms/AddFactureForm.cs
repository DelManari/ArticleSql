using ArticleSql.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArticleSql.Forms
{
    public partial class AddFactureForm : Form
    {
        public AddFactureForm()
        {
            InitializeComponent();
            displayAllFactures();
        }
        public void displayAllFactures()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DAL_Facture.selectAllFactures();

        }
        public void display(int idd)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DAL_Facture.GetLignesFacture(idd);

            //dataGridView1.Columns["Id"].Visible = false;
        }
        private void AddFactureForm_Load(object sender, EventArgs e)
        {

        }
        //good gj 
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtreference.Text) && !string.IsNullOrWhiteSpace(txtDate.Text)) {
                if (DAL_Facture.checkExisting(txtreference.Text) == 0)
                {
                    display(DAL_Facture.insertFacture(new Entities.Facture(txtreference.Text, txtDate.Text)));
                    MessageBox.Show("Facture " + txtreference.Text + " Has created successfuly !");

                }
                else
                {
                 //   MessageBox.Show("facture exsisted");
                    display(DAL_Facture.checkExisting(txtreference.Text));
                }
            }
            else
            {
                MessageBox.Show("Fields are empty ! ");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        public void setTextVal(string refo,string datee)
        {
            txtDate.Text = datee;
            txtreference.Text = refo;
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
               DataGridViewRow dr = dataGridView1.SelectedRows[0];
            txtreference.Text = dr.Cells[1].Value.ToString();
            txtDate.Text = dr.Cells[2].Value.ToString();
            //insert ligne
            LigneFactureForm lff;
               string datee = txtDate.Text;
           string refi = txtreference.Text;
            int resId = DAL_Facture.checkExisting(txtreference.Text);
            lff = new LigneFactureForm(resId, refi,datee);
            this.Hide();
                lff.Show();
           // MessageBox.Show(lff.refirence.ToString());
                

        }

        private void txtreference_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
