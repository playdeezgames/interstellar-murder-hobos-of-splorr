Public Class HexGridEntity_should
    <Fact>
    Sub draw()
        Dim plotter As New Mock(Of IPlotter)
        Dim sprite As New Mock(Of ISprite)
        Dim subject As IEntity = New HexGridEntity(Nothing, (0.0F, 0.0F).ToReadOnlyValueSource, plotter.Object, 1L, sprite.Object)
        Dim renderer As Object = Nothing
        subject.Draw(renderer)
        plotter.Verify(Function(x) x.PlotX(0L, 0L))
        plotter.Verify(Function(x) x.PlotY(0L, 0L))
        plotter.VerifyNoOtherCalls()
        sprite.Verify(Sub(x) x.Draw(Nothing, (0, 0), (255, 255, 255, 255), 0))
        sprite.VerifyNoOtherCalls()
    End Sub
End Class
