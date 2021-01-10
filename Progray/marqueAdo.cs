using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Progray
{
    class marqueAdo : Ado
    {
  
        public static void createMarque(Marque marque)
        {

            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO marque(NOMMARQUE) VALUES(@NOMMARQUE)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@NOMMARQUE", marque.Nom);
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
                    Marque marque = new Marque((int)reader["IDMARQUE"],(String)reader["NOMMARQUE"]);
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

        public static void update(string unNom, int unId)
        {
            open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE marque SET NOMMARQUE = @NOMMARQUE WHERE IDMARQUE = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", unId);
            cmd.Parameters.AddWithValue("@NOMMARQUE", unNom);
            cmd.ExecuteNonQuery();
            close();
        }

        public static void delete(int unId)
        {
            try
            {

          
            open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM marque WHERE IDMARQUE = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", unId);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Marque supprimée");
            close();
            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur ! La marque est contenue dans un dépôt");

            }
        }   
    }
}
