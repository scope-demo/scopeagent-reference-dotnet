﻿Imports Microsoft.Extensions.Logging
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenTracing.Noop
Imports OpenTracing.Util
Imports Reference.VB
' ReSharper disable InconsistentNaming
' ReSharper disable UnusedVariable

''' <summary>
''' Geo Integration Test
''' </summary>
<TestClass>
Public Class MongoGeoIntegrationTest
    Private _logger As ILogger

    ''' <summary>
    ''' Initialize test
    ''' </summary>
    <TestInitialize>
    Public Sub Init()

        'If no global tracer is registered (not running with scope-run), we register the Noop tracer
        If Not GlobalTracer.IsRegistered() Then
            GlobalTracer.Register(NoopTracerFactory.Create())
        End If

        Dim loggerFactory = New LoggerFactory()
        _logger = loggerFactory.CreateLogger(Of MongoGeoIntegrationTest)()

    End Sub

    ''' <summary>
    ''' Mongo Geo Test
    ''' </summary>
    ''' <returns>Test task</returns>
    <TestMethod>
    Public Async Function MongoOKTest() As Task
        Const UUID = "9E219725-490E-4509-A42D-D0388DF317D4"

        Dim tracer = GlobalTracer.Instance

        Dim geoPoint As GeoPoint
        Dim geoServiceCache = New GeoServiceRedisCache()
        Dim geoService = New GeoService()

        Using scope As OpenTracing.IScope = tracer.BuildSpan("Get GeoPoint Data").StartActive()
            _logger.LogInformation("Getting data from cache")
            geoPoint = Await geoServiceCache.GetGeoPointAsync(UUID)
            If geoPoint Is Nothing Then
                _logger.LogWarning("The GeoPoint was not found in the cache.")
                geoPoint = Await geoService.GetGeoPointAsync(UUID)
                Assert.IsNotNull(geoPoint, "The GeoPoint shouldn't be null")
                _logger.LogInformation("The GeoPoint was retrieved from the GeoService: {geoPoint}", geoPoint)
                Await geoServiceCache.SetGeoPointAsync(UUID, geoPoint)
            Else
                _logger.LogInformation("The GeoPoint was found in the cache: {geoPoint}", geoPoint)
            End If
        End Using

        Dim streetMap As OpenStreetMapItem
        Dim openStreetMapServiceCache = New OpenStreetMapRedisCache()
        Dim openStreetMapService = New OpenStreetMapService()

        Using scope As OpenTracing.IScope = tracer.BuildSpan("Get OpenStreet Data").StartActive()
            _logger.LogInformation("Getting data from cache")
            streetMap = Await openStreetMapServiceCache.GetOpenStreetMapAsync(UUID)
            If streetMap Is Nothing Then
                _logger.LogWarning("The OpenStreet data was not found in the cache.")
                streetMap = Await openStreetMapService.GetOpenStreetMapAsync(geoPoint)
                Assert.IsNotNull(streetMap, "The OpenStreet data is null!")
                _logger.LogInformation("The OpenStreet data was retrieved from the Service: {openStreetMap}", streetMap)
                Await openStreetMapServiceCache.SetOpenStreetMapAsync(UUID, streetMap)
            Else
                _logger.LogInformation("The OpenStreet data was found in the cache: {openStreetMap}", streetMap)
            End If
        End Using

        Dim dbService As IPersistentData = New MongoDBService()

        Using scope As OpenTracing.IScope = tracer.BuildSpan("Save data").StartActive()
            _logger.LogInformation("Ensuring migrations")
            Await dbService.EnsureMigrationAsync()

            _logger.LogInformation("Saving data to DB")
            If (Await dbService.SaveDataAsync(geoPoint, streetMap)) Then
                _logger.LogInformation("Data saved to db.")
            Else
                _logger.LogInformation("Data is already in the db.")
            End If
        End Using

        Using scope As OpenTracing.IScope = tracer.BuildSpan("Cleaning").StartActive()
            _logger.LogInformation("Cleaning GeoService cache data.")
            Await geoServiceCache.DeleteAsync(UUID)
            Await openStreetMapServiceCache.DeleteAsync(UUID)
        End Using

    End Function

End Class


