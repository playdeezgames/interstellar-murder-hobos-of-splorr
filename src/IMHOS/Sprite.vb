Public Class Sprite
    Implements ISprite
    Private textureRegion As ITextureRegion
    Private origin As (Single, Single)
    Private scale As (Single, Single)
    Private effects As (Boolean, Boolean)
    Private layerDepth As Single
    Sub New(
        textureRegion As ITextureRegion,
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
            position,
            color,
            rotation,
            origin,
            scale,
            effects,
            layerDepth)
    End Sub
End Class
