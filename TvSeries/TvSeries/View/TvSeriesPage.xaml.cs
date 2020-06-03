using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using TraktNet.Objects.Get.Episodes;
using TraktNet.Objects.Get.Syncs.Activities;
using TvSeries.Model;
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

      

        
        private  void SeasonPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            var season = (SeasonModel)SePicker.SelectedItem;
            EpPicker.IsEnabled = true;
            EpPicker.ItemsSource = season.Episodes;
            
        }

        private async void EpisodePickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            var episode = (ITraktEpisode)EpPicker.SelectedItem;
            
            if (episode != null)
            await Navigation.PushAsync(new EpisodePage(episode));
           

        }
    }
}


        







    
