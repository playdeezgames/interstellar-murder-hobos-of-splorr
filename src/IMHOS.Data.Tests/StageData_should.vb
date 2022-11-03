Public Class StageData_should
    <Fact>
    Sub instantiate()
        Dim subject As IStageData = New StageData()
        subject.ShouldNotBeNull
    End Sub
End Class


