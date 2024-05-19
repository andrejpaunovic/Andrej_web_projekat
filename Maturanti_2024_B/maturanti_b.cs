using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace Maturanti_2024_B
{

    public class maturanti_b
    {
        SqlConnection conn = new SqlConnection();
        string webConfig = ConfigurationManager.ConnectionStrings["Webp"].ConnectionString;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public int Dodaj_Korisnika(string email, string lozinka)
        {
            conn.ConnectionString = webConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Osoba_Insert";
            comm.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 240, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@broj_telefona", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;

        }

        public DataSet Admin_Svi()
        {
            conn.ConnectionString = webConfig;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Svi_Korisnici";
            conn.Open();
            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return (ds);
        }


        public int Unos_Korisnik(string email, string loz)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Korisnik_Insert";
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, loz));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }


        public int Unos_SGodina(string s_godina)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "S_Godina_Insert";
            comm.Parameters.Add(new SqlParameter("@s_godina", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, s_godina));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }


        public DataSet Godina_Svi()
        {
            conn.ConnectionString = webConfig;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Sve_Godine";
            conn.Open();
            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return (ds);
        }

        public int Bacanje_godine(int godina)
        {
            conn.ConnectionString = webConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "S_Delete_ID";
            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, godina));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }



        public int Upis_Predmeta(string n_predmet)
        {
            conn.ConnectionString = webConfig;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Predmet_Insert";
            comm.Parameters.Add(new SqlParameter("@n_predmet", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, n_predmet));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }

            else
            {
                rezultat = 1;
            }
            return rezultat;
        }



    }
}