Public Class Sprites_should
    <Fact>
    Sub read()
        Const spriteId = 1L
        Const textureRegionId = 2L
        Dim textureRegions As New Mock(Of ITextureRegions)
        Dim subject As ISprites = New Sprites(textureRegions.Object, New Dictionary(Of Long, (Long, (Single, Single), (Single, Single), (Boolean, Boolean), Single)) From
        {
            {spriteId, (textureRegionId, (3.0F, 4.0F), (5.0F, 6.0F), (False, True), 7.0F)}
        })
        subject.Read(spriteId).ShouldNotBeNull
        textureRegions.Verify(Function(x) x.Read(textureRegionId))
        textureRegions.VerifyNoOtherCalls()
    End Sub
End Class
