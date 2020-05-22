﻿using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FanartTv.Helper
{
  /// <summary>
  /// Download the Url to String
  /// </summary>
  public class Json
  {
    /// <summary>
    /// Url to String
    /// </summary>
    /// <param name="url">The Url of the Website</param>
    /// <returns>Jsonstring</returns>
    public static async Task<string> GetJson(string url)
    {
      try
      {
        API.ErrorOccurred = false;
        API.ErrorMessage = string.Empty;

        WebRequest request = WebRequest.Create(url);
        request.Proxy = WebRequest.DefaultWebProxy;
        request.Credentials = CredentialCache.DefaultCredentials;
        request.Proxy.Credentials = CredentialCache.DefaultCredentials;
       WebResponse response = await request.GetResponseAsync();
        var reader = new StreamReader(response.GetResponseStream());
        return reader.ReadToEnd();
      }
      catch (Exception ex)
      {
        API.ErrorOccurred = true;
        API.ErrorMessage = ex.Message;
        return "";
      }
    }
  }
}
