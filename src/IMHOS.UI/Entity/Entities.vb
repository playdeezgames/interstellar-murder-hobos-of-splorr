Public Class Entities
    Implements IEntities
    Private ReadOnly children As New List(Of IEntity)
    Function Add(instance As IEntity) As Long Implements IEntities.Add
        Dim id = children.LongCount
        children.Add(instance)
        Return id
    End Function
    Function Read(id As Long) As IEntity Implements IEntities.Read
        Return children(CInt(id))
    End Function
    Sub Draw(renderer As Object) Implements IEntities.Draw
        For Each child In children
            child.Draw(renderer)
        Next
    End Sub
End Class
