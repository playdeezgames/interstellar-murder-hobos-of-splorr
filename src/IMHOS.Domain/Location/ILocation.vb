Public Interface ILocation
    ReadOnly Property Name As String
    ReadOnly Property Vessel As IVessel
    ReadOnly Property HasFeatures As Boolean
    ReadOnly Property Features As IEnumerable(Of IFeature)
End Interface
