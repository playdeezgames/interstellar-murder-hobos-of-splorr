
Public Class Sprite
    Implements ISprite
    Private textureRegion As TextureRegion
    Private origin As (Single, Single)
    Private scale As (Single, Single)
    Private effects As (Boolean, Boolean)
    Private layerDepth As Single
    Sub New(
        textureRegion As TextureRegion,
        origin As (Single, Single),
        scale As (Single, Single),
        effects As (Boolean, Boolean),
        layerDepth As Single)
        Me.textureRegion = textureRegion
        Me.origin = origin
        Me.scale = scale
        Me.effects = effects
        Me.layerDepth = layerDepth
    End Sub
    Sub Draw(
            spriteBatch As Object,
            position As (Single, Single),
            color As (Byte, Byte, Byte, Byte),
            rotation As Single) Implements ISprite.Draw
        textureRegion.Draw(
            spriteBatch,
            New Vector2(position.Item1, position.Item2),
            New Color(color.Item1, color.Item2, color.Item3, color.Item4),
            rotation,
            New Vector2(origin.Item1, origin.Item2),
            New Vector2(scale.Item1, scale.Item2),
            If(effects.Item1, SpriteEffects.FlipHorizontally, SpriteEffects.None) And If(effects.Item2, SpriteEffects.FlipVertically, SpriteEffects.None),
            layerDepth)
    End Sub
End Class
