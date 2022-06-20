namespace api.Models
{
    public interface IStarterMix
    {
        public int Mass();
        public double Hydration();
        public double TemperatureC { get; set; }
        public double TemperatureF();
    }
}
