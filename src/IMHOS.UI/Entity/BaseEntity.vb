Public MustInherit Class BaseEntity
    Implements IEntity
    Protected parent As IEntity = Nothing
    Sub New(parent As IEntity, offset As (Single, Single), rotation As Single)
        Me.parent = parent
        Me.Offset = offset
        Me.Rotation = rotation
    End Sub

    Public ReadOnly Property Position As (Single, Single) Implements IEntity.Position
        Get
            Dim parentPosition = If(parent IsNot Nothing, parent.Position, (0.0F, 0.0F))
            Return (parentPosition.Item1 + offset.Item1, parentPosition.Item2 + offset.Item2)
        End Get
    End Property

    Public Property Offset As (Single, Single) Implements IEntity.Offset
    Public Property Rotation As Single Implements IEntity.Rotation

    Public Overridable Sub Update(delta As TimeSpan) Implements IEntity.Update
        For Each child In children
            child.Value.Update(delta)
        Next
    End Sub
    Protected ReadOnly children As New Dictionary(Of Guid, IEntity)
    Function Add(child As IEntity) As Guid Implements IEntity.Add
        Dim id = Guid.NewGuid
        children.Add(id, child)
        Return id
    End Function
    Function Read(id As Guid) As IEntity Implements IEntity.Read
        Return children(id)
    End Function
    Overridable Sub Draw(renderer As Object) Implements IEntity.Draw
        For Each child In children
            child.Value.Draw(renderer)
        Next
    End Sub
End Class
