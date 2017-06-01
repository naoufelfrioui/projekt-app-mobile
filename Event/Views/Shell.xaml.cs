using System.ComponentModel;
using System.Linq;
using System;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Template10.Mvvm;
using Event.Models;
using System.Collections.Generic;

namespace Event.Views
{
    public sealed partial class Shell : Page
    {
      
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;
        Services.SettingsServices.SettingsService _settings;
        

        public Shell()
        {
            
            Instance = this;
            InitializeComponent();
            _settings = Services.SettingsServices.SettingsService.Instance;
            Dictionar dic = new Dictionar();
            this.SetMenu(dic.English);
           
        }

        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }

        public void SetMenu(Dictionary<string, string> DictionaryEntry)
        {  
            menu1.Text = DictionaryEntry["menu1"];
            menu2.Text = DictionaryEntry["menu2"];
            menu3.Text = DictionaryEntry["menu3"];
            menu4.Text = DictionaryEntry["menu4"];
            menu5.Text = DictionaryEntry["menu5"];
            SecondaryButton1.Text = DictionaryEntry["SecondaryButton1"];
            SecondaryButton2.Text = DictionaryEntry["SecondaryButton2"];
        }
        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
            HamburgerMenu.RefreshStyles(_settings.AppTheme, true);
            HamburgerMenu.IsFullScreen = _settings.IsFullScreen;
            HamburgerMenu.HamburgerButtonVisibility = _settings.ShowHamburgerButton ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

