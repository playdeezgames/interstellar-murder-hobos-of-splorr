Public Class PlayProcessor_should
    Private Sub WithSubject(stuffToDo As Action(Of IWorldProcessor))
        Dim subject = New PlayProcessor()
        stuffToDo(subject)
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
End Class
