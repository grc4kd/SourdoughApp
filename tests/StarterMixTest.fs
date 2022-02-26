module tests

open NUnit.Framework
open NUnit.Framework.Constraints

open Ingredients

[<SetUp>]
let Setup () = ()

// for posterity's sake, these are the previously defined tests
// I will be re-implementing the code that satisfies these test dependencies
// and the functionality under test
[<Test>]
let RunNormalTests () =
    Assert.That(
        0.68,
        Is
            .EqualTo(Hydration 289.0 1.0 260.261905 450.738095)
            .Within(0.000001)
    )

    let testIngredientsActual = Components 289.0 1.0 0.68 1000.0

    Assert.That(
        289,
        Is
            .EqualTo(testIngredientsActual.Starter)
            .Within(0.000001)
    )

    Assert.That(
        260.261905,
        Is
            .EqualTo(testIngredientsActual.Water)
            .Within(0.000001)
    )

    Assert.That(
        450.738095,
        Is
            .EqualTo(testIngredientsActual.Flour)
            .Within(0.000001)
    )

    Assert.That(
        9.09090,
        Is
            .EqualTo(testIngredientsActual.Salt)
            .Within(0.000001)
    )

[<Test>]
let NewStarterTest () =
    Assert.AreEqual(1, NewStarter 100.0 100.0)

// begin new tests -- 2022-02-01 - TDD
[<Test>]
let GetFlourMassAvgTest() =
    let starter = 289.0
    let starterHydration = 100.0
    let desiredHydration = 0.68
    let desiredMass = 1000.0
    
    let testIngredientsActual = Components starter starterHydration desiredHydration desiredMass
    
    Assert.That(testIngredientsActual.Flour, Is.EqualTo(450.738095).Within(0.000001))

// http://breadandcompanatico.com/2013/10/16/extreme-country-sourdough-for-world-bread-day/
[<Test>]
let GetFlourMassExtreme1Test() =
    let starter = 428
    let starterHydration = 120
    let desiredHydration = 0.85
    let desiredMass = 2168
    
    let testIngredientsActual = Components starter starterHydration desiredHydration desiredMass
    
    Assert.That(testIngredientsActual.Water, Is.EqualTo(950).Within(0.000001))

