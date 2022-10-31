Public Class TextureRegion
    Implements ITextureRegion
    Private texture As Texture2D
    Private sourceRectangle As Rectangle?
    Sub New(texture As Texture2D, sourceRectangle As Rectangle?)
        Me.texture = texture
        Me.sourceRectangle = sourceRectangle
    End Sub
    Sub Draw(spriteBatch As Object, position As (Single, Single), color As (Byte, Byte, Byte, Byte), rotation As Single, origin As (Single, Single), scale As (Single, Single), effects As (Boolean, Boolean), layerDepth As Single) Implements ITextureRegion.Draw
        DirectCast(spriteBatch, SpriteBatch).Draw(
            texture,
            New Vector2(position.Item1, position.Item2),
            sourceRectangle,
            New Color(color.Item1, color.Item2, color.Item3, color.Item4),
            rotation,
            New Vector2(origin.Item1, origin.Item2),
            New Vector2(scale.Item1, scale.Item2),
            If(effects.Item1, SpriteEffects.FlipHorizontally, SpriteEffects.None) And If(effects.Item2, SpriteEffects.FlipVertically, SpriteEffects.None),
            layerDepth)
    End Sub
End Class
