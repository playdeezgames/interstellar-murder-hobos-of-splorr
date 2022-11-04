Public Class StageData
    Implements IStageData
    Sub New()
        Actor = New ActorData
        Feature = New FeatureData
        LeadActor = New LeadActorData
        Location = New LocationData
        Vessel = New VesselData
    End Sub
    Public ReadOnly Property Actor As IActorData Implements IStageData.Actor
    Public ReadOnly Property Feature As IFeatureData Implements IStageData.Feature
    Public ReadOnly Property LeadActor As ILeadActorData Implements IStageData.LeadActor
    Public ReadOnly Property Location As ILocationData Implements IStageData.Location
    Public ReadOnly Property Vessel As IVesselData Implements IStageData.Vessel
End Class
