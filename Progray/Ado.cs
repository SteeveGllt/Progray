using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    public abstract class Ado
    {

        public static MySqlConnection conn;
        protected static void open()
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
        protected static void close()
        {
            if (conn != null)
            {
                conn.Close();
                Console.WriteLine("Connexion fermée");
            }
        }
    }
}
