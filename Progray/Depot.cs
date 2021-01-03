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
        Client c;
        Materiel m;
        DateTime dateDepot;
        String delai;

        public int idDepot { get => IDDEPOT; set => IDDEPOT = value; }
        public Marque Marque { get => marque; set => marque = value; }
        public Client C { get => c; set => c = value; }
        public Materiel M { get => m; set => m = value; }
        public DateTime DateDepot { get => dateDepot; set => dateDepot = value; }
        public string Delai { get => delai; set => delai = value; }
        

        public Depot(Marque uneMarque, Client unClient, Materiel unMateriel, String unDelai)
        {
            this.IDDEPOT = 0;
            this.Marque = uneMarque;
            this.c = unClient;
            this.m = unMateriel;
            this.dateDepot = DateTime.Now;
            this.delai = unDelai;
        }
    }
}
