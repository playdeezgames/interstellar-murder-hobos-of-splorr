Public Class ReadOnlyValueSource(Of TValue)
    Implements IReadValueSource(Of TValue)

    Protected value As TValue

    Public Sub New(value As TValue)
        Me.value = value
    End Sub

    Public Function Read() As TValue Implements IReadValueSource(Of TValue).Read
        Return value
    End Function
End Class
