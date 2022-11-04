Public Class FeatureData
    Implements IFeatureData
    Private names As New Dictionary(Of Guid, String)
    Private locations As New Dictionary(Of Guid, Guid)
    Sub New()
    End Sub

    Public Function Create(name As String, locationId As Guid) As Guid Implements IFeatureData.Create
        Dim id = Guid.NewGuid
        names(id) = name
        locations(id) = locationId
        Return id
    End Function

    Public Function CountForLocation(locationId As Guid) As Long Implements IFeatureData.CountForLocation
        Return locations.Where(Function(x) x.Value = locationId).Count
    End Function

    Public Function ReadForLocation(locationId As Guid) As IEnumerable(Of Guid) Implements IFeatureData.ReadForLocation
        Return locations.Where(Function(x) x.Value = locationId).Select(Function(x) x.Key)
    End Function

    Public Function ReadName(featureId As Guid) As String Implements IFeatureData.ReadName
        Dim result As String = Nothing
        If names.TryGetValue(featureId, result) Then
            Return result
        End If
        Return Nothing
    End Function
End Class
