﻿Public Class Instances
    Private ReadOnly children As New List(Of SpriteInstance)
    Function Add(instance As SpriteInstance) As Long
        Dim id = children.LongCount
        children.Add(instance)
        Return id
    End Function
    Function Read(id As Long)
        Return children(id)
    End Function
    Sub Draw(spriteBatch As SpriteBatch)
        For Each child In children
            child.Draw(spriteBatch)
        Next
    End Sub
End Class
