Public Class PlayProcessor_should
    Private Sub WithSubject(stuffToDo As Action(Of IWorldProcessor, Mock(Of ITerminal)), choices As String())
        WithTerminal(
            Sub(terminal)
                Dim subject = New PlayProcessor(terminal.Object)
                stuffToDo(subject, terminal)
            End Sub, choices)
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject, terminal)
                subject.ShouldNotBeNull
            End Sub, {})
    End Sub
    <Fact>
    Sub run()
        WithSubject(
            Sub(subject, terminal)
                Dim world As New Mock(Of IWorld)
                subject.Run(world.Object)
                world.VerifyNoOtherCalls()
                terminal.Verify(Sub(x) x.WriteLine(It.IsAny(Of String)))
                terminal.Verify(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String())))
                terminal.Verify(Sub(x) x.Clear())
            End Sub, {"Abandon Game", "Yes"})
    End Sub
End Class
