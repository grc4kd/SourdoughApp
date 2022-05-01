module Ingredients

type Ingredients =
    {
        Starter : float
        Water : float
        Flour : float
        Salt : float
    }

let NewStarter water flour : float =
    water / flour

let Hydration starter starterHydration water flour =
    let sD = starter / (starterHydration + 1.0)
    let sW = (starterHydration * starter) / (starterHydration + 1.0)
    let wet = sW + water
    let dry = sD + flour
    wet / dry

let Components starter starterHydration desiredHydration desiredMass =
    let sD = starter / (starterHydration + 1.0)
    let sW = (starterHydration * starter) / (starterHydration + 1.0)
    let flour = (desiredMass - sD - (desiredHydration * sD)) / (desiredHydration + 1.0)
    let water = desiredMass - flour - starter
    let salt = (desiredMass * 0.909090) / 100.0
    {
        Starter = starter
        Water = water
        Flour = flour
        Salt = salt
    }