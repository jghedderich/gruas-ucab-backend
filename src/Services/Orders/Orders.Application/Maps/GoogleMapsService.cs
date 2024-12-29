using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Orders.Application.Maps
{
    public class GoogleMapsService(HttpClient httpClient, IConfiguration configuration)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _apiKey = configuration["GoogleMaps:ApiKey"];

        public async Task<double> GetDistanceAsync(CoordinatesDto origin, CoordinatesDto destination)
        {
            var parsedOrigin = $"{origin.Latitude},{origin.Longitude}";
            var parsedDestination = $"{destination.Latitude},{destination.Longitude}";

            var requestUri = $"https://maps.googleapis.com/maps/api/directions/json?" +
                             $"origin={parsedOrigin}&destination={parsedDestination}&key={_apiKey}";

            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var json = JObject.Parse(await response.Content.ReadAsStringAsync());

            // Accessing the distance from the directions API response
            var distance = json["routes"]?[0]?["legs"]?[0]?["distance"]?["value"]?.ToObject<double>();

            return distance.HasValue ? distance.Value / 1000.0 : 0.0; // Convert to kilometers.
        }

    }
}    

