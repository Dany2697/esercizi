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
using Xamarin.Forms.Internals;
using TvSeries.Model;
using System.Diagnostics;
using TraktNet.Objects.Get.Seasons;
using System.Net.Http;
using System.Net;

namespace TvSeries
{
    public static class SerieTvSeed
    {
        public static TraktClient client = new TraktClient("2c91116b65ac7df04fc5d024d203456bde61a9be5ef2a3437ec975f372009614");

        public static TVDB tvdb = new TVDB("b88ab70eb1e17a369cbe5f494f30cb9c");






        public static async Task<List<PageModel>> GetTopTenAsync()
        {




            List<PageModel> tempList = new List<PageModel>();

            List<SerieTvModel> lista = new List<SerieTvModel>();

            TraktPagedResponse<ITraktTrendingShow> trendingShowsTop10 = await client.Shows.GetTrendingShowsAsync(new TraktExtendedInfo().SetFull());



            foreach (ITraktTrendingShow trendingShow in trendingShowsTop10)
            {
                
                    var showImages = await tvdb.GetShow((int)trendingShow.Ids.Tvdb);
                
               
                

                    lista.Add(new SerieTvModel
                    {

                        Id = trendingShow.Ids.Slug,
                        ImagePath = showImages.Poster.AbsoluteUri.Replace("http", "https") 


                    });

                if (lista.Count == 4)
                {
                    tempList.Add(new PageModel(lista));
                    lista = new List<SerieTvModel>();
                }

            }
                

                

            
                if (lista.Count < 4 && lista.Count > 0)
                {
                    tempList.Add(new PageModel(lista));
                }


            return tempList;


        }




        public static async Task<SerieTvModel> GetSingleTvSeriesAsync(string Id)
        {



            var show =  client.Shows.GetShowAsync(Id, new TraktExtendedInfo().SetFull());  
            var seasons = client.Seasons.GetAllSeasonsAsync(Id, new TraktExtendedInfo().SetEpisodes().SetFull());
            
            
            await Task.WhenAll(show, seasons);

            var showInfo = show.Result.Value;
            var showImages = await tvdb.GetShow((int)showInfo.Ids.Tvdb);
            
           
            
            var listSeason = new List<SeasonModel>();
            var listEpisode = new List<EpisodeModel>();
            foreach(var season in seasons.Result.Value)
            {
                foreach(var episode in season.Episodes)
                {
                   
                    listEpisode.Add(new EpisodeModel
                    {
                       
                        Title = episode.Title,
                        Overview = episode.Overview,
                        Number = episode.Number,
                        Aired = episode.FirstAired,
                        Runtime = episode.Runtime,
                        Season = episode.SeasonNumber,
                        Show = Id
                    });
                }
                

                listSeason.Add(new SeasonModel
                {
                    Title = season.Title,
                    Episodes = listEpisode,
                    
                    
                });
                listEpisode = new List<EpisodeModel>();
            }
           

            SerieTvModel serieTvModel = new SerieTvModel()
            {
                Title = showInfo.Title,
                Description = showInfo.Overview,
                Year = showInfo.Year.ToString(),
                ImagePath = showImages.Poster.AbsoluteUri.Replace("http", "https"),
                Genres = showInfo.Genres,
                Seasons = listSeason,
                

            };

            return serieTvModel;
        }

        public static async Task<ProfiloModel> GetInfoUserAsync()
        {
            TraktResponse<ITraktUser> traktUser = await client.Users.GetUserProfileAsync("me", new TraktExtendedInfo().SetFull());

            var userInfo = traktUser.Value;

            ProfiloModel profiloModel = new ProfiloModel()
            {
                Nome = userInfo.Name,
                Username = userInfo.Username,
                Citta = userInfo.Location,
                Eta = userInfo.Age,
                

            };
            return profiloModel;
        }


    }
}
