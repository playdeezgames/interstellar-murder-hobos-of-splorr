Public Class Entity_should
    Private Sub WithSubject(
                           stuffToDo As Action(Of IEntity,
                           Mock(Of IReadValueSource(Of ISprite)),
                           Mock(Of IReadValueSource(Of (Single, Single))),
                           Mock(Of IReadValueSource(Of (Byte, Byte, Byte, Byte))),
                           Mock(Of IReadValueSource(Of Single))))
        Dim sprite As New Mock(Of IReadValueSource(Of ISprite))
        sprite.Setup(Function(x) x.Read).Returns((New Mock(Of ISprite)).Object)
        Dim position As New Mock(Of IReadValueSource(Of (Single, Single)))
        Dim color As New Mock(Of IReadValueSource(Of (Byte, Byte, Byte, Byte)))
        Dim rotation As New Mock(Of IReadValueSource(Of Single))
        Dim subject As IEntity = New Entity(Nothing, sprite.Object, position.Object, color.Object, rotation.Object)
        stuffToDo(subject, sprite, position, color, rotation)
        color.VerifyNoOtherCalls()
        rotation.VerifyNoOtherCalls()
        position.VerifyNoOtherCalls()
        sprite.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub draw()
        WithSubject(
            Sub(subject, sprite, position, color, rotation)
                Dim renderer As Object = Nothing
                subject.Draw(renderer)
                sprite.Verify(Sub(s) s.Read.Draw(renderer, (0.0F, 0.0F), (0, 0, 0, 0), 0.0F))
                rotation.Verify(Function(w) w.Read)
                color.Verify(Function(w) w.Read)
                position.Verify(Function(x) x.Read)
            End Sub)

    End Sub
    <Fact>
    Sub have_a_position()
        WithSubject(
            Sub(subject, sprite, position, color, rotation)
                subject.Position.ShouldBe((0.0F, 0.0F))
                position.Verify(Function(x) x.Read)
            End Sub)
    End Sub
End Class
