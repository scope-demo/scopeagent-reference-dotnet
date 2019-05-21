namespace Reference.Tests.FSharp.MSTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open System.Net.Http

[<TestClass>]
type SimpleUnitTest () =

    [<TestMethod>]
    member this.HttpOK () = 
        Async.RunSynchronously(async {
            use client = new HttpClient()
            let! _ = client.GetAsync("http://www.google.com") |> Async.AwaitTask
            ()
        })

    [<TestMethod>]
    member this.HttpBadFormat () = 
        Async.RunSynchronously(async {
            use client = new HttpClient()
            let! _ = client.GetAsync("http://www.badUrl.c213") |> Async.AwaitTask
            ()
        })

    [<TestMethod>]
    member this.HttpKO () = 
        Async.RunSynchronously(async {
            use client = new HttpClient()
            let! _ = client.GetAsync("http://localhost") |> Async.AwaitTask
            ()
        })
    
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