Public Class MainProcessor_should
    Private Sub WithSubject(stuffToDo As Action(Of IMainProcessor, Mock(Of ITerminal)))
        Dim terminal As New Mock(Of ITerminal)
        Dim subject As IMainProcessor = New MainProcessor(terminal.Object)
        stuffToDo(subject, terminal)
        terminal.VerifyNoOtherCalls()
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
                terminal.Setup(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String()))).Returns("Ok")
                subject.Run()
                terminal.Verify(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String())))
                terminal.Verify(Sub(x) x.WriteLine(It.IsAny(Of String)))
            End Sub)
    End Sub
End Class
