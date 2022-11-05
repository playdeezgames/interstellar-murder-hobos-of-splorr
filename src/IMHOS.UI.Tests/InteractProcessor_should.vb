Public Class InteractProcessor_should
    Private Sub WithSubject(stuffToDo As Action(Of IInteractProcessor, Mock(Of ITerminal)), choices As String())
        WithTerminal(
            Sub(terminal)
                Dim subject As IInteractProcessor = New InteractProcessor(terminal.Object)
                stuffToDo(subject, terminal)
            End Sub, choices)
    End Sub
    <Fact>
    Sub instantiates()
        WithSubject(
            Sub(subject, terminal)
                subject.ShouldNotBeNull
            End Sub, {})
    End Sub
    <Fact>
    Sub run()
        WithSubject(
            Sub(subject, terminal)
                Dim stage As New Mock(Of IStage)
                stage.SetupGet(Function(x) x.LeadActor.Location.Features).Returns(Array.Empty(Of IFeature))
                subject.Run(stage.Object)
                stage.Verify(Function(x) x.LeadActor.Location.Features)
                stage.VerifyNoOtherCalls()
                terminal.Verify(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String())))
            End Sub, {Constants.Prompts.NeverMind})
    End Sub
End Class
