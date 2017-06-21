using Event.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using System;
using Windows.UI.Xaml;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Event.Models;
using System.Collections.Generic;

namespace Event.Views
{
    public sealed partial class Messelist : Page
    {


        public Messelist()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
           
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            //Create an HTTP client object
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            Uri requestUri = new Uri(this.AddressField.Text);

            //Send the GET request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                //httpResponseBody
                OutputField.Text = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            // MatchCollection m1 = Regex.Matches(OutputField.Text, @"<strong\s*(.+?)\s*</strong>", RegexOptions.Singleline);
            MatchCollection m1 = Regex.Matches(OutputField.Text, "<section id=\"content\">\\s*(.+?)\\s*</section>", RegexOptions.Singleline);

            MatchCollection m2 = Regex.Matches(OutputField.Text, "<span class=\"black\">\\s*(.+?)\\s*</span>", RegexOptions.Singleline);
            foreach (Match m in m1)
            {
                if (m.Groups[1].Value != "Dates and Cities:")
                {
                    Output1.Text = Output1.Text + m.Groups[1].Value;
                }
            }
            //foreach (Match m in m2)
            // {               
            //        Output1.Text = Output1.Text + m.Groups[1].Value;

            // }
        }


        private async void getdata(object sender, RoutedEventArgs e)
        {  List<String> list = new List<String>();

            String url = "https://feeds.citibikenyc.com/stations/stations.json";
            //String url = "http://samples.openweathermap.org/data/2.5/weather?zip=94040,us&appid=b1b15e88fa797225412429c1c50c122a1";
            Windows.Web.Http.HttpClient Client = new Windows.Web.Http.HttpClient();
            Uri requestUri = new Uri(url);
            string response = await Client.GetStringAsync(requestUri);
            json.Text = response;
          //  var data = JsonConvert.DeserializeObject<RootObject>(response);
            // json.Text = data.main.temp.ToString();
            
           
        }
    }
}

