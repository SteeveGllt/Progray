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
    /// Logique d'interaction pour pageVoirMarque.xaml
    /// </summary>
    public partial class pageVoirMarque : Page
    {
        public pageVoirMarque()
        {
            InitializeComponent();
            dgVoirMarque.ItemsSource = marqueAdo.all();
        }

        private void dgVoirMarque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Marque m = (Marque)(dgVoirMarque.CurrentItem);
        }
    }
}
