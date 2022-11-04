Imports IMHOS.Data

Public Class Location_should
    Private Sub WithSubject(stuffToDo As Action(Of ILocation, Mock(Of IStageData), Guid))
        Dim data As New Mock(Of IStageData)
        Dim id = Guid.NewGuid
        Dim subject As ILocation = New Location(data.Object, id)
        stuffToDo(subject, data, id)
        data.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject, data, id)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub have_a_name()
        WithSubject(
            Sub(subject, data, id)
                data.SetupGet(Function(x) x.Location).Returns((New Mock(Of ILocationData)).Object)
                subject.Name.ShouldBeNull
                data.Verify(Function(x) x.Location.ReadName(id))
            End Sub)
    End Sub
End Class
