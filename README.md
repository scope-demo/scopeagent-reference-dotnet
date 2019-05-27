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
    - [**`OkTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L15:L25): A simple UnitTest comparing two strings.
    - [**`ErrorTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L27:L47): A simple UnitTest to demonstrate exception handling.
    - [**`SkipTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L49:L56): An empty UnitTest with the `Skip/Ignore` attribute.
    - [**`FailTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L58:L78): A simple UnitTest to demonstrate an `Assert` exception.
    
- **FactorialUnitTest**
    - [**`FactorialTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/FactorialUnitTest.cs#L31:L56): UnitTest with a *Factorial algorithm* that creates an OpenTracing `Span` and `Event` on every
    recursion using the [`GlobalTracer`](https://www.nuget.org/packages/OpenTracing/) and the [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2) logger.
    
- **SerilogUnitTest**
    - [**`SerilogExample`**](tests/csharp/Reference.Tests.CSharp.MSTest/SerilogUnitTest.cs#L26:L49): UnitTest demonstrating `Events` creation using the [`Serilog`](https://serilog.net/) structured logger. 
    
- **NLogUnitTest**
    - [**`NLogExample`**](tests/csharp/Reference.Tests.CSharp.MSTest/NLogUnitTest.cs#L26:L49): UnitTest demonstrating `Events` creation using the [`NLog`](https://nlog-project.org/) structured logger.
    
- **Log4NetUnitTest**
    - [**`Log4NetExample`**](tests/csharp/Reference.Tests.CSharp.MSTest/Log4NetUnitTest.cs#L25:L45): UnitTest demonstrating `Events` creation using the [`log4net`](https://logging.apache.org/log4net/) logger.


## Available Integration Tests

- **SimpleIntegrationTest**: *Integration tests without any Opentracing neither ScopeAgent dependency*
    - [**`HttpOK`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleIntegrationTest.cs#L14:L22): A simple `HttpClient` request to *http://www.google.com*.
    - [**`HttpBadFormat`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleIntegrationTest.cs#L24:L32): A simple `HttpClient` request to *http://www.badUrl.c213* to throw a `BadRequest`exception.
    - [**`HttpKO`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleIntegrationTest.cs#L34:L42): A simple `HttpClient` request to *http://localhost* to throw a `SocketException` exception 
    (assuming no listener is setted on localhost:80).

- **GeoIntegrationTest**: *(Available only on C# and VB.NET UnitTest Project)*
    - [**`CompleteOKTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/GeoIntegrationTest.cs#L34:L105): *A complex UnitTest demonstrating:*
    
        - `Span` creation using the [`GlobalTracer`](https://www.nuget.org/packages/OpenTracing/).
        - `Event` creation using the [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2) structured logger.
        - `Redis` client instrumentation.
        - `Http` client instrumentation with an instrumented service (IntegrationTest).
        - `Http` client instrumentation without an instrumented service.
        - `Entity framework` instrumentation using the `SqlServer` connector.
