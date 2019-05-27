namespace Reference.Tests.FSharp.NUnit

open NUnit.Framework
open NLog
open NLog.Config
open System

type NLogUnitTest () =
    let mutable _logger : Logger = null

    [<SetUp>]
    member this.Init() =
        LogManager.Configuration <- new LoggingConfiguration()
        _logger <- LogManager.GetCurrentClassLogger();
    
    [<Test>]
    member this.NLogExample () =
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