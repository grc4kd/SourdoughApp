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

        // TODO: calculate hydration dynamically
        // public int Hydration => Ingredients(
        //     Starter = 0, 
        //     Flour, 
        //     Water, 
        //     Salt = 0);

        public float Hydration => (float)Ingredients.Hydration(0, Flour, Water, 0);

        // volume in milliliters
        public int Volume { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

}

