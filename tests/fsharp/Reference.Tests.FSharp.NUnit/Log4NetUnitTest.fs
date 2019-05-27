namespace Reference.Tests.FSharp.NUnit

open NUnit.Framework
open log4net
open System

type Log4NetUnitTest () =
    let mutable _logger : ILog = null

    [<SetUp>]
    member this.Init() =
        _logger <- LogManager.GetLogger(typedefof<Log4NetUnitTest>)
    
    [<Test>]
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
