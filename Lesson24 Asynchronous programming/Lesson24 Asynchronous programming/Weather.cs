using System.Text;
using System.Text.Json;

namespace Lesson24_Asynchronous_programming
{
    public class Weather
    {
        static HttpClient client = new HttpClient();

        public static async Task<string> GetWeatherAsync(string longitude, string latitude)
        {
            using HttpResponseMessage response = await client.GetAsync("http://www.7timer.info/bin/api.pl?" +
                                                                       $"lon={longitude}&lat={latitude}" +
                                                                       "&product=civillight" +
                                                                       "&output=json");
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<WeatherInfoCivillight>(result);

            string res = "";
            foreach (var dates in json.dataseries) 
            {
                var validDate = new StringBuilder(dates.date.ToString()).Insert(4, ".").Insert(7, ".");
                res += $"Date: {validDate}\n" +
                    $"Weather: {dates.weather}\n" +
                    $"Wind up to: {dates.wind10m_max}m/s\n" +
                    $"Temperature min: {dates.temp2m.min}C, max: {dates.temp2m.max}C\n\n";
            }
            return res;
        }

        private class WeatherInfoCivillight
        {
            public string product { get; set; }
            public string init { get; set; }
            public List<DataSeries> dataseries { get; set; }

            public class DataSeries
            {
                public int date { get; set; }
                public string weather { get; set; }
                public Temperature temp2m { get; set; }
                public int wind10m_max { get; set; }

                public class Temperature
                {
                    public int max { get; set; }
                    public int min { get; set; }
                }
            }
        }
    }
}