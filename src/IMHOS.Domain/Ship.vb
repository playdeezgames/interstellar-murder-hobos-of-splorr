Public Class Ship
    Implements IShip
    Sub New()
        Direction = 0L
    End Sub

    Public ReadOnly Property Direction As Long Implements IShip.Direction
End Class
