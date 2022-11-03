﻿Public Class MainProcessor
    Implements IProcessor
    Private terminal As ITerminal
    Sub New(terminal As ITerminal)
        Me.terminal = terminal
    End Sub

    Public Sub Run() Implements IProcessor.Run
        TitleScreen()
        MainMenu()
    End Sub

    Private Sub MainMenu()
        terminal.Clear()
        Dim done = False
        While Not done
            Dim answer = terminal.Choose("[olive]Main Menu:[/]", Constants.Prompts.Start, Constants.Prompts.Quit)
            Select Case answer
                Case Constants.Prompts.Start
                    StartGame()
                Case Constants.Prompts.Quit
                    done = ConfirmQuit()
            End Select
        End While
    End Sub

    Private Sub StartGame()
        Dim world As IWorld = New World
        PlayGame(world)
    End Sub

    Private Sub PlayGame(world As IWorld)
        terminal.Clear()
        terminal.WriteLine("Playing the Game!")
        terminal.Choose("[olive]Now What?[/]", Constants.Prompts.AbandonGame)
        terminal.Clear()
    End Sub

    Private Function ConfirmQuit() As Boolean
        Return terminal.Choose("[red]Are you sure you want to quit?[/]", Constants.Prompts.No, Constants.Prompts.Yes) = Constants.Prompts.Yes
    End Function

    Private Sub TitleScreen()
        terminal.Clear()
        terminal.WriteLine("Interstellar Murder Hobos of SPLORR!!")
        terminal.Choose(String.Empty, Constants.Prompts.Ok)
    End Sub
End Class
