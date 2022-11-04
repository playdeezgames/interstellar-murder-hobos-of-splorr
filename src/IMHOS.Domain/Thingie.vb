Public MustInherit Class Thingie
    Protected ReadOnly data As IStageData
    Protected ReadOnly id As Guid
    Sub New(data As IStageData, id As Guid)
        Me.data = data
        Me.id = id
    End Sub
End Class
