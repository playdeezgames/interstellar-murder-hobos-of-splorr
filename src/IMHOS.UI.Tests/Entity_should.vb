Public Class Entity_should
    <Fact>
    Sub draw()
        Dim sprite As New Mock(Of ISprite)
        Const X = 1.0F
        Const Y = 2.0F
        Dim color As New Mock(Of IReadValueSource(Of (Byte, Byte, Byte, Byte)))
        Dim rotation As New Mock(Of IReadValueSource(Of Single))
        Dim renderer As Object = Nothing
        Dim subject As IEntity = New Entity(sprite.Object, (X, Y), color.Object, rotation.Object)
        subject.Draw(renderer)
        sprite.Verify(Sub(s) s.Draw(renderer, (X, Y), (0, 0, 0, 0), 0.0F))
        rotation.Verify(Function(w) w.Read)
        rotation.VerifyNoOtherCalls()
        color.Verify(Function(w) w.Read)
        color.VerifyNoOtherCalls()
        sprite.VerifyNoOtherCalls()
    End Sub
End Class
