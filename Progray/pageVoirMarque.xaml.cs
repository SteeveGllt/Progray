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
        int idMarque = 0;
        public pageVoirMarque()
        {
            InitializeComponent();
            gridMarque.Visibility = Visibility.Hidden;
            dgVoirMarque.ItemsSource = marqueAdo.all();
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;
        }

        private void dgVoirMarque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgVoirMarque.SelectedItem != null)
            {
                btnModifier.IsEnabled = true;
                btnSupprimer.IsEnabled = true;
            }
            else
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }
            Marque m = (Marque)(dgVoirMarque.CurrentItem);
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
          

            dgVoirMarque.Visibility = Visibility.Hidden;

            btnModifier.Visibility = Visibility.Hidden;
            btnSupprimer.Visibility = Visibility.Hidden;
            gridMarque.Visibility = Visibility.Visible;

            Marque marque = (Marque)dgVoirMarque.SelectedItem;
            idMarque = marque.idMarque;

            tbxNomMarque.Text = marque.Nom;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            marqueAdo.update(tbxNomMarque.Text, idMarque);
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Marque marque = (Marque)dgVoirMarque.SelectedItem;
            idMarque = marque.idMarque;
            marqueAdo.delete(idMarque);
        }
    }
}
