module tests

open NUnit.Framework

// Open the Ingredients library under test.
open domain.units.Mass
open domain.formulas
open domain.models

[<Test>]
let PlainHydrationTest () =
    let starter: float<g> = 289.0<g>
    // 1 part flour : 1 part water = 1.00
    let starterHydration: float = 1.00
    let water: float<g> = 260.261905<g>
    let flour: float<g> = 450.738095<g>

    Assert.That(Hydration starter starterHydration water flour, Is.EqualTo(0.68).Within(0.000001))

[<Test>]
let PlainComponentsTest () =
    let starter = 289.0<g>
    let starterHydration = 1.0
    let desiredHydration = 0.68
    let desiredMass = 1000.0<g>

    let testIngredientsActual =
        Bread.Components starter starterHydration desiredHydration desiredMass

    Assert.That(testIngredientsActual.Starter, Is.EqualTo(289))
    Assert.That(testIngredientsActual.Water, Is.EqualTo(260.261904).Within(0.000001))
    Assert.That(testIngredientsActual.Flour, Is.EqualTo(450.738095).Within(0.000001))

[<Test>]
let NewStarterTest () =
    Assert.AreEqual(1, Bread.NewStarter 100.0 100.0)

(*
Example Recipe (EXTREMEly salty)
Ingredients for two large loaves:
  420 g active sourdough starter with 100% hydration
  730 g bread flour, 225 g all-purpose flour
  660 g water
  salt
  In total hydration was about 85%.
*)
type RecipeSampleTestData =
    { starter: float<g>
      starterHydration: float
      desiredHydration: float
      desiredMass: float<g>
      water: float<g>
      flour: float<g> }

let testData =
    { starter = 420.0<g>
      starterHydration = 1.00 // with 100% hydration
      desiredHydration = 0.85 // total hydration was about 85%
      desiredMass = (420.0<g> + 730.0<g> + 225.0<g> + 660.0<g>)
      water = 725.0<g>
      flour = 890.0<g> }

[<Test>]
let ExtremeComponentTest () =
    let components =
        Bread.Components testData.starter testData.starterHydration testData.desiredHydration testData.desiredMass

    Assert.Multiple (fun () ->
        Assert.AreEqual(testData.flour, components.Flour)
        Assert.AreEqual(testData.starter, components.Starter)
        Assert.AreEqual(testData.water, components.Water))

[<Test>]
let ExtremeHydrationTest () =
    let hydration: float =
        Hydration testData.starter testData.starterHydration testData.water testData.flour

    Assert.That(hydration, Is.EqualTo(0.85))
