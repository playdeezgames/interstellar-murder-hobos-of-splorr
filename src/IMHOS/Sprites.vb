Class Sprites
    Friend Const SpriteHex = 1L
    Friend Const SpriteShip = 2L
    Private Shared source As IReadOnlyDictionary(Of Long, (Long, Vector2, Vector2, SpriteEffects, Single)) =
        New Dictionary(Of Long, (Long, Vector2, Vector2, SpriteEffects, Single)) From
        {
            {SpriteHex, (TextureRegions.TextureRegionHex, New Vector2(32, 32), New Vector2(1, 1), SpriteEffects.None, 0)},
            {SpriteShip, (TextureRegions.TextureRegionShip, New Vector2(32, 32), New Vector2(1, 1), SpriteEffects.None, 0)}
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
