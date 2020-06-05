using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvSeries.View;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TvSeries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMain : MasterDetailPage
    {
        public MasterDetailPageMain()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var title = (MasterDetailPageMasterMenuItem)MasterPage.ListView.SelectedItem;
            if (title != null)
            {
                switch (title.Title)
                {
                    case "Home":
                        Detail = new NavigationPage(new MainPage());
                        break;

                    case "Profile":

                        if (SerieTvSeed.client.Authentication.IsAuthorized)
                        {
                            Detail = new NavigationPage(new ProfiloPage());
                        }
                        else
                        {
                            try
                            {
                                var authResult = await WebAuthenticator.AuthenticateAsync(
                            new Uri("https://trakt.tv/oauth/authorize?response_type=code&client_id=2c91116b65ac7df04fc5d024d203456bde61a9be5ef2a3437ec975f372009614&redirect_uri=mytraktapp%3A%2F%2Foauth2redirect"),
                            new Uri("mytraktapp://oauth2redirect"));


                                var code = authResult.Properties["code"];



                                await SerieTvSeed.client.Authentication.GetAuthorizationAsync(code, "2c91116b65ac7df04fc5d024d203456bde61a9be5ef2a3437ec975f372009614", "7a29cf906bd27b8991ed7baaacdf88de70510e98c269b7a01c7b2a7b60e3c54f", "mytraktapp://oauth2redirect");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;
                }
            }
            MasterPage.ListView.SelectedItem = null;

        }







        //  Detail = new NavigationPage(new ProfiloPage());



    }
}