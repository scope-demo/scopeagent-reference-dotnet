namespace Reference.Tests.FSharp.xUnit

open Xunit
open NLog
open NLog.Config
open System

type NLogUnitTest () =
    
    [<Fact>]
    member this.NLogExample () =
        let logConfig = new LoggingConfiguration()
        LogManager.Configuration <- logConfig
        let _logger = LogManager.GetCurrentClassLogger()

        _logger.Trace("Trace in NLog")
        _logger.Debug("Debug in NLog")
        _logger.Info("Info in NLog")
        _logger.Warn("Warn in NLog")
        _logger.Error("Error in NLog")
        _logger.Fatal("Fatal in NLog")

        try
            raise (new Exception("Sample exception"))
        with 
            | ex -> _logger.Error(ex, "Exception error.")

        let logInfo = { Id = 6; Name = "Jacket"; Color = "Orange" }
        _logger.Info("Structured log: {logStruct}", logInfo)