Public Class ShipEntity_should
    Private Sub WithSubject(
                           stuffToDo As Action(Of IEntity,
                           Mock(Of ISprite)))
        Dim sprite As New Mock(Of ISprite)
        Dim position = (0.0F, 1.0F)
        Dim rotation = 3.0F
        Dim subject As IEntity = New ShipEntity(Nothing, sprite.Object, position, (4, 5, 6, 7), rotation)
        stuffToDo(subject, sprite)
        sprite.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject, sprite)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
End Class
