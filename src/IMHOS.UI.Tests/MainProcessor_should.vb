Public Class MainProcessor_should
    Private Sub WithSubject(stuffToDo As Action(Of IProcessor, Mock(Of ITerminal)), ParamArray choices As String())
        Dim terminal As New Mock(Of ITerminal)
        Dim choiceQueue As New Queue(Of String)(choices)
        terminal.Setup(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String()))).Returns(Function() choiceQueue.Dequeue)
        Dim subject As IProcessor = New MainProcessor(terminal.Object)
        stuffToDo(subject, terminal)
        terminal.VerifyNoOtherCalls()
        choiceQueue.ShouldBeEmpty
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject, terminal)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub run()
        WithSubject(
            Sub(subject, terminal)
                subject.Run()
                terminal.Verify(Sub(x) x.Clear())
                terminal.Verify(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String())))
                terminal.Verify(Sub(x) x.WriteLine(It.IsAny(Of String)))
            End Sub, "Ok", "Quit")
    End Sub
End Class
