using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

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
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;
            gridMateriel.Visibility = Visibility.Hidden;
            
        }

        private void dgVoirMateriel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgVoirMateriel.SelectedItem != null)
            {
                btnModifier.IsEnabled = true;
                btnSupprimer.IsEnabled = true;
            }
            else
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }
            Materiel m = (Materiel)(dgVoirMateriel.CurrentItem);
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            gridMateriel.Visibility = Visibility.Visible;
            grid.Visibility = Visibility.Hidden;

            Materiel materiel = (Materiel)dgVoirMateriel.SelectedItem;
            idMateriel = materiel.IdMateriel;

            tbxType.Text = materiel.TypeMateriel;
            
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer ?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Materiel materiel = (Materiel)dgVoirMateriel.SelectedItem;
                idMateriel = materiel.IdMateriel;
                materielAdo.delete(idMateriel);

                dgVoirMateriel.ItemsSource = null;
                dgVoirMateriel.ItemsSource = materielAdo.all();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            gridMateriel.Visibility = Visibility.Hidden;
            grid.Visibility = Visibility.Visible;
            materielAdo.update(tbxType.Text, idMateriel);

            dgVoirMateriel.ItemsSource = null;
            dgVoirMateriel.ItemsSource = materielAdo.all();
        }

        private void tbxRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _itemSourceList = new CollectionViewSource() { Source = materielAdo.all() };
            ICollectionView Itemlist = _itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => ((Materiel)item).TypeMateriel.Contains(tbxRecherche.Text));
            Itemlist.Filter = yourCostumFilter;
            dgVoirMateriel.ItemsSource = Itemlist;
        }

        private void gridMateriel_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnValider_Click(null, null);
            }
        }
    }
}
