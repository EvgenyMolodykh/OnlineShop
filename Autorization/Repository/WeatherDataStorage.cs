using Autorization.Enums;
using Autorization.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Autorization.Repository
{
    public class WeatherDataStorage
    {
        public static List<DayForecastModel> GetAll()
        {
            List<DayForecastModel> dayForecastModels = new List<DayForecastModel>();
            var random = new Random();
            for (int i = -3; i <= 3; i++)
            {
                DateTime date = DateTime.Now.AddDays(i);

                dayForecastModels.Add(new DayForecastModel
                {
                    DataTime = date,
                    MaxTemperature = random.Next(0, 35),
                    MinTemperature = random.Next(-35, 0),
                    Location = CityStorage.GetRandomCity(),
                    Wheather = WeatherConditionsStorage.WeatherConditionGetRandom(),
                    WeekDay = date.DayOfWeek,
                    Pressure = Math.Round(random.Next(740, 780) + random.NextDouble(), 1), 
                    WindSpeed = Math.Round(random.Next(0, 20) + random.NextDouble(), 1), 
                    WindDirection = WindDirectionStorage.GetRandomWindDirection(),
                });
            }
            return dayForecastModels;
        }
    }
}
