namespace Reference.Tests.FSharp.xUnit

open Xunit
open log4net
open System

type Log4NetUnitTest () =
    let _logger : ILog = LogManager.GetLogger(typedefof<Log4NetUnitTest>)

    [<Fact>]
    member this.Log4NetExample () =
        _logger.Debug("Debug in NLog")
        _logger.Info("Info in NLog")
        _logger.Warn("Warn in NLog")
        _logger.Error("Error in NLog")
        _logger.Fatal("Fatal in NLog")

        try
            raise (new Exception("Sample exception"))
        with 
            | ex -> _logger.Error("Exception error.", ex)
