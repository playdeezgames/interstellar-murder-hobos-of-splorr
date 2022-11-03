Public Class ShipEntity
    Inherits SpriteEntity
    Private ship As IShip

    Public Sub New(ship As IShip, parent As IEntity, sprite As ISprite, offset As (Single, Single), color As (Byte, Byte, Byte, Byte), rotation As Single)
        MyBase.New(parent, sprite, offset, color, rotation)
        Me.ship = ship
    End Sub
    Public Overrides Sub Update(delta As TimeSpan)
        MyBase.Update(delta)
        rotation = CSng(CDbl(ship.Direction) * Math.PI / 3.0)
    End Sub
End Class
