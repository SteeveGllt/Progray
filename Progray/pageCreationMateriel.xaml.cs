using System;
using System.Collections.Generic;
using System.IO;
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
using ZXing;

namespace Progray
{
    /// <summary>
    /// Logique d'interaction pour pageCreationMateriel.xaml
    /// </summary>
    public partial class pageCreationMateriel : Page
    {
        public pageCreationMateriel()
        {
            InitializeComponent();
        }

        private void btnTypeMateriel_Click(object sender, RoutedEventArgs e)
        {
            //Erreur en cas de validation sans avoir rentré de matériel
            if(tbxTypeMateriel.Text == "")
            {
                MessageBox.Show("Veuillez remplir les champs");
                lblMateriel.Foreground = Brushes.Red;
            }
            else
            {
                //Permet de mettre la première lettre en majuscule
                string oldString = tbxTypeMateriel.Text;
                string newString = oldString[0].ToString().ToUpper() + oldString.Substring(1).ToLower();

                //Création d'un nouveau matériel
                Materiel m = new Materiel(0, newString);
                //on ajoute le nouveau client en base de données
                materielAdo.createMateriel(m);
            }
            
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnTypeMateriel_Click(null, null);
            }
        }
    }
}
