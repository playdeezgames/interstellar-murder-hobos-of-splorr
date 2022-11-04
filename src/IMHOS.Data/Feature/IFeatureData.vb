Public Interface IFeatureData
    Function Create(name As String, locationId As Guid) As Guid
    Function ReadForLocation(locationId As Guid) As IEnumerable(Of Guid)
    Function ReadName(featureId As Guid) As String
End Interface
