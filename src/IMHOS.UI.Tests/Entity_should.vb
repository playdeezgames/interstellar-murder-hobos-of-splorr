Public Class Entity_should
    <Fact>
    Sub draw()
        Dim sprite As New Mock(Of ISprite)
        Const X = 1.0F
        Const Y = 2.0F
        Const R As Byte = 3
        Const G As Byte = 4
        Const B As Byte = 5
        Const A As Byte = 6
        Dim rotation As New Mock(Of IValueSource(Of Single))
        Dim renderer As Object = Nothing
        Dim subject As IEntity = New Entity(sprite.Object, (X, Y), (R, G, B, A), rotation.Object)
        subject.Draw(renderer)
        sprite.Verify(Sub(s) s.Draw(renderer, (X, Y), (R, G, B, A), 0.0F))
        rotation.Verify(Function(w) w.Read)
        rotation.VerifyNoOtherCalls()
        sprite.VerifyNoOtherCalls()
    End Sub
End Class
