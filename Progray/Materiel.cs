using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    public class Materiel
    {
        int IDMATERIEL;
        String TYPEMATERIEL;

        public int IdMateriel { get => IDMATERIEL; set => IDMATERIEL = value; }
        public string TypeMateriel { get => TYPEMATERIEL; set => TYPEMATERIEL = value; }

        public Materiel()
        {
           
        }
        public Materiel(int unId, String unType)
        {
            this.IDMATERIEL = unId;
            this.TYPEMATERIEL = unType;
        }
        public Materiel(String unType)
        {
            this.TYPEMATERIEL = unType;
        }
        public Materiel(int unId)
        {
            this.IDMATERIEL = unId;
        }

        public override string ToString()
        {
            return this.TypeMateriel;
        }
    }
}
