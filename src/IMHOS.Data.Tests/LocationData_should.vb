Public Class LocationData_should
    Private Sub WithSubject(stuffToDo As Action(Of ILocationData, Mock(Of IStageData)))
        Dim data As New Mock(Of IStageData)
        Dim subject As ILocationData = New LocationData(data.Object)
        stuffToDo(subject, data)
        data.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject, data)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub create()
        WithSubject(
            Sub(subject, data)
                Const name = "one"
                subject.Create(name).ShouldNotBe(Guid.Empty)
            End Sub)
    End Sub
    <Fact>
    Sub read_name()
        WithSubject(
            Sub(subject, data)
                Dim id = Guid.Empty
                subject.ReadName(id).ShouldBeNull
            End Sub)
    End Sub
End Class
