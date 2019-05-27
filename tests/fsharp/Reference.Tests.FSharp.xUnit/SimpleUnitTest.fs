namespace Reference.Tests.FSharp.xUnit

open Xunit
open System.Net.Http
open System

type SimpleUnitTest () =

    [<Fact>]
    member this.OkTest() =
        let str01 = "Hello World"
        let str02 = "hello world"
        Assert.True(String.Equals(str01, str02, StringComparison.OrdinalIgnoreCase))

    [<Fact>]
    member this.ErrorTest() =
        let base64 = Convert.ToBase64String([|byte(1); byte(2); byte(3); byte(10); byte(11); byte(12)|] : byte[])
        let result = Convert.FromBase64String(base64.Substring(1))
        ()

    
    [<Fact(Skip="Skipped test demo")>]
    member this.SkipTest() =
        ()
    
    [<Fact>]
    member this.FailTest() =
        Assert.True(this.IsPrime(411))
        ()


    member private this.IsPrime(value: int) : bool =
        let mutable primeFlag = true
        for primeI in 2..(value/2) do 
            primeFlag <- (value % primeI = 0)
        primeFlag