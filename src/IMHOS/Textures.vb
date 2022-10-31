Public Module Textures
    Friend Const TextureHex = 1L
    Friend Const TextureShip = 2L
    Private ReadOnly fileTable As IReadOnlyDictionary(Of Long, String) =
        New Dictionary(Of Long, String) From
        {
            {TextureHex, "Content/hex.png"},
            {TextureShip, "Content/ship.png"}
        }
    Private ReadOnly textureTable As Dictionary(Of Long, Texture2D) = New Dictionary(Of Long, Texture2D)
    Sub Load(graphicsDevice As GraphicsDevice)
        For Each entry In fileTable
            Using stream As New FileStream(entry.Value, FileMode.Open)
                textureTable(entry.Key) = Texture2D.FromStream(graphicsDevice, stream)
            End Using
        Next
    End Sub
    Function Read(textureId As Long) As Texture2D
        Return textureTable(textureId)
    End Function
End Module
