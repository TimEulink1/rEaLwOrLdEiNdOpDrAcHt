using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using EindProject.Models;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System;

namespace EindProject.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var x = testAsync("https://monitoringapi.solaredge.com/site/1644119/envBenefits?systemUnits=Metrics&api_key=CXPXKNZ85EBSC5VA6TIKIJDKKVVSDIRA&=");
        }

        private void OnPointerEnter(object sender, PointerEventArgs e)
        {
            //do something when pointer enters
        }

        public async Task<EnvBenfitsResult> testAsync(string uri)
        {
            // Move these lines to a "service" or something
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(uri);
            
            var env = JsonSerializer.Deserialize<EnvBenfitsResult>(content);
            return env;
        }
    }
}
