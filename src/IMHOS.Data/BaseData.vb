Public MustInherit Class BaseData
    Protected ReadOnly data As IStageData
    Sub New(data As IStageData)
        Me.data = data
    End Sub
End Class
