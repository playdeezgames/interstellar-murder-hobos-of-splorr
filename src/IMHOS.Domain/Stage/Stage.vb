Public Class Stage
    Implements IStage
    Dim data As IStageData
    Sub New(data As IStageData)
        Me.data = data
    End Sub

    Public ReadOnly Property LeadActor As IActor Implements IStage.LeadActor
        Get
            Return Actor.FromId(data, data.LeadActor.Read)
        End Get
    End Property
End Class
