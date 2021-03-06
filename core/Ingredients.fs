module Ingredients

// Mass, grams.
[<Measure>]
type g

type Ingredients =
    {
        Starter : float<g>
        Water : float<g>
        Flour : float<g>
        Salt : float<g>
    }

let NewStarter water flour : float =
    water / flour

let Hydration (starter: float<g>) starterHydration (water: float<g>) (flour: float<g>) =
    let sD: float<g> = starter / (starterHydration + 1.0)
    let sW: float<g> = (starterHydration * starter) / (starterHydration + 1.0)
    let wet: float<g> = sW + water
    let dry: float<g> = sD + flour
    wet / dry

let Components (starter: float<g>) starterHydration desiredHydration (desiredMass: float<g>) =
    let sD: float<g> = starter / (starterHydration + 1.0)
    let hydrationComponent: float<g> = desiredHydration * sD
    let flour: float<g> = (desiredMass - sD - hydrationComponent) / (desiredHydration + 1.0)
    let water = desiredMass - flour - starter
    let salt = (desiredMass * 0.909090) / 100.0
    {
        Starter = starter
        Water = water
        Flour = flour
        Salt = salt
    }