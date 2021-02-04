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
            //Erreur en cas de validation sans la marque et/ou le modele
            if (cbxTitre.Text == "" || tbxNom.Text == "")
            {
                MessageBox.Show("Veuillez remplir les champs");
                lblNom.Foreground = Brushes.Red;
                lblTitre.Foreground = Brushes.Red;
            }
            //Si le prénom du client n'est pas remplit
            else if(tbxPrenom.Text == "")
            {
                
                Client c = new Client(0, cbxTitre.Text, tbxNom.Text.ToUpper(), tbxPrenom.Text, tbxAdresse.Text, tbxCp.Text, tbxVille.Text, tbxTelephone.Text, tbxMobile.Text, tbxMail.Text, cbxStatut.Text);
                //on ajoute le nouveau client en base de données
                clientAdo.create(c);
            }
            else
            {
                string oldString = tbxPrenom.Text;
                string newString = oldString[0].ToString().ToUpper() + oldString.Substring(1).ToLower();
                Client c = new Client(0, cbxTitre.Text, tbxNom.Text.ToUpper(), newString, tbxAdresse.Text, tbxCp.Text, tbxVille.Text, tbxTelephone.Text, tbxMobile.Text, tbxMail.Text, cbxStatut.Text);
                //on ajoute le nouveau client en base de données
                clientAdo.create(c);
            }
            
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Button_Click(null, null);
            }
        }
    }
}
