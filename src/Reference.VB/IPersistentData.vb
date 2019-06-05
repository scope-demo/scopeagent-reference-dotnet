Imports System.Threading.Tasks
' ReSharper disable UnusedMember.Global

''' <summary>
''' Persistent data interface
''' </summary>
Public Interface IPersistentData
    ''' <summary>
    ''' Ensure migration
    ''' </summary>
    ''' <returns>Migration task</returns>
    Function EnsureMigrationAsync() As Task
    ''' <summary>
    ''' Save data to database
    ''' </summary>
    ''' <param name="geoPoint">GeoPoint value</param>
    ''' <param name="item">OpenStreetMapItem value</param>
    ''' <returns>Save database task</returns>
    Function SaveDataAsync(geoPoint As GeoPoint, item As OpenStreetMapItem) As Task(Of Boolean)
    ''' <summary>
    ''' Get all data
    ''' </summary>
    ''' <returns>List with all geo data</returns>
    Function GetAllAsync() As Task(Of List(Of (GeoPoint As GeoPoint, StreetMap As OpenStreetMapItem)))
End Interface