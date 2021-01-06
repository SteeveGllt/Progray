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
    /// Logique d'interaction pour pageVoirDepot.xaml
    /// </summary>
    public partial class pageVoirDepot : Page
    {
        public pageVoirDepot()
        {
            InitializeComponent();
            dgDepotAll.ItemsSource = depotAdo.all();

        }

        private void dgDepotAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Depot d = (Depot)(dgDepotAll.SelectedItem);
            
        }
    }
}
