namespace webapi.models
{
    public class Starter : IStarter
    {
        // water as mass in grams
        public double Water => CoreStarter.Ingredients.Water;
        // flour as mass in grams
        public double Flour => CoreStarter.Ingredients.Flour;

        private readonly Core.Starter CoreStarter;

        public Starter(double water, double flour) {
            CoreStarter = new Core.Starter(new Core.Ingredients {
                Water = water, 
                Flour = flour
            });
        }

        // total mass in grams
        public double Mass => CoreStarter.Mass;

        public double Hydration => CoreStarter.Hydration;
    }

}

