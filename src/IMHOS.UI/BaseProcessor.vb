Public MustInherit Class BaseProcessor
    Protected ReadOnly terminal As ITerminal
    Sub New(terminal As ITerminal)
        Me.terminal = terminal
    End Sub
End Class
