Public Interface IEntity
    Function Add(child As IEntity) As Guid
    Function Read(id As Guid) As IEntity
    ReadOnly Property Position As (Single, Single)
    Property Offset As (Single, Single)
    Sub Update(delta As TimeSpan)
    Sub Draw(renderer As Object)
End Interface