using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using FanartTv.Types;

namespace FanartTv.TV
{
  /// <summary>
  /// Get images for Latest Shows
  /// </summary>
  public class Latest
  {
    
    /// <summary>
    /// API Result
    /// </summary>
    /// <param name="apiKey">Users api_key</param>
    /// <param name="clientKey">Users client_key</param>
    /// <returns>List of images for Latest Shows</returns>
    public static async Task<List<TvLatest>> GetTvLatestsAsync()
    {
      try
      {
        List<TvLatest> tmp;
        API.ErrorOccurred = false;
        API.ErrorMessage = string.Empty;

       
                var json = await Helper.Json.GetJson(API.Server + "tv/latest" +  "?api_key=" + API.Key);
                if (API.ErrorOccurred)
          return new List<TvLatest>();

        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
          var settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
          var serializer = new DataContractJsonSerializer(typeof(List<TvLatest>), settings);
          tmp = (List<TvLatest>)serializer.ReadObject(ms);
        }
        return tmp ?? new List<TvLatest>();
      }
      catch (Exception ex)
      {
        API.ErrorOccurred = true;
        API.ErrorMessage = ex.Message;
        return new List<TvLatest>();
      }
    }
  }
}
