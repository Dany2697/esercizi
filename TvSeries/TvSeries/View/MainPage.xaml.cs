using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Essentials;
using System;
using TvSeries.ViewModel;
using TvSeries.View;
using System.Collections.Generic;

namespace TvSeries
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        

        MainPageViewModel mainPageViewModel = new MainPageViewModel();

        

        public MainPage() 
        {
            InitializeComponent();
            mainPageViewModel.Navigation = Navigation;
        }
        protected override async void OnAppearing()
        {
            
            base.OnAppearing();
           
            mainPageViewModel.SerieTvModels = await SerieTvSeed.GetTopTenAsync();
            BindingContext = mainPageViewModel;
            

        }
        
       
      /*  private async void Accedi_Clicked(object sender, EventArgs e)
        {
            if (SerieTvSeed.client.Authentication.IsAuthorized == false)
            {

                try { 
            var authResult = await WebAuthenticator.AuthenticateAsync(
        new Uri("https://trakt.tv/oauth/authorize?response_type=code&client_id=2c91116b65ac7df04fc5d024d203456bde61a9be5ef2a3437ec975f372009614&redirect_uri=mytraktapp%3A%2F%2Foauth2redirect"),
        new Uri("mytraktapp://oauth2redirect"));

            
                var code = authResult.Properties["code"];

                

                await SerieTvSeed.client.Authentication.GetAuthorizationAsync(code, "2c91116b65ac7df04fc5d024d203456bde61a9be5ef2a3437ec975f372009614", "7a29cf906bd27b8991ed7baaacdf88de70510e98c269b7a01c7b2a7b60e3c54f", "mytraktapp://oauth2redirect");
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
 
            } else await Navigation.PushAsync(new ProfiloPage());

        } */

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if(height > width)
            {
                
                
            } 
        }

        
    }
}
