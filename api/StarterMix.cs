namespace api
{
    public class StarterMix
    {
        // water as mass in grams
        public int Water { get; set; }

        // flour as mass in grams
        public int Flour { get; set; }
    
        // total mass in grams
        public int Mass => Water + Flour;

        public double Hydration => Ingredients.NewStarter(Water, Flour);

        // volume in milliliters
        public int Volume { get; set; }

        public float TemperatureC { get; set; }

        public float TemperatureF => TemperatureC * 9 / 5 + 32;

        public string Status { get; set; }
    }

}

