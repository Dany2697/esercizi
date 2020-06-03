using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraktNet.Objects.Get.Episodes;
using TvSeries.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TvSeries.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EpisodePage : ContentPage
    {
        public EpisodePage(ITraktEpisode episode)
        {
            InitializeComponent();

            BindingContext = episode;
        }

       
    }
}