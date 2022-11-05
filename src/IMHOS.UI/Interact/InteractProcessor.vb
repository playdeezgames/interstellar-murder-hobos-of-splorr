Public Class InteractProcessor
    Inherits BaseProcessor
    Implements IInteractProcessor
    Sub New(terminal As ITerminal)
        MyBase.New(terminal)
    End Sub

    Public Sub Run(stage As IStage) Implements IInteractProcessor.Run
        Dim features = stage.LeadActor.Location.Features
        Dim choices As New List(Of String) From {Constants.Prompts.NeverMind}
        Dim table = features.ToDictionary(Function(x) x.Name, Function(x) x)
        choices.AddRange(table.Keys)
        Dim answer = terminal.Choose("[olive]Interact With:[/]", choices.ToArray)
        If table.ContainsKey(answer) Then
            InteractWithFeature(table(answer))
        End If
    End Sub

    Private Sub InteractWithFeature(feature As IFeature)
        Dim choices As New List(Of String) From {Constants.Prompts.NeverMind}
        Dim verbs = feature.Verbs
        Dim answer = terminal.Choose($"[olive]Interact With {feature.Name}:[/]", choices.ToArray)
    End Sub
End Class
