using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB
{
    //--------------------------------------------------------------------------------------
    public static class DBConnect
    {
        //ApiKey = "9f2df9da";
        // 
        
        public static void GetResponse(string SearchType, string SearchParam, ref MovieResponse RespObj)
        {
            string url = "http://www.omdbapi.com/?t=&apikey=9f2df9da" + "&" + SearchType + "=" +SearchParam;
            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var json = webClient.DownloadString(url);
                var jsonObject = JObject.Parse(json);

                if (jsonObject["Response"].ToString() == "True")
                {
                    if (SearchType == "i")
                        RespObj = JsonConvert.DeserializeObject<Movie>(json);
                    else if (SearchType == "s")
                        RespObj = JsonConvert.DeserializeObject<SearchMovie>(json);
                }
                else 
                {
                    throw new Exception("Error: Movie not found!");
                }
               
            }
        }
    }
    //--------------------------------------------------------------------------------------
}
