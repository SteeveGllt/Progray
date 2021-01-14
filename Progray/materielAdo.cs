using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Progray
{
    class materielAdo : Ado
    {
  
      
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
                MessageBox.Show("Matériel créé");
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
        public static void update(string unType, int unId)
        {
            open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE materiel SET TYPEMATERIEL = @TYPEMATERIEL WHERE IDMATERIEL = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", unId);
            cmd.Parameters.AddWithValue("@TYPEMATERIEL", unType);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Matériel modifié");
            close();
        }

        public static void delete(int unId)
        {
            try
            {

            
            open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM materiel WHERE IDMATERIEL = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", unId);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Matériel supprimé");
            MessageBox.Show("Matériel supprimé");
                close();
            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur ! Le matériel est contenu dans un dépôt");

            }
        }
    }
}
