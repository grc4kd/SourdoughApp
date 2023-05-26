namespace api.models
{
    public interface IStarterMix
    {
        public int Mass { get; set; }
        public double TemperatureC { get; set; }
        public int Volume { get; set; }
        public double Hydration();
        public double TemperatureF();
    }
}
