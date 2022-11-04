Public Class VesselData
    Implements IVesselData
    Private ReadOnly table As New Dictionary(Of Guid, String)
    Public Function Create(name As String) As Guid Implements IVesselData.Create
        Dim id = Guid.NewGuid
        table(id) = name
        Return id
    End Function
    Public Function ReadName(vesselId As Guid) As String Implements IVesselData.ReadName
        Dim record As String = Nothing
        If table.TryGetValue(vesselId, record) Then
            Return record
        End If
        Return Nothing
    End Function
End Class
