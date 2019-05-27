namespace Reference.Tests.FSharp.MSTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open System.Net.Http

[<TestClass>]
type SimpleIntegrationTest () =

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
            let! _ = client.GetAsync("http://localhost:24555") |> Async.AwaitTask
            ()
        })
    