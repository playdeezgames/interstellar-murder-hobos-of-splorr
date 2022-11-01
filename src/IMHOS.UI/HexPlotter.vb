Public Class HexPlotter
    Implements IPlotter
    Private ReadOnly width As Single
    Private ReadOnly height As Single
    Sub New(width As Single, height As Single)
        Me.width = width
        Me.height = height
    End Sub

    Public Function PlotX(x As Long, y As Long) As Single Implements IPlotter.PlotX
        Return x * width
    End Function

    Public Function PlotY(x As Long, y As Long) As Single Implements IPlotter.PlotY
        Return y * height + If(x Mod 2 = 1, height / 2, 0.0F)
    End Function
End Class
