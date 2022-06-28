module tests

open NUnit.Framework
open FSharp.Data.UnitSystems.SI.UnitSymbols

// Open the Ingredients library under test.
open Ingredients

// Import unit of measure from Ingredients module.
[<Measure>]
type g = Ingredients.g

[<SetUp>]
let Setup () = ()

// for posterity's sake, these are the previously defined tests
// I will be re-implementing the code that satisfies these test dependencies
// and the functionality under test
[<Test>]
let PlainHydrationTest () =
    let starter: float<g> = 289.0<g>
    let starterHydration: float = 1.00  // baker's math, 1 part flour : 1 part water => 100% == 1.00
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
        Components starter starterHydration desiredHydration desiredMass

    Assert.That(testIngredientsActual.Starter, Is.EqualTo(289))
    Assert.That(testIngredientsActual.Water, Is.EqualTo(260.261904).Within(0.000001))
    Assert.That(testIngredientsActual.Flour, Is.EqualTo(450.738095).Within(0.000001))
    Assert.That(testIngredientsActual.Salt, Is.EqualTo(9.09090).Within(0.000001))

[<Test>]
let NewStarterTest () =
    Assert.AreEqual(1, NewStarter 100.0 100.0)

// Ingredients for two large loaves: 
// 420 g active sourdough starter with 100% hydration made
// 730 g bread flour, 225 g all-purpose flour
// 620 g water + 40g to be added when you put
// 100 g salt to add when you make the folds (but look at your dough before you add it); 20 grams of sea salt. 
// In total hydration was about 85%.

[<Test>]
let ExtremeComponentTest () =
    let starter = 420.0<g> // 420 g active sourdough starter
    let starterHydration = 1.00 // with 100% hydration
    let desiredHydration = 0.86254295532646053 // total hydration was about 85%
    let desiredMass = 2155.0<g> // 420+730+225+620+40+100+20
    // salt is always 90.90909% of total mass / 100 g

    let testIngredientsActual =
        Components starter starterHydration desiredHydration desiredMass

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