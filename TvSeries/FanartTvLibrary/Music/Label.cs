using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using FanartTv.Types;

namespace FanartTv.Music
{
  /// <summary>
  /// Get Images for Label
  /// </summary>
  public class Label
  {
    
    /// <summary>
    /// API Result
    /// </summary>
    /// <param name="mbId">Labels musicbrainz id</param>
    /// <param name="apiKey">Users api_key</param>
    /// <returns>List of Images for a Label</returns>
    /// <param name="clientKey">Users client_key</param>
    public  static async Task<LabelData> GetLabelDataAsync(string mbId)
    {
      try
      {
        LabelData tmp;
        API.ErrorOccurred = false;
        API.ErrorMessage = string.Empty;


                var json = await Helper.Json.GetJson(API.Server + "music/labels/" + mbId + "?api_key=" + API.Key);
                if (API.ErrorOccurred)
          return new LabelData();

        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
          var settings = new DataContractJsonSerializerSettings {UseSimpleDictionaryFormat = true};
          var serializer = new DataContractJsonSerializer(typeof (LabelData), settings);
          tmp = (LabelData) serializer.ReadObject(ms);
        }
        return tmp ?? new LabelData();
      }
      catch (Exception ex)
      {
        API.ErrorOccurred = true;
        API.ErrorMessage = ex.Message;
        return new LabelData();
      }
    }
  }
}