
Public Class CFieldValue
    Private mValueIndex As Integer
    Public Property ValueIndex() As Integer
        Get
            Return mValueIndex
        End Get
        Set(ByVal value As Integer)
            mValueIndex = value
        End Set
    End Property
End Class
Public Class DateFieldValue
    Inherits CFieldValue
    Private mFieldValue As Date
    Public Property FieldValue() As DateTime
        Get
            Return mFieldValue
        End Get
        Set(ByVal value As DateTime)
            mFieldValue = value
        End Set
    End Property
End Class
Public Class NumberFieldValue
    Inherits CFieldValue
    Private mFieldValue As Long
    Public Property FieldValue() As Long
        Get
            Return mFieldValue
        End Get
        Set(ByVal value As Long)
            mFieldValue = value
        End Set
    End Property
End Class
Public Class TextFieldValue
    Inherits CFieldValue
    Private mFieldValue As String
    Public Property FieldValue() As String
        Get
            Return mFieldValue
        End Get
        Set(ByVal value As String)
            mFieldValue = value
        End Set
    End Property
End Class
Public Class OnOffFieldValue
    Inherits CFieldValue
    Private mFieldValue As OnOffValues
    Public Enum OnOffValues
        dChecked = 0
        dUnchecked = 1
    End Enum
    Public Property FieldValue() As OnOffValues
        Get
            Return mFieldValue
        End Get
        Set(ByVal value As OnOffValues)
            mFieldValue = value
        End Set
    End Property
End Class