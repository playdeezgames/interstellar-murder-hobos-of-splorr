Public Class Entity
    Private sprite As Sprite
    Private position As Vector2
    Private color As Color
    Private rotation As Single
    Sub New(sprite As Sprite, position As Vector2, color As Color, rotation As Single)
        Me.sprite = sprite
        Me.position = position
        Me.color = color
        Me.rotation = rotation
    End Sub
    Sub Draw(spriteBatch As SpriteBatch)
        sprite.Draw(spriteBatch, position, color, rotation)
    End Sub
End Class
