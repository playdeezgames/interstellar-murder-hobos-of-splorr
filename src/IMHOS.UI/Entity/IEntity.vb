Public Interface IEntity
    ReadOnly Property Position As (Single, Single)
    Sub Update(delta As TimeSpan)
    Sub Draw(renderer As Object)
End Interface