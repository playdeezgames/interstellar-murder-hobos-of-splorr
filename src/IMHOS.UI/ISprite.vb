Public Interface ISprite
    Sub Draw(
            renderer As Object,
            position As (Single, Single),
            color As (Byte, Byte, Byte, Byte),
            rotation As Single)
End Interface