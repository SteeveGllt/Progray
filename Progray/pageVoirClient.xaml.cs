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
    /// Logique d'interaction pour pageVoirClient.xaml
    /// </summary>
    public partial class pageVoirClient : Page
    {
        int idClient = 0;
        int idDepot = 0;
        List<Client> clients;
        Depot depot = new Depot();

        string[] titre = new string[] { "Monsieur", "Madame" };
        string[] statut = new string[] { "Particulier", "Professionnel" };
       


        public pageVoirClient()
        {
            InitializeComponent();
            gridModif.Visibility = Visibility.Hidden;
            dgClientAll.ItemsSource = clientAdo.all();
            cbxTitre.ItemsSource = titre;
            cbxStatut.ItemsSource = statut;
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;


        }

        private void dgClientAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgClientAll.SelectedItem != null)
            {
                btnModifier.IsEnabled = true;
                btnSupprimer.IsEnabled = true;
            }
            else
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }
         
                Client c = (Client)(dgClientAll.SelectedItem);
            
            
         
            
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            gridMain.Visibility = Visibility.Hidden;

            gridModif.Visibility = Visibility.Visible;
            


            Client client = (Client)dgClientAll.SelectedItem;
            idClient = client.idClient;

            cbxTitre.Text = client.Titre;
            tbxNom.Text = client.Nom;
            tbxPrenom.Text = client.Prenom;
            tbxAdresse.Text = client.Adresse;
            tbxCp.Text = client.Cp;
            tbxVille.Text = client.Ville;
            tbxTelephone.Text = client.Telephone;
            tbxMobile.Text = client.Mobile;
            tbxMail.Text = client.AdresseMail;
            cbxStatut.Text = client.Statut;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            clientAdo.update(cbxTitre.Text, tbxNom.Text, tbxPrenom.Text, tbxAdresse.Text, tbxCp.Text, tbxVille.Text, tbxTelephone.Text, tbxMobile.Text, tbxMail.Text, cbxStatut.Text, idClient);
            gridModif.Visibility = Visibility.Hidden;
            gridMain.Visibility = Visibility.Visible;

            dgClientAll.ItemsSource = null;
            dgClientAll.ItemsSource = clientAdo.all();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer ?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Client client = (Client)dgClientAll.SelectedItem;
                idClient = client.idClient;

                clientAdo.delete(idClient);

                dgClientAll.ItemsSource = null;
                dgClientAll.ItemsSource = clientAdo.all();
            }
            else if (dialogResult == DialogResult.No)
            {

            }

            



            
            
        }

        private void tbxClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _itemSourceList = new CollectionViewSource() { Source = clientAdo.all() };
            ICollectionView Itemlist = _itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => ((Client)item).Nom.Contains(tbxClient.Text));
            Itemlist.Filter = yourCostumFilter;
            dgClientAll.ItemsSource = Itemlist;
        }
    }
}
