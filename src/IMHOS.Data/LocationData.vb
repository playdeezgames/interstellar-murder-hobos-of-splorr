Public Class LocationData
    Implements ILocationData
    Private ReadOnly data As IStageData
    Private ReadOnly table As New Dictionary(Of Guid, String)
    Sub New(data As IStageData)
        Me.data = data
    End Sub
    Public Function Create(name As String) As Guid Implements ILocationData.Create
        Dim id = Guid.NewGuid
        table(id) = name
        Return id
    End Function

    Public Function ReadName(id As Guid) As String Implements ILocationData.ReadName
        Dim name As String = Nothing
        If table.TryGetValue(id, name) Then
            Return name
        End If
        Return Nothing
    End Function
End Class
