Public Interface IHexGridEntity
    Inherits IEntity
    ReadOnly Property Hex(column As Long, row As Long) As IEntity
End Interface
