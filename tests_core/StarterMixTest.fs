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
    Assert.That(testIngredientsActual.Salt, Is.EqualTo(9.09090).Within(0.000001))

[<Test>]
let NewStarterTest () =
    Assert.AreEqual(1, Bread.NewStarter 100.0 100.0)

(*
Example Recipe (EXTREMEly salty)
Ingredients for two large loaves: 
  420 g active sourdough starter with 100% hydration made
  730 g bread flour, 225 g all-purpose flour
  620 g water + 40g to be added when you put
  100 g salt to add when you make the folds (but look at your dough before you add it); 20 grams of sea salt. 
  In total hydration was about 85%.
*)
[<Test>]
let ExtremeComponentTest () =
    let starter = 420.0<g>
    let starterHydration = 1.00 // with 100% hydration
    let desiredHydration = 0.86254295532646053 // total hydration was about 85%
    let desiredMass = 420.0<g> + 730.0<g> + 225.0<g> + 620.0<g> + 40.0<g> + 100.0<g> + 20.0<g>

    // constant for salt, 90.90909% of total mass / 100 g

    let testIngredientsActual =
        Bread.Components starter starterHydration desiredHydration desiredMass

    // 620 + 40
    Assert.That(testIngredientsActual.Water, Is.EqualTo(787.97970479704782))
    // 700 + 150 + 100
    Assert.That(testIngredientsActual.Flour, Is.EqualTo(947.02029520295207))

[<Test>]
let ExtremeHydrationTest () =
    let starter: float<g> = 428.0<g> // 420 g active sourdough starter
    let starterHydration: float = 1.00 // with 100% hydration
    let water: float<g> = 640.0<g> + 50.0<g> + 100.0<g>
    let flour: float<g> = 700.0<g> + 150.0<g> + 100.0<g>

    let hydration: float = Hydration starter starterHydration water flour
    Assert.That(hydration, Is.EqualTo(0.86254295532646053))