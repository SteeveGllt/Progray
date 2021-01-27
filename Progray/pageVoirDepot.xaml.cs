using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        string[] delai = new string[] { "Normal - suivant la date de dépôt", "Moyen - 48 heures de délai +50€ HT", "Urgent - 24 heures de délai +75€ HT", "PRIORITAIRE - SAV DANS LA JOURNEE +95€ HT" };
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
            tbxNumSerie.Text = depot.NumSerie;
            tbxTache.Text = depot.Tache;

            

        }
        private void btnValide_Click(object sender, RoutedEventArgs e)
        {
            gridModifier.Visibility = Visibility.Hidden;
            grid.Visibility = Visibility.Visible;

            depotAdo.update(cbxDelai.Text, idDepot);
            depotAdo.updateTache(tbxNumSerie.Text, tbxTache.Text, idDepot);
            depotAdo.updateProbleme(tbxProbleme.Text, idDepot);

        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Depot depot = (Depot)dgDepotAll.SelectedItem;
            idDepot = depot.idDepot;

            depotAdo.delete(idDepot);

        }

        private void tbxRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _itemSourceList = new CollectionViewSource() { Source = depotAdo.all() };
            ICollectionView Itemlist = _itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => ((Depot)item).Client.Nom.Contains(tbxRecherche.Text));
            Itemlist.Filter = yourCostumFilter;
            dgDepotAll.ItemsSource = Itemlist;
        }
    }
}
