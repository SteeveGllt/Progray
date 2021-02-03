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
        List<Marque> marques;
        List<Materiel> materiels;
        int idDepot = 0;
        int idProbleme = 0;
        Depot depot;
        string[] delai = new string[] { "Normal - suivant la date de dépôt", "Moyen - 48 heures de délai +50€ HT", "Urgent - 24 heures de délai +75€ HT", "PRIORITAIRE - SAV DANS LA JOURNEE +95€ HT" };
        public pageVoirDepot()
        {
            InitializeComponent();
            dgDepotAll.ItemsSource = depotAdo.all();
            cbxDelai.ItemsSource = delai;

            this.marques = marqueAdo.all();
            cbxMarque.ItemsSource = null;
            cbxMarque.ItemsSource = this.marques;

            this.materiels = materielAdo.all();
            cbxMateriel.ItemsSource = null;
            cbxMateriel.ItemsSource = this.materiels;

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

            dgDepotAll.ItemsSource = null;
            dgDepotAll.ItemsSource = depotAdo.all();

        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer ?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Depot depot = (Depot)dgDepotAll.SelectedItem;
                idDepot = depot.idDepot;

                depotAdo.delete(idDepot);

                dgDepotAll.ItemsSource = null;
                dgDepotAll.ItemsSource = depotAdo.all();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            

        }

        private void tbxRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Permet d'actualiser le datagrid avec les données saisies
            var _itemSourceList = new CollectionViewSource() { Source = depotAdo.all() };
            ICollectionView Itemlist = _itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => ((Depot)item).Client.Nom.Contains(tbxRecherche.Text));
            Itemlist.Filter = yourCostumFilter;
            dgDepotAll.ItemsSource = Itemlist;

          
        }

        private void cbxMarque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Marque marque = (Marque)cbxMarque.SelectedItem;

            //Permet d'actualiser le datagrid avec les données saisies
            var _itemSourceList = new CollectionViewSource() { Source = depotAdo.all() };
            ICollectionView Itemlist = _itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => ((Depot)item).Marque.Nom.Contains(marque.Nom));
            Itemlist.Filter = yourCostumFilter;
            dgDepotAll.ItemsSource = Itemlist;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Materiel materiel = (Materiel)cbxMateriel.SelectedItem;

            //Permet d'actualiser le datagrid avec les données saisies
            var _itemSourceList = new CollectionViewSource() { Source = depotAdo.all() };
            ICollectionView Itemlist = _itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => ((Depot)item).Materiel.TypeMateriel.Contains(materiel.TypeMateriel));
            Itemlist.Filter = yourCostumFilter;
            dgDepotAll.ItemsSource = Itemlist;
        }

        private void tbxRechercheNumSerie_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Permet d'actualiser le datagrid avec les données saisies
            var _itemSourceList = new CollectionViewSource() { Source = depotAdo.all() };
            ICollectionView Itemlist = _itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => ((Depot)item).NumSerie.Contains(tbxRechercheNumSerie.Text));
            Itemlist.Filter = yourCostumFilter;
            dgDepotAll.ItemsSource = Itemlist;
        }

        private void tbxNumIdentifiant_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Permet d'actualiser le datagrid avec les données saisies
            var _itemSourceList = new CollectionViewSource() { Source = depotAdo.all() };
            ICollectionView Itemlist = _itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => ((Depot)item).NumIdentifiantPdf.Contains(tbxNumIdentifiant.Text));
            Itemlist.Filter = yourCostumFilter;
            dgDepotAll.ItemsSource = Itemlist;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            //Permet d'actualiser le datagrid avec les données saisies
            var _itemSourceList = new CollectionViewSource() { Source = depotAdo.all() };
            ICollectionView Itemlist = _itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => Convert.ToString(((Depot)item).idDepot).Contains(tbxRechercheId.Text));
            Itemlist.Filter = yourCostumFilter;
            dgDepotAll.ItemsSource = Itemlist;
        }
    }
}
