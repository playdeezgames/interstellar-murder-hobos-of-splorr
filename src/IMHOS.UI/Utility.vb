Imports System.Runtime.CompilerServices

Public Module Utility
    <Extension>
    Public Function ToReadOnlyValueSource(Of TValue)(value As TValue) As IReadValueSource(Of TValue)
        Return New ReadOnlyValueSource(Of TValue)(value)
    End Function
End Module
