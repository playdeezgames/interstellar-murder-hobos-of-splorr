Public Class FixedValueSource(Of TValue)
    Implements IValueSource(Of TValue)

    Private value As TValue

    Public Sub New(value As TValue)
        Me.value = value
    End Sub

    Public Function Read() As TValue Implements IValueSource(Of TValue).Read
        Return value
    End Function
End Class
