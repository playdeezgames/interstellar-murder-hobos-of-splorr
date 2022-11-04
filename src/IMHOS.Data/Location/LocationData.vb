Public Class LocationData
    Implements ILocationData
    Private ReadOnly table As New Dictionary(Of Guid, (String, Guid))
    Public Function Create(name As String, vesselId As Guid) As Guid Implements ILocationData.Create
        Dim id = Guid.NewGuid
        table(id) = (name, vesselId)
        Return id
    End Function

    Public Function ReadName(locationId As Guid) As String Implements ILocationData.ReadName
        Dim record As (String, Guid) = (Nothing, Guid.Empty)
        If table.TryGetValue(locationId, record) Then
            Return record.Item1
        End If
        Return Nothing
    End Function

    Public Function ReadVessel(locationId As Guid) As Guid? Implements ILocationData.ReadVessel
        Dim record As (String, Guid) = (Nothing, Guid.Empty)
        If table.TryGetValue(locationId, record) Then
            Return record.Item2
        End If
        Return Nothing
    End Function
End Class
