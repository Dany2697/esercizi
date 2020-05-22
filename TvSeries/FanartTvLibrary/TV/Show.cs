using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using FanartTv.Types;

namespace FanartTv.TV
{
    /// <summary>
    /// Get images for a Show
    /// </summary>
    public class Show
    {
        
       

        /// <summary>
        /// API Result
        /// </summary>
        /// <param name="theTvBbId">thetvdb id for the show.</param>
        /// <returns>List of images for a Shows</returns>
        public static async Task<TvData> GetShowImagesAsync(string theTvBbId)
        {
            try
            {
                TvData tmp;
                API.ErrorOccurred = false;
                API.ErrorMessage = string.Empty;
                
               
                 var json = await Helper.Json.GetJson(API.Server + "tv/" + theTvBbId + "?api_key=" + API.Key);

               

                if (API.ErrorOccurred)
                    return new TvData();

                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    var settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
                    var serializer = new DataContractJsonSerializer(typeof(TvData), settings);
                    tmp = (TvData)serializer.ReadObject(ms);
                }
                return tmp ?? new TvData();
            }
            catch (Exception ex)
            {
                API.ErrorOccurred = true;
                API.ErrorMessage = ex.Message;
                return new TvData();
            }
        }


    }
}


