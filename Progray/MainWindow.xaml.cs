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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Path = System.IO.Path;
using Paragraph = iTextSharp.text.Paragraph;
using Control = System.Windows.Controls.Control;
using PdfSharp.Pdf;
using DocumentFormat.OpenXml.Bibliography;
using Rectangle = iTextSharp.text.Rectangle;

namespace Progray
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {
            InitializeComponent();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageVoirClient();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageCreationClient();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageCreationMateriel();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageVoirMateriel();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageVoirMarque();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageCreationMarque();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageCreationDepot();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageVoirDepot();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageVoirModele();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            frame.Content = new pageAjoutModele();
        }


    }
}
