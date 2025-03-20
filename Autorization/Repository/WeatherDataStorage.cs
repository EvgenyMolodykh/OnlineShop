using Autorization.Models;

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
                dayForecastModels.Add(new DayForecastModel
                {
                    DataTime = DateTime.Now.AddDays(i),
                    MaxTemperature = random.Next(0, 35),
                    MinTemperature = random.Next(-35, 0),
                });
            }
            return dayForecastModels;
        }
    }
}
