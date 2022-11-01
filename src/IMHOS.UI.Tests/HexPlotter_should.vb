Public Class HexPlotter_should
    <Theory>
    <InlineData(0L, 0L, 0.0F)>
    <InlineData(1L, 0L, 24.0F)>
    <InlineData(2L, 0L, 48.0F)>
    <InlineData(0L, 1L, 0.0F)>
    <InlineData(1L, 1L, 24.0F)>
    <InlineData(2L, 1L, 48.0F)>
    Sub plot_x(x As Long, y As Long, expectedPlotX As Single)
        Const width = 24.0F
        Const height = 32.0F
        Dim subject As IPlotter = New HexPlotter(width, height)
        subject.PlotX(x, y).ShouldBe(expectedPlotX)
    End Sub
    <Theory>
    <InlineData(0L, 0L, 0.0F)>
    <InlineData(1L, 0L, 16.0F)>
    <InlineData(2L, 0L, 0.0F)>
    <InlineData(0L, 1L, 32.0F)>
    <InlineData(1L, 1L, 48.0F)>
    <InlineData(2L, 1L, 32.0F)>
    Sub plot_y(x As Long, y As Long, expectedPlotY As Single)
        Const width = 24.0F
        Const height = 32.0F
        Dim subject As IPlotter = New HexPlotter(width, height)
        subject.PlotY(x, y).ShouldBe(expectedPlotY)
    End Sub
End Class
