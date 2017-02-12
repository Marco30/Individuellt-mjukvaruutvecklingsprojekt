using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

using MVT.Model;

namespace MVT.Model.DAL// Marco Villegas
{
    public class KontaktDAL : DALBase
    {

        // Hämtar ut alla Kontakter
        public IEnumerable<KontaktTyp> GetKontakter()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //List objekt, plats för 100 ref
                    var Kontakter = new List<KontaktTyp>(100);

                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("appSchema.usp_AllaKontakttyper", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutningen, databasen
                    conn.Open();

                    //skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        //Tar reda på vilket index de olika kolumnerna har.
                        var KategoriIDIndex = reader.GetOrdinal("KontakttypID");
                        var KategoriTypIndex = reader.GetOrdinal("Kontakttyp");

                        //Så länge set finns poster kvar. Annars false
                        while (reader.Read())
                        {
                            Kontakter.Add(new KontaktTyp
                            {
                                //Hämtar ut column innehållet med namn egenskaper
                                KontakttypID = reader.GetInt32(KategoriIDIndex),
                                Kontakttyp = reader.GetString(KategoriTypIndex)
                            });
                        }
                    }

                    //Tar bort det minne som inte används
                    Kontakter.TrimExcess();

                    //Returnerar ett list obj med ref kategori obj
                    return Kontakter;
                }
                catch
                {
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }

        // Hämtar en Kontaktuppgifter.
        public IEnumerable<KontaktTyp> GetMemberKontaktInfoById(int MemberId)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett List-objekt med 100 platser.
                    var KontaktInfo = new List<KontaktTyp>(100);

                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appschema.usp_GetMedlemKontaktByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.AddWithValue("@MedlemID", MemberId);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Så länge som det finns poster att läsa returnerar Read true och läsningen fortsätter.
                        while (reader.Read())
                        {
                            // Tar reda på vilket index de olika kolumnerna har.
                            var medIdIndex = reader.GetOrdinal("MedlemID");
                            int KUIndex = reader.GetOrdinal("Kontaktuppgift");
                            int KTypIndex = reader.GetOrdinal("Kontakttyp");
                            int KTIDpIndex = reader.GetOrdinal("KontaktID");
                            // Returnerar referensen till de skapade Aktivitets-objektet.
                            KontaktInfo.Add(new KontaktTyp
                            {
                                MedID = reader.GetInt32(medIdIndex),
                                Kontaktuppgift = reader.GetString(KUIndex),
                                Kontakttyp = reader.GetString(KTypIndex),
                                KontaktID = reader.GetInt32(KTIDpIndex),
                            });
                        }
                    }

                    // Avallokerar minne som inte används och skickar tillbaks listan med aktiviteter.
                    KontaktInfo.TrimExcess();
                    return KontaktInfo;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        // Skapar en ny post i tabellen Kontakt.
        public void AddKontaktInfoById(KontaktTyp K)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appschema.usp_AddKontaktuppgift88", conn); // Den lagrade proceduren lägger in meddlem, kontaktinfo och Befattnings
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int).Value = K.MedID;
                    cmd.Parameters.Add("@Kontaktuppgift", SqlDbType.VarChar, 30).Value = K.Kontaktuppgift;
                    cmd.Parameters.Add("@KontakttypID", SqlDbType.Int).Value = K.KontakttypID;


                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Fel uppstod i  the data access layer.");
                }
            }
        }

        // Uppdaterar en medlems Kontaktuppgifter i tabellen kontakt.
        public void UpdateKontaktInfoById(KontaktTyp K)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateMedlemKontaktByID1", conn); // Den lagrade proceduren uppdatrar medlem, kontaktinfo och befatnings tabellen   
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver för medlemsid:t.
                    //cmd.Parameters.AddWithValue("@MedlemID", member.MedID);


                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int, 4).Value = K.MedID;
                    cmd.Parameters.Add("@KontaktID", SqlDbType.Int, 4).Value = K.KontaktID;
                    cmd.Parameters.Add("@Kontaktuppgift", SqlDbType.VarChar, 30).Value = K.Kontaktuppgift;


                    // Öppnar anslutningen till databasen.
                    conn.Open();


                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Fel uppstod i data access layer.");
                }
            }
        }

        // tar bort medlems Kontaktuppgif i tabellen Kontak.
        public void DeletKontaktInfoById(KontaktTyp K)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteMedlemKontaktInfoByID", conn); // Den lagrade proceduren uppdatrar medlem, kontaktinfo och befatnings tabellen   
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver för medlemsid:t.
                    //cmd.Parameters.AddWithValue("@MedlemID", member.MedID);


                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int, 4).Value = K.MedID;
                    cmd.Parameters.Add("@KontaktID", SqlDbType.Int, 4).Value = K.KontaktID;


                    // Öppnar anslutningen till databasen.
                    conn.Open();


                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Fel uppstod i data access layer.");
                }
            }
        }


    }
}