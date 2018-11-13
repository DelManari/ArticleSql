using ArticleSql.Entities;
using ArticleSql.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArticleSql.DAL
{
    class DAL_Facture
    {
        static string myConnecting = @"Server= DESKTOP-5801JMQ\SQLEXPRESS01; Database= ArticleV2; Integrated Security=True;";
        static SqlConnection myConn = new SqlConnection(myConnecting);

        public static int checkExisting(string f)
        {
            myConn.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT id FROM [Facture] WHERE ([Reference] = @user)", myConn);
            check_User_Name.Parameters.AddWithValue("@user", f);
            int? UserExist = (int?)check_User_Name.ExecuteScalar();
            myConn.Close();
            if (UserExist == null) return (int)0;
            else
              return (int)UserExist;
           
        }
        public static DataTable selectAllFactures()
        {
            try
            {
                var select = "SELECT * FROM Facture ;";
                var dataAdapter = new SqlDataAdapter(select, myConn);
                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                myConn.Close();
                return ds.Tables[0];
            }catch(Exception e)
            {
                MessageBox.Show("Pls Check The Connection to the Database");
                Application.Exit();
                return null;
            }
        }
        public static int insertFacture(Facture f)
        {
            SqlCommand cmd = new SqlCommand("insert into Facture values(@ref,@date)", myConn);
            cmd.Parameters.AddWithValue("@ref",f.reference);
            cmd.Parameters.AddWithValue("@date", f.date);

            myConn.Open();
            cmd.ExecuteNonQuery();
            myConn.Close();
            return f.id;
        }
        public static void insertLigneFacture(LigneFacture l)
        {
            SqlCommand cmd = new SqlCommand("insert into LigneFacture values(@idFacture,@idArticle,@quantite,@pu)", myConn);
            cmd.Parameters.AddWithValue("@idFacture", l.f);
            cmd.Parameters.AddWithValue("@idArticle", l.a);
            cmd.Parameters.AddWithValue("@quantite",l.Quantite);
            cmd.Parameters.AddWithValue("@pu", l.prixUnit);
            myConn.Open();
            cmd.ExecuteNonQuery();
            myConn.Close();
        }
        public static DataTable GetLignesFacture(int idFacture)
        {
            var select = "SELECT Article.Reference , Article.Designation,Article.Quantite,Article.Prix ,LigneFacture.Quantite as qteDemande FROM LigneFacture ,Article Where Article.Id = LigneFacture.IdArticle AND LigneFacture.IdFacture = " + idFacture + ";";

            var dataAdapter = new SqlDataAdapter(select, myConn);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            myConn.Close();
            return ds.Tables[0];

        }

        public static Facture GetFullFacture(int id)
        {
            var select = "SELECT Facture.date , Facture.Reference,LigneFacture.Id,Article.Id, Article.Reference , Article.Designation,Article.Quantite,Article.Prix ,LigneFacture.Quantite as qteDemande FROM LigneFacture ,Article,Facture Where Article.Id = LigneFacture.IdArticle AND Facture.Id =" + id+" AND LigneFacture.IdFacture = " + id + ";";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(select,myConn);
            adapter.Fill(dt);
            myConn.Close();
            Facture f = new Facture();
            f.id = id;
            LigneFacture[] lf = new LigneFacture[200];
            int i = 0;

            foreach(DataRow c in dt.Rows)
            {
                f.date = c[0].ToString();
                f.reference = c[1].ToString();
                lf[i] = new LigneFacture(int.Parse(c[2].ToString()), id, int.Parse(c[3].ToString()), int.Parse(c[7].ToString()), float.Parse(c[8].ToString()));
                i++;
            }
            f.Articles = lf;
            return f;
        }
        public static SqlDataAdapter GetFullFactureTB(int id)
        {
            var select = "SELECT Facture.date , Facture.Reference,LigneFacture.Id as ligneId,article.Id as articleId, article.Reference as articleRef, article.Designation as articleDes,article.Quantite as articleQte,article.Prix as articlePrix ,LigneFacture.Quantite as qteDemande FROM LigneFacture ,article,Facture Where article.Id = LigneFacture.IdArticle AND Facture.Id =" + 1002+ " AND LigneFacture.IdFacture = " + 1002 + ";" + "SELECT Facture.date , Facture.Reference,LigneFacture.Id as ligneId,article.Id as articleId, article.Reference as articleRef, article.Designation as articleDes,article.Quantite as articleQte,article.Prix as articlePrix ,LigneFacture.Quantite as qteDemande FROM LigneFacture ,article,Facture Where article.Id = LigneFacture.IdArticle AND Facture.Id =" + 1005 + " AND LigneFacture.IdFacture = " + 1005 + ";";

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(select, myConn);

            adapter.Fill(dt);
            myConn.Close();

            return adapter;
        }
    }
}
