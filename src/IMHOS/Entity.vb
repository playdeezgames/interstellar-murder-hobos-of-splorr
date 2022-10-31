Public Class Entity
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
    Sub Draw(spriteBatch As SpriteBatch)
        sprite.Draw(spriteBatch, position, color, rotation)
    End Sub
End Class
