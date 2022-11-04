Friend Class StageFactory
    Implements IStageFactory
    Private ReadOnly data As IStageData
    Sub New(data As IStageData)
        Me.data = data
    End Sub
    Public Function CreateStage() As IStage Implements IStageFactory.CreateStage
        Dim vesselId = data.Vessel.Create("Yer Ship")
        Dim locationId = data.Location.Create("Yer Pilot's Chair", vesselId)
        Dim helmFeatureId = data.Feature.Create("Helm", locationId)
        Dim throttleFeatureId = data.Feature.Create("Throttle", locationId)
        Dim seatBeltFeatureId = data.Feature.Create("Seat Belt", locationId)
        Dim actorId = data.Actor.Create("You", locationId)
        data.LeadActor.Write(actorId)
        Return New Stage(data)
    End Function
End Class
