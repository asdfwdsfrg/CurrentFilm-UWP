using CurrentFilm.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrentFilm.Models;

namespace CurrentFilm.Services
{
    public static class LocationService
    {
        public static async Task<CoordinateString> GetLoction()
        {
            string LocJson = await HttpServices.SendGetRequestAsync(HttpServices.ipLocationApiUri);
            string Loc = JsonToObject.DataContract<Location>(LocJson).rectangle;
            char[] splitChars = { ',', ';' };
            string[] splitedLoc = Loc.Split(splitChars);
            CoordinateString coordinate = new CoordinateString();
            coordinate.longtitude = splitedLoc[0];
            coordinate.latitude = splitedLoc[1];
            return coordinate;
        }
        public static async Task<string> GetCity()
        {
            string LocJson = await HttpServices.SendGetRequestAsync(HttpServices.ipLocationApiUri);
            string LocCity = JsonToObject.DataContract<Location>(LocJson).city;
            int x = LocCity.LastIndexOf('市');
            return LocCity.Remove(x);
        }
    }
}
