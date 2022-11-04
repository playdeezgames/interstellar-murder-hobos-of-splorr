Public Interface IActorData
    Function Create(name As String, locationId As Guid) As Guid
    Function ReadName(actorId As Guid) As String
    Function ReadLocation(actorId As Guid) As Guid?
End Interface
