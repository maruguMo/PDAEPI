Namespace EventsNameSpace
    Public Class EventArgs
        Inherits System.EventArgs
        Private mStatusValue As Object
        Private mCancelOp As Boolean
        Public Property Cancel() As Boolean
            Get
                Return mCancelOp
            End Get
            Set(ByVal value As Boolean)
                mCancelOp = value
            End Set
        End Property

        Public Property StatusValue() As Object
            Get
                Return mStatusValue
            End Get
            Set(ByVal value As Object)
                mStatusValue = value
            End Set
        End Property
    End Class
End Namespace
