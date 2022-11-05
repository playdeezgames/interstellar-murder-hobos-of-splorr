Public Interface IFeature
    ReadOnly Property Name As String
    ReadOnly Property Verbs As IEnumerable(Of IVerb)
End Interface
