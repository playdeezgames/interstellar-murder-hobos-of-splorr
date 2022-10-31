Public Class Sprite
    Private textureRegion As TextureRegion
    Private origin As Vector2
    Private scale As Vector2
    Private effects As SpriteEffects
    Private layerDepth As Single
    Sub New(
        textureRegion As TextureRegion,
        origin As Vector2,
        scale As Vector2,
        effects As SpriteEffects,
        layerDepth As Single)
        Me.textureRegion = textureRegion
        Me.origin = origin
        Me.scale = scale
        Me.effects = effects
        Me.layerDepth = layerDepth
    End Sub
    Friend Sub Draw(spriteBatch As SpriteBatch, position As Vector2, color As Color, rotation As Single)
        textureRegion.Draw(spriteBatch, position, color, rotation, origin, scale, effects, layerDepth)
    End Sub
End Class
