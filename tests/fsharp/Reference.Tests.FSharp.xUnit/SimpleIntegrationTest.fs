namespace Reference.Tests.FSharp.xUnit

open Xunit
open System.Net.Http
open System

type SimpleIntegrationTest () =

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
            let! _ = client.GetAsync("http://localhost:24555") |> Async.AwaitTask
            ()
        })
