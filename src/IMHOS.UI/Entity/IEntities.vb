Public Interface IEntities
    Function Add(child As IEntity) As Long
    Function Read(id As Long) As IEntity
    Sub Draw(renderer As Object)

End Interface
