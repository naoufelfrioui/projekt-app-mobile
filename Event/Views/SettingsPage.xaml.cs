using Event.Models;
using Event.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Event.Views
{
    public sealed partial class SettingsPage : Page
    {
        Template10.Services.SerializationService.ISerializationService _SerializationService;
        private MainPageViewModel vm;
      
        public SettingsPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            _SerializationService = Template10.Services.SerializationService.SerializationService.Json;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_SerializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }

        private void Arabic_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Dictionar dic = new Dictionar();
            Shell.Instance.SetMenu(dic.Arabic);
            this.SetValue(dic.Arabic);
            
           
           
           

        }

        private void English_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Dictionar dic = new Dictionar();
            Shell.Instance.SetMenu(dic.English);
            Settings.HorizontalContentAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            
            this.SetValue(dic.English);
            
        }



        public void SetValue(Dictionary<string, string> DictionaryEntry)
        {
            
            pageHeader.Content = DictionaryEntry["SettingspageHeader"];
            Privacystatement.Header = DictionaryEntry["Privacystatement"];
            About.Header = DictionaryEntry["About"];
            Settings.Header = DictionaryEntry["SettingsHeader"];

            UseShellDrawnBackButtonToggleSwtich.Header = DictionaryEntry["UseShellDrawnBackButtonToggleSwtichHeader"];
            UseShellDrawnBackButtonToggleSwtich.OffContent = DictionaryEntry["UseShellDrawnBackButtonToggleSwtichOffContent"];
            UseShellDrawnBackButtonToggleSwtich.OnContent = DictionaryEntry["UseShellDrawnBackButtonToggleSwtichOnContent"];

            UseLightThemeToggleSwitch.Header = DictionaryEntry["UseLightThemeToggleSwitchHeader"];
            UseLightThemeToggleSwitch.OffContent = DictionaryEntry["UseLightThemeToggleSwitchOffContent"];
            UseLightThemeToggleSwitch.OnContent = DictionaryEntry["UseLightThemeToggleSwitchOnContent"];

            ShowHamburgerButtonToggleSwitch.Header = DictionaryEntry["ShowHamburgerButtonToggleSwitchHeader"];
            ShowHamburgerButtonToggleSwitch.OffContent = DictionaryEntry["ShowHamburgerButtonToggleSwitchOffContent"];
            ShowHamburgerButtonToggleSwitch.OnContent = DictionaryEntry["ShowHamburgerButtonToggleSwitchOnContent"];

            IsFullScreenToggleSwitch.Header = DictionaryEntry["IsFullScreenToggleSwitchHeader"];
            IsFullScreenToggleSwitch.OffContent = DictionaryEntry["IsFullScreenToggleSwitchOffContent"];
            IsFullScreenToggleSwitch.OnContent = DictionaryEntry["IsFullScreenToggleSwitchOnContent"];

            languages.Text = DictionaryEntry["languages"];
            English.Text = DictionaryEntry["English"];
            Arabic.Text = DictionaryEntry["Arabic"];

            BusyTextTextBox.Header = DictionaryEntry["BusyTextTextBox"];
            ShowBusyButton.Content = DictionaryEntry["ShowBusyButton"];
        }
    }
}
