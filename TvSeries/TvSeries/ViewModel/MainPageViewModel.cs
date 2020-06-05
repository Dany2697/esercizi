using System;
using System.Collections.Generic;
using System.Windows.Input;
using TvSeries.Model;
using TvSeries.View;
using Xamarin.Forms;

namespace TvSeries.ViewModel
{
   public  class MainPageViewModel
    {
        public ICommand MyCommand { set; get; }
        public INavigation Navigation { get; set; }
        SerieTvModel serie = new SerieTvModel();
        
        

        public  MainPageViewModel()
        {
            
            MyCommand = new Command<string>(OnTapped);
        }

        public async void OnTapped(string Id)
        {
            
           serie = await SerieTvSeed.GetSingleTvSeriesAsync(Id);

            await Navigation.PushAsync(new TvSeriesPage(serie));
          
            
        }

       

        public List<PageModel> SerieTvModels { get; set; }

        

        


    }
}
