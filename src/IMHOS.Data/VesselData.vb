Public Class VesselData
    Implements IVesselData

    Public Function Create(name As String) As Guid Implements IVesselData.Create
        Return Guid.NewGuid
    End Function
End Class
