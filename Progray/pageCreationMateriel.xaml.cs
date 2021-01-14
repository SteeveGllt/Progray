using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Progray
{
    /// <summary>
    /// Logique d'interaction pour pageCreationMateriel.xaml
    /// </summary>
    public partial class pageCreationMateriel : Page
    {
        public pageCreationMateriel()
        {
            InitializeComponent();
        }

        private void btnTypeMateriel_Click(object sender, RoutedEventArgs e)
        {
            Materiel m = new Materiel(0, tbxTypeMateriel.Text);
            //on ajoute le nouveau client en base de données
            materielAdo.createMateriel(m);
        }
    }
}
