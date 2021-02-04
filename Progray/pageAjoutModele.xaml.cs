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
    /// Logique d'interaction pour pageAjoutModele.xaml
    /// </summary>
    public partial class pageAjoutModele : Page
    {
        List<Marque> marques;
        int idMarque = 0;
        Modele modele;
        public pageAjoutModele()
        {
            InitializeComponent();
            //Remplit la combobox de toutes les marques dans la base de données
            this.marques = marqueAdo.all();
            cbxMarque.ItemsSource = null;
            cbxMarque.ItemsSource = this.marques;
        }

        private void cbxMarque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Récupère l'ID de la marque sélectionnée
            Marque marque = (Marque)cbxMarque.SelectedItem;
            idMarque = marque.idMarque;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Erreur en cas de validation sans la marque et/ou le modele
            if(cbxMarque.Text == "" || tbxModele.Text == "")
            {
                MessageBox.Show("Veuillez remplir les champs");
                lblMarque.Foreground = Brushes.Red;
                lblModele.Foreground = Brushes.Red;
            }
            else
            {
                //Création du modele et ajout dans la base de données
                Marque marque = (Marque)cbxMarque.SelectedItem;
                Modele mod = new Modele(0, tbxModele.Text, marque);
                modele = modeleAdo.createModel(mod);
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
