Friend Module Utility
    Friend Sub WithTerminal(stuffToDo As Action(Of Mock(Of ITerminal)), choices As String())
        Dim terminal As New Mock(Of ITerminal)
        Dim choiceQueue As New Queue(Of String)(choices)
        terminal.Setup(Function(x) x.Choose(It.IsAny(Of String), It.IsAny(Of String()))).Returns(Function() choiceQueue.Dequeue)

        stuffToDo(terminal)

        terminal.VerifyNoOtherCalls()
        choiceQueue.ShouldBeEmpty
    End Sub
End Module
