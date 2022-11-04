Public Interface IFeatureData
    Function Create(name As String, locationId As Guid) As Guid
    Function CountForLocation(locationId As Guid) As Long
    Function ReadForLocation(locationId As Guid) As IEnumerable(Of Guid)
End Interface
