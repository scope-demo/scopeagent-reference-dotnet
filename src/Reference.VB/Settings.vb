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
    ''' Postgresql connection string
    ''' </summary>
    Public Const PostgresConnectionString As String = "Host=postgres;Port=5432;User ID=testUser;Password=testPassw0rd;Database=test;Pooling=true;"
End Class


