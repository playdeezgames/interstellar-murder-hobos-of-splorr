Public Class ReadOnlyValueSource_should
    <Fact>
    Sub have_a_fixed_value()
        Const fixedValue = 1.0F
        Dim subject As IReadValueSource(Of Single) = New ReadOnlyValueSource(Of Single)(fixedValue)
        subject.Read().ShouldBe(fixedValue)
    End Sub
End Class
