Public Class Sprite
    Private texture As Texture2D
    Private sourceRectangle As Rectangle?
    Private origin As Vector2
    Private scale As Vector2
    Private effects As SpriteEffects
    Private layerDepth As Single
    Sub New(
        texture As Texture2D,
        sourceRectangle As Rectangle?,
        origin As Vector2,
        scale As Vector2,
        effects As SpriteEffects,
        layerDepth As Single)
        Me.texture = texture
        Me.sourceRectangle = sourceRectangle
        Me.origin = origin
        Me.scale = scale
        Me.effects = effects
        Me.layerDepth = layerDepth
    End Sub
    Friend Sub Draw(spriteBatch As SpriteBatch, position As Vector2, color As Color, rotation As Single)
        spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth)
    End Sub
End Class
