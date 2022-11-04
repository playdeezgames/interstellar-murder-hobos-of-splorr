Public Class FeatureData
    Implements IFeatureData
    Private locationTable As New Dictionary(Of Guid, Guid)
    Sub New()
    End Sub

    Public Function Create(name As String, locationId As Guid) As Guid Implements IFeatureData.Create
        Dim id = Guid.NewGuid
        locationTable(id) = locationId
        Return id
    End Function

    Public Function CountForLocation(locationId As Guid) As Long Implements IFeatureData.CountForLocation
        Return locationTable.Where(Function(x) x.Value = locationId).Count
    End Function
End Class
