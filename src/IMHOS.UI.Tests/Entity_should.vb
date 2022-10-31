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
        Const Rotation = 7.0F
        Dim renderer As Object = Nothing
        Dim subject As IEntity = New Entity(sprite.Object, (X, Y), (R, G, B, A), Rotation)
        subject.Draw(renderer)
        sprite.Verify(Sub(s) s.Draw(renderer, (X, Y), (R, G, B, A), Rotation))
        sprite.VerifyNoOtherCalls()
    End Sub
End Class
