Public Class TextureRegion
    Private texture As Texture2D
    Private sourceRectangle As Rectangle?
    Sub New(texture As Texture2D, sourceRectangle As Rectangle?)
        Me.texture = texture
        Me.sourceRectangle = sourceRectangle
    End Sub
    Sub Draw(spriteBatch As SpriteBatch, position As Vector2, color As Color, rotation As Single, origin As Vector2, scale As Vector2, effects As SpriteEffects, layerDepth As Single)
        spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth)
    End Sub
End Class
