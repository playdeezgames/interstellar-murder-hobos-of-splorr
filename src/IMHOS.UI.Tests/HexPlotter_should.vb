Public Class HexPlotter_should
    <Fact>
    Sub plot_x()
        Const width = 32.0F
        Const height = 24.0F
        Const y = 0L
        Const x = 0L
        Dim subject As IPlotter = New HexPlotter(width, height)
        subject.PlotX(x, y).ShouldBe(0.0F)
    End Sub
    <Fact>
    Sub plot_y()
        Const width = 32.0F
        Const height = 24.0F
        Const y = 0L
        Const x = 0L
        Dim subject As IPlotter = New HexPlotter(width, height)
        subject.PlotY(x, y).ShouldBe(0.0F)
    End Sub
End Class
