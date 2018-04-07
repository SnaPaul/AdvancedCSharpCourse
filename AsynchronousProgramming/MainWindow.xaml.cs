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

namespace AsynchronousProgramming
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
            await DownloadHtmlAsync("http://msdn.microsoft.com");

            var html = await GetHtmlAsync("http://msdn.microsoft.com");
            MessageBox.Show(html.Substring(0, 10));


            var getHtmlTask = GetHtmlAsync("http://msdn.microsoft.com");
            MessageBox.Show("Waiting for the task to complete.");
            var html1 = await getHtmlTask;
            MessageBox.Show(html1.Substring(11, 21));

        }
        
        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"D:\Paul\Projekte\AdvancedCSharpCourse\temp\result.html"))
            {
                streamWriter.Write(html);
            }

        }

        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"D:\Paul\Projekte\AdvancedCSharpCourse\temp\result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }

        public string GetHtml(string url)
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
