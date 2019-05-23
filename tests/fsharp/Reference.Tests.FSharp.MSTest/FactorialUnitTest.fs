namespace Reference.Tests.FSharp.MSTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open OpenTracing.Util
open OpenTracing.Noop
open Microsoft.Extensions.Logging

[<TestClass>]
type FactorialUnitTest () =
    let mutable _logger : ILogger<FactorialUnitTest> = null

    member private this.Factorial(number: int) =
        let tracer = GlobalTracer.Instance
        use scope = tracer.BuildSpan("Factorial for: " + number.ToString()).StartActive()
        let res = if (number = 1) then 1 else number * this.Factorial(number - 1)
        _logger.LogInformation("Calculating factorial for: " + number.ToString() + " = " + res.ToString())
        res

    [<TestInitialize>]
    member this.Init() =
        //If no global tracer is registered (not running with scope-run), we register the Noop tracer
        if (GlobalTracer.IsRegistered() = false) then
            GlobalTracer.Register(NoopTracerFactory.Create())
        let loggerFactory = new LoggerFactory()       
        _logger <- loggerFactory.CreateLogger<FactorialUnitTest>()
        ()
    
    [<TestMethod>]
    member this.FactorialTest () = 
        this.Factorial(20) |> ignore
        ()
