Public Class StageData_should
    <Fact>
    Sub instantiate()
        Dim subject As IStageData = New StageData()
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub has_location()
        Dim subject As IStageData = New StageData
        subject.Location.ShouldNotBeNull
    End Sub
    <Fact>
    Sub has_actor()
        Dim subject As IStageData = New StageData
        subject.Actor.ShouldNotBeNull
    End Sub
End Class


