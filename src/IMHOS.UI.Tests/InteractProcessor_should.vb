Imports IMHOS.Data

Public Class InteractProcessor_should
    <Fact>
    Sub instantiates()
        Dim subject As IInteractProcessor = New InteractProcessor
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub run()
        Dim stage As New Mock(Of IStage)
        Dim subject As IInteractProcessor = New InteractProcessor
        subject.Run(stage.Object)
        stage.VerifyNoOtherCalls()
    End Sub
End Class
