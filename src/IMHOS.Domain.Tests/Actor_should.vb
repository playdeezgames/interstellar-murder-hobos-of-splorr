Imports IMHOS.Data

Public Class Actor_should
    Private Sub WithSubject(stuffToDo As Action(Of IActor, Mock(Of IStageData), Guid))
        Dim data As New Mock(Of IStageData)
        Dim id = Guid.NewGuid
        Dim subject As IActor = New Actor(data.Object, id)
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
                data.SetupGet(Function(x) x.Actor).Returns((New Mock(Of IActorData)).Object)
                subject.Name.ShouldBeNull
                data.Verify(Function(x) x.Actor.ReadName(id))
            End Sub)
    End Sub
    <Fact>
    Sub have_location()
        WithSubject(
            Sub(subject, data, id)
                data.SetupGet(Function(x) x.Actor).Returns((New Mock(Of IActorData)).Object)
                subject.Location.ShouldBeNull
                data.Verify(Function(x) x.Actor.ReadLocation(id))
            End Sub)
    End Sub
End Class
