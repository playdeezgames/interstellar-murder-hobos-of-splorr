Public Class LocationData
    Implements ILocationData
    Private ReadOnly table As New Dictionary(Of Guid, String)
    Public Function Create(name As String, vesselId As Guid) As Guid Implements ILocationData.Create
        Dim id = Guid.NewGuid
        table(id) = name
        Return id
    End Function

    Public Function ReadName(id As Guid) As String Implements ILocationData.ReadName
        Dim name As String = Nothing
        If table.TryGetValue(id, name) Then
            Return name
        End If
        Return Nothing
    End Function
End Class
