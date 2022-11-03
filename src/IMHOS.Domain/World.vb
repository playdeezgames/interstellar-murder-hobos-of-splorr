Public Class World
    Implements IWorld
    Sub New()
        PlayerShip = New Ship()
    End Sub
    Public ReadOnly Property PlayerShip As IShip Implements IWorld.PlayerShip
End Class
