Public Class Sprite_should
    <Fact>
    Sub draw()
        Dim textureRegion As New Mock(Of ITextureRegion)
        Dim renderer As Object = Nothing
        Dim subject As ISprite = New Sprite(textureRegion.Object, (1.0F, 2.0F), (3.0F, 4.0F), (False, True), 5.0F)
        subject.Draw(renderer, (6.0F, 7.0F), (8, 9, 10, 11), 12.0F)
        textureRegion.Verify(Sub(x) x.Draw(renderer, (6.0F, 7.0F), (8, 9, 10, 11), 12.0F, (1.0F, 2.0F), (3.0F, 4.0F), (False, True), 5.0F))
        textureRegion.VerifyNoOtherCalls()
    End Sub
End Class
