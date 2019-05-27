namespace Reference.Tests.FSharp.NUnit

open NUnit.Framework
open System.Net.Http

type SimpleIntegrationTest () =

    [<Test>]
    member this.HttpOK () = 
        Async.RunSynchronously(async {
            use client = new HttpClient()
            let! _ = client.GetAsync("http://www.google.com") |> Async.AwaitTask
            ()
        })

    [<Test>]
    member this.HttpBadFormat () = 
        Async.RunSynchronously(async {
            use client = new HttpClient()
            let! _ = client.GetAsync("http://www.badUrl.c213") |> Async.AwaitTask
            ()
        })

    [<Test>]
    member this.HttpKO () = 
        Async.RunSynchronously(async {
            use client = new HttpClient()
            let! _ = client.GetAsync("http://localhost:24555") |> Async.AwaitTask
            ()
        })
    