Public MustInherit Class BaseEntity
    Implements IEntity
    Protected parent As IEntity
    Protected relativePosition As IReadValueSource(Of (Single, Single))
    Sub New(parent As IEntity, relativePosition As IReadValueSource(Of (Single, Single)))
        Me.parent = parent
        Me.relativePosition = relativePosition
    End Sub

    Public ReadOnly Property Position As (Single, Single) Implements IEntity.Position
        Get
            Dim parentPosition = If(parent IsNot Nothing, parent.Position, (0.0F, 0.0F))
            Return (parentPosition.Item1 + relativePosition.Read.Item1, parentPosition.Item2 + relativePosition.Read.Item2)
        End Get
    End Property

    Public MustOverride Sub Draw(renderer As Object) Implements IEntity.Draw
End Class
