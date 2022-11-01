Public Class ReadWriteValueSource(Of TValue)
    Inherits ReadOnlyValueSource(Of TValue)
    Implements IWriteValueSource(Of TValue)

    Public Sub New(value As TValue)
        MyBase.New(value)
    End Sub

    Public Sub Write(value As TValue) Implements IWriteValueSource(Of TValue).Write
        Me.value = value
    End Sub
End Class
