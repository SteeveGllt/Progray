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
    /// Logique d'interaction pour pageCreationClient.xaml
    /// </summary>
    public partial class pageCreationClient : Page
    {
        string[] titre = new string[] { "Monsieur", "Madame" };
        string[] statut = new string[] { "Particulier", "Professionnel" };

        public pageCreationClient()
        {
            InitializeComponent();
            cbxTitre.ItemsSource = titre;
            cbxStatut.ItemsSource = statut;    
        }

        private void cbxTitre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string test = (string)cbxTitre.SelectedItem;
        }
        private void cbxStatut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = (string)cbxStatut.SelectedItem;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Client c = new Client(0, cbxTitre.Text , tbxNom.Text, tbxPrenom.Text, tbxAdresse.Text, tbxCp.Text, tbxVille.Text, tbxTelephone.Text, tbxMobile.Text, tbxMail.Text, cbxStatut.Text);
            //on ajoute le nouveau client en base de données
            clientAdo.create(c);
        }

        
    }
}
