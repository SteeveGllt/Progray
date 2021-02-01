using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour pageVoirModele.xaml
    /// </summary>
    public partial class pageVoirModele : Page
    {
        int code = 0;
        Frame frame;
        public pageVoirModele()
        {
            InitializeComponent();
            dgModele.ItemsSource = modeleAdo.all();
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;
            gridModifier.Visibility = Visibility.Hidden;
        }
       

        private void dgModele_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgModele.SelectedItem != null)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Modele modele = (Modele)dgModele.SelectedItem;
            code = modele.Code;
            modeleAdo.update(tbxModele.Text, code);
            gridMain.Visibility = Visibility.Visible;
            gridModifier.Visibility = Visibility.Hidden;

            dgModele.ItemsSource = null;
            dgModele.ItemsSource = modeleAdo.all();

            

        }


        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            gridMain.Visibility = Visibility.Hidden;
            gridModifier.Visibility = Visibility.Visible;




            Modele mod = (Modele)dgModele.SelectedItem;
            code = mod.Code;


            tbxModele.Text = mod.Model;
           
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment supprimer ?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Modele mod = (Modele)dgModele.SelectedItem;
                code = mod.Code;
                modeleAdo.delete(code);

                dgModele.ItemsSource = null;
                dgModele.ItemsSource = modeleAdo.all();
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        
        }
    }
}
