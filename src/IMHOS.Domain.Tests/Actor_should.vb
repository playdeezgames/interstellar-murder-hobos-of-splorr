Imports IMHOS.Data

Public Class Actor_should
    <Fact>
    Sub instantiate()
        Dim data As New Mock(Of IStageData)
        Dim id = Guid.NewGuid
        Dim subject As IActor = New Actor(data.Object, id)

        subject.ShouldNotBeNull

        data.VerifyNoOtherCalls()
    End Sub
End Class
