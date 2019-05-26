namespace Reference.Tests.FSharp.MSTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open System.Net.Http

[<TestClass>]
type SimpleUnitTest () =

    [<TestMethod>]
    [<Ignore("Skipped test demo")>]
    member this.SkipTest() =
        ()
    
    [<TestMethod>]
    member this.FailTest() =
        Assert.AreEqual(true, this.IsPrime(411))


    member private this.IsPrime(value: int) =
        let mutable primeFlag = true
        for primeI in 2..(value/2) do 
            primeFlag <- (value % primeI = 0)
        primeFlag