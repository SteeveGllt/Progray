using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    class marqueAdo
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
        public static void createMarque(Marque marque)
        {

            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO marque(NOM) VALUES(@NOM)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@NOM", marque.Nom);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Marque crée");
                close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static List<Marque> all()
        {
            try
            {
                List<Marque> marques = new List<Marque>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM marque");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    Marque marque = new Marque((int)reader["IDMARQUE"],(String)reader["NOM"]);
                    marques.Add(marque);
                }
                reader.Close();
                return marques;
            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                close();
            }
        }
    }
}
