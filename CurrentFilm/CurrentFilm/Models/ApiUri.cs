using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentFilm.Models
{
    public static class ApiUri
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
    }
}
