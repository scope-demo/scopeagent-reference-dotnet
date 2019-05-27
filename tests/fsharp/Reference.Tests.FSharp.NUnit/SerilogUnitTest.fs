namespace Reference.Tests.FSharp.NUnit

open NUnit.Framework
open Serilog
open System

type SerilogUnitTest () =
    let mutable _logger : ILogger = null

    [<SetUp>]
    member this.Init() =
        let mutable loggerConfig = new LoggerConfiguration()
        loggerConfig <- loggerConfig.MinimumLevel.Information()
        _logger <- loggerConfig.CreateLogger()
    
    [<Test>]
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