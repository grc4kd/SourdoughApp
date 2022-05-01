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
    let starterHydration: float = 1.0
    let water: float<g> = 260.261905<g>
    let flour: float<g> = 450.738095<g>

    Assert.That(Hydration starter starterHydration water flour, Is.EqualTo(0.68).Within(0.000001))

[<Test>]
let PlainComponentsTest () =
    let starter = 289.0
    let starterHydration = 1.0
    let desiredHydration = 0.68
    let desiredMass = 1000.0

    let testIngredientsActual =
        Components starter starterHydration desiredHydration desiredMass

    Assert.That(testIngredientsActual.Starter, Is.EqualTo(289))

    Assert.That(testIngredientsActual.Water, Is.EqualTo(260.261904).Within(0.000001))

    Assert.That(testIngredientsActual.Flour, Is.EqualTo(450.738095).Within(0.000001))

    Assert.That(testIngredientsActual.Salt, Is.EqualTo(9.09090).Within(0.000001))

[<Test>]
let NewStarterTest () =
    Assert.AreEqual(1, NewStarter 100.0 100.0)

// Website: http://breadandcompanatico.com/2013/10/16/extreme-country-sourdough-for-world-bread-day/
// Ingredients for two large loaves: 428 g active sourdough starter with 120% hydration made
// using organic stone-ground bread flour (protein: 10.5%), 700 g bread flour (protein: 12%),
// 150 g organic stone-ground all-purpose flour (protein: 8.5%), 100 g organic whole-grain spelt
// flour (mine was from sprouted spelt; protein: 13%), 640 g water + 50 to be added when you put
// salt + 100 to add when you make the folds (but look at your dough before you add it); 20 grams
// of sea salt. In total hydration was 85%.

[<Test>]
let ExtremeComponentTest () =
    let starter = 428 // 428 g active sourdough starter
    let starterHydration = 1.2 // with 120% hydration
    let desiredHydration = 0.89420174741858627 // total hydration was 85% [misprint]
    let desiredMass = 2168 // 428+700+150+100+640+50+100
    // 20g of salt excluded, salt is calculator output only ATM

    let testIngredientsActual =
        Components starter starterHydration desiredHydration desiredMass

    // 640 + 50 + 100
    Assert.That(testIngredientsActual.Water, Is.EqualTo(790).Within(0.000001))
    // 700 + 150 + 100
    Assert.That(testIngredientsActual.Flour, Is.EqualTo(950).Within(0.000001))

[<Test>]
let ExtremeHydrationTest () =
    let starter: float<g> = 428.0<g> // 428 g active sourdough starter
    let starterHydration: float = 1.2 // with 120% hydration
    let water: float<g> = 640.0<g> + 50.0<g> + 100.0<g>
    let flour: float<g> = 700.0<g> + 150.0<g> + 100.0<g>

    let hydration: float = Hydration starter starterHydration water flour
    Assert.That(hydration, Is.EqualTo(0.894201).Within(0.000001))

[<Test>]
let ConvertGramstoKilogramsTest () =
    let grams = 2000.0<g>

    Assert.That(ConvertGramsToKilograms(grams), Is.EqualTo(2<kg>))

    let grams = 2.0<g>

    Assert.That(ConvertGramsToKilograms(grams), Is.EqualTo(0.002<kg>))

    let grams = 2342423454242.0<g>

    Assert.That(ConvertGramsToKilograms(grams), Is.EqualTo(2342423454.242<kg>))
