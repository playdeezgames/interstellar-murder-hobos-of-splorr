Public Class Feature
    Inherits Thingie
    Implements IFeature
    Sub New(data As IStageData, id As Guid)
        MyBase.New(data, id)
    End Sub
    Friend Shared Function FromId(data As IStageData, id As Guid?) As IFeature
        Return If(id.HasValue, New Feature(data, id.Value), Nothing)
    End Function
End Class
