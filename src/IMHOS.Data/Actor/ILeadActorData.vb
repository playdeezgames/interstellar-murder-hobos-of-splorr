Public Interface ILeadActorData
    Sub Write(actorId As Guid)
    Function Read() As Guid?
End Interface
