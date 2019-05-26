namespace Reference.Tests.FSharp.NUnit

open NUnit.Framework
open System.Net.Http

type SimpleUnitTest () =
    
    [<Test>]
    [<Ignore("Skipped test demo")>]
    member this.SkipTest() =
        ()
    
    [<Test>]
    member this.FailTest() =
        Assert.AreEqual(true, this.IsPrime(411))


    member private this.IsPrime(value: int) =
        let mutable primeFlag = true
        for primeI in 2..(value/2) do 
            primeFlag <- (value % primeI = 0)
        primeFlag