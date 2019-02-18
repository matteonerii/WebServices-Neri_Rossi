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
using System.Net.Http;
using System.IO;
using System.Web.Script.Serialization;

namespace Client__Rossi
{
    public partial class MainWindow : Window
    {
        static string mycontent;
        public MainWindow()
        {
            InitializeComponent();
            JavaScriptSerializer jvObj = new JavaScriptSerializer();
            jvObj.Deserialize<string>(mycontent);
        }
        /*
         * APPUNTI
         * 
         * Lo 'using' è un sistema di gestione delle eccezioni analogo alla struttura Try-Catch-Finally ma più performante
         * 
         * la parola chiave 'await' permette una gestione asincrona
         * 
         */


        private void btn_Invoke_Click(object sender, RoutedEventArgs e)
        {
            //CodiceFiscale.CodiceFiscaleSoapClient soapClient = new CodiceFiscale.CodiceFiscaleSoapClient();

            //string response = soapClient.CalcolaCodiceFiscale(txt_Name.Text, txt_Surname.Text, txt_CityBirth.Text, txt_Birth.Text, txt_Gender.Text);

           // MessageBox.Show(response);
        }
        /*
         * BOTTONE POST
         */
        private void btn_ShowPOST_Click(object sender, RoutedEventArgs e)
        {
            //string url = "http://webservices.dotnethell.it/codicefiscale.asmx/CalcolaCodiceFiscale";
            //PostRequest(url, txt_Name.Text, txt_Surname.Text, txt_CityBirth.Text, txt_Birth.Text, txt_Gender.Text);
        }
        /*
         * BOTTONE GET
         */
        private void btn_ShowGet_Click(object sender, RoutedEventArgs e)
        {
            //string url = "http://webservices.dotnethell.it/codicefiscale.asmx/CalcolaCodiceFiscale?Nome="
                //+ txt_Name.Text + "&Cognome=" + txt_Surname.Text + "&ComuneNascita=" + txt_CityBirth.Text + "&DataNascita=" + txt_Birth.Text + "&Sesso=" + txt_Gender.Text;


            //GetRequest(url);
        }
        /*
         * Metodo che effettua la 'GET' asincrono e statico
         */
        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        mycontent = await content.ReadAsStringAsync();
                        //MessageBox.Show(mycontent);
                    }
                }
            }
        }
        /*
         * Bottone realtivo alla pulizia della listbox di stampa
         */
        private void btn_ClearListBox_Click(object sender, RoutedEventArgs e)
        {
            lstPrint.Items.Clear();
        }
        /*
         * Bottone relativo alla stampa dell'elenco dei libri presenti
         * nel reparto "Ultimi arrivi" e della categoria "Fumetti"
         */
        private void btn_LastArrival_Click(object sender, RoutedEventArgs e)
        {

        }
        /*
         * Bottone relativo alla stampa di tutti i libri nel catalogo 
         */
        private void btn_Catalog_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://10.13.100.39/cartella/WebServices-Neri_Rossi/SERVER/?funzione="+"0";
            GetRequest(url);
            lstPrint.Items.Add(url);
        }
        /*
         * Bottone relativo alla stampa di tutti i libri scontati presenti in tutti 
         * i reparti in ordine crescente per sconto
         */
        private void btn_PrintDepartments_Click(object sender, RoutedEventArgs e)
        {

        }
        /*
         * Bottone relativo alla stampa dell'elenco dei libri archiviati all'interno
         * di un periodo definito da due date 
         */
        private void btn_PrintArchived_Click(object sender, RoutedEventArgs e)
        {

        }
        /*
         * Bottone relativo alla stampa dell' elenco dei titoli dei libri acquistati 
         * con il rispettivo numero copie e username dell'utente associato a quel carrello
         */
        private void btn_PrintPurchasedBooks_Click(object sender, RoutedEventArgs e)
        {
            string beginData = txt_FirstDate.Text;
            string endDate = txt_SecondDAte.Text;
        }
    }
}