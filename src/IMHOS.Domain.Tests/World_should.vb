Public Class World_should
    <Fact>
    Sub instantiate()
        Dim subject As IWorld = New World()
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub have_player_ship()
        Dim subject As IWorld = New World()
        subject.PlayerShip.ShouldNotBeNull
    End Sub
End Class

