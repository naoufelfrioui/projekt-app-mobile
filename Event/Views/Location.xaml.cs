using Event.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Popups;
using System;
using Windows.System;
using System.Globalization;
using System.Resources;
using Newtonsoft.Json;
using Event.Models;
using System.Collections.Generic;
using Template10.Services.NavigationService;

namespace Event.Views
{
    public sealed partial class Location : Page
    {

        public Here messe { get; set; }
        public Location()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
           
            this.Get_Position();
        }
            private async void Get_Position()
        {
            
            try
            {              
                var locator = new Geolocator();
                locator.DesiredAccuracyInMeters =80;
                var position = await locator.GetGeopositionAsync();
                var myPosition = new Windows.Devices.Geolocation.BasicGeoposition();
                myPosition.Latitude = 52.52464 ;
                myPosition.Longitude = 13.40514;
                var myPoint = new Windows.Devices.Geolocation.Geopoint(myPosition);
                await maps.TrySetViewAsync(myPoint, 18D);
                MapIcon mapIcon1 = new MapIcon();
                mapIcon1.Location = myPoint;
                mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapIcon1.ZIndex = 0;
                mapIcon1.Title = "";
                maps.MapElements.Add(mapIcon1);

                  maps.MapElements.Add(mapIcon1);

            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.ToString());
                await dialog.ShowAsync();
            }
        }

       
        
    }
}

