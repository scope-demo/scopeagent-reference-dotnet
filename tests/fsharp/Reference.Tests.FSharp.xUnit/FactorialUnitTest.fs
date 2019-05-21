namespace Reference.Tests.FSharp.xUnit

open Xunit
open OpenTracing.Util
open OpenTracing.Noop
open Microsoft.Extensions.Logging

type FactorialUnitTest () =
    let loggerFactory = new LoggerFactory()       
    // We add the ScopeAgent Logger instrumentation (Automatically added on ASP.NET Core project)
    let iLoggerFactory = loggerFactory.AddScopeAgentLogger()
    let _logger = iLoggerFactory.CreateLogger<FactorialUnitTest>()

    member private this.Factorial(number: int) =
        let tracer = GlobalTracer.Instance
        use scope = tracer.BuildSpan("Factorial for: " + number.ToString()).StartActive()
        let res = if (number = 1) then 1 else number * this.Factorial(number - 1)
        _logger.LogInformation("Calculating factorial for: " + number.ToString() + " = " + res.ToString())
        res

    [<Fact>]
    member this.FactorialTest () = 
        //If no global tracer is registered (not running with scope-run), we register the Noop tracer
        if (GlobalTracer.IsRegistered() = false) then
            GlobalTracer.Register(NoopTracerFactory.Create())
        this.Factorial(20) |> ignore
        ()
