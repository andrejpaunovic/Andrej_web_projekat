using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.EnterpriseServices;

namespace Maturanti_2024_B
{
    public partial class Pregledkorisnika : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        string webConfig = ConfigurationManager.ConnectionStrings["Webp"].ConnectionString;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        static int a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"] == "null")
            {
                Response.Redirect("login.aspx");
            }
            if (a != 1)
            {
                a = 1;
                PopulateDateDropDown();
                PopulateStudioDropDown();
            }
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

        private void PopulateStudioDropDown()
        {
            conn.ConnectionString = webConfig;
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Prostorija", conn);
            DataTable dt_studio = new DataTable();
            adapter.Fill(dt_studio);

            ddlStudio.DataSource = dt_studio;
            ddlStudio.DataValueField = "id";
            ddlStudio.DataTextField = "ime_studija";
            ddlStudio.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void PopulateOdDropDown()
        {
            conn.ConnectionString = webConfig;
            string query = "SELECT s10_11, s11_12, s12_13, s13_14, s14_15, s15_16, s16_17, s17_18, s18_19, s19_20, s20_21, s21_22, s22_23, s23_24 " +
                              "FROM Termini " +
                              "JOIN Prostorija ON id_prostorije = Prostorija.id " +
                              "JOIN Datum ON id_datuma = Datum.id " +
                              "WHERE id_prostorije = @studioId AND id_datuma = @dateId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@studioId", ddlStudio.SelectedValue);
            adapter.SelectCommand.Parameters.AddWithValue("@dateId", ddlDate.SelectedValue);

            DataTable dt_od = new DataTable();
            adapter.Fill(dt_od);

            ddlod.Items.Clear();
            for (int i = 0; i < 13; i++)
            {
                if ((dt_od.Rows[0][i].ToString() == "False") && (dt_od.Rows[0][i + 1].ToString() == "False"))
                {
                    ddlod.Items.Add(new ListItem((i + 10).ToString(), (i + 10).ToString()));
                }
            }
            if(ddlod.Items.Count > 0 && ddlod.SelectedIndex>=0)
            {
                PopulateDoDropDown();
            }
        }

        protected void PopulateDoDropDown()
        {
            conn.ConnectionString = webConfig;
            string query = "SELECT s10_11, s11_12, s12_13, s13_14, s14_15, s15_16, s16_17, s17_18, s18_19, s19_20, s20_21, s21_22, s22_23, s23_24 " +
                               "FROM Termini " +
                               "JOIN Prostorija ON id_prostorije = Prostorija.id " +
                               "JOIN Datum ON id_datuma = Datum.id " +
                               "WHERE id_prostorije = @studioId AND id_datuma = @dateId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@studioId", ddlStudio.SelectedValue);
            adapter.SelectCommand.Parameters.AddWithValue("@dateId", ddlDate.SelectedValue);

            DataTable dt_do = new DataTable();
            adapter.Fill(dt_do);

            int startIndex = int.Parse(ddlod.SelectedValue) - 10;
            ddldo.Items.Clear();
            for (int i = startIndex; i < 13; i++)
            {
                if ((dt_do.Rows[0][i].ToString() == "False") && (dt_do.Rows[0][i + 1].ToString() == "False"))
                {
                    ddldo.Items.Add(new ListItem((i + 12).ToString(), (i + 12).ToString()));
                }
                else break;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((ddlDate.SelectedIndex >= 0) && (ddlStudio.SelectedIndex >= 0))
            {
                PopulateOdDropDown();
                SqlDataSource1.SelectCommand = "Select datum, s10_11 as '10-11', s11_12 as '11-12', s12_13 as '12-13', s13_14 as '13-14', s14_15 as '14-15', s15_16 as'15-16', s16_17 as '16-17', s17_18 as '17-18', s18_19 as '18-19', s19_20 as '19-20', s20_21 as '20-21', s21_22 as '21-22', s22_23 as '22-23', s23_24 as '23-24', ime_studija from Termini join Prostorija on id_prostorije = Prostorija.id join Datum on id_datuma = Datum.id where datum>GETDATE() and id_prostorije = " + ddlStudio.SelectedValue + "order by id_datuma desc";
                SqlDataSource2.SelectCommand = "Select datum, s10_11 as '10-11', s11_12 as '11-12', s12_13 as '12-13', s13_14 as '13-14', s14_15 as '14-15', s15_16 as'15-16', s16_17 as '16-17', s17_18 as '17-18', s18_19 as '18-19', s19_20 as '19-20', s20_21 as '20-21', s21_22 as '21-22', s22_23 as '22-23', s23_24 as '23-24', ime_studija from Termini join Prostorija on id_prostorije = Prostorija.id join Datum on id_datuma = Datum.id where id_prostorije = " + ddlStudio.SelectedValue + " and id_datuma = " + ddlDate.SelectedValue + " order by id_datuma desc";
            }
        }

        protected void ddlod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlod.SelectedIndex >= 0)
            {
                PopulateDoDropDown();
            }
        }

        protected void btnunesi_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = webConfig;
            if (ddlDate.SelectedIndex >= 0 && ddlStudio.SelectedIndex >= 0 && ddlod.SelectedIndex >= 0 && ddldo.SelectedIndex >= 0)
            {
                StringBuilder naredba = new StringBuilder("INSERT INTO Zakazivanje (pocetak_termina, kraj_termina, id_prostorije, id_osoba, id_datuma) VALUES (");
                naredba.Append(ddlod.Text);
                naredba.Append(", " + ddldo.Text);
                naredba.Append(", " + ddlStudio.SelectedValue);
                naredba.Append(", (Select MAX(id) from Osoba), ");
                naredba.Append(ddlDate.SelectedValue + ") ");
                comm = new SqlCommand(naredba.ToString(), conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception Greska)
                {
                    return;
                }
                UpdateTermini();
                ddldo.Items.Clear();
                ddlod.Items.Clear();

            }
        }
        private void UpdateTermini()
        {
            conn = new SqlConnection(webConfig);
            for (int i = int.Parse(ddlod.SelectedItem.Text); i < int.Parse(ddldo.SelectedItem.Text); i++)
            {
                string pravi = "s" + i.ToString() + "_" + (i + 1).ToString();
                StringBuilder stringBuilder = new StringBuilder("UPDATE Termini SET ");
                stringBuilder.Append(pravi + " = 1 WHERE id_datuma = ");
                stringBuilder.Append(ddlDate.SelectedValue + " AND id_prostorije = ");
                stringBuilder.Append(ddlStudio.SelectedValue);
                comm = new SqlCommand(stringBuilder.ToString(), conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception Greska)
                {
                    return;
                }
            }
            GridView1.DataBind();
            grid_termini.DataBind();
        }

        protected void ddlod_TextChanged(object sender, EventArgs e)
        {

        }
    }
}