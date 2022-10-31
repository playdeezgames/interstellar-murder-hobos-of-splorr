Class Sprites
    Friend Const SpriteHex = 1L
    Friend Const SpriteShip = 2L
    Private Shared source As IReadOnlyDictionary(Of Long, (Long, (Single, Single), (Single, Single), (Boolean, Boolean), Single)) =
        New Dictionary(Of Long, (Long, (Single, Single), (Single, Single), (Boolean, Boolean), Single)) From
        {
            {SpriteHex, (Constants.TextureRegions.Hex, (32.0F, 32.0F), (1.0F, 1.0F), (False, False), 0)},
            {SpriteShip, (Constants.TextureRegions.Ship, (32.0F, 32.0F), (1.0F, 1.0F), (False, False), 0)}
        }
    Private ReadOnly table As New Dictionary(Of Long, Sprite)
    Sub New(textureregions As TextureRegions)
        For Each entry In source
            table(entry.Key) = New Sprite(textureregions.Read(entry.Value.Item1), entry.Value.Item2, entry.Value.Item3, entry.Value.Item4, entry.Value.Item5)
        Next
    End Sub

    Friend Function Read(spriteId As Long) As Sprite
        Return table(spriteId)
    End Function
End Class
