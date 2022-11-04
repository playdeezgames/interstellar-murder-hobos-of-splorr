Public Interface IFeatureData
    Function Create(name As String, locationId As Guid) As Guid
    Function CountForLocation(locationId As Guid) As Long
End Interface
