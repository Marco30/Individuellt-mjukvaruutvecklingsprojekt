using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace MVT.Model.DAL
{
    public class ExisterarDAL : DALBase
    {

        // kontrollerar om medlem redan finns i aktivitet 
        public void ExisterarMedlemAktivitet(MemberActivity M)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.aktivitetMedlemexisterar", conn); // Den lagrade proceduren lägger in meddlem, kontaktinfo och Befattnings
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@medlemID", SqlDbType.Int).Value = M.MedID;
                    cmd.Parameters.Add("@AktivitetstypID", SqlDbType.Int).Value = M.AktID;

                    // Hämtar data från den lagrade proceduren.
                    cmd.Parameters.Add("@intOutput", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();


                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Member-objektet värdet.
                    M.Existerar = (int)cmd.Parameters["@intOutput"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Fel uppstod i  the data access layer.");
                }
            }
        }
    }
}