Module TextureRegions
    Friend Const TextureRegionHex = 1
    Friend Const TextureRegionShip = 2
    Private ReadOnly source As IReadOnlyDictionary(Of Long, (Long, Rectangle?)) =
        New Dictionary(Of Long, (Long, Rectangle?)) From
        {
            {TextureRegionHex, (TextureHex, Nothing)},
            {TextureRegionShip, (TextureShip, Nothing)}
        }
    Private ReadOnly table As New Dictionary(Of Long, TextureRegion)
    Friend Sub Load()
        For Each entry In source
            table(entry.Key) = New TextureRegion(Textures.Read(entry.Value.Item1), entry.Value.Item2)
        Next
    End Sub
End Module
