﻿Public Class Sprites
    Implements ISprites
    Private ReadOnly table As New Dictionary(Of Long, ISprite)
    Sub New(textureregions As ITextureRegions, source As IReadOnlyDictionary(Of Long, (Long, (Single, Single), (Single, Single), (Boolean, Boolean), Single)))
        For Each entry In source
            table(entry.Key) = New Sprite(textureregions.Read(entry.Value.Item1), entry.Value.Item2, entry.Value.Item3, entry.Value.Item4, entry.Value.Item5)
        Next
    End Sub

    Function Read(spriteId As Long) As ISprite Implements ISprites.Read
        Return table(spriteId)
    End Function
End Class
