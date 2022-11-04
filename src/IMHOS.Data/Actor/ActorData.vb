Public Class ActorData
    Implements IActorData
    Private ReadOnly table As New Dictionary(Of Guid, (String, Guid))

    Public Function Create(name As String, locationId As Guid) As Guid Implements IActorData.Create
        Dim id = Guid.NewGuid
        table(id) = (name, locationId)
        Return id
    End Function

    Public Function ReadName(actorId As Guid) As String Implements IActorData.ReadName
        Dim record As (String, Guid) = (Nothing, Guid.Empty)
        If table.TryGetValue(actorId, record) Then
            Return record.Item1
        End If
        Return Nothing
    End Function

    Public Function ReadLocation(actorId As Guid) As Guid? Implements IActorData.ReadLocation
        Dim record As (String, Guid) = (Nothing, Guid.Empty)
        If table.TryGetValue(actorId, record) Then
            Return record.Item2
        End If
        Return Nothing
    End Function
End Class
