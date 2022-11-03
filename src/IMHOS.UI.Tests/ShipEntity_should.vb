Imports IMHOS.Domain

Public Class ShipEntity_should
    Private Sub WithSubject(
                           stuffToDo As Action(Of IEntity,
                           Mock(Of ISprite),
                           Mock(Of IShip)))
        Dim sprite As New Mock(Of ISprite)
        Dim ship As New Mock(Of IShip)
        Dim position = (0.0F, 1.0F)
        Dim rotation = 3.0F
        Dim subject As IEntity = New ShipEntity(ship.Object, Nothing, sprite.Object, position, (4, 5, 6, 7), rotation)
        stuffToDo(subject, sprite, ship)
        sprite.VerifyNoOtherCalls()
        ship.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub instantiate()
        WithSubject(
            Sub(subject, sprite, ship)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub update()
        WithSubject(
            Sub(subject, sprite, ship)
                subject.Update(New TimeSpan(1L))
                ship.VerifyGet(Function(x) x.Direction)
            End Sub)
    End Sub
End Class
