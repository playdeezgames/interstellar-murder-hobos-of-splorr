Public Interface ITextures
    Function Read(textureId As Long) As Object
End Interface
Public Class Textures
    Implements ITextures
    Private ReadOnly textureTable As Dictionary(Of Long, Texture2D) = New Dictionary(Of Long, Texture2D)
    Sub New(graphicsDevice As GraphicsDevice, fileTable As IReadOnlyDictionary(Of Long, String))
        For Each entry In fileTable
            Using stream As New FileStream(entry.Value, FileMode.Open)
                textureTable(entry.Key) = Texture2D.FromStream(graphicsDevice, stream)
            End Using
        Next
    End Sub
    Function Read(textureId As Long) As Object Implements ITextures.Read
        Return textureTable(textureId)
    End Function
End Class
