using Lesson24_Asynchronous_programming;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var position = await Geoposition.GetGeopositionAsync();
        var text = await Weather.GetWeatherAsync(position.longitude, position.latitude);

        Console.WriteLine(text);
    }
}