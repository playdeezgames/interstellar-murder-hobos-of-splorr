Public Class Stage_should
    Private Sub WithSubject(stuffToDo As Action(Of IStage))
        Dim subject As IStage = New Stage()
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
    Sub have_lead_actor()
        WithSubject(
            Sub(subject)
                subject.LeadActor.ShouldNotBeNull
            End Sub)
    End Sub
End Class

