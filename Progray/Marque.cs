using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    public class Marque
    {
        int IDMARQUE;
        String NOM;

        public string Nom { get => NOM; set => NOM = value; }
        public int idMarque { get => IDMARQUE; set => IDMARQUE = value; }

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
            return this.Nom;
        }
    }
}
