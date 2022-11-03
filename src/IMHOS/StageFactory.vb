Friend Class StageFactory
    Implements IStageFactory
    Private ReadOnly data As IStageData
    Sub New(data As IStageData)
        Me.data = data
    End Sub
    Public Function CreateStage() As IStage Implements IStageFactory.CreateStage
        'create ship
        Dim locationId = data.Location.Create("Yer Ship")
        'create pilot
        'set pilot as lead actor
        Return New Stage(data)
    End Function
End Class
