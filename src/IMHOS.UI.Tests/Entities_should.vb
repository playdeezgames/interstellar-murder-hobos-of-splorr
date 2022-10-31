Public Class Entities_should
    <Fact>
    Sub add()
        Dim entity As New Mock(Of IEntity)
        Dim subject As IEntities = New Entities()
        subject.Add(entity.Object).ShouldBe(0)
        entity.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub read()
        Dim subject As IEntities = New Entities()
        Should.Throw(Of ArgumentOutOfRangeException)(Sub()
                                                         subject.Read(0)
                                                     End Sub)
    End Sub
    <Fact>
    Sub draw()
        Dim subject As IEntities = New Entities()
        Dim renderer As Object = Nothing
        Dim entity As New Mock(Of IEntity)
        subject.Add(entity.Object)
        subject.Draw(renderer)
        entity.Verify(Sub(x) x.Draw(renderer))
        entity.VerifyNoOtherCalls()
    End Sub
End Class


