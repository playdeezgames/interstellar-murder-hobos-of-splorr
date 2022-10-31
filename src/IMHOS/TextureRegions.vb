Friend Class TextureRegions
    Friend Const TextureRegionHex = 1L
    Friend Const TextureRegionShip = 2L
    Private Shared ReadOnly source As IReadOnlyDictionary(Of Long, (Long, Rectangle?)) =
        New Dictionary(Of Long, (Long, Rectangle?)) From
        {
            {TextureRegionHex, (Textures.TextureHex, Nothing)},
            {TextureRegionShip, (Textures.TextureShip, Nothing)}
        }
    Private ReadOnly table As New Dictionary(Of Long, TextureRegion)
    Sub New(textures As Textures)
        For Each entry In source
            table(entry.Key) = New TextureRegion(textures.Read(entry.Value.Item1), entry.Value.Item2)
        Next
    End Sub
    Function Read(textureRegionId As Long)
        Return table(textureRegionId)
    End Function
End Class
