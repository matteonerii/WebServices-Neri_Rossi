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

namespace Client__Rossi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                        string mycontent = await content.ReadAsStringAsync();
                        MessageBox.Show(mycontent);
                    }
                }
            }
        }

        /*
         * Metodo che effettua la 'POST' asincrono e statico
         */
        async static void PostRequest(string url, string name, string surname, string citybirth, string birth, string gender)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string> ("Nome", name),
                new KeyValuePair<string, string> ("Cognome", surname),
                new KeyValuePair<string, string> ("ComuneNascita", citybirth),
                new KeyValuePair<string, string> ("DataNascita", birth),
                new KeyValuePair<string, string> ("Sesso", gender),
            };

            HttpContent http_content = new FormUrlEncodedContent(queries);

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url, http_content))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        MessageBox.Show(mycontent);
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

        private void btn_Catalog_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://10.13.100.39/cartella/SERVER/index.php?name=" + "People of the Wind";
            GetRequest(url);
        }
    }
}
