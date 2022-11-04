Public Class LocationData
    Implements ILocationData
    Private ReadOnly names As New Dictionary(Of Guid, String)
    Private ReadOnly vessels As New Dictionary(Of Guid, Guid)
    Public Function Create(name As String, vesselId As Guid) As Guid Implements ILocationData.Create
        Dim id = Guid.NewGuid
        names(id) = name
        vessels(id) = vesselId
        Return id
    End Function
    Public Function ReadName(locationId As Guid) As String Implements ILocationData.ReadName
        Dim result As String = Nothing
        If names.TryGetValue(locationId, result) Then
            Return result
        End If
        Return Nothing
    End Function
    Public Function ReadVessel(locationId As Guid) As Guid? Implements ILocationData.ReadVessel
        Dim result As Guid = Nothing
        If vessels.TryGetValue(locationId, result) Then
            Return result
        End If
        Return Nothing
    End Function
End Class
