Public Class ActorData
    Implements IActorData
    Private ReadOnly table As New Dictionary(Of Guid, (String, Guid))

    Public Function Create(name As String, locationId As Guid) As Guid Implements IActorData.Create
        Dim id = Guid.NewGuid
        table(id) = (name, locationId)
        Return id
    End Function

    Public Function ReadName(id As Guid) As String Implements IActorData.ReadName
        Dim record As (String, Guid) = (Nothing, Guid.Empty)
        If table.TryGetValue(id, record) Then
            Return record.Item1
        End If
        Return Nothing
    End Function
End Class
