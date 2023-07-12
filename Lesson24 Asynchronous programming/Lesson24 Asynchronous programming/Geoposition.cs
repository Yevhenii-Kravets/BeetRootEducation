using System.Text.Json;

namespace Lesson24_Asynchronous_programming
{
    public class Geoposition
    {
        static HttpClient client = new HttpClient();

        public static async Task<(string latitude, string longitude)> GetGeopositionAsync()
        {
            using HttpResponseMessage response = await client.GetAsync("http://www.geoplugin.net/json.gp?");

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<IPInfo>(result);

            return (json.geoplugin_latitude, json.geoplugin_longitude);
        }

        private class IPInfo
        {
            public string geoplugin_request { get; set; }
            public int geoplugin_status { get; set; }
            public string geoplugin_delay { get; set; }
            public string geoplugin_credit { get; set; }
            public string geoplugin_city { get; set; }
            public string geoplugin_region { get; set; }
            public string geoplugin_regionCode { get; set; }
            public string geoplugin_regionName { get; set; }
            public string geoplugin_areaCode { get; set; }
            public string geoplugin_dmaCode { get; set; }
            public string geoplugin_countryCode { get; set; }
            public string geoplugin_countryName { get; set; }
            public int geoplugin_inEU { get; set; }
            public bool geoplugin_euVATrate { get; set; }
            public string geoplugin_continentCode { get; set; }
            public string geoplugin_continentName { get; set; }
            public string geoplugin_latitude { get; set; }
            public string geoplugin_longitude { get; set; }
            public string geoplugin_locationAccuracyRadius { get; set; }
            public string geoplugin_timezone { get; set; }
            public string geoplugin_currencyCode { get; set; }
            public string geoplugin_currencySymbol { get; set; }
            public string geoplugin_currencySymbol_UTF8 { get; set; }
            public float geoplugin_currencyConverter { get; set; }
        }
    }

}
