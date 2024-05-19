using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Maturanti_2024_B
{
    public partial class Primer2 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        string webConfig = ConfigurationManager.ConnectionStrings["Webp"].ConnectionString;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        static int t;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDatumUcitaj();
            if (t!=1)
            {
                t = 1;
                PopulateDateDropDown();
            }
        }

        private void txtDatumUcitaj()
        {
            conn = new SqlConnection(webConfig);
            SqlDataAdapter adapter = new SqlDataAdapter(" SELECT DATEADD(day, 1, (Select datum from Datum where id = (select MAX(id) from Datum)))", conn);
            DataTable dt_datum = new DataTable();
            adapter.Fill(dt_datum);
            string a = dt_datum.Rows[0][0].ToString();
            string b, c;
            int d = 0;
            b = "";
            c = "";
            for (int i = 0; i < a.Length; i++)
            {
                if ((d == 0) && (a[i] == '/') && (a[i + 2] != '/'))
                {
                    b = a[i + 1].ToString() + a[i + 2];
                    d = 1;
                }
                if ((d == 0) && (a[i] == '/') && (a[i + 2] == '/'))
                {
                    b = a[i + 1].ToString();
                    d = 1;
                }
                if ((d == 1) && (a[i] == '/'))
                {
                    c = a[i + 1].ToString() + a[i + 2] + a[i + 3] + a[i + 4];
                    d = 1;
                }

            }
            if (a[1] == '/')
            {
                b = c + "-" + "0" + a[0] + "-" + b;
            }
            if (a[1] != '/')
            {
                b = c + "-" + a[0] + a[1] + "-" + b;
            }
            txt_Datum.Text = b;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("INSERT INTO Datum (datum) VALUES('");
            naredba.Append(txt_Datum.Text + "')");
            conn = new SqlConnection(webConfig);
            SqlCommand Komanda = new SqlCommand(naredba.ToString(), conn);
            int prosao = 0;
            try
            {
                conn.Open();
                Komanda.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception Greska)
            {
                prosao = 1;
            }
            if (prosao == 0)
            {
                InsertTermini();
            }
            txtDatumUcitaj();
        }

        private void InsertTermini()
        {
            for (int i = 0; i < 4; i++)
            {
                StringBuilder naredba = new StringBuilder("INSERT INTO Termini(id_datuma, id_prostorije, s10_11, s11_12, s12_13, s13_14, s14_15, s15_16, s16_17, s17_18, s18_19, s19_20, s20_21, s21_22, s22_23, s23_24) VALUES(");
                naredba.Append("(SELECT MAX(id) FROM Datum), ");
                naredba.Append((i + 1).ToString() + ", ");
                naredba.Append("0,0,0,0,0,0,0,0,0,0,0,0,0,0");
                naredba.Append(")");
                conn = new SqlConnection(webConfig);
                SqlCommand Komanda = new SqlCommand(naredba.ToString(), conn);
                try
                {
                    conn.Open();
                    Komanda.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception Greska)
                {

                }
                naredba.Clear();
            }
            PopulateDateDropDown();

        }
        private void PopulateDateDropDown()
        {
            conn.ConnectionString = webConfig;
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Datum where datum>GETDATE() ORDER BY id DESC", conn);
            DataTable dt_date = new DataTable();
            adapter.Fill(dt_date);
            ddlDate.DataSource = dt_date;
            ddlDate.DataValueField = "id";
            ddlDate.DataTextField = "datum";
            ddlDate.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(ddlDate.SelectedIndex>=0)
            {
                SqlDataSource2.SelectCommand = "Select ime_studija,pocetak_termina,kraj_termina,ime, broj_telefona from Zakazivanje join Prostorija on id_prostorije=Prostorija.id join Datum on id_datuma=Datum.id join Osoba on id_osoba= Osoba.id where id_datuma ="+ddlDate.SelectedValue;
            }
        }
    }
}