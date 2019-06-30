using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;

namespace LoanApi.Utilities
{
    public class HttpHelper
    {
        public const string SupportedMediaType = "application/json";
        public static JsonMediaTypeFormatter JsonFormatter = new JsonMediaTypeFormatter
        {
            SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }
        };
    }
}