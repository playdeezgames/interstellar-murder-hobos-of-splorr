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
End Class
