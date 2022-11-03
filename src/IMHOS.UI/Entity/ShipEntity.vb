Public Class ShipEntity
    Inherits SpriteEntity

    Public Sub New(parent As IEntity, sprite As ISprite, offset As (Single, Single), color As (Byte, Byte, Byte, Byte), rotation As Single)
        MyBase.New(parent, sprite, offset, color, rotation)
    End Sub
End Class
