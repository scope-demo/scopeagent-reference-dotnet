namespace Reference.Tests.FSharp.NUnit

open NUnit.Framework
open OpenTracing.Util
open OpenTracing.Noop
open Microsoft.Extensions.Logging

type FactorialUnitTest () =
    let mutable _logger : ILogger<FactorialUnitTest> = null

    member private this.Factorial(number: int) =
        let tracer = GlobalTracer.Instance
        use scope = tracer.BuildSpan("Factorial for: " + number.ToString()).StartActive()
        let res = if (number = 1) then 1 else number * this.Factorial(number - 1)
        _logger.LogInformation("Calculating factorial for: " + number.ToString() + " = " + res.ToString())
        res

    [<SetUp>]
    member this.Init() =
        //If no global tracer is registered (not running with scope-run), we register the Noop tracer
        if (GlobalTracer.IsRegistered() = false) then
            GlobalTracer.Register(NoopTracerFactory.Create())
        let loggerFactory = new LoggerFactory()       
        // We add the ScopeAgent Logger instrumentation (Automatically added on ASP.NET Core project)
        let iLoggerFactory = loggerFactory.AddScopeAgentLogger()
        _logger <- iLoggerFactory.CreateLogger<FactorialUnitTest>()
        ()
    
    [<Test>]
    member this.FactorialTest () = 
        this.Factorial(20) |> ignore
        ()
