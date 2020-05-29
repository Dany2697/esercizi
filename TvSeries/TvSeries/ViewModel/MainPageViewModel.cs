using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TraktNet.Objects.Get.Shows;
using TraktNet.Requests.Parameters;
using TraktNet.Responses;
using TvSeries.Model;
using TvSeries.ViewModel;
using Xamarin.Forms;

namespace TvSeries.ViewModel
{
   public  class MainPageViewModel
    {
        public ICommand MyCommand { set; get; }
        SerieTvModel serie = new SerieTvModel();
        

        public  MainPageViewModel()
        {
            MyCommand = new Command<string>(OnTapped);
        }

        public async void OnTapped(string Id)
        {

           serie = await SerieTvSeed.GetSingleTvSeriesAsync(Id);
            
            
            await Application.Current.MainPage.Navigation.PushAsync(new TvSeriesPage(serie));

        }

        public List<PageModel> SerieTvModels { get; set; }

        

        


    }
}
