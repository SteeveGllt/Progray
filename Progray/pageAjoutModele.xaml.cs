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
            this.marques = marqueAdo.all();
            cbxMarque.ItemsSource = null;
            cbxMarque.ItemsSource = this.marques;
        }

        private void cbxMarque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Marque marque = (Marque)cbxMarque.SelectedItem;
            idMarque = marque.idMarque;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Marque marque = (Marque)cbxMarque.SelectedItem;
            Modele mod = new Modele(0, tbxModele.Text, marque);
            modele = modeleAdo.createModel(mod);
        }
    }
}
