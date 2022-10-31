Public Class TextureRegions
    Private ReadOnly table As New Dictionary(Of Long, TextureRegion)
    Sub New(textures As ITextures, source As IReadOnlyDictionary(Of Long, (Long, ((Integer, Integer), (Integer, Integer))?)))
        For Each entry In source
            table(entry.Key) = New TextureRegion(textures.Read(entry.Value.Item1), entry.Value.Item2)
        Next
    End Sub
    Function Read(textureRegionId As Long) As TextureRegion
        Return table(textureRegionId)
    End Function
End Class
