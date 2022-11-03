Public Class Entity_also_should
    <Fact>
    Sub add()
        Dim entity As New Mock(Of IEntity)
        Dim subject As IEntity = New Entities(Nothing, (0.0F, 0.0F))
        subject.Add(entity.Object).ShouldNotBe(Guid.Empty)
        entity.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub read()
        Dim subject As IEntity = New Entities(Nothing, (0.0F, 0.0F))
        Should.Throw(Of KeyNotFoundException)(Sub()
                                                  subject.Read(Guid.NewGuid)
                                              End Sub)
    End Sub
    <Fact>
    Sub draw()
        Dim subject As IEntity = New Entities(Nothing, (0.0F, 0.0F))
        Dim renderer As Object = Nothing
        Dim entity As New Mock(Of IEntity)
        subject.Add(entity.Object)
        subject.Draw(renderer)
        entity.Verify(Sub(x) x.Draw(renderer))
        entity.VerifyNoOtherCalls()
    End Sub
End Class


