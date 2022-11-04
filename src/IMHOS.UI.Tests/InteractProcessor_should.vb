Public Class InteractProcessor_should
    <Fact>
    Sub instantiates()
        Dim subject As IInteractProcessor = New InteractProcessor
        subject.ShouldNotBeNull
    End Sub
End Class
