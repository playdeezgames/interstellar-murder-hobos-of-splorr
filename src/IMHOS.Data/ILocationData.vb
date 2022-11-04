Public Interface ILocationData
    Function Create(name As String, vesselId As Guid) As Guid
    Function ReadName(locationId As Guid) As String
End Interface
