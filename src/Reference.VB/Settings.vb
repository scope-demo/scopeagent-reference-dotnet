' ReSharper disable InconsistentNaming
' ReSharper disable ClassNeverInstantiated.Global

''' <summary>
''' Settings
''' </summary>
Public NotInheritable Class Settings
    ''' <summary>
    ''' Redis HostName
    ''' </summary>
    Public Const RedisHostName As String = "redis"
    ''' <summary>
    ''' DB ConnectionString
    ''' </summary>
    Public Const DBConnectionString As String = "Data Source=sqlserver;Initial Catalog=test;Persist Security Info=True;User ID=testUser;Password=testPassw0rd"
    ''' <summary>
    ''' MongoDB Url
    ''' </summary>
    Public Const MongoDBUrl As String = "mongodb://mongo:27017"
    ''' <summary>
    ''' MongoDB Database
    ''' </summary>
    Public Const MongoDBDatabase As String = "Reference"
    ''' <summary>
    ''' MongoDB Collection
    ''' </summary>
    Public Const MongoDBCollection As String = "Geo"
End Class


