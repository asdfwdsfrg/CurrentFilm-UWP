using CurrentFilm.Models;
using CurrentFilm.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace CurrentFilm.Services
{
    public static class HttpServices
    {
        public static string ipLocationApiUri = "http://restapi.amap.com/v3/ip?key=52f41ecb8481df329c89b0e2cfbaf0c4";
        //高德地图APi
        public static string doubanRecentFilmApiUri = "http://api.douban.com/v2/movie/in_theaters?apikey=0b2bdeda43b5688921839c8ecb20399b";
        //豆瓣Api ： 正在热映
        public static string doubanComingFilmApiUri = "http://api.douban.com/v2/movie/coming_soon?apikey=0b2bdeda43b5688921839c8ecb20399b";
        //豆瓣Api ： 即将上映
        public static string searchMapApiUri = "http://restapi.amap.com/v3/place/text?parameters";
        //关键字搜索   keywords/
        public static string doubanCinemaApiUri = "http://api.douban.com//v2/movie/cinemas/nearby?apikey=0b2bdeda43b5688921839c8ecb20399b&start=0&count=9";
        //豆瓣电影附近影院api
        public static async Task<string> SendGetRequestAsync(string uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(uri);
            return await responseMessage.Content.ReadAsStringAsync();
        }
        public static async Task<Models.Film> GetRecentFilmAsync(int current, int need)
        {
            Models.Film data = new Film();
            try
            {
                //CoordinateString longAndLat = await LocationService.GetLoction();
               // string city = await LocationService.GetCity();
                Dictionary<string, string> paramaters = new Dictionary<string, string>();
               // if (longAndLat != null && city != null)
                {
                    paramaters.Add("start", current.ToString());
                  //  paramaters.Add("city", city);
                    paramaters.Add("count", need.ToString());
                }
                string uri = UriBuilder.BuildUri(doubanRecentFilmApiUri, paramaters);
                string x = await SendGetRequestAsync(uri);
                data = Service.JsonToObject.DataContract<Models.Film>(x);
            }
            catch
            {
                throw new InvalidOperationException("Can't get data");
            }
            return data;         
         }
        public static async Task<Models.Film> GetComingFilmAsync(int current, int need)
        {
            Models.Film data = new Film();
            try
            {
                //CoordinateString longAndLat = await LocationService.GetLoction();
                // string city = await LocationService.GetCity();
                Dictionary<string, string> paramaters = new Dictionary<string, string>();
                // if (longAndLat != null && city != null)
                {
                    paramaters.Add("start", current.ToString());
                    //  paramaters.Add("city", city);
                    paramaters.Add("count", need.ToString());
                }
                string uri = UriBuilder.BuildUri(doubanComingFilmApiUri, paramaters);
                string x = await SendGetRequestAsync(uri);
                data = Service.JsonToObject.DataContract<Models.Film>(x);
            }
            catch
            {
                throw new InvalidOperationException("Can't get data");
            }
            return data;
        }
    }
}
