Imports IMHOS.Data

Public Class Stage_should
    Private Sub WithSubject(stuffToDo As Action(Of IStage, Mock(Of IStageData)))
        Dim data As New Mock(Of IStageData)
        Dim subject As IStage = New Stage(data.Object)
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
    Sub have_lead_actor()
        WithSubject(
            Sub(subject, data)
                subject.LeadActor.ShouldNotBeNull
            End Sub)
    End Sub
End Class

