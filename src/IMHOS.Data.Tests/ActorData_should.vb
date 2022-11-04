Public Class ActorData_should
    <Fact>
    Sub instantiate()
        Dim subject As IActorData = New ActorData
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub create()
        Const name = "one"
        Dim subject As IActorData = New ActorData
        subject.Create(name).ShouldNotBe(Guid.Empty)
    End Sub
    <Fact>
    Sub have_name_it_was_created_with()
        Const name = "one"
        Dim subject As IActorData = New ActorData
        Dim id = subject.Create(name)
        subject.ReadName(id).ShouldBe(name)
    End Sub
End Class
