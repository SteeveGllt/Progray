using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    class clientAdo
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
        public static void create(Client client)
        {

            try
            {
                open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO client(IDCLIENT, TITRE,NOM,PRENOM,ADRESSE,CP,VILLE,TELEPHONE,MOBILE,ADRESSE_MAIL, ENTREPRISE) VALUES(0, @TITRE, @NOM, @PRENOM, @ADRESSE, @CP, @VILLE, @TELEPHONE, @MOBILE, @ADRESSE_MAIL, @ENTREPRISE)";
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
                cmd.Parameters.AddWithValue("@ENTREPRISE", client.Entreprise);
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
                    Client client = new Client((int)reader["IDCLIENT"], (String)reader["TITRE"], (String)reader["NOM"], (String)reader["PRENOM"], (String)reader["ADRESSE"], (String)reader["CP"], (String)reader["VILLE"], (int)reader["TELEPHONE"], (int)reader["MOBILE"], (String)reader["ADRESSE_MAIL"], (String)reader["ENTREPRISE"]);
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

    }
}
