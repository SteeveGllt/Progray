using iTextSharp.text;
using iTextSharp.text.pdf;
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
using Paragraph = iTextSharp.text.Paragraph;

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

            Probleme probleme = new Probleme(0, depot, tbxProbleme.Text);
            problemeAdo.createProbleme(probleme);

            

            PdfPTable pdfTableBlank = new PdfPTable(1);





            PdfPTable pdfTable1 = new PdfPTable(1);
            PdfPTable pdfTable2 = new PdfPTable(1);
            PdfPTable pdfTable3 = new PdfPTable(2);
            PdfPTable pdfTableText = new PdfPTable(2);
            PdfPTable pdfTarif = new PdfPTable(1);
            PdfPTable pdfImage = new PdfPTable(1);

            System.Drawing.Font fontH1 = new System.Drawing.Font("Currier", 16);

            pdfTable1.WidthPercentage = 80;
            pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            pdfTable1.DefaultCell.BorderWidth = 0;
            pdfTable1.DefaultCell.Padding = 10;


            pdfTable3.DefaultCell.Padding = 5;
            pdfTable3.WidthPercentage = 80;
            pdfTable3.DefaultCell.BorderWidth = 0.5f;

            pdfTableText.DefaultCell.Padding = 5;
            pdfTableText.WidthPercentage = 80;
            pdfTableText.DefaultCell.BorderWidth = 0.5f;

            pdfTarif.DefaultCell.Padding = 5;
            pdfTarif.WidthPercentage = 80;
            pdfTarif.DefaultCell.BorderWidth = 0.5f;

            pdfTarif.DefaultCell.BorderColor = new CMYKColor(0f, 0f, 0f, 0f);

            


            string imageUrl = @"C:\Users\steev\source\repos\Progray\Progray\progray.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageUrl);

            jpg.ScaleToFit(80f, 70f);


            jpg.Alignment = Element.ALIGN_CENTER;

            Phrase p1 = new Phrase("FICHE SAV", FontFactory.GetFont("Times New Roman", 15, Font.BOLD));
            pdfTable1.AddCell(p1);

            

  


            pdfTable3.AddCell(new Phrase("TITRE", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.Titre));
            pdfTable3.AddCell(new Phrase("NOM CLIENT", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.Nom));
            pdfTable3.AddCell(new Phrase("PRENOM CLIENT", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.Prenom));
            pdfTable3.AddCell(new Phrase("ADRESSE", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.Adresse));
            pdfTable3.AddCell(new Phrase("CODE POSTAL", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.Cp));
            pdfTable3.AddCell(new Phrase("VILLE", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.Ville));
            pdfTable3.AddCell(new Phrase("TELEPHONE", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.Telephone));
            pdfTable3.AddCell(new Phrase("MOBILE", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.Mobile));
            pdfTable3.AddCell(new Phrase("ADRESSE MAIL", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.AdresseMail));
            pdfTable3.AddCell(new Phrase("STATUT", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTable3.AddCell(new Phrase(depot.Client.Statut));


            pdfTableText.AddCell(new Phrase("MATERIEL", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTableText.AddCell(new Phrase(depot.Materiel.TypeMateriel));
            pdfTableText.AddCell(new Phrase("MARQUE", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTableText.AddCell(new Phrase(depot.Marque.Nom));
            pdfTableText.AddCell(new Phrase("DELAI", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTableText.AddCell(new Phrase(depot.Delai));
            pdfTableText.AddCell(new Phrase("DATE DEPOT", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTableText.AddCell(new Phrase(Convert.ToString(depot.DateDepot)));
            pdfTableText.AddCell(new Phrase("PROBLEME", FontFactory.GetFont("Times New Roman", 12, Font.BOLD)));
            pdfTableText.AddCell(new Phrase(Convert.ToString(probleme.ToString())));

            using (StreamReader sr = new StreamReader("progray.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    //pdfTarif.AddCell(line);
                }
            }
            using (StreamReader sr = new StreamReader("tarif.txt"))
            {
                string line;
                
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    pdfTarif.AddCell(line);
                   
                }
            }

            string folderPath = "D:\\PDF\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            int fileCount = Directory.GetFiles(@"D:\\PDF").Length;
            string strFileName = "FicheSav"+ depot.Client.Nom + (fileCount + 1) + ".pdf";


            using (FileStream stream = new FileStream(folderPath + strFileName, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();


                pdfDoc.Add(jpg);
                pdfDoc.Add(pdfTable1);
                pdfDoc.Add(new Paragraph("Informations client : " + "\n" + " ", FontFactory.GetFont("Times New Roman", 14, Font.BOLD)));
                pdfDoc.Add(pdfTable2);
                pdfDoc.Add(pdfTableBlank);
                pdfDoc.Add(pdfTable3);
                pdfDoc.Add(new Paragraph("Matériel déposé : " + "\n" + " ", FontFactory.GetFont("Times New Roman", 14, Font.BOLD)));
                pdfDoc.Add(pdfTableText);      
                pdfDoc.NewPage();
                pdfDoc.Add(new Paragraph("Tarif : " + "\n" + " ", FontFactory.GetFont("Times New Roman", 14, Font.BOLD)));
                pdfDoc.Add(pdfTarif);
                pdfDoc.NewPage();

                pdfDoc.Close();
                stream.Close();

            }
        }
    }
}
