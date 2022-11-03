Imports IMHOS.Data

Public Class MainProcessor_should
    Private Sub WithSubject(stuffToDo As Action(Of IProcessor, Mock(Of ITerminal), Mock(Of IStageProcessor), Mock(Of IStageFactory)), choices As String())
        WithTerminal(
            Sub(terminal)
                Dim playProcessor As New Mock(Of IStageProcessor)
                Dim factory As New Mock(Of IStageFactory)
                Dim subject As IProcessor = New MainProcessor(terminal.Object, playProcessor.Object, factory.Object)
                stuffToDo(subject, terminal, playProcessor, factory)
                playProcessor.VerifyNoOtherCalls()
                factory.Verify(Function(x) x.CreateStage())
                factory.VerifyNoOtherCalls()
            End Sub, choices)
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject, terminal, playProcessor, factory)
                subject.ShouldNotBeNull
            End Sub, {})
    End Sub
    <Fact>
    Sub run()
        WithSubject(
            Sub(subject, terminal, playProcessor, factory)
                subject.Run()
                terminal.Verify(Sub(x) x.Clear())
                terminal.Verify(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String())))
                terminal.Verify(Sub(x) x.WriteLine(It.IsAny(Of String)))
                playProcessor.Verify(Sub(x) x.Run(It.IsAny(Of IStage)))
            End Sub, {"Ok", "Start", "Abandon Game", "Yes", "Quit", "Yes"})
    End Sub
End Class
