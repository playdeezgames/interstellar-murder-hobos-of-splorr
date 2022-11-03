Public Class Ship_should
    <Fact>
    Sub instantiate()
        Dim subject As IShip = New Ship()
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub have_direction()
        Dim subject As IShip = New Ship()
        subject.Direction.ShouldBe(0L)
    End Sub
End Class
