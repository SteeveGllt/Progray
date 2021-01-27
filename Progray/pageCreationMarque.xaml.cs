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
            Marque m = new Marque(0, tbxMarque.Text);
            
            //on ajoute la nouvelle marque en base de données
           marque =  marqueAdo.createMarque(m);

        }
    }
}
