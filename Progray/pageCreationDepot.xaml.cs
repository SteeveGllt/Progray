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
    /// Logique d'interaction pour pageCreationDepot.xaml
    /// </summary>
    public partial class pageCreationDepot : Page
    {
        List<Materiel> materiels;
        List<Marque> marques;
        List<Client> clients;
        Depot depot;
        string[] delai = new string[] { "Normal", "Autre" };
        public pageCreationDepot()
        {
            InitializeComponent();
            cbxDelai.ItemsSource = delai;

            this.clients = clientAdo.all();
            cbxClient.ItemsSource = null;
            cbxClient.ItemsSource = this.clients;

            this.marques = marqueAdo.all();
            cbxMarque.ItemsSource = null;
            cbxMarque.ItemsSource = this.marques;

            this.materiels = materielAdo.all();
            cbxMateriel.ItemsSource = null;
            cbxMateriel.ItemsSource = this.materiels;

        }

        private void cbxClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client client = (Client)(cbxClient.SelectedItem);
        }

        private void cbxMateriel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Materiel materiel = (Materiel)(cbxMateriel.SelectedItem);
        }

        private void cbxMarque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Marque marque = (Marque)(cbxMarque.SelectedItem);
        }

        private void cbxDelai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string d = (string)cbxDelai.SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Marque marque = (Marque)(cbxMarque.SelectedItem);
            Client client = (Client)(cbxClient.SelectedItem);
            Materiel materiel = (Materiel)(cbxMateriel.SelectedItem);
            Depot d = new Depot(marque, client, materiel, cbxDelai.Text);
            depot = depotAdo.createDepot(d);
        }
    }
}
