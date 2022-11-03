Public Class HexPlotter
    Implements IPlotter
    Private ReadOnly width As Single
    Private ReadOnly halfHeight As Single
    Sub New(width As Single, height As Single)
        Me.width = width
        Me.halfHeight = height / 2.0F
    End Sub

    Public Function PlotX(x As Long, y As Long) As Single Implements IPlotter.PlotX
        Return x * width + y * width
    End Function

    Public Function PlotY(x As Long, y As Long) As Single Implements IPlotter.PlotY
        Return y * halfHeight - x * halfHeight
    End Function
End Class
