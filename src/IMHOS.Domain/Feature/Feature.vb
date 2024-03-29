﻿Public Class Feature
    Inherits Thingie
    Implements IFeature
    Sub New(data As IStageData, id As Guid)
        MyBase.New(data, id)
    End Sub

    Public ReadOnly Property Name As String Implements IFeature.Name
        Get
            Return data.Feature.ReadName(id)
        End Get
    End Property

    Public ReadOnly Property Verbs As IEnumerable(Of IVerb) Implements IFeature.Verbs
        Get
            Return Array.Empty(Of IVerb)
        End Get
    End Property

    Friend Shared Function FromId(data As IStageData, id As Guid?) As IFeature
        Return If(id.HasValue, New Feature(data, id.Value), Nothing)
    End Function
End Class
