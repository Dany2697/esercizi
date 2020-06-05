using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TvSeries.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfiloPage : ContentPage
    {
        public ProfiloPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

           
            BindingContext = await SerieTvSeed.GetInfoUserAsync();

        }
    }
}