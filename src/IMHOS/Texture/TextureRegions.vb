Public Class TextureRegions
    Implements ITextureRegions
    Private ReadOnly table As New Dictionary(Of Long, ITextureRegion)
    Sub New(textures As ITextures, source As IReadOnlyDictionary(Of Long, (Long, ((Integer, Integer), (Integer, Integer))?)))
        For Each entry In source
            table(entry.Key) = New TextureRegion(textures.Read(entry.Value.Item1), entry.Value.Item2)
        Next
    End Sub
    Function Read(textureRegionId As Long) As ITextureRegion Implements ITextureRegions.Read
        Return table(textureRegionId)
    End Function
End Class
