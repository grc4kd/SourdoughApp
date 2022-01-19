module Ingredients

type Ingredients =
    {
        Starter : float
        Water : float
        Flour : float
        Salt : float
    }

let Hydration starter starterHydration water flour =
    match starter with
    | 0.0 -> water / flour
    | _ ->
        let sD = starter / (starterHydration + 1.0)
        let sW = (starterHydration * starter) / (starterHydration + 1.0)
        let wet = sW + water
        let dry = sD + flour
        wet / dry

let Components starter starterHydration desiredHydration desiredMass =
    let sD = starter / (starterHydration + 1.0)
    let sW = (starterHydration * starter) / (starterHydration + 1.0)
    let flour = (desiredMass - sD - (desiredHydration * sD)) / (desiredHydration + 1.0)
    {
        Starter = starter
        Water = desiredMass - sD - sW - flour
        Flour = flour
        Salt = (desiredMass * 0.909090) / 100.0
    }