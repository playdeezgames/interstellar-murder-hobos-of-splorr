Public Class Location
    Inherits Thingie
    Implements ILocation

    Public Sub New(data As IStageData, id As Guid)
        MyBase.New(data, id)
    End Sub

    Friend Shared Function FromId(data As IStageData, id As Guid?) As ILocation
        Return If(id.HasValue, New Location(data, id.Value), Nothing)
    End Function
End Class
