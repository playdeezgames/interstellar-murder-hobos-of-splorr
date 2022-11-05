Public Class InteractProcessor
    Inherits BaseProcessor
    Implements IInteractProcessor
    Sub New(terminal As ITerminal)
        MyBase.New(terminal)
    End Sub

    Public Sub Run(stage As IStage) Implements IInteractProcessor.Run
        Dim features = stage.LeadActor.Location.Features
        Dim choices As New List(Of String) From {Constants.Prompts.NeverMind}
        choices.AddRange(features.Select(Function(x) x.Name))
        Dim answer = terminal.Choose("[olive]Interact With:[/]", choices.ToArray)
    End Sub
End Class
