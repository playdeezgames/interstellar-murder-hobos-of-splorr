Public Class FeatureData
    Implements IFeatureData
    Sub New()
    End Sub

    Public Function Create(name As String, locationId As Guid) As Guid Implements IFeatureData.Create
        Return Guid.NewGuid
    End Function
End Class
