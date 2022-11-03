Public Class MainProcessor_should
    Private Sub WithSubject(stuffToDo As Action(Of IProcessor, Mock(Of ITerminal), Mock(Of IWorldProcessor)), ParamArray choices As String())
        Dim terminal As New Mock(Of ITerminal)
        Dim playProcessor As New Mock(Of IWorldProcessor)
        Dim choiceQueue As New Queue(Of String)(choices)
        terminal.Setup(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String()))).Returns(Function() choiceQueue.Dequeue)
        Dim subject As IProcessor = New MainProcessor(terminal.Object, playProcessor.Object)
        stuffToDo(subject, terminal, playProcessor)
        playProcessor.VerifyNoOtherCalls()
        terminal.VerifyNoOtherCalls()
        choiceQueue.ShouldBeEmpty
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject, terminal, playProcessor)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub run()
        WithSubject(
            Sub(subject, terminal, playProcessor)
                subject.Run()
                terminal.Verify(Sub(x) x.Clear())
                terminal.Verify(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String())))
                terminal.Verify(Sub(x) x.WriteLine(It.IsAny(Of String)))
                playProcessor.Verify(Sub(x) x.Run(It.IsAny(Of IWorld)))
            End Sub, "Ok", "Start", "Abandon Game", "Yes", "Quit", "Yes")
    End Sub
End Class
