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
                Show showImage = new Show(trendingShow.Ids.Tvdb.ToString(), API.Key, API.cKey);
               


                tempList.Add(new SerieTvModel 
                {
                    Title = trendingShow.Title,
                     Id = trendingShow.Ids.Slug,
                     ImagePath = showImage.List.Tvposter[0].Url


                });

              

            }
           


            return tempList;
            


        }

            


    public static async Task<SerieTvModel> GetSingleTvSeries(string Id)
        {



            TraktResponse<ITraktShow> show = await client.Shows.GetShowAsync(Id, new TraktExtendedInfo().SetFull());
            var showInfo = show.Value;

            Show showImage = new Show(showInfo.Ids.Tvdb.ToString(), API.Key, API.cKey);

            SerieTvModel serieTvModel = new SerieTvModel()
            {
                Title = showInfo.Title,
                Description = showInfo.Overview,
                Year = showInfo.Year.ToString(),
                ImagePath = showImage.List.Tvposter[0].Url,
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
