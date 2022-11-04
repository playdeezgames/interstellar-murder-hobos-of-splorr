Public Class FeatureData_should
    <Fact>
    Sub instantiate()
        Dim subject As IFeatureData = New FeatureData
        subject.ShouldNotBeNull
    End Sub
End Class
