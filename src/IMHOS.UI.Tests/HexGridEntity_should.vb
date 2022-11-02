Public Class HexGridEntity_should
    Sub WithSubject(stuffToDo As Action(Of IHexGridEntity, Mock(Of IReadValueSource(Of (Single, Single))), Mock(Of IPlotter), Mock(Of ISprite)))
        Dim plotter As New Mock(Of IPlotter)
        Dim sprite As New Mock(Of ISprite)
        Dim position As New Mock(Of IReadValueSource(Of (Single, Single)))
        Dim subject As IHexGridEntity = New HexGridEntity(Nothing, position.Object, plotter.Object, 1L, sprite.Object)
        stuffToDo(subject, position, plotter, sprite)
        plotter.VerifyNoOtherCalls()
        sprite.VerifyNoOtherCalls()
        position.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub draw()
        WithSubject(
            Sub(subject, position, plotter, sprite)
                Dim renderer As Object = Nothing
                subject.Draw(renderer)
                plotter.Verify(Function(x) x.PlotX(0L, 0L))
                plotter.Verify(Function(x) x.PlotY(0L, 0L))
                sprite.Verify(Sub(x) x.Draw(Nothing, (0, 0), (255, 255, 255, 255), 0))
                position.Verify(Function(x) x.Read)
            End Sub)
    End Sub
    <Fact>
    Sub read_hex_that_exists()
        WithSubject(
            Sub(subject, position, plotter, sprite)
                subject.Hex(0L, 0L).ShouldNotBeNull
                plotter.Verify(Function(x) x.PlotX(0L, 0L))
                plotter.Verify(Function(x) x.PlotY(0L, 0L))
            End Sub)
    End Sub
End Class
