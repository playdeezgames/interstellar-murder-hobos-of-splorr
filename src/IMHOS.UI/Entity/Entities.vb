Public Class Entities
    Inherits BaseEntity

    Public Sub New(parent As IEntity, offset As (Single, Single))
        MyBase.New(parent, offset, 0.0F)
    End Sub
End Class
