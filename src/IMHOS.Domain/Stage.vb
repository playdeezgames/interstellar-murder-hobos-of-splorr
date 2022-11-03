Public Class Stage
    Implements IStage
    Sub New()
    End Sub

    Public ReadOnly Property LeadActor As IActor Implements IStage.LeadActor
        Get
            Return New Actor()
        End Get
    End Property
End Class
