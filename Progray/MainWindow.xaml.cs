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

namespace Progray
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Materiel> materiels;
        List<Marque> marques;
        List<Client> clients;
        Depot depot;
        
        
        public MainWindow()
        {
            InitializeComponent();
            this.materiels = materielAdo.all();
            this.marques = marqueAdo.all();
            this.clients = clientAdo.all();

            //List<Materiel> materiel = new List<Materiel>();
            //foreach (Materiel m in materiels)
            //{
            //    materiel.Add(m);

            //}
            //dgMateriel.ItemsSource = materiel;

            //List<Marque> marque = new List<Marque>();
            //foreach (Marque m in marques)
            //{
            //    marque.Add(m);

            //}
            //dgMarque.ItemsSource = marque;

            gridEntête.Visibility = Visibility.Visible;
            gridMenu.Visibility = Visibility.Visible;
            gridPage.Visibility = Visibility.Hidden;
            gridMarque.Visibility = Visibility.Hidden;
            gridCreerMateriel.Visibility = Visibility.Hidden;
            gridClient.Visibility = Visibility.Hidden;
            gridProbleme.Visibility = Visibility.Hidden;
            gridDepot.Visibility = Visibility.Hidden;





        }

        
        private void cbxMateriel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // comme pour le datagrid on récupère le fighter sélectionné
            Materiel m = (Materiel)(cbxMateriel.SelectedItem);
            tbxChoixMateriel.Text = m.TypeMateriel;
        }

        

        private void btnCreerMateriel_Click(object sender, RoutedEventArgs e)
        {

            gridMenu.Visibility = Visibility.Hidden;
            gridEntête.Visibility = Visibility.Hidden;
            gridCreerMateriel.Visibility = Visibility.Visible;
        }

        private void btnCreerMarque_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Visibility = Visibility.Hidden;
            gridEntête.Visibility = Visibility.Hidden;
            gridMarque.Visibility = Visibility.Visible;
        }

        private void btnTypeMateriel_Click(object sender, RoutedEventArgs e)
        {
            Materiel m = new Materiel(0, tbxTypeMateriel.Text);
            //on ajoute le nouveau client en base de données
            materielAdo.createMateriel(m);

            gridCreerMateriel.Visibility = Visibility.Hidden;
            gridMenu.Visibility = Visibility.Visible;
            gridEntête.Visibility = Visibility.Visible;
        }

        private void btnRetourMateriel_Click(object sender, RoutedEventArgs e)
        {
            gridCreerMateriel.Visibility = Visibility.Hidden;
            gridMenu.Visibility = Visibility.Visible;
            gridEntête.Visibility = Visibility.Visible;
        }

        private void btnCreerMarque1_Click(object sender, RoutedEventArgs e)
        {
            Marque m = new Marque(0, tbxMarque.Text);
            //on ajoute la nouvelle marque en base de données
            marqueAdo.createMarque(m);

            gridMarque.Visibility = Visibility.Hidden;
            gridMenu.Visibility = Visibility.Visible;
            gridEntête.Visibility = Visibility.Visible;
        }

        private void btnRetourMarque_Click(object sender, RoutedEventArgs e)
        {
            gridMarque.Visibility = Visibility.Hidden;
            gridMenu.Visibility = Visibility.Visible;
            gridEntête.Visibility = Visibility.Visible;
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            gridPage.Visibility = Visibility.Hidden;
            gridMenu.Visibility = Visibility.Visible;
            gridEntête.Visibility = Visibility.Visible;
        }
 
        //Bouton pour valider le dépôt
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Marque marque = (Marque)(cbxMarque.SelectedItem);
            Client client = (Client)(cbxClient.SelectedItem);
            Materiel materiel = (Materiel)(cbxMateriel.SelectedItem);
            Depot d = new Depot(marque, client, materiel, tbxDelai.Text);
            depot = depotAdo.createDepot(d);
            

            gridDepot.Visibility = Visibility.Hidden;
            gridProbleme.Visibility = Visibility.Visible;
        }

        //Bouton pour passer du menu au création client
        private void btnCreerClient_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Visibility = Visibility.Hidden;
            gridClient.Visibility = Visibility.Visible;
        }

        //Création du client + Retour menu
        private void btnValideClient_Click(object sender, RoutedEventArgs e)
        {
            Client c = new Client(0, tbxTitre.Text, tbxNom.Text, tbxPrenom.Text, tbxAdresse.Text, tbxCp.Text, tbxVille.Text, tbxTelephone.Text, tbxMobile.Text, tbxMail.Text, tbxEntreprise.Text);
            //on ajoute le nouveau client en base de données
            clientAdo.create(c);


            gridClient.Visibility = Visibility.Hidden;

            gridMenu.Visibility = Visibility.Visible;
        }

        //Bouton pour retourner de la création de client au menu
        private void btnRetourClient_Click(object sender, RoutedEventArgs e)
        {
            gridClient.Visibility = Visibility.Hidden;
            gridMenu.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
        //Bouton pour passer du menu au Dépôt
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gridMenu.Visibility = Visibility.Hidden;
            gridDepot.Visibility = Visibility.Visible;

            cbxMateriel.ItemsSource = null;
            cbxMateriel.ItemsSource = this.materiels;

            cbxMarque.ItemsSource = null;
            cbxMarque.ItemsSource = this.marques;

            cbxClient.ItemsSource = null;
            cbxClient.ItemsSource = this.clients;
        }

        private void cbxMarque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // comme pour le datagrid on récupère la marque sélectionné
            Marque marque = (Marque)(cbxMarque.SelectedItem);
            tbxChoixMarque.Text = marque.Nom;
        }

        private void cbxClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // comme pour le datagrid on récupère la marque sélectionné
            Client client = (Client)(cbxClient.SelectedItem);
            tbxChoixClient.Text = client.Titre + " | " + client.Nom + " | " + client.Prenom + " | " + client.Adresse + " | " + client.Cp + " | " + client.Ville + " | " + client.Telephone + " | " + client.Mobile + " | " + client.AdresseMail + " | " + client.Statut;
        }

        //Bouton retour de la fenêtre dépôt
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            gridDepot.Visibility = Visibility.Hidden;
            gridMenu.Visibility = Visibility.Visible;
        }
        private void btnClient_Click(object sender, RoutedEventArgs e)
        {

            Probleme probleme = new Probleme(0, depot, tbxProbleme.Text);
            problemeAdo.createProbleme(probleme);

            gridProbleme.Visibility = Visibility.Hidden;
            gridPage.Visibility = Visibility.Visible;
        
            using (StreamReader sr = new StreamReader("progray.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    tbxTarif.Text += line;
                }
            }
            using (StreamReader sr = new StreamReader("tarif.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    tbxTarif2.Text += line;
                }
            }



        }

        private void btnImprimer_Click(object sender, RoutedEventArgs e)
        {
            

            string outputTempFile = Path.Combine(Application.StartupPath, tbxTitrePDF.Text + "_temp.pdf"); ;
            string outputFile = Path.Combine(Application.StartupPath, tbxTitrePDF.Text + ".pdf");

            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(outputFile, FileMode.Create, FileAccess.ReadWrite));
            PdfPTable test = new PdfPTable(3);
            
            string cellule = tbxChoixClient.Text;
            document.Open();
            
            document.Add(new Paragraph("Information client : " + );
            document.Add(new Paragraph(" " + "\n" + " "));
            document.Add(new Paragraph("Matériel : " + tbxChoixMateriel.Text));
            document.Add(new Paragraph("Marque : " + tbxChoixMarque.Text));
            document.Add(new Paragraph("Délai : " + tbxDelai.Text));
            document.Add(new Paragraph("Problème(s) : " + tbxProbleme.Text));
            document.Add(new Paragraph(tbxTarif.Text));
            document.Add(new Paragraph("Signature client : "));
            document.Add(new Paragraph("Cadre réservé à l'atelier : "));
            document.Add(new Paragraph("Tarif au 05/06/2015 :" + tbxTarif2.Text));
            document.AddTitle(tbxTitrePDF.Text);

           

            document.Close();
            

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
    }
}
