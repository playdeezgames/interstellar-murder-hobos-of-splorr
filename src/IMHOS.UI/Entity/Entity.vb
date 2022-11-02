Public Class Entity
    Implements IEntity
    Private parent As IEntity
    Private sprite As IReadValueSource(Of ISprite)
    Private position As IReadValueSource(Of (Single, Single))
    Private color As IReadValueSource(Of (Byte, Byte, Byte, Byte))
    Private rotation As IReadValueSource(Of Single)
    Sub New(
           parent As IEntity,
           sprite As IReadValueSource(Of ISprite),
           position As IReadValueSource(Of (Single, Single)),
           color As IReadValueSource(Of (Byte, Byte, Byte, Byte)),
           rotation As IReadValueSource(Of Single))
        Me.sprite = sprite
        Me.position = position
        Me.color = color
        Me.rotation = rotation
    End Sub
    Sub Draw(renderer As Object) Implements IEntity.Draw
        sprite.Read().Draw(renderer, position.Read, color.Read(), rotation.Read())
    End Sub
End Class
