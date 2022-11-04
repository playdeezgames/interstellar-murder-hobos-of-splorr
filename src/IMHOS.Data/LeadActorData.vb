Public Class LeadActorData
    Implements ILeadActorData
    Private actorId As Guid?

    Public Sub Write(actorId As Guid) Implements ILeadActorData.Write
        Me.actorId = actorId
    End Sub
End Class
