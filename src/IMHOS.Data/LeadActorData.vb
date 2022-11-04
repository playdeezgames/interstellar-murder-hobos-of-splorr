Public Class LeadActorData
    Implements ILeadActorData
    Private actorId As Guid? = Nothing

    Public Sub Write(actorId As Guid) Implements ILeadActorData.Write
        Me.actorId = actorId
    End Sub

    Public Function Read() As Guid? Implements ILeadActorData.Read
        Return actorId
    End Function
End Class
