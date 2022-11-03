Module Program
    Sub Main(args As String())
        Dim terminal As ITerminal = New Terminal()
        Dim mainProcessor As IMainProcessor = New MainProcessor(terminal)
        mainProcessor.Run()
    End Sub
End Module
