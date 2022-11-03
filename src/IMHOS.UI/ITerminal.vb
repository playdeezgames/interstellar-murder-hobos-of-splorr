Public Interface ITerminal
    Sub WriteLine(text As String)
    Function Choose(title As String, ParamArray choices As String()) As String
End Interface
