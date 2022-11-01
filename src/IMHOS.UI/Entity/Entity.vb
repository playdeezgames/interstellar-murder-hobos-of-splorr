Imports System.ComponentModel

Public Class Entity
    Implements IEntity
    Private sprite As ISprite
    Private position As (Single, Single)
    Private color As (Byte, Byte, Byte, Byte)
    Private rotation As IValueSource(Of Single)
    Sub New(sprite As ISprite, position As (Single, Single), color As (Byte, Byte, Byte, Byte), rotation As IValueSource(Of Single))
        Me.sprite = sprite
        Me.position = position
        Me.color = color
        Me.rotation = rotation
    End Sub
    Sub Draw(renderer As Object) Implements IEntity.Draw
        sprite.Draw(renderer, position, color, rotation.Read())
    End Sub
End Class
