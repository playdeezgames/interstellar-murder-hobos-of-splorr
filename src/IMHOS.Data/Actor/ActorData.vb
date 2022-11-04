Public Class ActorData
    Implements IActorData
    Private ReadOnly names As New Dictionary(Of Guid, String)
    Private ReadOnly locations As New Dictionary(Of Guid, Guid)
    Public Function Create(name As String, locationId As Guid) As Guid Implements IActorData.Create
        Dim id = Guid.NewGuid
        names(id) = name
        locations(id) = locationId
        Return id
    End Function

    Public Function ReadName(actorId As Guid) As String Implements IActorData.ReadName
        Dim record As String = Nothing
        If names.TryGetValue(actorId, record) Then
            Return record
        End If
        Return Nothing
    End Function

    Public Function ReadLocation(actorId As Guid) As Guid? Implements IActorData.ReadLocation
        Dim record As Guid = Nothing
        If locations.TryGetValue(actorId, record) Then
            Return record
        End If
        Return Nothing
    End Function
End Class
