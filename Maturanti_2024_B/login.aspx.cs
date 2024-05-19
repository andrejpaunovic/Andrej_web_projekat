using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maturanti_2024_B
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            maturanti_b provera_k = new maturanti_b();
            int rezultat;
            rezultat = provera_k.Dodaj_Korisnika(txtemail.Text, txtlozinka.Text);
            if(txtemail.Text=="Gera" && txtlozinka.Text == "000000")
            {
                rezultat = 1;
            }

            if (rezultat == 0)
            {
                Session["korisnik"] = txtemail.Text;
                Response.Redirect("Upis_termina.aspx");
            }

            else
            {
                if (txtemail.Text == "Gera" && txtlozinka.Text == "000000")
                {
                    Response.Redirect("Adminova_strana.aspx");
                }
                else
                {

                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void txtlozinka_TextChanged(object sender, EventArgs e)
        {

        }
    }
}