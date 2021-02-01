using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour pageVoirMarque.xaml
    /// </summary>
    public partial class pageVoirMarque : Page
    {
        int idMarque = 0;
        int code = 0;
        public pageVoirMarque()
        {
            InitializeComponent();
            gridMarque.Visibility = Visibility.Hidden;
            dgVoirMarque.ItemsSource = marqueAdo.all();
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;
            gridMarque.Visibility = Visibility.Hidden;
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

            grid.Visibility = Visibility.Hidden;
            gridMarque.Visibility = Visibility.Visible;

            Marque marque = (Marque)dgVoirMarque.SelectedItem;
            idMarque = marque.idMarque;
            

            tbxNomMarque.Text = marque.Nom;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.Visibility = Visibility.Visible;
            gridMarque.Visibility = Visibility.Hidden;
            marqueAdo.update(tbxNomMarque.Text, idMarque);

            dgVoirMarque.ItemsSource = null;
            dgVoirMarque.ItemsSource = marqueAdo.all();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
           

            

            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer ?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Marque marque = (Marque)dgVoirMarque.SelectedItem;
                idMarque = marque.idMarque;
                marqueAdo.delete(idMarque);

                dgVoirMarque.ItemsSource = null;
                dgVoirMarque.ItemsSource = marqueAdo.all();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}
