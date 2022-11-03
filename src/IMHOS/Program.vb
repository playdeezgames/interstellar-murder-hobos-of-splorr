Module Program
    Sub Main(args As String())
        Dim terminal As ITerminal = New Terminal()
        Dim mainProcessor As IProcessor = New MainProcessor(terminal)
        mainProcessor.Run()
    End Sub
End Module
