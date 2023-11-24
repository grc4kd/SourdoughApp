namespace domain.models

open domain.units.Mass

module Bread =
    let NewStarter water flour : float =
        water / flour

    let Components (starter: float<g>) starterHydration desiredHydration (desiredMass: float<g>) =
        let starterDryMass: float<g> = starter / (starterHydration + 1.0)
        let targetHydrationFactor: float<g> = desiredHydration * starterDryMass
        let flour: float<g> = (desiredMass - starterDryMass - targetHydrationFactor) / (desiredHydration + 1.0)
        let water: float<g> = desiredMass - flour - starter
        {|
            Starter = starter
            Water = water
            Flour = flour
        |}