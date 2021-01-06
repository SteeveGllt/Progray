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
    /// Logique d'interaction pour pageVoirMateriel.xaml
    /// </summary>
    public partial class pageVoirMateriel : Page
    {
        int idMateriel = 0;
        public pageVoirMateriel()
        {
            InitializeComponent();
            gridMateriel.Visibility = Visibility.Hidden;
            dgVoirMateriel.ItemsSource = materielAdo.all();
        }

        private void dgVoirMateriel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Materiel m = (Materiel)(dgVoirMateriel.CurrentItem);
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            dgVoirMateriel.Visibility = Visibility.Hidden;

            btnModifier.Visibility = Visibility.Hidden;
            btnSupprimer.Visibility = Visibility.Hidden;
            gridMateriel.Visibility = Visibility.Visible;

            Materiel materiel = (Materiel)dgVoirMateriel.SelectedItem;
            idMateriel = materiel.IdMateriel;

            tbxType.Text = materiel.TypeMateriel;
            
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Materiel materiel = (Materiel)dgVoirMateriel.SelectedItem;
            idMateriel = materiel.IdMateriel;
            materielAdo.delete(idMateriel);
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            materielAdo.update(tbxType.Text, idMateriel);
        }
    }
}
