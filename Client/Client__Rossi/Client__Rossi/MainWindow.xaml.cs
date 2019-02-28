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

/*
 * APPUNTI
 * 
 * Lo 'using' è un sistema di gestione delle eccezioni analogo alla struttura Try-Catch-Finally ma più performante
 * 
 * la parola chiave 'await' permette una gestione asincrona
 * 
 */

namespace Client__Rossi
{
    public partial class MainWindow : Window
    {
        string url = "http://10.13.100.39/cartella/WebServices-Neri_Rossi/SERVER/?funzione=";
        static public string titoli;
        static public string[] formattedTitles = new string[4];
        static string mycontent;
        public MainWindow()
        {
            InitializeComponent();
        }
        /*
         * Metodo che effettua la 'GET' asincrono e statico
         */
        async static Task GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        mycontent = await content.ReadAsStringAsync();
                        /*
                         * formattazione della stringa proveniente dal server
                         */
                        bool find = true;
                        int start = 0;
                        int end = 0;
                        int i = 0;

                        while (find == true)
                        {
                            if (mycontent.Substring(start).Contains("data"))
                            {
                                start = mycontent.IndexOf("data", start);
                                end = mycontent.IndexOf("]", start);
                                titoli = mycontent.Substring(start + 7, end - start - 7);
                                formattedTitles = titoli.Split(',');
                                start++;
                                i++;
                            }
                            else
                            {
                                find = false;
                            }
                        }
                        /*
                         * striga proveniente dal server (completa) usata per le prove
                         * di formattazione della stringa
                         */
                       //MessageBox.Show(mycontent);
                    }
                }
            }
        }
        /*
         * Bottone relativo alla stampa di tutti i libri nel catalogo 
         */
        private async void btn_Catalog_Click(object sender, RoutedEventArgs e)
        {
            Task task = GetRequest(url + "0");
            await task;
            string tmp = "";
            Show(tmp);
        }
        /*
         * Bottone relativo alla stampa di tutti i libri scontati presenti in tutti 
         * i reparti in ordine crescente per sconto
         */
        private async void btn_PrintDepartments_Click(object sender, RoutedEventArgs e)
        {
            Task task = GetRequest(url + "2");
            await task;
            string tmp = "";
            Show(tmp);
        }
        /*
         * Bottone relativo alla stampa dell'elenco dei libri archiviati all'interno
         * di un periodo definito da due date.
         */
        private async void btn_PrintArchived_Click(object sender, RoutedEventArgs e)
        {
            Task task = GetRequest(url + "3" + "&data1=" + txt_FirstDate.Text + "&data2=" + txt_SecondDAte.Text);
            await task;
            string tmp = "";
            Show(tmp);
        }
        /*
         * Bottone relativo alla stampa dell' elenco dei titoli dei libri acquistati 
         * con il rispettivo numero copie e username dell'utente associato a quel carrello
         */
        private async void btn_PrintPurchasedBooks_Click(object sender, RoutedEventArgs e)
        {
            Task task = GetRequest(url + "4");
            await task;
            string tmp = "";
            Show(tmp);
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
        private async void btn_LastArrival_Click(object sender, RoutedEventArgs e)
        {
            Task task = GetRequest(url + "1");
            await task;
            string tmp = "";
            Show(tmp);
        }

        public void Show(string tmp)
        {
            lstPrint.Items.Add("Risultato ricerca: \n");
            foreach (string str in formattedTitles)
            {  
                tmp = str.Trim('"');
            /*
             * con str.Trim formattiamo ulteriormente la stringa di output 
             * togliendo anche le doppie virgole separatrici dei nomi
             */
                lstPrint.Items.Add(tmp);
            }
        }
    }
}