namespace Reference.Tests.FSharp.NUnit

open NUnit.Framework
open System.Net.Http
open System

type SimpleUnitTest () =

    [<Test>]
    member this.OkTest() =
        let str01 = "Hello World"
        let str02 = "hello world"
        Assert.IsTrue(String.Equals(str01, str02, StringComparison.OrdinalIgnoreCase))

    [<Test>]
    member this.ErrorTest() =
        let base64 = Convert.ToBase64String([|byte(1); byte(2); byte(3); byte(10); byte(11); byte(12)|] : byte[])
        let result = Convert.FromBase64String(base64.Substring(1))
        ()
    
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