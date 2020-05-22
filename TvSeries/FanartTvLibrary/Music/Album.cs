using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using FanartTv.Types;

namespace FanartTv.Music
{
  /// <summary>
  /// Get Images for Album
  /// </summary>
  public class Album
  {
    

    /// <summary>
    /// API Result
    /// </summary>
    /// <param name="mbId">Albums musicbrainz release-group id</param>
    /// <param name="apiKey">Users api_key</param>
    /// <param name="clientKey">Users client_key</param>
    /// <returns>List of Images for a Album</returns>
    public static async Task <AlbumData> GetAlbumDataAsync(string mbId)
    {
      try
      {
        AlbumData tmp;
        API.ErrorOccurred = false;
        API.ErrorMessage = string.Empty;

       
                var json = await Helper.Json.GetJson(API.Server + "music/albums/" + mbId + "?api_key=" + API.Key);
                if (API.ErrorOccurred)
          return new AlbumData();

        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
          var settings = new DataContractJsonSerializerSettings {UseSimpleDictionaryFormat = true};

          var serializer = new DataContractJsonSerializer(typeof(AlbumData), settings);
          tmp = (AlbumData)serializer.ReadObject(ms);
        }
        return tmp ?? new AlbumData();
      }
      catch (Exception ex)
      {
        API.ErrorOccurred = true;
        API.ErrorMessage = ex.Message;
        return new AlbumData();
      }
    }
  }
}
