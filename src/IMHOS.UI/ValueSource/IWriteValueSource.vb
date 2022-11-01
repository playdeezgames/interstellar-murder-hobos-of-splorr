Public Interface IWriteValueSource(Of TValue)
    Inherits IReadValueSource(Of TValue)
    Sub Write(value As TValue)
End Interface
