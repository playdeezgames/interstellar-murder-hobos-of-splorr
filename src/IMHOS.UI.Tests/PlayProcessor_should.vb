Public Class PlayProcessor_should
    Private Sub WithSubject(
                           stuffToDo As Action(Of IPlayProcessor, Mock(Of ITerminal), Mock(Of IInteractProcessor)), choices As String())
        WithTerminal(
            Sub(terminal)
                Dim interactProcessor As New Mock(Of IInteractProcessor)
                Dim subject = New PlayProcessor(terminal.Object, interactProcessor.Object)
                stuffToDo(subject, terminal, interactProcessor)
                interactProcessor.VerifyNoOtherCalls()
            End Sub, choices)
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject, terminal, interact)
                subject.ShouldNotBeNull
            End Sub, {})
    End Sub
    <Fact>
    Sub run()
        WithSubject(
            Sub(subject, terminal, interact)
                Dim stage As New Mock(Of IStage)
                stage.SetupGet(Function(x) x.LeadActor.Location.Vessel).Returns((New Mock(Of IVessel)).Object)
                subject.Run(stage.Object)

                stage.VerifyGet(Function(x) x.LeadActor.Name)
                stage.VerifyGet(Function(x) x.LeadActor.Location)
                stage.VerifyGet(Function(x) x.LeadActor.Location.Name)
                stage.VerifyGet(Function(x) x.LeadActor.Location.Features)
                stage.VerifyGet(Function(x) x.LeadActor.Location.Vessel)
                stage.VerifyGet(Function(x) x.LeadActor.Location.Vessel.Name)
                stage.VerifyGet(Function(x) x.LeadActor)
                stage.VerifyNoOtherCalls()

                terminal.Verify(Sub(x) x.WriteLine(It.IsAny(Of String)))
                terminal.Verify(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String())))
                terminal.Verify(Sub(x) x.Clear())
            End Sub, {"Abandon Game", "Yes"})
    End Sub
End Class
