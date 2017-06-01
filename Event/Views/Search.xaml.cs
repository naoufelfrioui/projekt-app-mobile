using Event.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using System;
using System.Threading;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using Event.Models;
using System.Collections.Generic;
namespace Event.Views
{
    public sealed partial class Search : Page
    {
        List<Partylist> Partyl = new List<Partylist>();
        public Search()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            
        }

        private async void getdata()
        {
            List<String> list = new List<String>();

            //  String url = "https://www.goabase.net/api/party/json/?geoloc=Berlin&limit=10";
            String url = "https://www.goabase.net/api/party/json/?geoloc=Berlin&search="+Searchtext.Text+ "&limit=10";

            Windows.Web.Http.HttpClient Client = new Windows.Web.Http.HttpClient();
            Uri requestUri = new Uri(url);
            string response = await Client.GetStringAsync(requestUri);

            var data = JsonConvert.DeserializeObject<MesseListe>(response);
            Partyl = data.partylist;
            while (Partyl[0] == null)
            {
                Partyl = data.partylist;
                wait.Visibility = Visibility.Visible;
            }

            wait.Visibility = Visibility.Collapsed;
            dataItem.ItemsSource = Partyl;
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            List<String> list = new List<String>();

            //  String url = "https://www.goabase.net/api/party/json/?geoloc=Berlin&limit=10";
            String url = "https://www.goabase.net/api/party/json/?geoloc=Berlin&search=" + Searchtext.Text + "&limit=10";

            Windows.Web.Http.HttpClient Client = new Windows.Web.Http.HttpClient();
            Uri requestUri = new Uri(url);
            string response = await Client.GetStringAsync(requestUri);

            var data = JsonConvert.DeserializeObject<MesseListe>(response);
            Partyl = data.partylist;
            while (Partyl[0] == null)
            {
                Partyl = data.partylist;
                wait.Visibility = Visibility.Visible;
            }

            wait.Visibility = Visibility.Collapsed;
            dataItem.ItemsSource = Partyl;

        }
    }
}

