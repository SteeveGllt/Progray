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
    /// Logique d'interaction pour pageCreationMarque.xaml
    /// </summary>
    public partial class pageCreationMarque : Page
    {
        Marque marque;
        public pageCreationMarque()
        {
            InitializeComponent();
        }


        private void btnCreerMarque_Click(object sender, RoutedEventArgs e)
        {
            //Erreur en cas de validation sans avoir rentré de marque
            if (tbxMarque.Text == "")
            {
                MessageBox.Show("Veuillez remplir les champs");
                lblMarque.Foreground = Brushes.Red;
            }
            else
            {
                //Permet de mettre la première lettre en majuscule
                string oldString = tbxMarque.Text;
                string newString = oldString[0].ToString().ToUpper() + oldString.Substring(1).ToLower();
                Marque m = new Marque(0, newString);
            
                 //on ajoute la nouvelle marque en base de données
                 marque =  marqueAdo.createMarque(m);
            } 
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnCreerMarque_Click(null, null);
            }
        }
    }
}
