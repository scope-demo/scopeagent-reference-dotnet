# ScopeAgent .NET Reference Project

ScopeAgent-Reference is the reference app to showcase Scope integration and functionality in a `.NET Core` 
Solution, containing examples for `C#`, `VB.NET` and `F#`

>In order to execute it, please follow the instructions at https://scope.undefinedlabs.com/docs/dotnet-installation

## Solution Structure

### Reference source code

| Path | Description |
|------|-------------|
| `src/Reference.Csharp` | **C# project** containing `Models`, `Entities`, `Http clients`, `Redis clients` and `Database connectors` as an application logic representation without any reference to Opentracing neither the ScopeAgent. 
| `src/Reference.VB` | **VB.NET project** containing `Models`, `Entities`, `Http clients`, `Redis clients` and `Database connectors` as an application logic representation without any reference to Opentracing neither the ScopeAgent.

### Reference unit tests

| Path | Description |
|------|-------------|
| `tests/csharp/Reference.Tests.CSharp.MSTest` | **C# project**  for `MSTest Framework` |
| `tests/csharp/Reference.Tests.CSharp.NUnit` | **C# project** for `NUnit Framework`  |
| `tests/csharp/Reference.Tests.CSharp.xUnit` | **C# project** for `xUnit Framework`  |
| `tests/csharp/Reference.Tests.VB.MSTest` | **VB.NET project** for `MSTest Framework` |
| `tests/csharp/Reference.Tests.VB.NUnit` | **VB.NET project** for `NUnit Framework` |
| `tests/csharp/Reference.Tests.VB.xUnit` | **VB.NET project** for `xUnit Framework` |
| `tests/csharp/Reference.Tests.FSharp.MSTest` | **F# project** for `MSTest Framework` |
| `tests/csharp/Reference.Tests.FSharp.NUnit` | **F# project** for `NUnit Framework`  |
| `tests/csharp/Reference.Tests.FSharp.xUnit` | **F# project** for `xUnit Framework`  |


## Available Unit Tests

- **SimpleUnitTest**: *Unit tests without any Opentracing neither ScopeAgent dependency*
    - [**`OkTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L15:L25): A simple UnitTest comparing two strings. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-b503-b45e70572dd3/trace)
    - [**`ErrorTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L27:L47): A simple UnitTest to demonstrate exception handling. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-c6a8-dc9da0720dcc/logs?eventId=07b1575b-f2d5-4c9a-8852-b9be2ea200f5)
    - [**`SkipTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L49:L56): An empty UnitTest with the `Skip/Ignore` attribute. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-9299-1a74feb2afbe/trace)
    - [**`FailTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L58:L78): A simple UnitTest to demonstrate an `Assert` exception. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-f667-068cc1648079/logs?eventId=767e1a64-348c-4bae-a9b9-a031f355b3f8)
    
- **FactorialUnitTest**
    - [**`FactorialTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/FactorialUnitTest.cs#L31:L56): UnitTest with a *Factorial algorithm* that creates an OpenTracing `Span` and `Event` on every
    recursion using the [`GlobalTracer`](https://www.nuget.org/packages/OpenTracing/) and the [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2) logger. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-2781-f08fff30dceb/trace)
    
- **SerilogUnitTest**
    - [**`SerilogExample`**](tests/csharp/Reference.Tests.CSharp.MSTest/SerilogUnitTest.cs#L26:L49): UnitTest demonstrating `Events` creation using the [`Serilog`](https://serilog.net/) structured logger.  [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-31f4-97e7d323b56a/logs)
    
- **NLogUnitTest**
    - [**`NLogExample`**](tests/csharp/Reference.Tests.CSharp.MSTest/NLogUnitTest.cs#L26:L49): UnitTest demonstrating `Events` creation using the [`NLog`](https://nlog-project.org/) structured logger.  [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-26c4-376e41227558/logs)
    
- **Log4NetUnitTest**
    - [**`Log4NetExample`**](tests/csharp/Reference.Tests.CSharp.MSTest/Log4NetUnitTest.cs#L25:L45): UnitTest demonstrating `Events` creation using the [`log4net`](https://logging.apache.org/log4net/) logger.  [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-2ef7-89adfb4cd1ad/logs)


## Available Integration Tests

- **SimpleIntegrationTest**: *Integration tests without any Opentracing neither ScopeAgent dependency*
    - [**`HttpOK`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleIntegrationTest.cs#L14:L22): A simple `HttpClient` request to *http://www.google.com*. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-7610-e7a5a9dbbb1c/trace)
    - [**`HttpBadFormat`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleIntegrationTest.cs#L24:L32): A simple `HttpClient` request to *http://www.badUrl.c213* to throw a `BadRequest`exception. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-463a-456f310cf080/trace)
    - [**`HttpKO`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleIntegrationTest.cs#L34:L42): A simple `HttpClient` request to *http://localhost* to throw a `SocketException` exception 
    (assuming no listener is setted on localhost:80). [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-f88a-cb2b86b36683/trace)

- **GeoIntegrationTest**: *(Available only on C# and VB.NET UnitTest Project)*
    - [**`CompleteOKTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/GeoIntegrationTest.cs#L34:L105): *A complex UnitTest demonstrating:*
    
        - `Span` creation using the [`GlobalTracer`](https://www.nuget.org/packages/OpenTracing/).
        - `Event` creation using the [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2) structured logger.
        - `Redis` client instrumentation.
        - `Http` client instrumentation with an instrumented service (IntegrationTest).
        - `Http` client instrumentation without an instrumented service.
        - `Entity framework` instrumentation using the `SqlServer` connector.
        
    [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-a024-62382f3919a6/trace)
