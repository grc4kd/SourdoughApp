module Ingredients

open FSharp.Data.UnitSystems.SI.UnitSymbols
// Mass, grams.
[<Measure>]
type g

// Define conversion constants.
let gramsPerKilogram: float<g kg^- 1> = 1000.0<g/kg>

// Define conversion functions.
let ConvertGramsToKilograms (x: float<g>) = x / gramsPerKilogram


type Ingredients =
    {
        Starter : float
        Water : float
        Flour : float
        Salt : float
    }

let NewStarter water flour : float =
    water / flour

let Hydration (starter: float<g>) starterHydration (water: float<g>) (flour: float<g>) =
    let sD: float<g> = starter / (starterHydration + 1.0)
    let sW: float<g> = (starterHydration * starter) / (starterHydration + 1.0)
    let wet: float<g> = sW + water
    let dry: float<g> = sD + flour
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