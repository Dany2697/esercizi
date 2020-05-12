using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;

namespace TvSeries
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            accedi.Clicked += accedi_Clicked;

        }
        
        private async void accedi_Clicked(object sender, EventArgs e)
        {
            var authResult = await WebAuthenticator.AuthenticateAsync(
        new Uri("https://trakt.tv/oauth/authorize?response_type=code&client_id=%202c91116b65ac7df04fc5d024d203456bde61a9be5ef2a3437ec975f372009614&redirect_uri=%20mytraktapp%3A%2F%2Foauth2redirect"),
        new Uri("mytraktapp://oauth2redirect"));

            var accessToken = authResult?.AccessToken;
            
            
        }
        void OnImageTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TvSeriesPage());
        }
    }
}
