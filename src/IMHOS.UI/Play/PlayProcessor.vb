﻿Public Class PlayProcessor
    Inherits BaseProcessor
    Implements IPlayProcessor
    Private interactProcessor As IInteractProcessor
    Sub New(terminal As ITerminal, interactProcessor As IInteractProcessor)
        MyBase.New(terminal)
        Me.interactProcessor = interactProcessor
    End Sub

    Public Sub Run(stage As IStage) Implements IPlayProcessor.Run
        Dim done = False
        While Not done
            Dim lead As IActor = stage.LeadActor
            Dim location As ILocation = lead.Location
            Dim vessel As IVessel = location.Vessel
            Dim features = location.Features
            terminal.Clear()
            terminal.WriteLine($"Name: {lead.Name}")
            terminal.WriteLine($"Location: {location.Name}")
            terminal.WriteLine($"Vessel: {vessel.Name}")
            Dim choices As New List(Of String)
            If features.Any Then
                terminal.WriteLine($"Features: {String.Join(", ", features.Select(Function(x) x.Name))}")
                choices.Add(Constants.Prompts.Interact)
            End If
            choices.Add(Constants.Prompts.AbandonGame)
            Select Case terminal.Choose("[olive]Now What?[/]", choices.ToArray)
                Case Constants.Prompts.Interact
                    interactProcessor.Run(stage)
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
