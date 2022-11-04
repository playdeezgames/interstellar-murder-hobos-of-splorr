Module Program
    Sub Main(args As String())
        Dim terminal As ITerminal = New Terminal()
        Dim interactProcessor As IInteractProcessor = New InteractProcessor
        Dim playProcessor As IPlayProcessor = New PlayProcessor(terminal, interactProcessor)
        Dim data As IStageData = New StageData
        Dim factory As IStageFactory = New StageFactory(data)
        Dim mainProcessor As IMainProcessor = New MainProcessor(terminal, playProcessor, factory)
        mainProcessor.Run()
    End Sub
End Module
