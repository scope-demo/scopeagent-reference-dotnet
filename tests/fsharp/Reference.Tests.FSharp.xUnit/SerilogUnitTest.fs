namespace Reference.Tests.FSharp.xUnit

open Xunit
open Serilog
open System

type SerilogUnitTest () =
    let logConfig = new LoggerConfiguration()
    let logConfig = logConfig.MinimumLevel.Information()
    let _logger = logConfig.CreateLogger()

    [<Fact>]
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