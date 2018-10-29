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
        public LigneFactureForm(int id,string refi,string datee)
        {
            InitializeComponent();
            remprireComboBox();
            this.id = id;
            this.refirence = refi;
            this.date = datee;
            display(id);
        }

        public string refirence;
        public string date;
        public int id;
        public int resultId;
        public void display(int id)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DAL_Facture.GetLignesFacture(id);

            //dataGridView1.Columns["Id"].Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {

                LigneFacture l = new LigneFacture();
                l.f = id;
                l.a = DAL_Article.getArticleIdByRef(comboref.SelectedValue.ToString());
                l.prixUnit = float.Parse(txtPU.Text);
                // MessageBox.Show("done " + l.prixUnit);

                l.Quantite = int.Parse(txtquantit.Text);
            //MessageBox.Show("done " + l.f + l.a + l.prixUnit + l.Quantite);
            if (int.Parse(txtquantit.Text) <= DAL_Article.getQuantite(l.a))
            {
                DAL_Facture.insertLigneFacture(l);
                Article NewArticle = new Article();
                   NewArticle =DAL_Article.getArticleById(l.a);
                NewArticle.qte -= l.Quantite;
                DAL_Article.update(NewArticle);
                display(id);
                MessageBox.Show("New Quantite =  " + DAL_Article.getQuantite(l.a));

            }
            else
            {
                MessageBox.Show("Quantite Missing "+DAL_Article.getQuantite(l.a));
            }
           
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

        private void LigneFactureForm_Load(object sender, EventArgs e)
        {

        }
    }
}
