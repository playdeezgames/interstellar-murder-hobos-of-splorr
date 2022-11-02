Public Class HexGridEntity
    Implements IEntity
    Private children As New List(Of IEntity)
    Sub New(plotter As IPlotter, size As Long, sprite As ISprite)
        Dim columns = size * 2L - 1L
        Dim rows = size * 2L - 1L
        Dim color As (Byte, Byte, Byte, Byte) = (255, 255, 255, 255)
        For column = 0 To columns - 1
            For row = 0 To rows - 1
                If (column + row) >= (size - 1) AndAlso (column + row) <= (3L * size - 3L) Then
                    Dim xy As (Single, Single) = (plotter.PlotX(column, row), plotter.PlotY(column, row))
                    Dim entity = New Entity(
                        Nothing,
                        sprite.ToReadOnlyValueSource,
                        xy.ToReadOnlyValueSource,
                        color.ToReadOnlyValueSource,
                        0.0F.ToReadOnlyValueSource)
                    children.Add(entity)
                End If
            Next
        Next
    End Sub
    Public Sub Draw(renderer As Object) Implements IEntity.Draw
        For Each child In children
            child.Draw(renderer)
        Next
    End Sub
End Class
