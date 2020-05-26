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
using TVDBSharp;

namespace TvSeries
{
    public static class SerieTvSeed
    {
        public static TraktClient client = new TraktClient("2c91116b65ac7df04fc5d024d203456bde61a9be5ef2a3437ec975f372009614");

        public static TVDB tvdb = new TVDB("b88ab70eb1e17a369cbe5f494f30cb9c");

        public static TVDBSharp.Models.Show showImages = new TVDBSharp.Models.Show();




        public static async Task<List<SerieTvModel>> GetTopTen()
        {
            

            

            List<SerieTvModel> tempList = new List<SerieTvModel>();

            List<string> images = new List<string>();
            
            TraktPagedResponse<ITraktTrendingShow> trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo().SetFull());

           

            foreach (ITraktTrendingShow trendingShow in trendingShowsTop10)
            {
                
                  showImages = await tvdb.GetShow((int)trendingShow.Ids.Tvdb);
                

                
                tempList.Add(new SerieTvModel
                {
                    Title = trendingShow.Title,
                    Id = trendingShow.Ids.Slug,
                    ImagePath = showImages.Poster.AbsoluteUri.Replace("http", "https")


                }); 



            }

            return tempList;
              


        }

            


    public static async Task<SerieTvModel> GetSingleTvSeries(string Id)
        {



            TraktResponse<ITraktShow> show = await client.Shows.GetShowAsync(Id, new TraktExtendedInfo().SetFull());
            var showInfo = show.Value;
            try { 
             showImages = await tvdb.GetShow((int)showInfo.Ids.Tvdb);
             }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

        SerieTvModel serieTvModel = new SerieTvModel()
            {
                Title = showInfo.Title,
                Description = showInfo.Overview,
                Year = showInfo.Year.ToString(),
               // ImagePath = showImages.Poster.AbsoluteUri.Replace("http", "https"),
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
