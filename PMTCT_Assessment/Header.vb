Public Class Header
    Private mHeaderTitle As String = ""
    Private mHeaderInstructions As String = ""
    Private mHeaderID As String = ""
    Public Property HeaderTitle() As String
        Get
            Return mHeaderTitle
        End Get
        Set(ByVal value As String)
            mHeaderTitle = value
        End Set
    End Property
    Public Property HeaderInstructions() As String
        Get
            Return mHeaderInstructions
        End Get
        Set(ByVal value As String)
            mHeaderInstructions = value
        End Set
    End Property
    Public Property HeaderID() As String
        Get
            Return mHeaderID
        End Get
        Set(ByVal value As String)
            mHeaderID = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return mHeaderTitle
    End Function
End Class
