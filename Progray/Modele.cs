using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    public class Modele
    {
        private int code;
        private string modele;
        private Marque marque;

        private int idMarque;

        public int Code { get => code; set => code = value; }
        public string Model { get => modele; set => modele = value; }
        public Marque Marque { get => marque; set => marque = value; }
        public Modele() { }
        public Modele(int unCode, string unModele, Marque uneMarque)
        {
            this.code = unCode;
            this.modele = unModele;
            this.marque = uneMarque;
        }
        //public Modele(int unCode, string unModele, int uneMarque)
        //{
        //    this.code = unCode;
        //    this.modele = unModele;
        //    this.idMarque = uneMarque;
        //}
        public override string ToString()
        {
            return modele;
        }
    }
}
