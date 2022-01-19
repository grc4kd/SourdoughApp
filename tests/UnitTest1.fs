module tests

open NUnit.Framework
open NUnit.Framework.Constraints

open Ingredients

[<SetUp>]
let Setup () = ()

[<Test>]
let EqualityTestsWithTolerance () =
    let testIngredientsActual = Components 289.0 1.0 0.68 1000.0
    Assert.AreEqual(450.73, testIngredientsActual.Flour, 0.01)

    Assert.That(
        450.7,
        Is
            .EqualTo(testIngredientsActual.Flour)
            .Within(0.05)
    )

    Assert.That(4.0, Is.Not.EqualTo(5.0).Within(0.5))
    Assert.That(4.99f, Is.EqualTo(5.0f).Within(0.05f))
    Assert.That(4.99m, Is.EqualTo(5.0m).Within(0.05m))
    Assert.That(3999999999u, Is.EqualTo(4000000000u).Within(5u))
    Assert.That(499, Is.EqualTo(500).Within(5))
    Assert.That(4999999999L, Is.EqualTo(5000000000L).Within(5L))
    Assert.That(5999999999UL, Is.EqualTo(6000000000UL).Within(5UL))

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
    Assert.AreEqual(100, Hydration 0.0 100.0 100.0 0.0)
