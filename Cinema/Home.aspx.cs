using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Cinema
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(Cinema);

            string selectedValue = DropDownList2.SelectedValue;

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "INSERT INTO TabellaCinema(Nome, Cognome, SalaNord, SalaSud, SalaEst, Ridotta) VALUES (@Nome, @Cognome, @SalaNord, @SalaSud, @SalaEst, @Ridotta)";
                command.Parameters.AddWithValue("@Nome", Nome.Text);
                command.Parameters.AddWithValue("@Cognome", Cognome.Text);
                command.Parameters.AddWithValue("@SalaNord", selectedValue == "Nord" ? true : false);
                command.Parameters.AddWithValue("@SalaSud", selectedValue == "Sud" ? true : false);
                command.Parameters.AddWithValue("@SalaEst", selectedValue == "Est" ? true : false);
                command.Parameters.AddWithValue("@Ridotta", Ridotta.Checked);



                Response.Write("Inserito con successo");

            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(Cinema);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT Count(SalaNord) FROM TabellaCinema WHERE SalaNord=1";
                command.CommandText = "SELECT Count(SalaNord) FROM TabellaCinema WHERE SalaNord=1 AND Ridotta = 1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int SalaNord = reader.GetInt32(0);
                    Dettagli.InnerHtml = "Biglietti Sala Nord" + SalaNord;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(Cinema);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT Count(SalaSud) FROM TabellaCinema WHERE SalaSud=1";
                command.CommandText = "SELECT Count(SalaSud) FROM TabellaCinema WHERE SalaSud=1 AND Ridotta = 1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int SalaSud = reader.GetInt32(0);
                    Dettagli.InnerHtml = "Biglietti Sala Sud" + SalaSud;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(Cinema);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT Count(SalaEst) FROM TabellaCinema WHERE SalaEst=1";
                command.CommandText = "SELECT Count(SalaEst) FROM TabellaCinema WHERE SalaEst=1 AND Ridotta = 1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int SalaEst = reader.GetInt32(0);
                    Dettagli.InnerHtml = "Biglietti Sala Est" + SalaEst;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
    }
}