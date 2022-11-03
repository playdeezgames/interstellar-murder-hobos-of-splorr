Public Class MainProcessor
    Implements IMainProcessor
    Private terminal As ITerminal
    Sub New(terminal As ITerminal)
        Me.terminal = terminal
    End Sub

    Public Sub Run() Implements IMainProcessor.Run
        terminal.WriteLine("Hello, world!")
        terminal.Choose(String.Empty, "Ok")
    End Sub
End Class
