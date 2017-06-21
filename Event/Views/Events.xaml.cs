using Windows.System;
using Event.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Globalization;
using System.Resources;
using System.Threading;
using System;
using Newtonsoft.Json;
using Event.Models;
using System.Collections.Generic;
using Template10.Services.NavigationService;
using Windows.UI.Popups;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Event.Views
{
    public sealed partial class Events : Page
    {
        List<Messe> listmesse = new List<Messe>();
        RandomAccessStreamReference mapIconStreamReference;

       
        public Events()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            Panelmaps.Visibility = Visibility.Collapsed;
            Paneldata.Visibility = Visibility.Collapsed;
            wait.Visibility = Visibility.Visible;
            List<Messe> messel = new List<Messe>();

            //this.getdata();
            this.Messeliste();
            mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png"));
        }



        private async void Messeliste()
        {

            String url = "https://www.jasonbase.com/things/EYBG.json";
            //String url = "https://www.jasonbase.com/things/04lE.json";
            //  String url = "http://www.expodatabase.de/api/1/messen/show.php?json=1&city=paris&token=df9c447drg67zHujLiopq7774dh567sIjkzT";

            //String url = "http://samples.openweathermap.org/data/2.5/weather?zip=94040,us&appid=b1b15e88fa797225412429c1c50c122a1";
            Windows.Web.Http.HttpClient Client = new Windows.Web.Http.HttpClient();
            Uri requestUri = new Uri(url);
            string response = await Client.GetStringAsync(requestUri);

            var data = JsonConvert.DeserializeObject<MesseListe>(response);
            listmesse = data.messen.messe;
            while (listmesse[0] == null)
            {
                listmesse = data.messen.messe;
                wait.Visibility = Visibility.Visible;
            }
            Paneldata.Visibility = Visibility.Visible;
            wait.Visibility = Visibility.Collapsed;
            dataItem.ItemsSource = listmesse;


        }


        private async void GridView_ItemClickAsync(object sender, ItemClickEventArgs e)
        {
            var selectMesse = (Messe)e.ClickedItem;
            Paneldata.Visibility = Visibility.Collapsed;
            Panelmaps.Visibility = Visibility.Visible;
            body.Text = selectMesse.body;
            title.Text = selectMesse.title;

            try
            {
                var locator = new Geolocator();
                locator.DesiredAccuracyInMeters = 100;
                var position = await locator.GetGeopositionAsync();
                var myPosition = new Windows.Devices.Geolocation.BasicGeoposition();
                myPosition.Latitude = selectMesse.location[1];
                myPosition.Longitude = selectMesse.location[0];
                var myPoint = new Windows.Devices.Geolocation.Geopoint(myPosition);
                await maps.TrySetViewAsync(myPoint, 12D);
                MapIcon mapIcon1 = new MapIcon();
                mapIcon1.Location = maps.Center;
                mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapIcon1.Image = mapIconStreamReference;
                mapIcon1.ZIndex = 0;
                mapIcon1.Title = selectMesse.title;
                maps.MapElements.Add(mapIcon1);

            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.ToString());
                await dialog.ShowAsync();
            }


        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Panelmaps.Visibility = Visibility.Collapsed;
            Paneldata.Visibility = Visibility.Visible;
            maps.MapElements.Clear();


        }

    }
}

