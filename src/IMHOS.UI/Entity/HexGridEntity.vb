Public Class HexGridEntity
    Inherits BaseEntity
    Private children As New List(Of IEntity)
    Sub New(parent As IEntity, relativePosition As IReadValueSource(Of (Single, Single)), plotter As IPlotter, size As Long, sprite As ISprite)
        MyBase.New(parent, relativePosition)
        Dim columns = size * 2L - 1L
        Dim rows = size * 2L - 1L
        Dim color As (Byte, Byte, Byte, Byte) = (255, 255, 255, 255)
        For column = 0 To columns - 1
            For row = 0 To rows - 1
                If (column + row) >= (size - 1) AndAlso (column + row) <= (3L * size - 3L) Then
                    Dim xy As (Single, Single) = (plotter.PlotX(column, row), plotter.PlotY(column, row))
                    Dim entity = New Entity(
                        Me,
                        sprite.ToReadOnlyValueSource,
                        xy.ToReadOnlyValueSource,
                        color.ToReadOnlyValueSource,
                        0.0F.ToReadOnlyValueSource)
                    children.Add(entity)
                End If
            Next
        Next
    End Sub
    Public Overrides Sub Draw(renderer As Object)
        For Each child In children
            child.Draw(renderer)
        Next
    End Sub
End Class
