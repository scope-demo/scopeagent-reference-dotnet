namespace Reference.Tests.FSharp.MSTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open NLog
open NLog.Config
open System

[<TestClass>]
type NLogUnitTest () =
    let mutable _logger : Logger = null

    [<TestInitialize>]
    member this.Init() =
        LogManager.Configuration <- new LoggingConfiguration()
        _logger <- LogManager.GetCurrentClassLogger();
    
    [<TestMethod>]
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