Public Class Location
    Inherits Thingie
    Implements ILocation

    Public Sub New(data As IStageData, id As Guid)
        MyBase.New(data, id)
    End Sub

    Public ReadOnly Property Name As String Implements ILocation.Name
        Get
            Return data.Location.ReadName(id)
        End Get
    End Property

    Public ReadOnly Property Vessel As IVessel Implements ILocation.Vessel
        Get
            Return Nothing
        End Get
    End Property

    Friend Shared Function FromId(data As IStageData, id As Guid?) As ILocation
        Return If(id.HasValue, New Location(data, id.Value), Nothing)
    End Function
End Class
