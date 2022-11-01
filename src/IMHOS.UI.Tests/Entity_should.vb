Public Class Entity_should
    <Fact>
    Sub draw()
        Dim sprite As New Mock(Of IReadValueSource(Of ISprite))
        sprite.Setup(Function(x) x.Read).Returns((New Mock(Of ISprite)).Object)
        Dim position As New Mock(Of IReadValueSource(Of (Single, Single)))
        Dim color As New Mock(Of IReadValueSource(Of (Byte, Byte, Byte, Byte)))
        Dim rotation As New Mock(Of IReadValueSource(Of Single))
        Dim renderer As Object = Nothing
        Dim subject As IEntity = New Entity(sprite.Object, position.Object, color.Object, rotation.Object)
        subject.Draw(renderer)
        sprite.Verify(Sub(s) s.Read.Draw(renderer, (0.0F, 0.0F), (0, 0, 0, 0), 0.0F))
        rotation.Verify(Function(w) w.Read)
        rotation.VerifyNoOtherCalls()
        color.Verify(Function(w) w.Read)
        color.VerifyNoOtherCalls()
        position.Verify(Function(x) x.Read)
        position.VerifyNoOtherCalls()
        sprite.VerifyNoOtherCalls()
    End Sub
End Class
