Public Class Vessel
    Inherits Thingie
    Implements IVessel

    Public Sub New(data As IStageData, id As Guid)
        MyBase.New(data, id)
    End Sub

    Public ReadOnly Property Name As String Implements IVessel.Name
        Get
            Return data.Vessel.ReadName(id)
        End Get
    End Property

    Friend Shared Function FromId(data As IStageData, id As Guid?) As IVessel
        Return If(id.HasValue, New Vessel(data, id.Value), Nothing)
    End Function
End Class
