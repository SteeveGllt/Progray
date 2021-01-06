using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progray
{
    class Probleme
    {
        int IDPROBLEME;
        Depot depot;
        String DESCRIPTION;

        public int idProbleme { get => IDPROBLEME; set => IDPROBLEME = value; }
        public string Description { get => DESCRIPTION; set => DESCRIPTION = value; }
        public Depot Depot { get => depot; set => depot = value; }
        public Probleme()
        {
        }
        public Probleme(int unId, Depot unDepot, String uneDescription)
        {
            this.IDPROBLEME = unId;
            this.depot = unDepot;
            this.DESCRIPTION = uneDescription;
        }
       
    }
}
