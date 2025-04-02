using DataServices;
using Rad302SampleExam2024.DataModel;
using Tracker.WebAPIClient;

namespace Rad302SampleExam2024.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00999995", StudentName: "Paul Powell",
                       activityName: "Rad302 Mock Exam 2025", Task: "Using Programme Schema");

            // Second Argument is null as we are not using the local storage service here
            IHttpClientService client = new HttpClientService(new HttpClient() { BaseAddress = new Uri("Https://localhost:7109") }, null);
            // Must wait for the result as Main is not async
            List<WeatherForecast> forecasts = client.getCollection<WeatherForecast>("WeatherForecast").Result;
            if (forecasts == null || forecasts.Count > 0)
            {
                foreach (var forecast in forecasts)
                {
                    // have to use full reference because of the namespace
                    System.Console.WriteLine($"Date: {forecast.Date} Temp: {forecast.TemperatureC} Summary: {forecast.Summary}");
                }
            }
            System.Console.ReadKey();
            System.Console.WriteLine("Done...");
        }
    }
}