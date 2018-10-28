using ArticleSql.DAL;
using ArticleSql.Entities;
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
    public partial class LigneFactureForm : Form
    {
        public LigneFactureForm()
        {
            InitializeComponent();
            remprireComboBox();
        }


        public string refirence;
        public string date;
        public int id;

        private void button1_Click(object sender, EventArgs e)
        {
            AddFactureForm fv = new AddFactureForm();
            fv.display(id);
            fv.setTextVal(refirence,date);
            LigneFacture l = new LigneFacture();
            l.f = id;
          //  MessageBox.Show("done " + l.f);
          //  MessageBox.Show(comboref.SelectedValue.ToString());
          //  MessageBox.Show(comboref.SelectedValue.ToString());
            l.a = DAL_Article.getArticleIdByRef(comboref.SelectedValue.ToString());
          //  MessageBox.Show("t3aditha " + l.a);

            l.prixUnit = float.Parse(txtPU.Text);
           // MessageBox.Show("done " + l.prixUnit);

            l.Quantite = int.Parse(txtquantit.Text);
            //MessageBox.Show("done " + l.f + l.a + l.prixUnit + l.Quantite);
            DAL_Facture.insertLigneFacture(l);
            this.Hide();
            fv.display(id);
            fv.Show();
        }
        private void remprireComboBox()
        {
            comboref.DisplayMember = "Reference";
            comboref.ValueMember = "Reference";
            comboref.DataSource = DAL_Article.selectRef();
        }

        private void comboref_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtdesignation.Text = DAL_Article.getDesignationArticleByRef(comboref.SelectedValue.ToString());
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
          //  DataTable dt = DAL_Article.search(textBox4.Text);
            comboref.DisplayMember = "Reference";
            comboref.ValueMember = "Reference";
            comboref.DataSource = DAL_Article.search(textBox4.Text);

        }
    }
}
