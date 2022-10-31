Public Class Entities
    Private ReadOnly children As New List(Of Entity)
    Function Add(instance As Entity) As Long
        Dim id = children.LongCount
        children.Add(instance)
        Return id
    End Function
    Function Read(id As Long) As Entity
        Return children(CInt(id))
    End Function
    Sub Draw(spriteBatch As SpriteBatch)
        For Each child In children
            child.Draw(spriteBatch)
        Next
    End Sub
End Class
