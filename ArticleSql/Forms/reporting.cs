using ArticleSql.DAL;
using Microsoft.Reporting.WinForms;
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
    public partial class reporting : Form
    {
       public AddFactureForm facform;
        public reporting()
        {
            InitializeComponent();
        }

        private void reporting_Load(object sender, EventArgs e)
        {
            DataSet1 Data_Set = new DataSet1();
            DataSet1 Data_Set2 = new DataSet1();
            string refi = facform.GetRef();
            DAL_Facture.GetFullFactureTB(DAL_Facture.checkExisting(refi)).Fill(Data_Set);
            DAL_Facture.GetFullFactureTB(DAL_Facture.checkExisting(refi)).Fill(Data_Set2);

            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rds = new ReportDataSource("DataSet1", Data_Set.Tables[1]);

            ReportDataSource rds2 = new ReportDataSource("DataSet1", Data_Set2.Tables[2]);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.DataSources.Add(rds2);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
