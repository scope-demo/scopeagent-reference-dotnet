namespace Reference.Tests.FSharp.xUnit

open Xunit
open System.Net.Http

type SimpleUnitTest () =

    [<Fact>]
    member this.HttpOK () = 
        Async.RunSynchronously(async {
            use client = new HttpClient()
            let! _ = client.GetAsync("http://www.google.com") |> Async.AwaitTask
            ()
        })

    [<Fact>]
    member this.HttpBadFormat () = 
        Async.RunSynchronously(async {
            use client = new HttpClient()
            let! _ = client.GetAsync("http://www.badUrl.c213") |> Async.AwaitTask
            ()
        })

    [<Fact>]
    member this.HttpKO () = 
        Async.RunSynchronously(async {
            use client = new HttpClient()
            let! _ = client.GetAsync("http://localhost") |> Async.AwaitTask
            ()
        })
    
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