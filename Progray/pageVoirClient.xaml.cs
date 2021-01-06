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
    /// Logique d'interaction pour pageVoirClient.xaml
    /// </summary>
    public partial class pageVoirClient : Page
    {
        int idClient = 0;
        int idDepot = 0;
        Depot depot = new Depot();

        string[] titre = new string[] { "Monsieur", "Madame" };
        string[] statut = new string[] { "Particulier", "Professionnel" };
       


        public pageVoirClient()
        {
            InitializeComponent();
            gridTest.Visibility = Visibility.Hidden;
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
            
            dgClientAll.Visibility = Visibility.Hidden;
            
            btnModifier.Visibility = Visibility.Hidden;
            btnSupprimer.Visibility = Visibility.Hidden;
            gridTest.Visibility = Visibility.Visible;

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
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            

            Client client = (Client)dgClientAll.SelectedItem;
            idClient = client.idClient;

            clientAdo.delete(idClient);



            
            
        }
    }
}
