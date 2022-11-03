Public Class HexGridEntity
    Inherits BaseEntity
    Implements IHexGridEntity
    Private ReadOnly table As New Dictionary(Of (Long, Long), Guid)
    Sub New(parent As IEntity, offset As (Single, Single), plotter As IPlotter, size As Long, sprite As ISprite)
        MyBase.New(parent, offset)
        Dim color As (Byte, Byte, Byte, Byte) = (255, 255, 255, 255)
        For column = -size To size
            For row = -size To size
                If Math.Abs(column + row) <= size Then
                    Dim xy As (Single, Single) = (plotter.PlotX(column, row), plotter.PlotY(column, row))
                    Dim entity = New Entity(
                        Me,
                        sprite.ToReadOnlyValueSource,
                        xy,
                        color,
                        0.0F)
                    table((column, row)) = Add(entity)
                End If
            Next
        Next
    End Sub

    Public ReadOnly Property Hex(column As Long, row As Long) As IEntity Implements IHexGridEntity.Hex
        Get
            Dim xy = (column, row)
            Dim id As Guid = Nothing
            If table.TryGetValue(xy, id) Then
                Return Read(id)
            End If
            Return Nothing
        End Get
    End Property

    Public Overrides Sub Draw(renderer As Object)
        For Each child In children
            child.Value.Draw(renderer)
        Next
    End Sub

    Public Overrides Sub Update(delta As TimeSpan)
    End Sub
End Class
