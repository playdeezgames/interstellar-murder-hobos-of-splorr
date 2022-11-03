Public Class Entity
    Inherits BaseEntity
    Implements IEntity
    Private sprite As IReadValueSource(Of ISprite)
    Private color As (Byte, Byte, Byte, Byte)
    Private rotation As Single
    Sub New(
           parent As IEntity,
           sprite As IReadValueSource(Of ISprite),
           offset As (Single, Single),
           color As (Byte, Byte, Byte, Byte),
           rotation As Single)
        MyBase.New(parent, offset)
        Me.sprite = sprite
        Me.color = color
        Me.rotation = rotation
    End Sub
    Overrides Sub Draw(renderer As Object) Implements IEntity.Draw
        MyBase.Draw(renderer)
        sprite.Read().Draw(renderer, Position, color, rotation)
    End Sub

    Public Overrides Sub Update(delta As TimeSpan)
        MyBase.Update(delta)
    End Sub
End Class
