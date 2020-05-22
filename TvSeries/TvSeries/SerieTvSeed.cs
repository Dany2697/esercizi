using System.Collections.Generic;
using System.Threading.Tasks;
using TraktNet;
using TraktNet.Objects.Get.Shows;
using TraktNet.Objects.Get.Users;
using TraktNet.Requests.Parameters;
using TraktNet.Responses;
using FanartTv;
using FanartTv.TV;
using System;
using System.Linq;
using FanartTv.Types;

namespace TvSeries
{
    public static class SerieTvSeed
    {
        public static TraktClient client = new TraktClient("2c91116b65ac7df04fc5d024d203456bde61a9be5ef2a3437ec975f372009614");

        

        
        
        

        public static async Task<List<SerieTvModel>> GetTopTen()
        {
            

                List<SerieTvModel> tempList = new List<SerieTvModel>();

            
            TraktPagedResponse<ITraktTrendingShow> trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo().SetFull());

            

            foreach (ITraktTrendingShow trendingShow in trendingShowsTop10)
            {
                TvData showImages = await Show.GetShowImagesAsync(trendingShow.Ids.Tvdb.ToString());
               


                tempList.Add(new SerieTvModel 
                {
                    Title = trendingShow.Title,
                     Id = trendingShow.Ids.Slug,
                     ImagePath = showImages.Tvposter[0].Url.Replace("/fanart","/preview")


                });

              

            }
           


            return tempList;
            


        }

            


    public static async Task<SerieTvModel> GetSingleTvSeries(string Id)
        {



            TraktResponse<ITraktShow> show = await client.Shows.GetShowAsync(Id, new TraktExtendedInfo().SetFull());
            var showInfo = show.Value;

            TvData showImages = await Show.GetShowImagesAsync(showInfo.Ids.Tvdb.ToString());

            SerieTvModel serieTvModel = new SerieTvModel()
            {
                Title = showInfo.Title,
                Description = showInfo.Overview,
                Year = showInfo.Year.ToString(),
                ImagePath = showImages.Tvposter[0].Url.Replace("/fanart", "/preview"),
                Genres = showInfo.Genres
               
            };

            return serieTvModel;
        }

        public static async Task<ProfiloModel> GetInfoUser()
        {
            TraktResponse<ITraktUser> traktUser = await client.Users.GetUserProfileAsync("me", new TraktExtendedInfo().SetFull());
            
            var userInfo = traktUser.Value;

            ProfiloModel profiloModel = new ProfiloModel()
            {
                Nome = userInfo.Name,
                Username = userInfo.Username,
                Citta = userInfo.Location
            };
            return profiloModel;
        }

       
    }
}
