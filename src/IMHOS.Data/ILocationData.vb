Public Interface ILocationData
    Function Create(name As String) As Guid
    Function ReadName(id As Guid) As String
End Interface
