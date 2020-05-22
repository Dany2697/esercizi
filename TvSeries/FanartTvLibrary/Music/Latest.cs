using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using FanartTv.Types;

namespace FanartTv.Music
{
  /// <summary>
  /// Get Images for Latest Artists
  /// </summary>
  public class Latest
  {
    
    /// <summary>
    /// API Result
    /// </summary>
    /// <param name="apiKey">Users api_key</param>
    /// <param name="clientKey"></param>
    /// <returns>List of Images for Latest Artists</returns>
    public static async Task<List<LatestArtistData>> GetLatestArtistsDataAsync()
    {
      try
      {
        List<LatestArtistData> tmp;
        API.ErrorOccurred = false;
        API.ErrorMessage = string.Empty;

      
                var json = await Helper.Json.GetJson(API.Server + "music/latest" +  "?api_key=" + API.Key);
                if (API.ErrorOccurred)
          return new List<LatestArtistData>();

        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
          var settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
          var serializer = new DataContractJsonSerializer(typeof(List<LatestArtistData>), settings);
          tmp = (List<LatestArtistData>)serializer.ReadObject(ms);
        }
        return tmp ?? new List<LatestArtistData>();
      }
      catch (Exception ex)
      {
        API.ErrorOccurred = true;
        API.ErrorMessage = ex.Message;
        return new List<LatestArtistData>();
      }
    }
  }
}
