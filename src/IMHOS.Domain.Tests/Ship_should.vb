Public Class Ship_should
    <Fact>
    Sub instantiate()
        Dim subject As IShip = New Ship()
        subject.ShouldNotBeNull
    End Sub
End Class
