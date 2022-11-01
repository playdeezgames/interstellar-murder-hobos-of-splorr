Public Interface IEntities
    Function Add(instance As IEntity) As Long
    Function Read(id As Long) As IEntity
    Sub Draw(renderer As Object)

End Interface
