using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using System;
using  System.Threading;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using Event.Models;
using System.Collections.Generic;

namespace Event.Views
{
    public sealed partial class MesseEvent : Page
    {
        List<Messe> messel=new List<Messe>() ;
        
        public MesseEvent()
        {
            
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            List<Messe> messel = new List<Messe>();
            this.getdata();


        }

        

        private async void getdata()
        {
            List<String> list = new List<String>();

            String url = "http://www.expodatabase.de/api/1/messen/show.php?json=1&city=paris&token=df9c447drg67zHujLiopq7774dh567sIjkzT";
          //  String url = "https://feeds.citibikenyc.com/stations/stations.json";
            //String url = "http://samples.openweathermap.org/data/2.5/weather?zip=94040,us&appid=b1b15e88fa797225412429c1c50c122a1";
            Windows.Web.Http.HttpClient Client = new Windows.Web.Http.HttpClient();
            Uri requestUri = new Uri(url);
            string response = await Client.GetStringAsync(requestUri);
           
            var data = JsonConvert.DeserializeObject<MesseListe>(response);
            messel = data.messen.messe;
            while (messel[0] == null)
            {
                messel = data.messen.messe;
                wait.Visibility = Visibility.Visible;
            }
              
            for(int i = 0; i < dataItem.Items.Count; i++)
            {
                
            }
            wait.Visibility = Visibility.Collapsed;
            dataItem.ItemsSource = messel;
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

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Messe = (Messe)e.ClickedItem;
            result.Text = Messe.title;
            
        }

       

        
    }

    
}

