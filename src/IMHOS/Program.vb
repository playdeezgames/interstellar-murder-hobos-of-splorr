Module Program
    Sub Main(args As String())
        Dim terminal As ITerminal = New Terminal()
        Dim playProcessor As IStageProcessor = New PlayProcessor(terminal)
        Dim data As IStageData = New StageData
        Dim factory As IStageFactory = New StageFactory(data)
        Dim mainProcessor As IProcessor = New MainProcessor(terminal, playProcessor, factory)
        mainProcessor.Run()
    End Sub
End Module
