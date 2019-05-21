namespace Reference.Tests.FSharp.MSTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open Serilog
open System

[<TestClass>]
type SerilogUnitTest () =
    let mutable _logger : ILogger = null

    [<TestInitialize>]
    member this.Init() =
        let mutable loggerConfig = new LoggerConfiguration()
        loggerConfig <- loggerConfig.MinimumLevel.Information()
        _logger <- loggerConfig.CreateLogger()
    
    [<TestMethod>]
    member this.SerilogExample () =
        _logger.Verbose("Verbose in Serilog")
        _logger.Debug("Debug in Serilog")
        _logger.Information("Information in Serilog")
        _logger.Warning("Warning in Serilog")
        _logger.Error("Error in Serilog")
        _logger.Fatal("Fatal in Serilog")

        try
            raise (new Exception("Sample exception"))
        with 
            | ex -> _logger.Error(ex, "Exception error.")

        let logInfo = { Id = 6; Name = "Jacket"; Color = "Orange" }
        _logger.Information("Structured log: {@logStruct}", logInfo)