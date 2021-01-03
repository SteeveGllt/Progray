using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    public class Client
    {
        int IDCLIENT;
        String TITRE;
        String NOM;
        String PRENOM;
        String ADRESSE;
        String CP;
        String VILLE;
        int TELEPHONE;
        int MOBILE;
        String ADRESSE_MAIL;
        String ENTREPRISE;
      

        public string Titre { get => TITRE; set => TITRE = value; }
        public string Nom { get => NOM; set => NOM = value; }
        public string Prenom { get => PRENOM; set => PRENOM = value; }
        public string Adresse { get => ADRESSE; set => ADRESSE = value; }
        public string Cp { get => CP; set => CP = value; }
        public string Ville { get => VILLE; set => VILLE = value; }
        public int Telephone { get => TELEPHONE; set => TELEPHONE = value; }
        public int Mobile { get => MOBILE; set => MOBILE = value; }
        public string AdresseMail { get => ADRESSE_MAIL; set => ADRESSE_MAIL = value; }
        public int idClient { get => IDCLIENT; set => IDCLIENT = value; }
        public string Entreprise { get => ENTREPRISE; set => ENTREPRISE = value; }

        public Client(int unId, String unTitre, String unNom, String unPrenom, String uneAdresse, String unCP, String uneVille, int unTelephone, int unMobile, String uneAdresseMail, String uneEntreprise)
        {
            this.IDCLIENT = unId;
            this.TITRE = unTitre;
            this.NOM = unNom;
            this.PRENOM = unPrenom;
            this.ADRESSE = uneAdresse;
            this.CP = unCP;
            this.VILLE = uneVille;
            this.TELEPHONE = unTelephone;
            this.MOBILE = unMobile;
            this.ADRESSE_MAIL = uneAdresseMail;
            this.ENTREPRISE = uneEntreprise;

        }
        public Client(String unNom, String unPrenom)
        {
            this.NOM = unNom;
            this.PRENOM = unPrenom; 
        }
        public Client(int unId)
        {
            this.IDCLIENT = unId;
        }
        public override string ToString()
        {
            return this.Nom + " " + this.Prenom;
           
        }
    }
}