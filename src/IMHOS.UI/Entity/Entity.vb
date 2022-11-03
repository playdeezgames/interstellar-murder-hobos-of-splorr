Public Class SpriteEntity
    Inherits BaseEntity
    Implements IEntity
    Private sprite As ISprite
    Private color As (Byte, Byte, Byte, Byte)
    Sub New(
           parent As IEntity,
           sprite As ISprite,
           offset As (Single, Single),
           color As (Byte, Byte, Byte, Byte),
           rotation As Single)
        MyBase.New(parent, offset, rotation)
        Me.sprite = sprite
        Me.color = color
    End Sub
    Overrides Sub Draw(renderer As Object) Implements IEntity.Draw
        MyBase.Draw(renderer)
        sprite.Draw(renderer, Position, color, rotation)
    End Sub
End Class
