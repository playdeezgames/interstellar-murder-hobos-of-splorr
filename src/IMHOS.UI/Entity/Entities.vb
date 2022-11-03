Public Class Entities
    Inherits BaseEntity

    Public Sub New(parent As IEntity, offset As (Single, Single))
        MyBase.New(parent, offset)
    End Sub
End Class
