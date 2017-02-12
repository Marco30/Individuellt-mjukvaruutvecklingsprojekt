using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MVT.Model.DAL// Marco Villegas
{
    public abstract class DALBase
    {
        //Fält
        private static string _connectionString; // Sträng med information som används för att ansluta till "SQL Server"-databasen

        //Konstruktorer
        static DALBase() // Initierar statiskt data, Konstruktorn anropas automatiskt innan första instansen skapas eller innan någon statisk medlem används
        {

            _connectionString = WebConfigurationManager.ConnectionStrings["MemberRegistryConnectionString"].ConnectionString;// Hämtar anslutningssträngen som finns i web.config.
        }

        //Metod
        protected SqlConnection CreateConnection() // initierar och Skapar ett anslutningsobjekt.
        {
            return new SqlConnection(_connectionString);
        }

    }
}