Public Class LocationData_should
    Private Sub WithSubject(stuffToDo As Action(Of ILocationData))
        Dim subject As ILocationData = New LocationData()
        stuffToDo(subject)
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub create()
        WithSubject(
            Sub(subject)
                Const name = "one"
                subject.Create(name).ShouldNotBe(Guid.Empty)
            End Sub)
    End Sub
    <Fact>
    Sub read_name()
        WithSubject(
            Sub(subject)
                Dim id = Guid.Empty
                subject.ReadName(id).ShouldBeNull
            End Sub)
    End Sub
End Class
