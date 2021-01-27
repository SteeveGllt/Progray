using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Progray
{
    public class modeleAdo : Ado
    {
        public static List<Modele> all()
        {
            try
            {
                List<Modele> modeles = new List<Modele>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM modele m inner join marque marq on m.IDMARQUE = marq.IDMARQUE");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    Marque marque = new Marque();
                    marque.Nom = (string)reader["NOMMARQUE"];
                    Modele modele = new Modele((Int32)reader["CODE"], (String)reader["MODELE"], marque);
                    modeles.Add(modele);
                }
                reader.Close();
                return modeles;

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
        public static Modele createModel(Modele modele)
        {
            

            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO modele(IDMARQUE, MODELE) VALUES(@IDMARQUE, @MODELE)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@IDMARQUE", modele.Marque.idMarque);
                cmd.Parameters.AddWithValue("@MODELE", modele.Model);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modèle ajouté");
                close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            return modele;
        }
        public static void delete(int unId)
        {
            try
            {


                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM modele WHERE CODE = @code";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@code", unId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modèle supprimé");
                close();
            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur ! Le modele est contenue dans un dépôt et/ou dans une table");

            }
        }
        public static void update(string unNom, int unId)
        {
            try
            {
            open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE modele SET MODELE = @MODELE WHERE CODE = @CODE";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@CODE", unId);
            cmd.Parameters.AddWithValue("@MODELE", unNom);
            cmd.ExecuteNonQuery();
                MessageBox.Show("Modèle modifié");
            close();
            }
            

            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);

            }
        }

    }
}
