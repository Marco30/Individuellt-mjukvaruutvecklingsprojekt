using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MVT.Model.DAL// Marco Villegas
{
    public class MemberDAL : DALBase
    {



        public IEnumerable<Member> GetMembers()// Hämtar alla medlemmar som finns i databasen
        {

            using (SqlConnection conn = CreateConnection()) // initierar och Skapar ett anslutningsobjekt
            {
                try
                {


                    var members = new List<Member>(70);// Skapar ett List med 70 platser

                    var cmd = new SqlCommand("appSchema.usp_MedlemsLista", conn);// SqlCommand-objekt initierars och Skapar

                    cmd.CommandType = CommandType.StoredProcedure;// används till att exekveras specifierad lagrad procedur


                    conn.Open();// Öppnar anslutningen till databasen

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar reda på vilket index de olika kolumnerna har
                        var medIdIndex = reader.GetOrdinal("MedlemID");
                        var fNamnIndex = reader.GetOrdinal("Fornamn");
                        var eNamnIndex = reader.GetOrdinal("Efternamn");
                        var BtyprIndex = reader.GetOrdinal("Befattningstyp");
                        var BMIndex = reader.GetOrdinal("Blevmedlem");




                        while (reader.Read())// while sats som är true så länge som det finns poster att läsa
                        {
                            // Hämtar ut datat för en post
                            members.Add(new Member
                            {
                                MedID = reader.GetInt32(medIdIndex),
                                Fnamn = reader.GetString(fNamnIndex),
                                Enamn = reader.GetString(eNamnIndex),
                                Befattningstyp = reader.GetString(BtyprIndex),
                                Blevmedlem = reader.GetDateTime(BMIndex).ToString("yyyy-MM-dd"),

                            });
                        }
                    }

                    // Avallokerar minne som inte används och skickar tillbaks listan med medlemmar
                    members.TrimExcess();
                    return members;
                }
                catch
                {
                    throw new ApplicationException("Fel uppstod i vid hämtningar av medlem från data bas");
                }
            }
        }

        // Hämtar en medlems uppgifter.
        public Member GetMemberById(int MedlemID)
        {

            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_getMedlem2", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver.
                    cmd.Parameters.AddWithValue("@MedlemID", MedlemID);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Så länge som det finns poster att läsa returnerar Read true och läsningen fortsätter.
                        if (reader.Read())
                        {
                            // Tar reda på vilket index de olika kolumnerna har.
                            int fNamnIndex = reader.GetOrdinal("Fornamn");
                            int eNamnIndex = reader.GetOrdinal("Efternamn");
                            int persNrIndex = reader.GetOrdinal("Personnummer");

                            int addressIndex = reader.GetOrdinal("Gatuadress");

                            int ortIndex = reader.GetOrdinal("Ort");

                            int ArvodeIndex = reader.GetOrdinal("Arvode");

                            var BtyIDIndex = reader.GetOrdinal("BefattningID");

                            var BtyprIndex = reader.GetOrdinal("Befattningstyp");
                            var BMIndex = reader.GetOrdinal("Blevmedlem");

                            // Returnerar referensen till de skapade Member-objektet.
                            return new Member
                            {
                                MedID = MedlemID,
                                Fnamn = reader.GetString(fNamnIndex),
                                Enamn = reader.GetString(eNamnIndex),
                                PersNR = reader.GetString(persNrIndex),
                                Address = reader.GetString(addressIndex),
                                Ort = reader.GetString(ortIndex),
                                Arvode = reader.GetInt32(ArvodeIndex),
                                Befattningstyp = reader.GetString(BtyprIndex),
                                Blevmedlem = reader.GetDateTime(BMIndex).ToString("yyyy-MM-dd"),
                                BefattningID = reader.GetInt32(BtyIDIndex),
                            };
                        }
                    }

                    return null;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Fel uppstod i data access layer.");
                }
            }


        }

        // Skapar en ny post i tabellen Medlem.
        public void InsertMember(Member member)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar och initierar ett SqlCommand-objekt som används till att exekveras specifierad lagrad procedur.
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddMedlem3", conn); // Den lagrade proceduren lägger in meddlem, kontaktinfo och Befattnings
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Personnummer", SqlDbType.VarChar, 12).Value = member.PersNR;
                    cmd.Parameters.Add("@Fornamn", SqlDbType.VarChar, 10).Value = member.Fnamn;
                    cmd.Parameters.Add("@Efternamn", SqlDbType.VarChar, 10).Value = member.Enamn;
                    cmd.Parameters.Add("@Ort", SqlDbType.VarChar, 25).Value = member.Ort;
                    cmd.Parameters.Add("@Gatuadress", SqlDbType.VarChar, 30).Value = member.Address;
                    cmd.Parameters.Add("@BefattningID", SqlDbType.Int).Value = member.BefattningID;



                    // Hämtar data från den lagrade proceduren.
                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();


                    // ExecuteNonQuery används för att exekvera den lagrade proceduren.
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar Member-objektet värdet.
                    member.MedID = (int)cmd.Parameters["@MedlemID"].Value;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Fel uppstod i  the data access layer.");
                }
            }
        }

        // Uppdaterar en medlems uppgifter i tabellen Medlem.
        public void UpdateMember(Member member)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateMedlem", conn); // Den lagrade proceduren uppdatrar medlem, kontaktinfo och befatnings tabellen   
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver för medlemsid:t.
                    //cmd.Parameters.AddWithValue("@MedlemID", member.MedID);


                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int, 4).Value = member.MedID;
                    cmd.Parameters.Add("@Personnummer", SqlDbType.VarChar, 12).Value = member.PersNR;
                    cmd.Parameters.Add("@Fornamn", SqlDbType.VarChar, 10).Value = member.Fnamn;
                    cmd.Parameters.Add("@Efternamn", SqlDbType.VarChar, 10).Value = member.Enamn;
                    cmd.Parameters.Add("@Ort", SqlDbType.VarChar, 25).Value = member.Ort;
                    cmd.Parameters.Add("@Gatuadress", SqlDbType.VarChar, 30).Value = member.Address;
                    cmd.Parameters.Add("@BefattningID", SqlDbType.Int).Value = member.BefattningID;

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


        // Tar bort en medlems uppgifter.
        public void DeleteMember(int memberId)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteMedlem", conn);// Den lagrade proceduren ären tar bort medleme
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int).Value = memberId;

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