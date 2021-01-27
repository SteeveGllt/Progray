using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    public class problemeAdo : Ado
    {
       
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
