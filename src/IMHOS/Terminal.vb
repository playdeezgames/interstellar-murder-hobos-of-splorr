Friend Class Terminal
    Implements ITerminal

    Public Sub WriteLine(text As String) Implements ITerminal.WriteLine
        AnsiConsole.MarkupLine(text)
    End Sub

    Public Function Choose(title As String, ParamArray choices As String()) As String Implements ITerminal.Choose
        Dim prompt As New SelectionPrompt(Of String) With {.Title = title}
        prompt.AddChoices(choices)
        Return AnsiConsole.Prompt(prompt)
    End Function
End Class
