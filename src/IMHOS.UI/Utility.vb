Imports System.Runtime.CompilerServices

Module Utility
    <Extension>
    Function ToReadOnlyValueSource(Of TValue)(value As TValue) As IReadValueSource(Of TValue)
        Return New ReadOnlyValueSource(Of TValue)(value)
    End Function
End Module
