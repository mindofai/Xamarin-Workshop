using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EssenstialsAndMap
{
    public class GoogleMapsApiService
    {

        private const string GMapsApiKey = "<google-map-api-key-here>";
        private const string ROUTE_DIRECTION_END_POINT = "/maps/api/directions/json";

        public async Task<RouteDirectionDto> GetRouteAsync(string origin, string destination)
        {
            var client = new HttpClient();

            var request = "https://maps.googleapis.com" + ROUTE_DIRECTION_END_POINT + "?";
            request += "origin=" + origin;
            request += "&destination=" + destination;
            request += "&key=" + GMapsApiKey;

            var result = await client.GetStringAsync(request);
            var routeDirectionDto = JsonConvert.DeserializeObject<RouteDirectionDto>(result);

            return routeDirectionDto;
        }
    }
}
