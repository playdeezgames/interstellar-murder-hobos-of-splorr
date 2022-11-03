Public Class Constants
    Public Class Textures
        Public Const Hex = 1L
        Public Const Ship = 2L
        Public Shared ReadOnly Source As IReadOnlyDictionary(Of Long, String) =
            New Dictionary(Of Long, String) From
        {
            {Hex, "Content/hex.png"},
            {Ship, "Content/ship.png"}
        }
    End Class
    Public Class TextureRegions
        Public Const Hex = 1L
        Public Const Ship = 2L
        Public Shared ReadOnly Source As IReadOnlyDictionary(Of Long, (Long, ((Integer, Integer), (Integer, Integer))?)) =
            New Dictionary(Of Long, (Long, ((Integer, Integer), (Integer, Integer))?)) From
        {
            {Hex, (Textures.Hex, Nothing)},
            {Ship, (Textures.Ship, Nothing)}
        }
    End Class
    Public Class Sprites
        Public Const Hex = 1L
        Public Const Ship = 2L
        Public Shared ReadOnly Source As IReadOnlyDictionary(Of Long, (Long, (Single, Single), (Single, Single), (Boolean, Boolean), Single)) = New Dictionary(Of Long, (Long, (Single, Single), (Single, Single), (Boolean, Boolean), Single)) From
        {
            {Hex, (TextureRegions.Hex, (32.0F, 32.0F), (1.0F, 1.0F), (False, False), 0)},
            {Ship, (TextureRegions.Ship, (32.0F, 32.0F), (1.0F, 1.0F), (False, False), 0)}
        }
    End Class
    Public Class Screen
        Public Const Width = 1280
        Public Const Height = 720
    End Class
    Public Class Plotter
        Public Const Width = 48.0F
        Public Const Height = 64.0F
    End Class
    Public Class HexGrid
        Public Const Size = 32L
    End Class
End Class
