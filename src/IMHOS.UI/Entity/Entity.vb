﻿Imports System.ComponentModel

Public Class Entity
    Implements IEntity
    Private sprite As ISprite
    Private position As IReadValueSource(Of (Single, Single))
    Private color As IReadValueSource(Of (Byte, Byte, Byte, Byte))
    Private rotation As IReadValueSource(Of Single)
    Sub New(
           sprite As ISprite,
           position As IReadValueSource(Of (Single, Single)),
           color As IReadValueSource(Of (Byte, Byte, Byte, Byte)),
           rotation As IReadValueSource(Of Single))
        Me.sprite = sprite
        Me.position = position
        Me.color = color
        Me.rotation = rotation
    End Sub
    Sub Draw(renderer As Object) Implements IEntity.Draw
        sprite.Draw(renderer, position.Read, color.Read(), rotation.Read())
    End Sub
End Class
