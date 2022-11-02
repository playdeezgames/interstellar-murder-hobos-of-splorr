Public Interface IEntity
    ReadOnly Property Position As (Single, Single)
    Sub Draw(renderer As Object)
End Interface