Public Class World_should
    <Fact>
    Sub instantiate()
        Dim subject As IWorld = New World()
        subject.ShouldNotBeNull
    End Sub
End Class

