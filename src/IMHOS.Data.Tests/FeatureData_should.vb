Public Class FeatureData_should
    <Fact>
    Sub instantiate()
        Dim subject As IFeatureData = New FeatureData
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub create()
        Const name = "one"
        Dim locationId = Guid.NewGuid
        Dim subject As IFeatureData = New FeatureData
        subject.Create(name, locationId).ShouldNotBe(Guid.Empty)
    End Sub
End Class
