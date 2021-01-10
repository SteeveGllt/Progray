using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Progray
{
    public class clientAdo : Ado
    {
     
        public static void create(Client client)
        {

            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO client(IDCLIENT, TITRE,NOM,PRENOM,ADRESSE,CP,VILLE,TELEPHONE,MOBILE,ADRESSE_MAIL, STATUT) VALUES(0, @TITRE, @NOM, @PRENOM, @ADRESSE, @CP, @VILLE, @TELEPHONE, @MOBILE, @ADRESSE_MAIL, @STATUT)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@TITRE", client.Titre);
                cmd.Parameters.AddWithValue("@NOM", client.Nom);
                cmd.Parameters.AddWithValue("@PRENOM", client.Prenom);
                cmd.Parameters.AddWithValue("@ADRESSE", client.Adresse);
                cmd.Parameters.AddWithValue("@CP", client.Cp);
                cmd.Parameters.AddWithValue("@VILLE", client.Ville);
                cmd.Parameters.AddWithValue("@TELEPHONE", client.Telephone);
                cmd.Parameters.AddWithValue("@MOBILE", client.Mobile);
                cmd.Parameters.AddWithValue("@ADRESSE_MAIL", client.AdresseMail);
                cmd.Parameters.AddWithValue("@STATUT", client.Statut);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Client crée");
                close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static List<Client> all()
        {
            try
            {
                List<Client> clients = new List<Client>();
                MySqlDataReader reader; // Contiendra les données
                open();
                MySqlCommand requete = new MySqlCommand("SELECT * FROM client");
                requete.Connection = conn; // Connexion instanciée auparavant
                reader = requete.ExecuteReader(); // Exécution de la requête SQL
                while (reader.Read())
                {
                    Client client = new Client((Int32)reader["IDCLIENT"],(String)reader["TITRE"], (String)reader["NOM"], (String)reader["PRENOM"], (String)reader["ADRESSE"], (String)reader["CP"], (String)reader["VILLE"], (String)reader["TELEPHONE"], (String)reader["MOBILE"], (String)reader["ADRESSE_MAIL"], (String)reader["STATUT"]);
                    clients.Add(client);
                }
                reader.Close();
                return clients;
                
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

        public static void update(string unTitre, string unNom, string unPrenom, string uneAdresse, string unCP, string uneVille, string unTelephone, string unMobile, string uneAdresseMail, string unStatut, int unId)
        {
            open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE client SET TITRE = @TITRE, NOM = @NOM, PRENOM = @PRENOM, ADRESSE = @ADRESSE, CP = @CP, VILLE = @VILLE, TELEPHONE = @TELEPHONE, MOBILE = @MOBILE, ADRESSE_MAIL = @ADRESSE_MAIL, STATUT = @STATUT WHERE IDCLIENT = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", unId);
            cmd.Parameters.AddWithValue("@TITRE", unTitre);
            cmd.Parameters.AddWithValue("@NOM", unNom);
            cmd.Parameters.AddWithValue("@PRENOM", unPrenom);
            cmd.Parameters.AddWithValue("@ADRESSE", uneAdresse);
            cmd.Parameters.AddWithValue("@CP", unCP);
            cmd.Parameters.AddWithValue("@VILLE", uneVille);
            cmd.Parameters.AddWithValue("@TELEPHONE", unTelephone);
            cmd.Parameters.AddWithValue("@MOBILE", unMobile);
            cmd.Parameters.AddWithValue("@ADRESSE_MAIL", uneAdresseMail);
            cmd.Parameters.AddWithValue("@STATUT", unStatut);
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
            cmd.CommandText = "DELETE FROM client WHERE IDCLIENT = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", unId);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Client supprimé");
            close();

            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
                MessageBox.Show("Erreur ! Le client à effectué un dépôt. Veuillez supprimer le problème");
             
            }

        }

    }
}
