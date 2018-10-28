using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArticleSql
{
    public partial class RechForm : Form
    {
        public RechForm()
        {
            InitializeComponent();
        }
        public MainForm main;
        private void recherchbtn_Click(object sender, EventArgs e)
        {
            main.rechPrix = txtprix.Text;
            main.rechPromo = txtpromo.Text;
            main.rechQuantit = txtquan.Text;
            this.Hide();
            main.rechAvance();
            main.Show();
        }
    }
}
