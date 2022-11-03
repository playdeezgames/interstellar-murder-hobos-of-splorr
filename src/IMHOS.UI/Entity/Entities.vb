Public Class Entities
    Implements IEntities
    Private ReadOnly children As New Dictionary(Of Guid, IEntity)
    Function Add(child As IEntity) As Guid Implements IEntities.Add
        Dim id = Guid.NewGuid
        children.Add(id, child)
        Return id
    End Function
    Function Read(id As Guid) As IEntity Implements IEntities.Read
        Return children(id)
    End Function
    Sub Draw(renderer As Object) Implements IEntities.Draw
        For Each child In children
            child.Value.Draw(renderer)
        Next
    End Sub
End Class
