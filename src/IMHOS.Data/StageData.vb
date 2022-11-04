Public Class StageData
    Implements IStageData
    Sub New()
        Actor = New ActorData
        Location = New LocationData
    End Sub
    Public ReadOnly Property Actor As IActorData Implements IStageData.Actor
    Public ReadOnly Property Location As ILocationData Implements IStageData.Location
End Class
