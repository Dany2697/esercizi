using TvSeries.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TvSeries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TvSeriesPage : ContentPage
    {
        public TvSeriesPage(SerieTvModel serie)
        {
            

            InitializeComponent();

            BindingContext = serie;
        }

        public TvSeriesPage()
        {
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                outerStack.Orientation = StackOrientation.Horizontal;
                
                
                
            }
            else outerStack.Orientation = StackOrientation.Vertical;
        }


        private async void OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SeasonPage());
        }
    }
}


        







    
