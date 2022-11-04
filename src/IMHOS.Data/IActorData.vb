Public Interface IActorData
    Function Create(name As String) As Guid
    Function ReadName(id As Guid) As String
End Interface
