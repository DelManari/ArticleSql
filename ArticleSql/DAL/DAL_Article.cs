using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace ArticleSql
{
    class DAL_Article
    {
        static string myConnecting = @"Server= DESKTOP-5801JMQ\SQLEXPRESS01; Database= ArticleV2; Integrated Security=True;";
       static SqlConnection myConn = new SqlConnection(myConnecting);

        public static DataTable affiche()
        {
            var select = "SELECT * FROM article";
            var dataAdapter = new SqlDataAdapter(select, myConn);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            myConn.Close();
            return ds.Tables[0];

        }
        public static DataTable selectRef()
        {
            var select = "SELECT Reference FROM article";
            var dataAdapter = new SqlDataAdapter(select, myConn);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            myConn.Close();
            return ds.Tables[0];

        }
        public static Article getArticleById(int id)
        {
            var select = "SELECT * FROM article where Id = " + id + ";";
            var dataAdapter = new SqlDataAdapter(select, myConn);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            myConn.Close();

            Article a = new Article((int)ds.Tables[0].Columns[0].DefaultValue, (string)ds.Tables[0].Columns[1].DefaultValue, (string)ds.Tables[0].Columns[2].DefaultValue, (int)ds.Tables[0].Columns[3].DefaultValue, (int)ds.Tables[0].Columns[4].DefaultValue, (bool)ds.Tables[0].Columns[5].DefaultValue, (string)ds.Tables[0].Columns[6].DefaultValue);
            return a;
        }

        public static int getArticleIdByRef(string refi)
        {
            var select = "SELECT Id FROM Article where Reference = '" + refi + "';";
            SqlCommand sqlCmnt = new SqlCommand(select, myConn);
            myConn.Open();
            int resukt = (int)sqlCmnt.ExecuteScalar();
            MessageBox.Show(resukt.ToString());
            myConn.Close();
            return resukt;

        }
        public static int insert(Article a)
        {
            SqlCommand cmd = new SqlCommand("insert into article values(@ref,@des,@prix,@qte,@promo,@date)", myConn);
            cmd.Parameters.AddWithValue("@ref", a.refi);
            cmd.Parameters.AddWithValue("@des", a.designation);
            cmd.Parameters.AddWithValue("@prix", a.prix);


            if (a.qte == 0)
                cmd.Parameters.AddWithValue("@qte", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@qte", a.qte);

            if (!a.promo.HasValue)
                cmd.Parameters.AddWithValue("@promo", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@promo", a.promo);

            if (string.IsNullOrEmpty(a.dateFinPromo))
                cmd.Parameters.AddWithValue("@date", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@date", a.dateFinPromo);

            myConn.Open();
           int sa =  cmd.ExecuteNonQuery();
            myConn.Close();
            return (sa);

        }
        public static int update(Article a)
        {
            SqlCommand cmd = new SqlCommand("update article set Prix=@prix,Designation=@des ,Quantite=@qte,Promo=@promo,DateFinPromo=@date,Reference=@ref where Id=@id", myConn);
            cmd.Parameters.AddWithValue("@ref", a.refi);
            cmd.Parameters.AddWithValue("@id", a.id);

            cmd.Parameters.AddWithValue("@des", a.designation);
            if(a.prix ==0)
            cmd.Parameters.AddWithValue("@prix",0);
            else 
                cmd.Parameters.AddWithValue("@prix", a.prix);

            if (a.qte == 0)
                cmd.Parameters.AddWithValue("@qte", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@qte", a.qte);

            if (!a.promo.HasValue)
                cmd.Parameters.AddWithValue("@promo", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@promo", a.promo);

            if (string.IsNullOrEmpty(a.dateFinPromo))
                cmd.Parameters.AddWithValue("@date", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@date", a.dateFinPromo);

            myConn.Open();
            int sa = cmd.ExecuteNonQuery();
            myConn.Close();
            return (sa);
        }
        public static int delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from article where Id=@ref", myConn);

            cmd.Parameters.AddWithValue("@ref", id);
            myConn.Open();
            int a = cmd.ExecuteNonQuery();
            myConn.Close();
            return a;
        }
        public static DataTable search(string cle)
        {
            myConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT* FROM article WHERE Designation LIKE '%' + @cle + '%' OR Prix LIKE '%' + @cle + '%'  OR DateFinPromo LIKE '%' + @cle + '%' OR Reference LIKE '%' + @cle + '%' ", myConn);
            cmd.Parameters.AddWithValue("@cle",cle);
            var dataAdapter = new SqlDataAdapter(cmd);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            myConn.Close();
            return(ds.Tables[0]);
        }
        public static DataTable searchAv(string cle1, string cle2, string cle3)
        {
            myConn.Open();
            string qury = "SELECT* FROM article WHERE 1=1 ";
            if (!String.IsNullOrEmpty(cle1))
            {
                qury += "AND prix = @cle1 ";
            }
            if (!String.IsNullOrEmpty(cle2))
            {
                qury += "AND Quantite = @cle2 ";
            }
            if (!String.IsNullOrEmpty(cle3))
            {
                qury += "AND promo = @cle3 ";
            }
            SqlCommand cmd = new SqlCommand(qury, myConn);
            cmd.Parameters.AddWithValue("@cle1", cle1);
            cmd.Parameters.AddWithValue("@cle2", cle2);
            cmd.Parameters.AddWithValue("@cle3", cle3);

            var dataAdapter = new SqlDataAdapter(cmd);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            myConn.Close();
            return(ds.Tables[0]);
        }


        public static string getDesignationArticleByRef(string cle)
        {
            myConn.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT Designation FROM [Article] WHERE ([Reference] = @user)", myConn);
            check_User_Name.Parameters.AddWithValue("@user", cle);
            string resukt = (string)check_User_Name.ExecuteScalar();
            myConn.Close();
            return resukt;


        }
    }

}
