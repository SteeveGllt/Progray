using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    public class Depot
    {

        private int IDDEPOT;
        private Modele modele;
        private Marque marque;
        private Client client;
        private Materiel materiel;
        private DateTime dateDepot;
        private string delai;
        private string tache;
        private string numSerie;
        private string probleme;


        public int idDepot { get => IDDEPOT; set => IDDEPOT = value; }
        public Client Client { get => client; set => client = value; }
        public Materiel Materiel { get => materiel; set => materiel = value; }
        public Marque Marque { get => marque; set => marque = value; }
        public Modele Modele { get => modele; set => modele = value; }
        public string NumSerie { get => numSerie; set => numSerie = value; }
        public string Probleme { get => probleme; set => probleme = value; }
        public DateTime DateDepot { get => dateDepot; set => dateDepot = value; }
        public string Delai { get => delai; set => delai = value; }
        public string Tache { get => tache; set => tache = value; }
        

        public Depot()
        {
            

        }
        //public Depot(Modele unModele, Client unClient, Materiel unMateriel, string unDelai)
        public Depot(Modele unModele, Client unClient, Materiel unMateriel, string unDelai)
        {
            this.IDDEPOT = 0;
            this.modele = unModele;
            this.client = unClient;
            this.materiel = unMateriel;
            this.dateDepot = DateTime.Now;
            this.delai = unDelai;
            
        }
        //public Depot(Modele unModele, Client unClient, Materiel unMateriel, string unDelai, string unNumSerie)
        public Depot(Modele unModele, Client unClient, Materiel unMateriel, string unDelai, string unNumSerie)
        {
            this.IDDEPOT = 0;
            this.modele = unModele;
            this.client = unClient;
            this.materiel = unMateriel;
            this.dateDepot = DateTime.Now;
            this.delai = unDelai;
            this.numSerie = unNumSerie;

        }
        //public Depot(int unId, Modele unModele, Client unClient, Materiel unMateriel, string unDelai, string unProbleme)
        public Depot(int unId, Modele unModele, Client unClient, Materiel unMateriel, string unDelai, string unProbleme)
        {
            this.IDDEPOT = unId;
            this.modele = unModele;
            this.client = unClient;
            this.Materiel = unMateriel;
            this.dateDepot = DateTime.Now;
            this.delai = unDelai;
            this.probleme = unProbleme;
            

        }
        //public Depot(int unId, Modele unModele, Client unClient, Materiel unMateriel, string unDelai, string unProbleme, string uneTache, string unNumSerie)
        public Depot(int unId, Modele unModele, Marque uneMarque, Client unClient, Materiel unMateriel, string unDelai, string unProbleme, string uneTache, string unNumSerie)
        {
            this.IDDEPOT = unId;
            this.modele = unModele;
            this.marque = uneMarque;
            this.client = unClient;
            this.materiel = unMateriel;
            this.dateDepot = DateTime.Now;
            this.delai = unDelai;
            this.probleme = unProbleme;
            this.tache = uneTache;
            this.numSerie = unNumSerie;


        }
        public Depot(string unDelai, string uneTache)
        {
            this.IDDEPOT = 0;
            this.delai = unDelai;
            this.tache = uneTache;

        }

        public Client getClient()
        {
            return this.client;
        }

    }
}
