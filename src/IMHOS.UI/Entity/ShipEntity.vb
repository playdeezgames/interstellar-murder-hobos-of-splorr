Public Class ShipEntity
    Inherits SpriteEntity
    Private ship As IShip

    Public Sub New(ship As IShip, parent As IEntity, sprite As ISprite, offset As (Single, Single), color As (Byte, Byte, Byte, Byte), rotation As Single)
        MyBase.New(parent, sprite, offset, color, rotation)
        Me.ship = ship
    End Sub
End Class
