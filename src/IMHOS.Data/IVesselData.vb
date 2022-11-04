Public Interface IVesselData
    Function Create(name As String) As Guid
    Function ReadName(vesselId As Guid) As String
End Interface
