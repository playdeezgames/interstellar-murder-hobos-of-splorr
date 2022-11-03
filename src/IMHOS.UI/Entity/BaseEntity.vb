Public MustInherit Class BaseEntity
    Implements IEntity
    Protected parent As IEntity
    Protected offset As (Single, Single)
    Sub New(parent As IEntity, offset As (Single, Single))
        Me.parent = parent
        Me.offset = offset
    End Sub

    Public ReadOnly Property Position As (Single, Single) Implements IEntity.Position
        Get
            Dim parentPosition = If(parent IsNot Nothing, parent.Position, (0.0F, 0.0F))
            Return (parentPosition.Item1 + offset.Item1, parentPosition.Item2 + offset.Item2)
        End Get
    End Property

    Public MustOverride Sub Draw(renderer As Object) Implements IEntity.Draw
End Class
