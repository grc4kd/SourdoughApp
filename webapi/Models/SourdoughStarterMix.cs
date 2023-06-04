namespace api.models
{
    public class SourdoughStarterMix : IStarterMix
    {
        // water as mass in grams
        public int Water;

        // flour as mass in grams
        public int Flour;

        // total mass in grams
        public int Mass
        {
            get { return Water + Flour; }
            set
            {
                if (value < 0) return;
                else
                {
                    Water = value;
                }
            }
        }

        public double Hydration() => domain.models.Recipe.NewStarter(Water, Flour);

        // volume in milliliters
        public int Volume { get; set; }

        private double temperatureC;
        public double TemperatureC {
            get
            {
                return temperatureC;
            }
            set
            {
                temperatureC = value;
            }
        }

        public double TemperatureF()
        {
            return TemperatureC * 9 / 5 + 32;
        }

        public string Status { get; set; }       
    }

}

