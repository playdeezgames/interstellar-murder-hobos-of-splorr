Public Class FixedValueSource_should
    <Fact>
    Sub have_a_fixed_value()
        Const fixedValue = 1.0F
        Dim subject As IValueSource(Of Single) = New FixedValueSource(Of Single)(fixedValue)
        subject.Read().ShouldBe(fixedValue)
    End Sub
End Class
