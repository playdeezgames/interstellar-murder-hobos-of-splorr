Imports System.Security.Cryptography.X509Certificates

Public Class StageData_should
    <Fact>
    Sub instantiate()
        Dim subject As IStageData = New StageData()
        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub have_location()
        Dim subject As IStageData = New StageData
        subject.Location.ShouldNotBeNull
    End Sub
    <Fact>
    Sub have_actor()
        Dim subject As IStageData = New StageData
        subject.Actor.ShouldNotBeNull
    End Sub
    <Fact>
    Sub have_lead_actor()
        Dim subject As IStageData = New StageData
        subject.LeadActor.ShouldNotBeNull
    End Sub
    <Fact>
    Sub have_vessel()
        Dim subject As IStageData = New StageData
        subject.Vessel.ShouldNotBeNull
    End Sub
End Class


