using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MVT.Model.DAL // Marco Villegas
{
    public class MemberActivityDAL : DALBase
    {


        // Hämtar deltagar i aktivtet 
        public IEnumerable<ActivityType> GetActivityById(int id)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett List-objekt med 100 platser.
                    var activityMembers = new List<ActivityType>(100);

                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetSpecifikAktivitet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.AddWithValue("@AktivitetstypID",id);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Så länge som det finns poster att läsa returnerar Read true och läsningen fortsätter.
                        while (reader.Read())
                        {
                            // Tar reda på vilket index de olika kolumnerna har.

                            var AktypIDIndex = reader.GetOrdinal("AktivitetstypID");
                            var medAktIdIndex = reader.GetOrdinal("medlemID");
                            var fNamnIndex = reader.GetOrdinal("Fornamn");
                            var eNamnIndex = reader.GetOrdinal("Efternamn");
                            var PernumerdIndex = reader.GetOrdinal("Personnummer");
                            var RegistreradIndex = reader.GetOrdinal("Registrerad");

                            // Returnerar referensen till de skapade MemberActivity-objektet.
                            activityMembers.Add(new ActivityType
                            {
                                AktID = reader.GetInt32(AktypIDIndex),
                                MedID = reader.GetInt32(medAktIdIndex),
                                Fnamn = reader.GetString(fNamnIndex),
                                Enamn = reader.GetString(eNamnIndex),
                                Pernumer = reader.GetString(PernumerdIndex),
                                Registrerad = reader.GetDateTime(RegistreradIndex).ToString("yyyy-MM-dd")
                            });
                        }
                    }

                    // Avallokerar minne som inte används och skickar tillbaks listan med medlemsaktiviteter.
                    activityMembers.TrimExcess();
                    return activityMembers;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }


        // tar bort medlem från aktivitet 
        public void DeleteMemberActivityById(ActivityType A)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteMedlemFronAktivitet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.AddWithValue("@MedlemID", A.MedID);
                    cmd.Parameters.AddWithValue("@AktivitetstypID", A.AktID);
                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Den lagrade proceduren innehåller en DELETE-sats och returnerar inga poster varför metoden 
                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

  

        // Skapar en ny post i tabellen Medlem.
        public void InsertMemberActivity(MemberActivity memberActivity)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddMedlemTillAktivtet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int).Value = memberActivity.MedID;
                    cmd.Parameters.Add("@AktivitetstypID", SqlDbType.Int).Value = memberActivity.AktID;
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

    
        public IEnumerable<ActivityType> MedlemDeltarAktiviteter(int id)
        {
  
         // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett List-objekt med 100 platser.
                    var activityMembers1 = new List<ActivityType>(100);

                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_MedlemDeltarAktivitet2", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.AddWithValue("@medlemID",id);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Så länge som det finns poster att läsa returnerar Read true och läsningen fortsätter.
                        while (reader.Read())
                        {
                            // Tar reda på vilket index de olika kolumnerna har.

                            var aktIdIndex = reader.GetOrdinal("AktivitetstypID");
                            var aktTypIndex = reader.GetOrdinal("Aktivitetstyp");

                            // Returnerar referensen till de skapade MemberActivity-objektet.
                            activityMembers1.Add(new ActivityType
                            {
                              AktID = reader.GetInt32(aktIdIndex),
                              Akttyp = reader.GetString(aktTypIndex)
                            });
                        }
                    }

                    // Avallokerar minne som inte används och skickar tillbaks listan med medlemsaktiviteter.
                    activityMembers1.TrimExcess();
                    return activityMembers1;
               }
               catch
                {
                    //Kastar ett eget undantag om ett undantag kastas.
                  throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }



    }
}