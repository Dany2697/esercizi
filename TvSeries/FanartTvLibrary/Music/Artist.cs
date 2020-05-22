using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using FanartTv.Types;

namespace FanartTv.Music
{
  /// <summary>
  /// Get Images for Artist
  /// </summary>
  public class Artist
  {
    
    /// <summary>
    /// API Result
    /// </summary>
    /// <param name="mbId">Musicbrainz id for the artist</param>
    /// <param name="apiKey">Users api_key</param>
    /// <param name="clientKey">Users client_key</param>
    /// <returns>List of Images for a Artist</returns>
    public static async Task<ArtistData> GetArtistDataAsync(string mbId)
    {
      try
      {
        ArtistData tmp;
        API.ErrorOccurred = false;
        API.ErrorMessage = string.Empty;

       
                var json = await Helper.Json.GetJson(API.Server + "music/" + mbId + "?api_key=" + API.Key);
                if (API.ErrorOccurred)
          return new ArtistData();

        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
          var settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
          var serializer = new DataContractJsonSerializer(typeof(ArtistData), settings);
          tmp = (ArtistData)serializer.ReadObject(ms);
        }
        return tmp ?? new ArtistData();
      }
      catch (Exception ex)
      {
        API.ErrorOccurred = true;
        API.ErrorMessage = ex.Message;
        return new ArtistData();
      }
    }
  }
}
