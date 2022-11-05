Public Class MainProcessor
    Inherits BaseProcessor
    Implements IMainProcessor
    Private playProcessor As IPlayProcessor
    Private factory As IStageFactory
    Sub New(terminal As ITerminal, playProcessor As IPlayProcessor, factory As IStageFactory)
        MyBase.New(terminal)
        Me.playProcessor = playProcessor
        Me.factory = factory
    End Sub

    Public Sub Run() Implements IMainProcessor.Run
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
        Dim world As IStage = factory.CreateStage()
        playProcessor.Run(world)
    End Sub

    Private Function ConfirmQuit() As Boolean
        Return Confirm("Are you sure you want to quit?")
    End Function
    Private Function Confirm(prompt As String) As Boolean
        Return terminal.Choose($"[red]{prompt}[/]", Constants.Prompts.No, Constants.Prompts.Yes) = Constants.Prompts.Yes
    End Function

    Private Sub TitleScreen()
        terminal.Clear()
        terminal.WriteLine("Interstellar Murder Hobos of SPLORR!!")
        terminal.Choose(String.Empty, Constants.Prompts.Ok)
    End Sub
End Class
