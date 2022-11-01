Public Class HexPlotter
    Implements IPlotter
    Sub New(width As Single, height As Single)

    End Sub

    Public Function PlotX(x As Long, y As Long) As Single Implements IPlotter.PlotX
        Return 0.0F
    End Function

    Public Function PlotY(x As Long, y As Long) As Single Implements IPlotter.PlotY
        Return 0.0F
    End Function
End Class
