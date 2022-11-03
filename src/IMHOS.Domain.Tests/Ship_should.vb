Public Class Ship_should
    <Fact>
    Sub instantiate()
        Dim subject As IShip = New Ship()
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub read_direction()
        Dim subject As IShip = New Ship()
        subject.Direction.ShouldBe(0L)
    End Sub
    <Fact>
    Sub write_direction()
        Dim subject As IShip = New Ship()
        subject.Direction = 1L
        subject.Direction.ShouldBe(1L)
    End Sub
End Class
