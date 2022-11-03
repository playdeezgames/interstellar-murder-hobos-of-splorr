Public Class PlayProcessor
    Implements IWorldProcessor
    Private terminal As ITerminal
    Sub New(terminal As ITerminal)
        Me.terminal = terminal
    End Sub

    Public Sub Run(world As IWorld) Implements IWorldProcessor.Run
        Dim done = False
        While Not done
            terminal.Clear()
            terminal.WriteLine("Playing the Game!")
            Select Case terminal.Choose("[olive]Now What?[/]", Constants.Prompts.AbandonGame)
                Case Constants.Prompts.AbandonGame
                    done = ConfirmAbandon()
            End Select
        End While
        terminal.Clear()
    End Sub
    Private Function ConfirmAbandon() As Boolean
        Return Confirm("Are you sure you want to abandon the game?")
    End Function
    Private Function Confirm(prompt As String) As Boolean
        Return terminal.Choose($"[red]{prompt}[/]", Constants.Prompts.No, Constants.Prompts.Yes) = Constants.Prompts.Yes
    End Function
End Class
