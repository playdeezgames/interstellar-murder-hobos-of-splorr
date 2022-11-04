Public Interface ILocation
    ReadOnly Property Name As String
    ReadOnly Property Vessel As IVessel
    ReadOnly Property Features As IEnumerable(Of IFeature)
End Interface
