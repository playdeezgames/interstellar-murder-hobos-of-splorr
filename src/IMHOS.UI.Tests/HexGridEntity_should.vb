Public Class HexGridEntity_should
    Sub WithSubject(stuffToDo As Action(Of IHexGridEntity,
                    Mock(Of IPlotter),
                    Mock(Of ISprite)))
        Dim plotter As New Mock(Of IPlotter)
        Dim sprite As New Mock(Of ISprite)
        Dim subject As IHexGridEntity = New HexGridEntity(Nothing, (0.0F, 1.0F), plotter.Object, 1L, sprite.Object)
        stuffToDo(subject, plotter, sprite)
        plotter.VerifyNoOtherCalls()
        sprite.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub draw()
        WithSubject(
            Sub(subject, plotter, sprite)
                Dim renderer As Object = Nothing
                subject.Draw(renderer)
                plotter.Verify(Function(x) x.PlotX(0L, 0L))
                plotter.Verify(Function(x) x.PlotY(0L, 0L))
                sprite.Verify(Sub(x) x.Draw(Nothing, (0, 1), (255, 255, 255, 255), 0))
            End Sub)
    End Sub
    <Fact>
    Sub read_hex_that_exists()
        WithSubject(
            Sub(subject, plotter, sprite)
                subject.Hex(0L, 0L).ShouldNotBeNull
                plotter.Verify(Function(x) x.PlotX(0L, 0L))
                plotter.Verify(Function(x) x.PlotY(0L, 0L))
            End Sub)
    End Sub
    <Fact>
    Sub update()
        WithSubject(
            Sub(subject, plotter, sprite)
                subject.Update(New TimeSpan(1L))
                plotter.Verify(Function(x) x.PlotX(0L, 0L))
                plotter.Verify(Function(x) x.PlotY(0L, 0L))
            End Sub)
    End Sub
End Class
