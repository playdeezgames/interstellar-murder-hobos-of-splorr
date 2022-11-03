Public Class Entity_should
    Private Sub WithSubject(
                           stuffToDo As Action(Of IEntity,
                           Mock(Of ISprite)))
        Dim sprite As New Mock(Of ISprite)
        Dim position = (0.0F, 1.0F)
        Dim rotation = 3.0F
        Dim subject As IEntity = New SpriteEntity(Nothing, sprite.Object, position, (4, 5, 6, 7), rotation)
        stuffToDo(subject, sprite)
        sprite.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub draw()
        WithSubject(
            Sub(subject, sprite)
                Dim renderer As Object = Nothing
                subject.Draw(renderer)
                sprite.Verify(Sub(s) s.Draw(renderer, (0.0F, 1.0F), (4, 5, 6, 7), 3.0F))
            End Sub)

    End Sub
    <Fact>
    Sub have_a_position()
        WithSubject(
            Sub(subject, sprite)
                subject.Position.ShouldBe((0.0F, 1.0F))
            End Sub)
    End Sub
    <Fact>
    Sub update()
        WithSubject(
            Sub(subject, sprite)
                subject.Update(New TimeSpan(1L))
            End Sub)
    End Sub
    <Fact>
    Sub read_offset()
        WithSubject(
            Sub(subject, sprite)
                subject.Offset.ShouldBe((0.0F, 1.0F))
            End Sub)
    End Sub
    <Fact>
    Sub write_offset()
        WithSubject(
            Sub(subject, sprite)
                subject.Offset = (1.0F, 2.0F)
                subject.Offset.ShouldBe((1.0F, 2.0F))
            End Sub)
    End Sub
End Class
