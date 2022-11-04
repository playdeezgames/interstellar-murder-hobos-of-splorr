Public Class LeadActorData_should
    <Fact>
    Sub instantiate()
        Dim subject As ILeadActorData = New LeadActorData
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub write()
        Dim subject As ILeadActorData = New LeadActorData
        subject.Write(Guid.NewGuid)
    End Sub
    <Fact>
    Sub read()
        Dim subject As ILeadActorData = New LeadActorData
        subject.Read.ShouldBeNull
    End Sub
End Class
