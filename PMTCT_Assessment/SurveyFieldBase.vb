Imports System.Collections
Imports System.Data
Imports System.Globalization
Public Class SurveyFieldBase
    Private mResponses As New List(Of FieldResponses)
    Private mFieldType As FieldDataTypes
    Private mFieldName As String
    Private mTableName As String
    Private mRequired As Boolean
    Private mIsSkipField As Boolean
    Private mResultsID As Object
    Private mQuestionID As String
    Private mFieldCaption As String
    Private mTabIndex As Integer
    Private mReadOnly As Boolean
    Public Property TabIndex() As Integer
        Get
            Return mTabIndex
        End Get
        Set(ByVal value As Integer)
            mTabIndex = value
        End Set
    End Property
    Public Property FieldReadOnly() As Boolean
        Get
            Return mReadOnly
        End Get
        Set(ByVal value As Boolean)
            mReadOnly = value
        End Set
    End Property
    Public Property FieldCaption() As String
        Get
            Return mFieldCaption
        End Get
        Set(ByVal value As String)
            mFieldCaption = value
        End Set
    End Property
    Public Structure FieldResponses
        Public CodedValue As Integer
        Public ResponseText As String
        Public Overrides Function ToString() As String
            Return ResponseText
        End Function
    End Structure
    Public Enum FieldDataTypes
        qdDate = 1
        qdNumber = 2
        qdText = 3
        qdOptions = 4
        qdMultipleNumber = 5
        qdStudyArea = 6
        qdMultipleDates = 7
        qdMultipleText = 8
        qdOnOff = 9
        qdMonth = 10
    End Enum
    Public Property QuestionID() As String
        Get
            Return mQuestionID
        End Get
        Set(ByVal value As String)
            mQuestionID = value
        End Set
    End Property
    Public ReadOnly Property Responses() As List(Of FieldResponses)
        Get
            Return mResponses
        End Get
    End Property
    Public Property IsSkipField() As Boolean
        Get
            Return mIsSkipField
        End Get
        Set(ByVal value As Boolean)
            mIsSkipField = value
        End Set
    End Property
    Public Property IsRequired() As Boolean
        Get
            Return mRequired
        End Get
        Set(ByVal value As Boolean)
            mRequired = value
        End Set
    End Property
    Public Property ResultsID() As Object
        Get
            Return mResultsID
        End Get
        Set(ByVal value As Object)
            mResultsID = value
        End Set
    End Property
    Public Property FieldType() As FieldDataTypes
        Get
            Return mFieldType
        End Get
        Set(ByVal value As FieldDataTypes)
            mFieldType = value
        End Set
    End Property
    Public Property FieldName() As String
        Get
            Return mFieldName
        End Get
        Set(ByVal value As String)
            mFieldName = value
        End Set
    End Property
    Public Property TableName() As String
        Get
            Return mTableName
        End Get
        Set(ByVal value As String)
            mTableName = value
        End Set
    End Property
    Public Sub LoadResponses(ByVal ResponseGroupID As String)
        Dim aFieldResponse As FieldResponses
        Dim aRow As DataRow
        If mResponses.Count = 0 Then
            Dim dt As New DataTable(My.Resources.ResponsesTable)
            dt = Data.ReadData(My.Resources.ResponsesTable, Constants.ResponseGroupIDColumn & " = " & ResponseGroupID, True, Constants.ResponseIDColumn, Data.SortEnum.Ascending)
            If dt.Rows.Count <> 0 Then
                For Each aRow In dt.Rows
                    aFieldResponse = New FieldResponses
                    aFieldResponse.CodedValue = aRow(Constants.CodedValueColumn)
                    aFieldResponse.ResponseText = aRow(Constants.ResponseTextColumn)
                    mResponses.Add(aFieldResponse)
                Next
            End If
        End If
    End Sub
    Public Overridable Function Validate(ByVal mValue As CFieldValue) As Boolean
        If mRequired = True Then
            If mValue Is Nothing Then
                Return False
            Else
                Select Case mFieldType
                    Case FieldDataTypes.qdDate
                        Dim aDateValue As DateFieldValue
                        aDateValue = mValue
                        If aDateValue.FieldValue = Nothing Then
                            Return False
                        Else
                            Return True
                        End If
                    Case FieldDataTypes.qdOptions
                        Dim aNumberValue As NumberFieldValue
                        aNumberValue = mValue
                        If aNumberValue.FieldValue < 0 Then
                            Return False
                        Else
                            Return True
                        End If
                    Case FieldDataTypes.qdNumber
                        Dim aNumberValue As NumberFieldValue
                        aNumberValue = mValue
                        Return True
                    Case FieldDataTypes.qdOnOff
                        Dim aOnOffValue As OnOffFieldValue
                        aOnOffValue = mValue
                        If aOnOffValue.FieldValue = Nothing Then
                            Return False
                        Else
                            Return True
                        End If
                    Case FieldDataTypes.qdStudyArea, FieldDataTypes.qdText
                        Dim aTextValue As TextFieldValue
                        aTextValue = mValue
                        If aTextValue.FieldValue.Trim() = "" Then
                            Return False
                        Else
                            Return True
                        End If
                End Select
            End If
        Else
            Return True
        End If
    End Function
    Public Sub AddResponse(ByVal FieldResponse As FieldResponses)
        Responses.Add(FieldResponse)
    End Sub
    Public Overrides Function ToString() As String
        Return Me.mFieldName
    End Function
End Class
Public Class SurveyFieldDate
    Inherits SurveyFieldBase
    Private mFieldValue As New DateFieldValue()
    Private mMax As DateTime = Nothing
    Private mMin As DateTime = Nothing
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
    Public Property FieldValue() As DateFieldValue
        Get
            Return mFieldValue
        End Get
        Set(ByVal value As DateFieldValue)
            mFieldValue = value
        End Set
    End Property
    Public Sub Clear()
        mFieldValue = New DateFieldValue
    End Sub
    Public Function ValidateRange() As Boolean
        If mFieldValue.FieldValue.CompareTo(mMin) < 0 Then
            Return False
        Else
            If mFieldValue.FieldValue.CompareTo(mMax) > 0 Then
                Return False
            End If
        End If
        Return True
    End Function
    Public Sub New()
        Me.FieldType = FieldDataTypes.qdDate
    End Sub
End Class
Public Class SurveyFieldText
    Inherits SurveyFieldBase
    Private mFieldValue As TextFieldValue
    Public ReadOnly Property UnknownValue() As String
        Get
            Return "UNK"
        End Get
    End Property
    Public Property FieldValue() As TextFieldValue
        Get
            Return mFieldValue
        End Get
        Set(ByVal value As TextFieldValue)
            mFieldValue = value
        End Set
    End Property
    Public Sub Clear()
        mFieldValue = New TextFieldValue()
        mFieldValue.FieldValue = " "
    End Sub
    Public Sub New()
        Me.FieldType = FieldDataTypes.qdText
    End Sub
End Class
Public Class SurveyFieldNumber
    Inherits SurveyFieldBase
    Private mFieldValue As NumberFieldValue
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
    Public Property FieldValue() As NumberFieldValue
        Get
            Return mFieldValue
        End Get
        Set(ByVal value As NumberFieldValue)
            mFieldValue = value
        End Set
    End Property
    Public Sub Clear()
        mFieldValue = Nothing
        mFieldValue = New NumberFieldValue
    End Sub
    Public Function ValidateRange() As Boolean
        If mFieldValue.FieldValue < mMin Then
            Return False
        Else
            If mFieldValue.FieldValue > mMax Then
                Return False
            End If
        End If
        Return True
    End Function
    Public Sub New()
        Me.FieldType = FieldDataTypes.qdNumber
    End Sub
End Class
Public Class SurveyFieldOnOff
    Inherits SurveyFieldBase
    Private mFieldValue As OnOffFieldValue
    Public ReadOnly Property UnknownValue() As Long
        Get
            Return -1
        End Get
    End Property
    Public Property FieldValue() As OnOffFieldValue
        Get
            Return mFieldValue
        End Get
        Set(ByVal value As OnOffFieldValue)
            mFieldValue = value
        End Set
    End Property
    Public Sub Clear()
        mFieldValue = New OnOffFieldValue
    End Sub
    Public Sub New()
        Me.FieldType = FieldDataTypes.qdOnOff
    End Sub
End Class