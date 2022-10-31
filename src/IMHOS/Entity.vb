Public Class Entity
    Implements IEntity
    Private sprite As Sprite
    Private position As (Single, Single)
    Private color As (Byte, Byte, Byte, Byte)
    Private rotation As Single
    Sub New(sprite As Sprite, position As (Single, Single), color As (Byte, Byte, Byte, Byte), rotation As Single)
        Me.sprite = sprite
        Me.position = position
        Me.color = color
        Me.rotation = rotation
    End Sub
    Sub Draw(renderer As Object) Implements IEntity.Draw
        sprite.Draw(renderer, position, color, rotation)
    End Sub
End Class
