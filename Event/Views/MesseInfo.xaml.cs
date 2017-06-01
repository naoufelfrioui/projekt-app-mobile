using Event.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Event.Models;

namespace Event.Views
{
    public sealed partial class MesseInfo : Page
    {
       
        public MesseInfo()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
               
    }
       public Messe Messe { get; set; }
    }
}

