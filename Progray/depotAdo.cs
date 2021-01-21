using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Progray
{
    class depotAdo : Ado
    {
        public static List<Depot> all()
        {
            try
            {
                List<Depot> depots = new List<Depot>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM (((depot d inner join marque m on d.IDMARQUE = m.IDMARQUE) inner join client c on d.IDCLIENT = c.IDCLIENT) inner join materiel mat on d.IDMATERIEL = mat.IDMATERIEL) inner join probleme p on d.IDDEPOT = p.IDDEPOT ORDER BY NOM");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    string tache = "";
                    Marque marque = new Marque();
                    marque.Nom = (string)reader["NOMMARQUE"];
                    Materiel materiel = new Materiel();
                    materiel.TypeMateriel = (string)reader["TYPEMATERIEL"];
                    Client client = new Client();
                    client.Prenom = (string)reader["PRENOM"];
                    client.Nom = (string)reader["NOM"];
                    if (!reader.IsDBNull(6))
                    {
                        tache = reader.GetString(6);
                    }

                    Depot depot = new Depot((Int32)reader["IDDEPOT"], marque, client, materiel, (string)reader["DELAI"], (string)reader["DESCRIPTION"], tache);
                    depots.Add(depot);
                }
                reader.Close();
                return depots;

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

        public static Depot createDepot(Depot d)
        {
            long id = 0;
            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO depot(IDMARQUE, IDCLIENT, IDMATERIEL, DATEDEPOT, DELAI, TACHE) VALUES(@IDMARQUE, @IDCLIENT, @IDMATERIEL, @DATEDEPOT, @DELAI, @TACHE)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@IDMARQUE", d.Marque.idMarque);
                cmd.Parameters.AddWithValue("@IDCLIENT", d.Client.idClient);
                cmd.Parameters.AddWithValue("@IDMATERIEL", d.Materiel.IdMateriel);
                cmd.Parameters.AddWithValue("@DATEDEPOT", d.DateDepot);
                cmd.Parameters.AddWithValue("@DELAI", d.Delai);
                cmd.Parameters.AddWithValue("@TACHE", d.Tache);
                cmd.ExecuteNonQuery();
                id = cmd.LastInsertedId;
                Console.WriteLine("Dépôt crée");
                MessageBox.Show("Dépôt créé");
                d.idDepot = (int)id;
                close();
                
            }   
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return d;

        }
        public static void update(string unProbleme, string unDelai, int unId)
        {
            try
            {

            
            open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE depot SET DELAI = @DELAI WHERE IDDEPOT = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", unId);
            cmd.Parameters.AddWithValue("@DELAI", unDelai);
                cmd.CommandText = "UPDATE probleme SET DESCRIPTION = @DESCRIPTION WHERE IDDEPOT = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@DESCRIPTION", unProbleme);
            cmd.ExecuteNonQuery();
            close();
                MessageBox.Show("Dépôt modifié");
            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur !");

            }

        }
        public static void delete(int unId)
        {
            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM probleme WHERE IDDEPOT = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", unId);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM depot WHERE IDDEPOT = @id";
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Depot supprimé");
                MessageBox.Show("Dépôt supprimé");
                close();

            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur ! Le client à effectué un dépôt. Veuillez supprimer le problème");

            }

        }
        public static void updateTache(string uneTache, int unId)
        {
            try
            {


                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE depot SET TACHE = @TACHE  WHERE IDDEPOT = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", unId);
                cmd.Parameters.AddWithValue("@TACHE", uneTache);
                cmd.ExecuteNonQuery();
                close();
            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur !");

            }

        }

    }
}
