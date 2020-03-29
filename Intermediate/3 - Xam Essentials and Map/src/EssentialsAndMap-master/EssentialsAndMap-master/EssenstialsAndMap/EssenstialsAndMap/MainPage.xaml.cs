using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace EssenstialsAndMap
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ReadDescription(object sender, EventArgs e)
        {
            TextToSpeech.SpeakAsync(description.Text, default);
        }

        private void CallContactNumber(object sender, EventArgs e)
        {
            PhoneDialer.Open(contactNumber.Text);
        }

        private async void SeeDirections(object sender, EventArgs e)
        {
            map.Pins.Clear();

            var myLocation = await Geolocation.GetLocationAsync();
            var storeLocation = await Geocoding.GetLocationsAsync(storeAddress.Text);

            var storePosition = new Position(storeLocation.FirstOrDefault().Latitude,
                storeLocation.FirstOrDefault().Longitude);

            var result = await GetRoute(
                $"{myLocation.Latitude},{myLocation.Longitude}",
                "14.560858,121.0164527");

            DrawRoute(result);

            map.MoveToRegion(new MapSpan(storePosition, 0.01, 0.01));

            //Map.OpenAsync(storeLocation.FirstOrDefault());
        }

        public async Task<RouteDirectionDto> GetRoute(string origin, string destination)
        {
            var gMapService = new GoogleMapsApiService();

            return await gMapService.GetRouteAsync(origin, destination);
        }

        private async void DrawRoute(RouteDirectionDto routeDirectionDto)
        {
            map.Pins.Clear();
            map.MapElements.Clear();

            var steps = ProcessRouteResult(routeDirectionDto);

            Xamarin.Forms.Maps.Polyline polyline = new Xamarin.Forms.Maps.Polyline()
            {
                StrokeWidth = 6,
                StrokeColor = Color.FromHex("#1BA1E2")
            };

            foreach (var coordinates in steps)
            {
                var position = new Position(coordinates.Latitude, coordinates.Longitude);
                polyline.Geopath.Add(position);
            }

            map.MapElements.Add(polyline);

            map.Pins.Add(new Pin()
            {
                Position = polyline.Geopath.First(),
                Label = "Origin",
                Type = PinType.SavedPin
            });

            map.Pins.Add(new Pin()
            {
                Position = polyline.Geopath.Last(),
                Label = "Destination",
                Type = PinType.SavedPin
            });

        }

        private List<Location> ProcessRouteResult(RouteDirectionDto result)
        {
            var routeCoordinates = GooglePolylineConverter.Decode(result.routes.FirstOrDefault().overview_polyline.points.ToString()).ToList();

            return routeCoordinates;
        }
    }
}
