Public Class StageData
    Implements IStageData
    Sub New()
        Location = New LocationData(Me)
    End Sub

    Public ReadOnly Property Location As ILocationData Implements IStageData.Location
End Class
