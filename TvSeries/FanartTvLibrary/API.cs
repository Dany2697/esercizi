namespace FanartTv
{
  public static class API
  {
    /// <summary>
    /// The current API key
    /// </summary>
    public static string Key = "99243c8f0ad757e2bea455a3772c6e40";
    
    /// <summary>
    /// The current client_API key
    /// </summary>
    public static string cKey = "f27b17a3c3f23e5ab61ce4fd423ca9f2";

    /// <summary>
    /// The current Server
    /// </summary>
    public static string Server = "http://webservice.fanart.tv/v3/";

    /// <summary>
    /// Is an Error occurred
    /// </summary>
    public static bool ErrorOccurred = false;

    /// <summary>
    /// Error Message
    /// </summary>
    public static string ErrorMessage = string.Empty;

    private static bool _proxy;

    /// <summary>
    /// Transparent Proxy
    /// </summary>
    public static bool Proxy
    {
      get { return _proxy; }
      set
      {
        _proxy = value;  
       Server = _proxy ? "http://fanarttv.apiary-proxy.com/v3/" : "http://webservice.fanart.tv/v3/";
      }
    }

  }
}
