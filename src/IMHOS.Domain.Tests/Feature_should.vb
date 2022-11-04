Imports IMHOS.Data

Public Class Feature_should
    Private Sub WithSubject(stuffToDo As Action(Of IFeature, Mock(Of IStageData), Guid))
        Dim data As New Mock(Of IStageData)
        Dim id = Guid.NewGuid
        Dim subject As IFeature = New Feature(data.Object, id)
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
    Sub have_name()
        WithSubject(
            Sub(subject, data, id)
                data.SetupGet(Function(x) x.Feature).Returns((New Mock(Of IFeatureData)).Object)
                subject.Name.ShouldBeNull
                data.Verify(Function(x) x.Feature.ReadName(id))
            End Sub)
    End Sub
End Class
