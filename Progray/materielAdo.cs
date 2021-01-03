using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    class materielAdo
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
        public static void createMateriel(Materiel materiel)
        {

            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO materiel(IDMATERIEL,TYPEMATERIEL) VALUES(0, @TYPEMATERIEL)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@TYPEMATERIEL", materiel.TypeMateriel);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Matériel crée");
                close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static List<Materiel> all()
        {
            try
            {
                List<Materiel> materiels = new List<Materiel>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM materiel");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    Materiel m = new Materiel((Int32)reader["IDMATERIEL"],(String)reader["TYPEMATERIEL"]);
                    materiels.Add(m);
                }
                reader.Close();
                return materiels;
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
