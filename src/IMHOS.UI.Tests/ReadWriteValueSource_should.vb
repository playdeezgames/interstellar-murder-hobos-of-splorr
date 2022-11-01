Public Class ReadWriteValueSource_should
    <Fact>
    Sub read()
        Const initialValue = 1.0F
        Dim subject As IWriteValueSource(Of Single) = New ReadWriteValueSource(Of Single)(initialValue)
        subject.Read().ShouldBe(1.0F)
    End Sub
    <Fact>
    Sub write()
        Const initialValue = 1.0F
        Const finalValue = 2.0F
        Dim subject As IWriteValueSource(Of Single) = New ReadWriteValueSource(Of Single)(initialValue)
        subject.Write(finalValue)
        subject.Read().ShouldBe(finalValue)
    End Sub
End Class
