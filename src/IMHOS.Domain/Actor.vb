Public Class Actor
    Inherits Thingie
    Implements IActor
    Sub New(data As IStageData, id As Guid)
        MyBase.New(data, id)
    End Sub
    Public ReadOnly Property Name As String Implements IActor.Name
        Get
            Return data.Actor.ReadName(id)
        End Get
    End Property
    Public ReadOnly Property Location As ILocation Implements IActor.Location
        Get
            Return Domain.Location.FromId(data, data.Actor.ReadLocation(id))
        End Get
    End Property
    Friend Shared Function FromId(data As IStageData, id As Guid?) As IActor
        Return If(id.HasValue, New Actor(data, id.Value), Nothing)
    End Function
End Class
