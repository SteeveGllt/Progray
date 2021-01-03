using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    class problemeAdo
    {
        static MySqlConnection conn;

        private static void open()
        {

            string cs = @"server=localhost;userid=root;password=;database=progray";
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                Console.WriteLine("Connexion ouverte");

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        private static void close()
        {
            if (conn != null)
            {
                conn.Close();
                Console.WriteLine("Connexion fermée");
            }
        }
        public static void createProbleme(Probleme probleme)
        {

            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO probleme(IDDEPOT, DESCRIPTION) VALUES(@IDDEPOT, @DESCRIPTION)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@IDDEPOT", probleme.Depot.idDepot);
                cmd.Parameters.AddWithValue("@DESCRIPTION", probleme.Description);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Problème crée");
                close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
       

    }
}
