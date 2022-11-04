Public Class VesselData_should
    <Fact>
    Sub instantiate()
        Dim subject As IVesselData = New VesselData
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub create()
        Const name = "one"
        Dim subject As IVesselData = New VesselData
        subject.Create(name).ShouldNotBe(Guid.Empty)
    End Sub
    <Fact>
    Sub have_a_name()
        Dim id = Guid.NewGuid
        Dim subject As IVesselData = New VesselData
        subject.ReadName(id).ShouldBeNull
    End Sub
End Class
