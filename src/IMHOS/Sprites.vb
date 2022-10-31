Public Class Sprites
    Friend Const SpriteHex = 1L
    Friend Const SpriteShip = 2L
    Private Shared source As IReadOnlyDictionary(Of Long, (Long, Vector2, Vector2, SpriteEffects, Single)) =
        New Dictionary(Of Long, (Long, Vector2, Vector2, SpriteEffects, Single)) From
        {
            {SpriteHex, (TextureRegionHex, New Vector2(32, 32), New Vector2(1, 1), SpriteEffects.None, 0)},
            {SpriteShip, (TextureRegionShip, New Vector2(32, 32), New Vector2(1, 1), SpriteEffects.None, 0)}
        }
    Private ReadOnly table As New Dictionary(Of Long, Sprite)
    Sub New()
        For Each entry In source
            table(entry.Key) = New Sprite(TextureRegions.Read(entry.Value.Item1), entry.Value.Item2, entry.Value.Item3, entry.Value.Item4, entry.Value.Item5)
        Next
    End Sub
End Class
