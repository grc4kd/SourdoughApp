module Tests

open Ingredients

let testDecimal (expected : decimal) (actual : decimal) (threshold : decimal) =
    let difference = abs (expected - actual)
    match difference < threshold with
    | true -> 
        true
    | false -> 
        printfn "test failed, expected: %M, actual %M" expected actual
        false

let RunTestSuite =
    let resultArray = Array.empty
    let result1 = testDecimal 0.68M (decimal (Hydration 289.0 1.0 260.261905 450.738095)) 0.000001M
    match result1 with
    | true -> () // empty unit, do nothing if test passed
    | false -> printfn "func Hydration test failed"

    let resultArray = Array.append resultArray [| result1 |]

    let testIngredientsExpected =
        {
            Starter = 289.0
            Water = 260.261905
            Flour = 450.738095n
            Salt = 9.0909
        } 
    let testIngredientsActual = Components 289.0 1.0 0.68 1000.0

    let result2 = testDecimal (decimal testIngredientsExpected.Starter) (decimal testIngredientsActual.Starter) 0.000001M
    let result3 = testDecimal (decimal testIngredientsExpected.Water) (decimal testIngredientsActual.Water) 0.000001M
    let result4 = testDecimal (decimal testIngredientsExpected.Flour) (decimal testIngredientsActual.Flour) 0.000001M
    let result5 = testDecimal (decimal testIngredientsExpected.Salt) (decimal testIngredientsActual.Salt) 0.000001M

    match result2, result3, result4, result5 with
    | true, true, true, true -> () // empty unit, do nothing if test passed
    | _, _, _, _ -> printfn "func Components test failed"

    let resultArray = Array.append resultArray [| result2; result3; result4; result5 |]

    // return false if at least one test failed
    // return true if all tests pass
    not (Array.contains false resultArray)
