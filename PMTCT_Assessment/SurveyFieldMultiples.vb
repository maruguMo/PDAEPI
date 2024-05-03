Public Class SurveyFieldMultipleDates
    Inherits SurveyFieldBase
    Private mFieldValues As New List(Of DateFieldValue)
    Private mMin As DateTime = Nothing
    Private mMax As DateTime = Nothing
    Public ReadOnly Property UnknownValue() As DateTime
        Get
            Return CDate("1800-01-01T00:00:00+03:00")
        End Get
    End Property
    Public Property Min() As DateTime
        Get
            Return mMin
        End Get
        Set(ByVal value As DateTime)
            mMin = value
        End Set
    End Property
    Public Property Max() As DateTime
        Get
            Return mMax
        End Get
        Set(ByVal value As DateTime)
            mMax = value
        End Set
    End Property
    Public ReadOnly Property FieldValues() As List(Of DateFieldValue)
        Get
            Return mFieldValues
        End Get
    End Property
    Public Function ValidateRange() As Boolean
        For Each mDateValue In mFieldValues
            If mDateValue.FieldValue.CompareTo(mMin) < 0 Then
                Return False
            Else
                If mDateValue.FieldValue.CompareTo(mMax) > 0 Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Public Shadows Function Validate(ByVal Values As List(Of DateFieldValue)) As Boolean
        If Me.IsRequired = True Then
            If Values IsNot Nothing Then
                If Values.Count = 0 Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Public Sub Add(ByVal DateValue As DateFieldValue)
        mFieldValues.Add(DateValue)
    End Sub
    Public Sub Clear()
        mFieldValues.Clear()
    End Sub
    Public Sub New()
        Me.FieldType = FieldDataTypes.qdMultipleDates
    End Sub
End Class
Public Class SurveyFieldMultipleText
    Inherits SurveyFieldBase
    Private mFieldValues As New List(Of TextFieldValue)
    Public ReadOnly Property UnknownValue() As String
        Get
            Return "UNK"
        End Get
    End Property
    Public ReadOnly Property FieldValues() As List(Of TextFieldValue)
        Get
            Return mFieldValues
        End Get
    End Property
    Public Sub Clear()
        mFieldValues.Clear()
    End Sub
    Public Sub Add(ByVal TextValue As TextFieldValue)
        mFieldValues.Add(TextValue)
    End Sub
    Public Shadows Function Validate(ByVal Values As List(Of TextFieldValue)) As Boolean
        If Me.IsRequired = True Then
            If Values IsNot Nothing Then
                If Values.Count = 0 Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Public Sub New()
        Me.FieldType = FieldDataTypes.qdMultipleText
    End Sub
End Class
Public Class SurveyFieldMultipleNumbers
    Inherits SurveyFieldBase
    Private mFieldValues As New List(Of NumberFieldValue)
    Private mMin As Long = Nothing
    Private mMax As Long = Nothing
    Public ReadOnly Property UnknownValue() As Long
        Get
            Return -1
        End Get
    End Property
    Public Property Min() As Long
        Get
            Return mMin
        End Get
        Set(ByVal value As Long)
            mMin = value
        End Set
    End Property
    Public Property Max() As Long
        Get
            Return mMax
        End Get
        Set(ByVal value As Long)
            mMax = value
        End Set
    End Property
    Public ReadOnly Property FieldValues() As List(Of NumberFieldValue)
        Get
            Return mFieldValues
        End Get
    End Property
    Public Shadows Function Validate(ByVal Values As List(Of NumberFieldValue)) As Boolean
        If Me.IsRequired = True Then
            If Values IsNot Nothing Then
                If Values.Count = 0 Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Public Function ValidateRange() As Boolean
        For Each mNumberValue In mFieldValues
            If mNumberValue.FieldValue < mMin Then
                Return False
            Else
                If mNumberValue.FieldValue > mMax Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Public Sub Clear()
        mFieldValues.Clear()
    End Sub
    Public Sub Add(ByVal NumberValue As NumberFieldValue)
        mFieldValues.Add(NumberValue)
    End Sub
    Public Sub New()
        Me.FieldType = FieldDataTypes.qdMultipleNumber
    End Sub
End Class