Public Class PlayProcessor
    Implements IStageProcessor
    Private terminal As ITerminal
    Sub New(terminal As ITerminal)
        Me.terminal = terminal
    End Sub

    Public Sub Run(stage As IStage) Implements IStageProcessor.Run
        Dim done = False
        While Not done
            Dim lead As IActor = stage.LeadActor
            Dim location As ILocation = lead.Location
            Dim vessel As IVessel = location.Vessel
            terminal.Clear()
            terminal.WriteLine($"Name: {lead.Name}")
            terminal.WriteLine($"Location: {location.Name}")
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
