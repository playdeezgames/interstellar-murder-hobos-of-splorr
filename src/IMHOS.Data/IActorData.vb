Public Interface IActorData
    Function Create(name As String, locationId As Guid) As Guid
    Function ReadName(id As Guid) As String
End Interface
