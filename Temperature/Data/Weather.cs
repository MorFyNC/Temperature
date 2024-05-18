namespace Temperature.Data
{
    public class Weather
    {
        public DateTime DateTime { get; set; }

        public decimal Temperature { get; set; }
        public WeatherStatus WeatherStatus {get; set;}
        public Weather(DateTime DateTime, decimal Temperature, WeatherStatus WeatherStatus)
        {
            this.DateTime = DateTime;
            this.Temperature = Temperature;
            this.WeatherStatus = WeatherStatus;
        }
    }
}
