namespace Reference.Tests.FSharp.MSTest

open Microsoft.VisualStudio.TestTools.UnitTesting
open log4net
open System

[<TestClass>]
type Log4NetUnitTest () =
    let mutable _logger : ILog = null

    [<TestInitialize>]
    member this.Init() =
        _logger <- LogManager.GetLogger(typedefof<Log4NetUnitTest>)
    
    [<TestMethod>]
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
