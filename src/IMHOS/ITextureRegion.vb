Public Interface ITextureRegion
    Sub Draw(spriteBatch As Object, position As (Single, Single), color As (Byte, Byte, Byte, Byte), rotation As Single, origin As (Single, Single), scale As (Single, Single), effects As (Boolean, Boolean), layerDepth As Single)
End Interface