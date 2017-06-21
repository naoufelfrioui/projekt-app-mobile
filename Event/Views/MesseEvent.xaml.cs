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
        


        }

        

      

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Messe = (Messe)e.ClickedItem;
            result.Text = Messe.title;
            
        }

       

        
    }

    
}

