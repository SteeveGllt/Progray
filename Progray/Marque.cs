using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    public class Marque
    {
        private int IDMARQUE;
        private String NOM;

        public int idMarque { get => IDMARQUE; set => IDMARQUE = value; }
        public string Nom { get => NOM; set => NOM = value; }

        public Marque(){ }

        public Marque(int unId, String unNom)
        {
            this.IDMARQUE = unId;
            this.NOM = unNom;
        }
        public Marque(String unNom)
        {
            this.NOM = unNom;
        }
        public Marque(int unId)
        {
            this.IDMARQUE = unId;
        }
        public override string ToString()
        {
            return Nom;
        }
    }
}
