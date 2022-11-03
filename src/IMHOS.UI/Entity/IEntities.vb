Public Interface IEntities
    Function Add(child As IEntity) As Guid
    Function Read(id As Guid) As IEntity
    Sub Draw(renderer As Object)

End Interface
