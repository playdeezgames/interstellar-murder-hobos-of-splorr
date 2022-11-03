Module Program
    Sub Main(args As String())
        Dim terminal As ITerminal = New Terminal()
        Dim playProcessor As IWorldProcessor = New PlayProcessor(terminal)
        Dim mainProcessor As IProcessor = New MainProcessor(terminal, playProcessor)
        mainProcessor.Run()
    End Sub
End Module
