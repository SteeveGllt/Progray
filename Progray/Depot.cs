using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    class Depot
    {
        int IDDEPOT;
        Marque marque;
        Client client;
        Materiel materiel;
        DateTime dateDepot;
        string delai;

        string nom;
        string nomclient;
        string prenomClient;
        string typemateriel;
        string probleme;

        public int idDepot { get => IDDEPOT; set => IDDEPOT = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Nomclient { get => nomclient; set => nomclient = value; }
        public string PrenomClient { get => prenomClient; set => prenomClient = value; }
        public string Typemateriel { get => typemateriel; set => typemateriel = value; }
        public DateTime DateDepot { get => dateDepot; set => dateDepot = value; }
        public string Delai { get => delai; set => delai = value; }
        public string Probleme { get => probleme; set => probleme = value; }
        public Marque Marque { get => marque; set => marque = value; }
        public Client Client { get => client; set => client = value; }
        public Materiel Materiel { get => materiel; set => materiel = value; }

        public Depot()
        {
            

        }
        public Depot(Marque uneMarque, Client unClient, Materiel unMateriel, string unDelai)
        {
            this.IDDEPOT = 0;
            this.Marque = uneMarque;
            this.client = unClient;
            this.materiel = unMateriel;
            this.dateDepot = DateTime.Now;
            this.delai = unDelai;
            
        }
        public Depot(int unId, string uneMarque, string unClient, string unPrenom, string unMateriel, string unDelai, string unProbleme)
        {
            this.IDDEPOT = unId;
            this.Nom = uneMarque;
            this.Nomclient = unClient;
            this.PrenomClient = unPrenom;
            this.Typemateriel = unMateriel;
            this.dateDepot = DateTime.Now;
            this.delai = unDelai;
            this.probleme = unProbleme;

        }
    }
}
