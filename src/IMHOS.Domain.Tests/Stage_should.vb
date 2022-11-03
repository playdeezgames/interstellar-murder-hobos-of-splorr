Public Class Stage_should
    <Fact>
    Sub instantiate()
        Dim subject As IStage = New Stage()
        subject.ShouldNotBeNull
    End Sub
End Class

