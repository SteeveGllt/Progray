using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Paragraph = iTextSharp.text.Paragraph;

namespace Progray
{
    /// <summary>
    /// Logique d'interaction pour pageVoirDepot.xaml
    /// </summary>
    public partial class pageVoirDepot : Page
    {

        int idDepot = 0;
        int idProbleme = 0;
        Depot depot;
        string[] delai = new string[] { "Normal", "Autre" };
        public pageVoirDepot()
        {
            InitializeComponent();
            dgDepotAll.ItemsSource = depotAdo.all();
            cbxDelai.ItemsSource = delai;

            gridModifier.Visibility = Visibility.Hidden;
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;

        }

        private void dgDepotAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dgDepotAll.SelectedItem != null)
            {
                btnModifier.IsEnabled = true;
                btnSupprimer.IsEnabled = true;
            }
            else
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }

            
        }

        private void cbxMarque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbxDelai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             string d = (string)(cbxDelai.SelectedItem);
        }

        

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            gridModifier.Visibility = Visibility.Visible;
            grid.Visibility = Visibility.Hidden;

            Depot depot = (Depot)(dgDepotAll.SelectedItem);
            idDepot = depot.idDepot;

          
            cbxDelai.Text = depot.Delai;
            tbxProbleme.Text = depot.Probleme;

            

        }
        private void btnValide_Click(object sender, RoutedEventArgs e)
        {
            gridModifier.Visibility = Visibility.Hidden;
            grid.Visibility = Visibility.Visible;

            depotAdo.update(tbxProbleme.Text, cbxDelai.Text, idDepot);
            depotAdo.updateTache(tbxTache.Text, idDepot);

        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Depot depot = (Depot)dgDepotAll.SelectedItem;
            idDepot = depot.idDepot;

            depotAdo.delete(idDepot);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
