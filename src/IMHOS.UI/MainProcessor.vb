Public Class MainProcessor
    Implements IProcessor
    Private terminal As ITerminal
    Sub New(terminal As ITerminal)
        Me.terminal = terminal
    End Sub

    Public Sub Run() Implements IProcessor.Run
        terminal.Clear()
        terminal.WriteLine("Hello, world!")
        terminal.Choose(String.Empty, "Ok")
    End Sub
End Class
