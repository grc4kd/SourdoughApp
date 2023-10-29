namespace domain.models

open domain.units.Mass

module Bread =
    let NewStarter water flour : float =
        water / flour

    let Components (starter: float<g>) starterHydration desiredHydration (desiredMass: float<g>) =
        let sD: float<g> = starter / (starterHydration + 1.0)
        let hydrationComponent: float<g> = desiredHydration * sD
        let flour: float<g> = (desiredMass - sD - hydrationComponent) / (desiredHydration + 1.0)
        let water: float<g> = desiredMass - flour - starter
        let salt: float<g> = (desiredMass * 0.909090) / 100.0
        {|
            Starter = starter
            Water = water
            Flour = flour
            Salt = salt
        |}