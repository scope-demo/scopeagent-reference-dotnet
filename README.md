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
    - [**`OkTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L15:L25): A simple UnitTest comparing two strings. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-28ea-4ba52395f076/trace)
    - [**`ErrorTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L27:L47): A simple UnitTest to demonstrate exception handling. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-16a5-9ab94addeb8e/logs?eventId=e49b019f-170b-40a6-b27b-6bd8d6274cf0)
    - [**`SkipTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L49:L56): An empty UnitTest with the `Skip/Ignore` attribute. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-42cc-b33a58197b59/trace)
    - [**`FailTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleUnitTest.cs#L58:L78): A simple UnitTest to demonstrate an `Assert` exception. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-dc70-fb9d1660857f/logs?eventId=e302f8d3-7e87-4e4e-b100-c8f50250ef25)
    
- **FactorialUnitTest**
    - [**`FactorialTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/FactorialUnitTest.cs#L31:L56): UnitTest with a *Factorial algorithm* that creates an OpenTracing `Span` and `Event` on every
    recursion using the [`GlobalTracer`](https://www.nuget.org/packages/OpenTracing/) and the [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2) logger. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-f281-81f57e8343d0/trace)
    
- **SerilogUnitTest**
    - [**`SerilogExample`**](tests/csharp/Reference.Tests.CSharp.MSTest/SerilogUnitTest.cs#L26:L49): UnitTest demonstrating `Events` creation using the [`Serilog`](https://serilog.net/) structured logger.  [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-5f94-b748ea09c4af/logs?eventId=585e7407-c2a7-40eb-b28f-edef588a05f8)
    
- **NLogUnitTest**
    - [**`NLogExample`**](tests/csharp/Reference.Tests.CSharp.MSTest/NLogUnitTest.cs#L26:L49): UnitTest demonstrating `Events` creation using the [`NLog`](https://nlog-project.org/) structured logger.  [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-3d0c-a652ca636afb/logs?eventId=db7213e0-e8b8-40c8-948d-94097f52f3e4)
    
- **Log4NetUnitTest**
    - [**`Log4NetExample`**](tests/csharp/Reference.Tests.CSharp.MSTest/Log4NetUnitTest.cs#L25:L45): UnitTest demonstrating `Events` creation using the [`log4net`](https://logging.apache.org/log4net/) logger.  [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-ffb1-df1336b41a87/logs)


## Available Integration Tests

- **SimpleIntegrationTest**: *Integration tests without any Opentracing neither ScopeAgent dependency*
    - [**`HttpOK`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleIntegrationTest.cs#L14:L22): A simple `HttpClient` request to *http://www.google.com*. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-e096-236be65eacf3/trace?spanId=00000000-0000-0000-431d-814cc37c77f3)
    - [**`HttpBadFormat`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleIntegrationTest.cs#L24:L32): A simple `HttpClient` request to *http://www.badUrl.c213* to throw a `BadRequest`exception. [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-1335-745a7e3b04d5/logs?eventId=9a100100-0a11-4910-9582-9c64093d5f38)
    - [**`HttpKO`**](tests/csharp/Reference.Tests.CSharp.MSTest/SimpleIntegrationTest.cs#L34:L42): A simple `HttpClient` request to *http://localhost* to throw a `SocketException` exception 
    (assuming no listener is setted on localhost:80). [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-72d7-cf4890a4a0ec/trace)

- **GeoIntegrationTest**: *(Available only on C# and VB.NET UnitTest Project)*
    - [**`CompleteOKTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/GeoIntegrationTest.cs#L34:L105): *A complex UnitTest demonstrating:*
    
        - `Span` creation using the [`GlobalTracer`](https://www.nuget.org/packages/OpenTracing/).
        - `Event` creation using the [`Microsoft.Extensions.Logging`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2) structured logger.
        - `Redis` client instrumentation.
        - `Http` client instrumentation with an instrumented service (IntegrationTest).
        - `Http` client instrumentation without an instrumented service.
        - `Entity framework` instrumentation using the `SqlServer` connector.
        
    [`View Results`](https://demo.scope.dev/explore/9b3b9640-cead-4362-b5e8-2aa0af1f2414/15f60180-24a2-4015-9a8d-f3773f724424/CSharp/test/00000000-0000-0000-5327-22d2a30d11e2/trace)

- **PostgresIntegrationTest**: *(Available only on C# and VB.NET UnitTest Project)*
    - [**`PostgresCompleteTest`**](tests/csharp/Reference.Tests.CSharp.MSTest/PostgresIntegrationTest.cs#L34:L105): *Clone of the `GeoIntegrationTest` using a postgresql database*
        
    [`View Results`]
