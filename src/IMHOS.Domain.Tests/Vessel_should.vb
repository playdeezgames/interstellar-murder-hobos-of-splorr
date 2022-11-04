Imports IMHOS.Data

Public Class Vessel_should
    Private Sub WithSubject(stuffToDo As Action(Of IVessel, Mock(Of IStageData), Guid))
        Dim data As New Mock(Of IStageData)
        Dim id = Guid.NewGuid
        Dim subject As IVessel = New Vessel(data.Object, id)
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
                data.SetupGet(Function(x) x.Vessel).Returns((New Mock(Of IVesselData)).Object)
                subject.Name.ShouldBeNull
                data.Verify(Function(x) x.Vessel.ReadName(id))
            End Sub)
    End Sub
End Class
