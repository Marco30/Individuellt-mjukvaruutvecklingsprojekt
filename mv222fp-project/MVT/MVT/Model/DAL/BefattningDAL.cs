using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace MVT.Model.DAL// Marco Villegas
{
    public class BefattningDAL : DALBase
    {

        // Hämtar ut alla Befattningar
        public IEnumerable<Befattning> GetallaBefattning()
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //List objekt, plats för 100 ref
                    var Befattnings = new List<Befattning>(100);

                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("appSchema.usp_AllaBefattningstyp", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutningen, databasen
                    conn.Open();

                    //skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        //Tar reda på vilket index de olika kolumnerna har.
                        var BefattningIDIndex = reader.GetOrdinal("BefattningID");
                        var BefattningsTypIndex = reader.GetOrdinal("BefattningsTyp");
                        var ArvodeIndex = reader.GetOrdinal("Arvode");

                        //Så länge set finns poster kvar. Annars false
                        while (reader.Read())
                        {
                            Befattnings.Add(new Befattning
                            {
                                //Hämtar ut column innehållet med namn egenskaper
                                BefattningID = reader.GetInt32(BefattningIDIndex),
                                Befattningstyp = reader.GetString(BefattningsTypIndex),
                                 Arvode = reader.GetInt32(ArvodeIndex),
                            });
                        }
                    }

                    //Tar bort det minne som inte används
                    Befattnings.TrimExcess();

                    //Returnerar ett list obj med ref kategori obj
                    return Befattnings;
                }
                catch
                {
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");
                }
            }
        }


        // Hämtar Befattnings för en Medlem
        public IEnumerable<Befattning> GetBefattningByID(int MedID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    //List objekt, plats för 100 ref
                    var Befattnings = new List<Befattning>(100);

                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetBefattningByID", conn); // Den lagrade proceduren uppdatrar medlem, kontaktinfo och befatnings tabellen   
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver för medlemsid:t.
                    cmd.Parameters.AddWithValue("@MedlemID", MedID);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        //Tar reda på vilket index de olika kolumnerna har.
                        var BefattningsTypIndex = reader.GetOrdinal("BefattningsTyp");
                        var ArvodeIndex = reader.GetOrdinal("Arvode");

                        //Så länge set finns poster kvar. Annars false
                        while (reader.Read())
                        {
                            Befattnings.Add(new Befattning
                            {
                                //Hämtar ut column innehållet med namn egenskaper
                                Befattningstyp = reader.GetString(BefattningsTypIndex),
                                Arvode = reader.GetInt32(ArvodeIndex),
                            });
                        }
                    }

                    //Tar bort det minne som inte används
                    Befattnings.TrimExcess();

                    //Returnerar ett list obj med ref kategori obj
                    return Befattnings;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Fel uppstod i data access layer.");
                }
            }
        }

        // uppdaterar Befattnings 
        public void UpdateBefattningByID(Befattning B)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateBefattningByID", conn); // Den lagrade proceduren uppdatrar medlem, kontaktinfo och befatnings tabellen   
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver 
                    cmd.Parameters.Add("@BefattningID", SqlDbType.Int).Value = B.BefattningID;
                    cmd.Parameters.Add("@Befattningstyp", SqlDbType.VarChar, 20).Value = B.Befattningstyp;
                    cmd.Parameters.Add("@Arvode", SqlDbType.Int).Value = B.Arvode;

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

        //listar alla befatningar som finns och arvoden 
        public IEnumerable<Befattning> GetBefattningDataInfo(Befattning B)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //List objekt, plats för 100 ref
                    var Befattnings1 = new List<Befattning>(100);

                    // exekveras specifierad lagrad procedur.
                    var cmd = new SqlCommand("appSchema.usp_GetAllaBefattningsData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutningen, databasen
                    conn.Open();

                    //skapar ett SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        //Tar reda på vilket index de olika kolumnerna har.
                        var BefattningIDIndex = reader.GetOrdinal("BefattningID");
                        var BefattningsTypIndex = reader.GetOrdinal("BefattningsTyp");
                        var ArvodeIndex = reader.GetOrdinal("Arvode");

                        //Så länge set finns poster kvar. Annars false
                        while (reader.Read())
                        {
                            Befattnings1.Add(new Befattning
                            {
                                //Hämtar ut column innehållet med namn egenskaper
                                BefattningID = reader.GetInt32(BefattningIDIndex),
                                Befattningstyp = reader.GetString(BefattningsTypIndex),
                                Arvode = reader.GetInt32(ArvodeIndex),
                            });
                        }
                    }

                    //Tar bort det minne som inte används
                    Befattnings1.TrimExcess();

                    //Returnerar ett list obj med ref kategori obj
                    return Befattnings1;
                }
                catch
                {
                    throw new ApplicationException("Det blev något fel i hämtningen från databasen!");

                }
            }
        }

        public void DeleteBefattningId(Befattning B)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteBefattning", conn); // Den lagrade proceduren uppdatrar medlem, kontaktinfo och befatnings tabellen   
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver för medlemsid:t.
                    //cmd.Parameters.AddWithValue("@MedlemID", member.MedID);


                    // Lägger till de paramterar den lagrade proceduren kräver.
                    cmd.Parameters.Add("@BefattningID", SqlDbType.Int, 4).Value = B.BefattningID;


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

        // uppdaterar Befattnings 
        public void AddBefattning(Befattning B)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddBefattning", conn); // Den lagrade proceduren uppdatrar medlem, kontaktinfo och befatnings tabellen   
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till den paramter den lagrade proceduren kräver 
                    cmd.Parameters.Add("@Befattningstyp", SqlDbType.VarChar, 20).Value = B.Befattningstyp;
                    cmd.Parameters.Add("@Arvode", SqlDbType.Int).Value = B.Arvode;

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