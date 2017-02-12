using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MVT.Model.DAL // Marco Villegas
{
    public class ActivityDAL : DALBase
    {
        //Hämtar alla aktiviteter som finns i databasen
        public IEnumerable<Activity> GetActivities()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett List-objekt med 100 platser.
                    var activities = new List<Activity>(100);

                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("appSchema.usp_AktivitetLista", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar reda på vilket index de olika kolumnerna har.
                        var aktIdIndex = reader.GetOrdinal("AktivitetstypID");
                        var akttypIndex = reader.GetOrdinal("Aktivitetstyp");
                        var aktstart = reader.GetOrdinal("Startdatum");
                        var aktslut = reader.GetOrdinal("Slutdatum");


                        // Så länge som det finns poster att läsa returnerar Read true och läsningen fortsätter.
                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post.
                            activities.Add(new Activity
                            {
                                AktID = reader.GetInt32(aktIdIndex),
                                Akttyp = reader.GetString(akttypIndex),
                                Startdatum = reader.GetDateTime(aktstart).ToString("yyyy-MM-dd"),
                                Slutdatum = reader.GetDateTime(aktslut).ToString("yyyy-MM-dd"),
                            });
                        }
                    }

                    // Avallokerar minne som inte används och skickar tillbaks listan med aktiviteter.
                    activities.TrimExcess();
                    return activities;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting members from the database.");
                }
            }
        }

       

        // Skapar en ny post i tabellen Medlem.
        public void AddAktivitet(Activity A)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddAktivitet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@Aktivitetstyp", SqlDbType.VarChar, 15).Value = A.Akttyp;
                    cmd.Parameters.Add("@Startdatum", SqlDbType.Date).Value = Convert.ToDateTime(A.Startdatum).Date;
                    cmd.Parameters.Add("@Slutdatum", SqlDbType.Date).Value = Convert.ToDateTime(A.Slutdatum).Date;
                    //cmd.Parameters.Add("@Avgiftstatus", SqlDbType.VarChar, 7).Value = memberActivity.Avgiftstatus;

                    // Hämtar data från den lagrade proceduren.
                    //cmd.Parameters.Add("@MedAktID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar MemberActivity-objektet värdet.
                    //memberActivity.MedAktID = (int)cmd.Parameters["@MedAktID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public void DeletActivityt(Activity A)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteAktivitet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@AktivitetstypID", SqlDbType.Int, 4).Value = A.AktID;
                    //cmd.Parameters.Add("@Avgiftstatus", SqlDbType.VarChar, 7).Value = memberActivity.Avgiftstatus;

                    // Hämtar data från den lagrade proceduren.
                    //cmd.Parameters.Add("@MedAktID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar MemberActivity-objektet värdet.
                    //memberActivity.MedAktID = (int)cmd.Parameters["@MedAktID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        // Skapar en ny post i tabellen Medlem.
        public void UpdateAktivitetInfoById(Activity A)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateMedlemKontaktByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@AktivitetstypID", SqlDbType.Int, 4).Value = A.AktID;
                    cmd.Parameters.Add("@Aktivitetstyp", SqlDbType.VarChar, 15).Value = A.Akttyp;
                    cmd.Parameters.Add("@Startdatum", SqlDbType.Date).Value = Convert.ToDateTime(A.Startdatum).Date;
                    cmd.Parameters.Add("@Slutdatum", SqlDbType.Date).Value = Convert.ToDateTime(A.Slutdatum).Date;
                    //cmd.Parameters.Add("@Avgiftstatus", SqlDbType.VarChar, 7).Value = memberActivity.Avgiftstatus;

                    // Hämtar data från den lagrade proceduren.
                    //cmd.Parameters.Add("@MedAktID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en INSERT-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar MemberActivity-objektet värdet.
                    //memberActivity.MedAktID = (int)cmd.Parameters["@MedAktID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

    }
}