using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace backend.Controllers
{
    [Route("api/iss")]
    [ApiController]
    public class IssController : ControllerBase
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        // GET /api/iss/iss-location
        [HttpGet("iss-location")]
        public async Task<IActionResult> GetIssLocation()
        {
            try
            {
                // 1. Get ISS Location from Open Notify API
                var response = await _httpClient.GetStringAsync("http://api.open-notify.org/iss-now.json");
                var issData = JsonConvert.DeserializeObject<dynamic>(response);

                // 2. Extract latitude and longitude
                double issLat = double.Parse(issData.iss_position.latitude.ToString());
                double issLon = double.Parse(issData.iss_position.longitude.ToString());

                // 3. Seattle coordinates
                double seattleLat = 47.6062;
                double seattleLon = -122.3321;

                // 4. Calculate the distance from Seattle to the ISS
                double distanceToSeattle = CalculateDistance(seattleLat, seattleLon, issLat, issLon);

                // 5. Return the response as JSON
                return Ok(new
                {
                    issLocation = new { latitude = issLat, longitude = issLon },
                    seattleLocation = new { lat = seattleLat, lon = seattleLon },
                    distanceToSeattle = distanceToSeattle
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "Failed to get ISS location", error = ex.Message });
            }
        }

        // Function to calculate distance between two points using Haversine formula
        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double toRadians(double degrees) => degrees * (System.Math.PI / 180);

            double R = 6371; // Radius of Earth in km
            double dLat = toRadians(lat2 - lat1);
            double dLon = toRadians(lon2 - lon1);
            double a = 
                System.Math.Sin(dLat / 2) * System.Math.Sin(dLat / 2) +
                System.Math.Cos(toRadians(lat1)) * System.Math.Cos(toRadians(lat2)) *
                System.Math.Sin(dLon / 2) * System.Math.Sin(dLon / 2);
            
            double c = 2 * System.Math.Atan2(System.Math.Sqrt(a), System.Math.Sqrt(1 - a));
            double distance = R * c; // Distance in km

            return distance;
        }
    }
}