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

namespace Event.Views
{
    public sealed partial class Events : Page
    {
        List<String> sourcelist = new List<String>();
        public Events()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            this.getdata();
        }

        private async void getdata()
        {
           

            String url = "http://www.expodatabase.de/api/1/messen/show.php?json=1&city=paris&token=df9c447drg67zHujLiopq7774dh567sIjkzT";
            //  String url = "https://feeds.citibikenyc.com/stations/stations.json";
            //String url = "http://samples.openweathermap.org/data/2.5/weather?zip=94040,us&appid=b1b15e88fa797225412429c1c50c122a1";
            Windows.Web.Http.HttpClient Client = new Windows.Web.Http.HttpClient();
            Uri requestUri = new Uri(url);
            string response = await Client.GetStringAsync(requestUri);
            var data = JsonConvert.DeserializeObject<MesseListe>(response);
         
            for (int i = 0; i < data.messen.messe.Count; i++)
            {
                sourcelist.Add(data.messen.messe[i].title);
            }
            Mymesselist.ItemsSource = sourcelist;
                // json.Text = data.main.temp.ToString();
                //json.Text = data.stationBeanList[1].stationName;


                /* for (int i = 0; i < data.messen.messe.Count; i++)
                 {
                     String ch = data.messen.messe[i].title + "\n"
                         + data.messen.messe[i].messelink + "\n"
                         + data.messen.messe[i].messe_country + "\n"
                         + data.messen.messe[i].messe_state + "\n"
                          + data.messen.messe[i].messelink + "\n"
                         + data.messen.messe[i].messe_typ + "\n";
                     list.Add(ch);
                 }
                */
            }

    }
}

