using System;
using System.Net.Http;

using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections.Generic;
using MyLoadMore.Models;

namespace MyLoadMore.Helpers
{
   public static class JsonService
    {
        static YoutubeBean result;

        public async static Task<YoutubeBean> CallPost(UserBean userbean, int pageIndex, int pageSize)
        {
            const string kUrl = "http://codemobiles.com/adhoc/youtubes/index.php";

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("username", userbean.Username));
            postData.Add(new KeyValuePair<string, string>("password", userbean.Password));
            postData.Add(new KeyValuePair<string, string>("page", "" + pageIndex));
            postData.Add(new KeyValuePair<string, string>("size", "" + pageSize));

            var content = new System.Net.Http.FormUrlEncodedContent(postData);

            var client = new HttpClient();
            var response = await client.PostAsync(kUrl, content);
            var msg = response.Content.ReadAsStringAsync().Result;
            result = JObject.Parse(msg).ToObject<YoutubeBean>();
            return result;

        }



        public async static Task<YoutubeBean> CallGet()
        {
            var http = new HttpClient();
            var text = await http.GetStringAsync("http://codemobiles.com/adhoc/youtubes");
            var main = JObject.Parse(text).ToObject<YoutubeBean>();

            return main;
        }


    }
}
