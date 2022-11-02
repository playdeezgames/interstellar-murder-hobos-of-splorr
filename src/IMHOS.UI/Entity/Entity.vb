Public Class Entity
    Inherits BaseEntity
    Implements IEntity
    Private sprite As IReadValueSource(Of ISprite)
    Private color As IReadValueSource(Of (Byte, Byte, Byte, Byte))
    Private rotation As IReadValueSource(Of Single)
    Sub New(
           parent As IEntity,
           sprite As IReadValueSource(Of ISprite),
           relativePosition As IReadValueSource(Of (Single, Single)),
           color As IReadValueSource(Of (Byte, Byte, Byte, Byte)),
           rotation As IReadValueSource(Of Single))
        MyBase.New(parent, relativePosition)
        Me.sprite = sprite
        Me.color = color
        Me.rotation = rotation
    End Sub
    Overrides Sub Draw(renderer As Object) Implements IEntity.Draw
        sprite.Read().Draw(renderer, Position, color.Read(), rotation.Read())
    End Sub
End Class
