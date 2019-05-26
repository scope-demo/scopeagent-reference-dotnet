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
    - **`SkipTest`**: An empty UnitTest with the `Skip/Ignore` attribute.
    - **`FailTest`**: A simple UnitTest to demonstrate an `Assert` exception.
    
- **FactorialUnitTest**
    - **`FactorialTest`**: UnitTest with a *Factorial algorithm* that creates an OpenTracing `Span` and `Event` on every
    recursion using the [`GlobalTracer`](https://www.nuget.org/packages/OpenTracing/) and the [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2) logger.
    
- **SerilogUnitTest**
    - **`SerilogExample`**: UnitTest demonstrating `Events` creation using the [`Serilog`](https://serilog.net/) structured logger. 
    
- **NLogUnitTest**
    - **`NLogExample`**: UnitTest demonstrating `Events` creation using the [`NLog`](https://nlog-project.org/) structured logger.
    
- **Log4NetUnitTest**
    - **`Log4NetExample`**: UnitTest demonstrating `Events` creation using the [`log4net`](https://logging.apache.org/log4net/) logger.


## Available Integration Tests

- **SimpleIntegrationTest**: *Integration tests without any Opentracing neither ScopeAgent dependency*
    - **`HttpOK`**: A simple `HttpClient` request to *http://www.google.com*.
    - **`HttpBadFormat`**: A simple `HttpClient` request to *http://www.badUrl.c213* to throw a `BadRequest`exception.
    - **`HttpKO`**: A simple `HttpClient` request to *http://localhost* to throw a `SocketException` exception 
    (assuming no listener is setted on localhost:80).

- **GeoIntegrationTest**: *(Available only on C# and VB.NET UnitTest Project)*
    - **`CompleteOKTest`**: *A complex UnitTest demonstrating:*
    
        - `Span` creation using the [`GlobalTracer`](https://www.nuget.org/packages/OpenTracing/).
        - `Event` creation using the [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2) structured logger.
        - `Redis` client instrumentation.
        - `Http` client instrumentation with an instrumented service (IntegrationTest).
        - `Http` client instrumentation without an instrumented service.
        - `Entity framework` instrumentation using the `SqlServer` connector.