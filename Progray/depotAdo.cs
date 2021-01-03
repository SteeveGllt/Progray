using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    class depotAdo
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
        public static Depot createDepot(Depot d)
        {
            long id = 0;
            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO depot(IDMARQUE, IDCLIENT, IDMATERIEL, DATEDEPOT, DELAI) VALUES(@IDMARQUE, @IDCLIENT, @IDMATERIEL, @DATEDEPOT, @DELAI)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@IDMARQUE", d.Marque.idMarque);
                cmd.Parameters.AddWithValue("@IDCLIENT", d.C.idClient);
                cmd.Parameters.AddWithValue("@IDMATERIEL", d.M.IdMateriel);
                cmd.Parameters.AddWithValue("@DATEDEPOT", d.DateDepot);
                cmd.Parameters.AddWithValue("@DELAI", d.Delai);
                cmd.ExecuteNonQuery();
                id = cmd.LastInsertedId;
                Console.WriteLine("Dépôt crée");
                d.idDepot = (int)id;
                close();
                
            }   
          

            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            return d;

        }

    }
}
