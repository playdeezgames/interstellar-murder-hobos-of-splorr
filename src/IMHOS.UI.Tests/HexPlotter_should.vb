Public Class HexPlotter_should
    <Theory>
    <InlineData(0L, 0L, 0.0F)>
    Sub plot_x(x As Long, y As Long, expectedPlotX As Single)
        Const width = 32.0F
        Const height = 24.0F
        Dim subject As IPlotter = New HexPlotter(width, height)
        subject.PlotX(x, y).ShouldBe(expectedPlotX)
    End Sub
    <Theory>
    <InlineData(0L, 0L, 0.0F)>
    Sub plot_y(x As Long, y As Long, expectedPlotY As Single)
        Const width = 32.0F
        Const height = 24.0F
        Dim subject As IPlotter = New HexPlotter(width, height)
        subject.PlotY(x, y).ShouldBe(expectedPlotY)
    End Sub
End Class
