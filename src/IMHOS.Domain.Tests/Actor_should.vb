Public Class Actor_should
    <Fact>
    Sub instantiate()
        Dim subject As IActor = New Actor()
        subject.ShouldNotBeNull
    End Sub
End Class
