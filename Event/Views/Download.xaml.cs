using Event.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Event.Models;

namespace Event.Views
{
    public sealed partial class Download : Page
    {
        public Download()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        private void Langue1_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Dictionar dic = new Dictionar();
            Shell.Instance.SetMenu(dic.Arabic);
        }

        private void Langue2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Dictionar dic = new Dictionar();
            Shell.Instance.SetMenu(dic.English);
        }
    }
}

