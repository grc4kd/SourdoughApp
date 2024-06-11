namespace Core;

public class SourdoughService
{
    public static double Hydration(Starter? starter, double water, double flour) {
        var safeStarter = starter ?? new Starter(new Ingredients {
            Water = 0,
            Flour = 0
        });

        var wet = WetMass(safeStarter.Hydration, safeStarter.Mass) + water;
        var dry = DryMass(safeStarter.Hydration, safeStarter.Mass) + flour;

        return wet / dry;
    }

    public static double Hydration(double starter, double starterHydration, double water, double flour) {
        var wet = WetMass(starterHydration, starter) + water;
        var dry = DryMass(starterHydration, starter) + flour;
        
        return Hydration(WetMass(starterHydration, starter) + water, DryMass(starterHydration, starter) + flour);
    }

    public static Ingredients Ingredients(double starter, double starterHydration, double desiredHydration, double desiredWeight)
    {
        var starterDry = DryMass(starterHydration, starter);
        var starterWet = WetMass(starterHydration, starter);
        
        var flour = (desiredWeight - starterDry - (desiredHydration * starterDry)) / (desiredHydration + 1);

        return new Ingredients() {
            Flour = flour,
            Water = desiredWeight - starterDry - starterWet - flour,
            Salt = desiredWeight * 0.909090 / 100
        };
    }

    public static double Hydration(double water, double flour)
    {
        return water / flour;
    }

    private static double DryMass(double hydration, double mass) {
        return mass / (hydration + 1);
    }

    private static double WetMass(double hydration, double mass) {
        return hydration * mass / (hydration + 1);
    }
}
