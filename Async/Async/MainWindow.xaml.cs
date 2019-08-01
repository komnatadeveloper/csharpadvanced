using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            // sync
            // DownloadHTML("http://www.sahibinden.com");

            // async
            //DownloadHtmlAsync("http://www.sahibinden.com");





            // Şimdi de farklı bir sync async sidik yarıştıralım

            // sync
            //var html = GetHtml("http://msdn.microsoft.com");
            //MessageBox.Show(html.Substring(0, 10));

            // async  --- YALNIZ BU SEFER, BURADA AWAIT KULLANDIGIMIZ İÇİN, Button_Click de async oluyor...   
            /*
            var html =  await GetHtmlAsync("http://msdn.microsoft.com");
            MessageBox.Show(html.Substring(0, 10));
            */


            // şimdi de gene async fakat, araya istersek başka işlemler koyacagımız bir şekilde deneyecegiz.
            var getHtmlTask =  GetHtmlAsync("http://msdn.microsoft.com"); // task type
            // ARANIN BAŞI
            MessageBox.Show("DOING SOMETHING");
            // ARANIN SONU :)

            var html = await getHtmlTask;  // şimdi taskten stringe döndü
            MessageBox.Show(html.Substring(0, 10));

        }

        public void DownloadHTML(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"\Users\Emrah\csharpadvanced\Async\result.html"))
            {
                streamWriter.Write(html);
            }
        }

        // şimdi de Asynch olsun 

        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"\Users\Emrah\csharpadvanced\Async\result.html") )
            {
                await streamWriter.WriteAsync(html);
            }
        }

        public string GetHtml(string  url)
        {
            var webClient = new WebClient();

            return webClient.DownloadString(url);
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            var webClient = new WebClient();

            return await webClient.DownloadStringTaskAsync(url);

        }
    }
}
