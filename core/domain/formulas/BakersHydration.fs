namespace domain

open units.Mass

module formulas =
    let Hydration (starter: float<g>) starterHydration (water: float<g>) (flour: float<g>) =
        let sD: float<g> = starter / (starterHydration + 1.0)
        let sW: float<g> = (starterHydration * starter) / (starterHydration + 1.0)
        let wet: float<g> = sW + water
        let dry: float<g> = sD + flour
        wet / dry