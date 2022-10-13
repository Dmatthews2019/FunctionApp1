using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;

namespace FunctionApp1.Extensions
{
    public static class ParsingExtension
    {
        public static T ParseJsonToObject<T>(this string body) {
            return JsonConvert.DeserializeObject<T>(body);
        }

        public static string ConvertToString(this Stream body)
        {
            Stream s = new MemoryStream();
            StreamReader sr = new StreamReader(s);
            s.Position = 0;
            sr.DiscardBufferedData();
            return new StreamReader(body).ReadToEnd();
        }

        public static string GetRequestBodyAsString(this HttpRequest req)
        {
            return req.Body.ConvertToString();
        }
    }
}
