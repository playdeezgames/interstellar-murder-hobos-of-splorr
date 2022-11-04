Public Class FeatureData
    Implements IFeatureData
    Private locations As New Dictionary(Of Guid, Guid)
    Sub New()
    End Sub

    Public Function Create(name As String, locationId As Guid) As Guid Implements IFeatureData.Create
        Dim id = Guid.NewGuid
        locations(id) = locationId
        Return id
    End Function

    Public Function CountForLocation(locationId As Guid) As Long Implements IFeatureData.CountForLocation
        Return locations.Where(Function(x) x.Value = locationId).Count
    End Function

    Public Function ReadForLocation(locationId As Guid) As IEnumerable(Of Guid) Implements IFeatureData.ReadForLocation
        Return locations.Where(Function(x) x.Value = locationId).Select(Function(x) x.Key)
    End Function
End Class
