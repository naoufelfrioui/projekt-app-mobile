using Event.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using System;
using System.Threading;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using Event.Models;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using System.Globalization;
using System.Resources;
using Template10.Services.NavigationService;
using Windows.UI.Popups;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;

namespace Event.Views
{
    public sealed partial class Search : Page
    {
        List<Partylist> Partyl = new List<Partylist>();
        RandomAccessStreamReference mapIconStreamReference;
        public Search()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            Panelmaps.Visibility = Visibility.Collapsed;
            Paneldata.Visibility = Visibility.Visible;
            Paneldata1.Visibility = Visibility.Visible;
            wait.Visibility = Visibility.Visible;
            mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png"));
            this.getdata();
        }

        private async void getdata()
        {
            

            // String url = "https://www.goabase.net/api/party/json/?country=Germany&limit=9";
            String url = "https://www.goabase.net/api/party/json/?country=Germany&search=&limit=30";

            Windows.Web.Http.HttpClient Client = new Windows.Web.Http.HttpClient();
            Uri requestUri = new Uri(url);
            string response = await Client.GetStringAsync(requestUri);

            //  var data = JsonConvert.DeserializeObject<MesseListe>(response);
            var data = JsonConvert.DeserializeObject<MesseListe>(response);
            Partyl = data.partylist;
           
            while (Partyl[0] == null)
            {

                wait.Visibility = Visibility.Visible;
            }

            for (int i = 0; i < Partyl.Count; i++)
            {
                Partyl[i].dateStart = Partyl[i].dateStart.Substring(0, 10);
                Partyl[i].dateEnd = Partyl[i].dateEnd.Substring(0, 10);
                if (Partyl[i].urlImageMedium == null )
                {
                    Partyl.Remove(Partyl[i]);
                }


            }
            result.Text = Partyl.Count.ToString();
            wait.Visibility = Visibility.Collapsed;
            dataItem.ItemsSource = Partyl;
        }


       

              private async void StartButton_Click(object sender, RoutedEventArgs e)
               {
            List<Partylist> Partyliste = new List<Partylist>();

           // String url = "https://www.goabase.net/api/party/json/?country=Germany&limit=9";
             String url = "https://www.goabase.net/api/party/json/?country=Germany&search=" + Searchtext.Text + "&limit=20";

            Windows.Web.Http.HttpClient Client = new Windows.Web.Http.HttpClient();
                   Uri requestUri = new Uri(url);
                   string response = await Client.GetStringAsync(requestUri);

                 //  var data = JsonConvert.DeserializeObject<MesseListe>(response);
                   var data= JsonConvert.DeserializeObject<MesseListe>(response);
            Partyl = data.partylist;
            Partyliste = data.partylist;
            while (Partyl[0] == null)
                   {
                       
                       wait.Visibility = Visibility.Visible;
                   }
           
                for (int i=0;i< Partyl.Count;i++)
                       {
                Partyl[i].dateStart=Partyl[i].dateStart.Substring(0, 10);
                Partyl[i].dateEnd = Partyl[i].dateEnd.Substring(0, 10);
                if (Partyl[i].urlImageMedium == null)
                {
                    Partyl.Remove(Partyl[i]);
                }

                   
                    }
            result.Text = Partyl.Count.ToString();
            wait.Visibility = Visibility.Collapsed;
              dataItem.ItemsSource = Partyl;

               }


        private async void GridView_ItemClickAsync(object sender, ItemClickEventArgs e)
        {
            var selectParty = (Partylist)e.ClickedItem;
            Paneldata.Visibility = Visibility.Collapsed;
            Paneldata1.Visibility = Visibility.Collapsed;
            Panelmaps.Visibility = Visibility.Visible;
            
            title.Text = selectParty.nameParty;

            try
            {
                var locator = new Geolocator();
                locator.DesiredAccuracyInMeters = 100;
                var position = await locator.GetGeopositionAsync();
                var myPosition = new Windows.Devices.Geolocation.BasicGeoposition();
                myPosition.Latitude = Convert.ToDouble(selectParty.geoLat) ;
                myPosition.Longitude = Convert.ToDouble(selectParty.geoLon) ;
                var myPoint = new Windows.Devices.Geolocation.Geopoint(myPosition);
                await maps.TrySetViewAsync(myPoint, 12D);
                MapIcon mapIcon1 = new MapIcon();
                mapIcon1.Location = maps.Center;
                mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapIcon1.Image = mapIconStreamReference;
                mapIcon1.ZIndex = 0;
                mapIcon1.Title = selectParty.nameParty;
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

