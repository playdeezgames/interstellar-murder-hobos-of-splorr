Public Class StageData
    Implements IStageData
    Sub New()
        Actor = New ActorData
        LeadActor = New LeadActorData
        Location = New LocationData
        Vessel = New VesselData
    End Sub
    Public ReadOnly Property Actor As IActorData Implements IStageData.Actor
    Public ReadOnly Property LeadActor As ILeadActorData Implements IStageData.LeadActor
    Public ReadOnly Property Location As ILocationData Implements IStageData.Location
    Public ReadOnly Property Vessel As IVesselData Implements IStageData.Vessel
End Class
