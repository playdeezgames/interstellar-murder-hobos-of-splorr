Public Class Actor
    Implements IActor
    Private ReadOnly data As IStageData
    Private ReadOnly id As Guid
    Sub New(data As IStageData, id As Guid)
        Me.data = data
        Me.id = id
    End Sub

    Public ReadOnly Property Name As String Implements IActor.Name
        Get
            Return data.Actor.ReadName(id)
        End Get
    End Property

    Friend Shared Function FromId(data As IStageData, id As Guid?) As IActor
        Return If(id.HasValue, New Actor(data, id.Value), Nothing)
    End Function
End Class
