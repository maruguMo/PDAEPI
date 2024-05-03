Imports System.Collections
Imports System.Data
Public Class SurveyQuestion

    Public Enum StudyAreaType
        studyAreaNone = 0
        studyAreaProvince = 1
        studyAreaSite = 2
        studyAreaDistrict = 3
        studyAreaCounty = 4
    End Enum
    Public Enum ControlType
        ctGenerate = 1
        ctInbuilt = 0
        ctCustom = 2
    End Enum
    Private mQuestionID As Integer
    Private mQuestionText As String
    Private mFieldCollection As New List(Of SurveyFieldBase)
    Private mQuestionNumber As String
    Private mSection As New Header
    Private mSubsection As New Header
    Private mInstructions As String = ""
    Private mResponseGroupID As String
    Private mStudyAreaType As StudyAreaType
    Private mControlType As ControlType
    Private mControlName As String
    Private mOtherFieldName As String
    Private mHasOther As String
    Public Property OtherFieldName() As String
        Get
            Return mOtherFieldName
        End Get
        Set(ByVal value As String)
            mOtherFieldName = value
        End Set
    End Property
    Public Property HasOther() As String
        Get
            Return mHasOther
        End Get
        Set(ByVal value As String)
            mHasOther = value
        End Set
    End Property
    Public Property QuestionControlType() As ControlType
        Get
            Return mControlType
        End Get
        Set(ByVal value As ControlType)
            mControlType = value
        End Set
    End Property
    Public Property ControlName() As String
        Get
            Return mControlName
        End Get
        Set(ByVal value As String)
            mControlName = value
        End Set
    End Property
    Public Property QStudyAreaType() As StudyAreaType
        Get
            Return mStudyAreaType
        End Get
        Set(ByVal value As StudyAreaType)
            mStudyAreaType = value
        End Set
    End Property
    Public Property QuestionInstruction() As String
        Get
            Return mInstructions
        End Get
        Set(ByVal value As String)
            mInstructions = value
        End Set
    End Property

    Public Property Section() As Header
        Get
            Return mSection
        End Get
        Set(ByVal value As Header)
            mSection = value
        End Set
    End Property
    Public Property Subsection() As Header
        Get
            Return mSubsection
        End Get
        Set(ByVal value As Header)
            mSubsection = value
        End Set
    End Property
    Public Property QuestionNumber() As String
        Get
            Return mQuestionNumber
        End Get
        Set(ByVal value As String)
            mQuestionNumber = value
        End Set
    End Property

    Public Property QuestionID() As Integer
        Get
            Return mQuestionID
        End Get
        Set(ByVal value As Integer)
            mQuestionID = value
        End Set
    End Property
    Public Property QuestionText() As String
        Get
            Return mQuestionText
        End Get
        Set(ByVal value As String)
            mQuestionText = value
        End Set
    End Property
    Public Property ResponseGroup() As String
        Get
            Return mResponseGroupID
        End Get
        Set(ByVal value As String)
            mResponseGroupID = value
        End Set
    End Property
#Region "Question Fields"
    Public Sub AddField(ByVal QuestionField As SurveyFieldBase)
        mFieldCollection.Add(QuestionField)
    End Sub
    Public Sub RemoveField(ByRef QuestionField As SurveyFieldBase)
        mFieldCollection.Remove(QuestionField)
    End Sub
    Public Sub ClearFields()
        mFieldCollection.Clear()
    End Sub
    Public ReadOnly Property Fields() As List(Of SurveyFieldBase)
        Get
            Return mFieldCollection
        End Get
    End Property
    Public Function ValidateFields() As Boolean
        Dim QuestionField As SurveyFieldBase
        Dim aTextField As SurveyFieldText
        Dim aNumberField As SurveyFieldNumber
        Dim aDateField As SurveyFieldDate
        Dim aMultiNumberField As SurveyFieldMultipleNumbers
        Dim aMultiDateField As SurveyFieldMultipleDates
        Dim aMultiTextField As SurveyFieldMultipleText
        Dim aOnOff As SurveyFieldOnOff
        For Each QuestionField In mFieldCollection
            Select Case QuestionField.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdDate
                    aDateField = QuestionField
                    If aDateField.Validate(aDateField.FieldValue) = False Then
                        Return False
                    End If
                    If (aDateField.Max = Nothing) And (aDateField.Min = Nothing) Then
                        Return True
                    Else
                        If aDateField.ValidateRange() = False Then
                            Return False
                        End If
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdMultipleDates
                    aMultiDateField = QuestionField
                    If aMultiDateField.Validate(aMultiDateField.FieldValues) = False Then
                        Return False
                    End If
                    If (aMultiDateField.Max = Nothing) And (aMultiDateField.Min = Nothing) Then
                        'do not return anything
                    Else
                        If aMultiDateField.ValidateRange() = False Then
                            Return False
                        End If
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdNumber
                    aNumberField = QuestionField
                    If aNumberField.Validate(aNumberField.FieldValue) = False Then
                        Return False
                    End If
                    If (aNumberField.Max = Nothing) And (aNumberField.Min = Nothing) Then
                        'do not return yet
                    Else
                        If aNumberField.ValidateRange() = False Then
                            Return False
                        End If
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdOnOff
                    aOnOff = QuestionField
                    If aOnOff.Validate(aOnOff.FieldValue) = False Then
                        Return False
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdOptions
                    aNumberField = QuestionField
                    If aNumberField.Validate(aNumberField.FieldValue) = False Then
                        Return False
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber
                    aMultiNumberField = QuestionField
                    If aMultiNumberField.Validate(aMultiNumberField.FieldValues) = False Then
                        Return False
                    End If
                    If (aMultiNumberField.Min = Nothing) And (aMultiNumberField.Max = Nothing) Then
                        'do not return anything
                    Else
                        If aMultiNumberField.ValidateRange() = False Then
                            Return False
                        End If
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdText, SurveyFieldBase.FieldDataTypes.qdStudyArea
                    aTextField = QuestionField
                    If aTextField.Validate(aTextField.FieldValue) = False Then
                        Return False
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                    aMultiTextField = QuestionField
                    If aMultiTextField.Validate(aMultiTextField.FieldValues) = False Then
                        Return False
                    End If
            End Select
        Next
        Return True
    End Function
    Public Sub ResetFields()
        Dim aSurveyQuestionField As SurveyFieldBase
        For Each aSurveyQuestionField In mFieldCollection
            Select Case aSurveyQuestionField.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdDate
                    Dim aDateField As SurveyFieldDate
                    aDateField = aSurveyQuestionField
                    aDateField.Clear()
                Case SurveyFieldBase.FieldDataTypes.qdMultipleDates
                    Dim aMultiDateField As SurveyFieldMultipleDates
                    aMultiDateField = aSurveyQuestionField
                    aMultiDateField.Clear()
                Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber
                    Dim aMultiNumberField As SurveyFieldMultipleNumbers
                    aMultiNumberField = aSurveyQuestionField
                    aMultiNumberField.Clear()
                Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                    Dim aMultiTextField As SurveyFieldMultipleText
                    aMultiTextField = aSurveyQuestionField
                    aMultiTextField.Clear()
                Case SurveyFieldBase.FieldDataTypes.qdOnOff
                    Dim aOnOffField As SurveyFieldOnOff
                    aOnOffField = aSurveyQuestionField
                    aOnOffField.Clear()
                Case SurveyFieldBase.FieldDataTypes.qdOptions
                    Dim aNumberField As SurveyFieldNumber
                    aNumberField = aSurveyQuestionField
                    aNumberField.Clear()
                    aNumberField.FieldValue.FieldValue = -1
                Case SurveyFieldBase.FieldDataTypes.qdNumber
                    Dim aNumberField As SurveyFieldNumber
                    aNumberField = aSurveyQuestionField
                    aNumberField.Clear()
                Case SurveyFieldBase.FieldDataTypes.qdStudyArea, SurveyFieldBase.FieldDataTypes.qdText
                    Dim aTextField As SurveyFieldText
                    aTextField = aSurveyQuestionField
                    aTextField.Clear()
            End Select
        Next
    End Sub
    Public Sub Prepare(Optional ByVal QuestionnaireID As Integer = 1)
        Dim dt As New DataTable("QuestionFields")
        Dim aRow As DataRow
        If mFieldCollection.Count = 0 Then
            LoadFieldsAndSkips()
        End If
        If mSection.HeaderID.Trim() <> "" Then
            dt = New DataTable("Sections")
            dt = Data.ReadData(My.Resources.QuestionnaireSections, Constants.SectionIDColumn & " = " & mSection.HeaderID)
            If dt.Rows.Count <> 0 Then
                aRow = dt.Rows(0)
                If aRow(Constants.SectionTitleColumn) IsNot DBNull.Value Then
                    mSection.HeaderTitle = aRow(Constants.SectionTitleColumn)
                End If
                If aRow(Constants.SectionInstructionColumn) IsNot DBNull.Value Then
                    mSection.HeaderInstructions = aRow(Constants.SectionInstructionColumn)
                End If
            End If
        End If
        'sections
        dt.Dispose()
        GC.Collect()
        If mSubsection.HeaderID.Trim() <> "" Then
            dt = New DataTable("Subsections")
            dt = Data.ReadData(My.Resources.QuestionnaireSubsections, Constants.SubSectionIDColumn & " = " & mSubsection.HeaderID)
            If dt.Rows.Count <> 0 Then
                aRow = dt.Rows(0)
                If aRow(Constants.SubSectionTitleColumn) IsNot DBNull.Value Then
                    mSubsection.HeaderTitle = aRow(Constants.SubSectionTitleColumn)
                End If
                If aRow(Constants.SubsectionInstructionColumn) IsNot DBNull.Value Then
                    mSubsection.HeaderInstructions = aRow(Constants.SubsectionInstructionColumn)
                End If
            End If
        End If
    End Sub
    Private Sub LoadFieldsAndSkips()
        Dim dt As New DataTable("QuestionFields")
        Dim aRow As DataRow
        Dim aTextField As SurveyFieldText
        Dim aNumberField As SurveyFieldNumber
        Dim aDateField As SurveyFieldDate
        Dim aMultiNumberField As SurveyFieldMultipleNumbers
        Dim aMultiDateField As SurveyFieldMultipleDates
        Dim aMultiTextField As SurveyFieldMultipleText
        Dim aOnOff As SurveyFieldOnOff

        'Read Fields
        If mFieldCollection.Count = 0 Then
            dt = Data.ReadData(My.Resources.TableFieldMappingTable, Constants.QuestionIDColumn & " = " & mQuestionID, True, Constants.TabIndexColumn, Data.SortEnum.Ascending)
            For Each aRow In dt.Rows
                'field type
                aTextField = Nothing
                aNumberField = Nothing
                aDateField = Nothing
                aMultiNumberField = Nothing
                aMultiDateField = Nothing
                aMultiTextField = Nothing
                Select Case aRow(Constants.FieldTypeColumn)
                    Case SurveyFieldBase.FieldDataTypes.qdDate
                        aDateField = New SurveyFieldDate()
                        aDateField.FieldName = aRow(Constants.FieldNameColumn)
                        aDateField.TableName = aRow(Constants.MappedTableNameColumn)
                        aDateField.QuestionID = mQuestionID
                        If mResponseGroupID <> Constants.NonExistent Then
                            aDateField.LoadResponses(mResponseGroupID)
                        End If
                        If aRow(Constants.DateMaxColumn) IsNot DBNull.Value Then
                            aDateField.Max = CType(aRow(Constants.DateMaxColumn), Date)
                        End If
                        If aRow(Constants.DateMinColumn) IsNot DBNull.Value Then
                            aDateField.Min = CType(aRow(Constants.DateMinColumn), Date)
                        End If
                        If aRow(Constants.IsSkipFieldColumn).ToString() = "1" Then
                            aDateField.IsSkipField = True
                        Else
                            aDateField.IsSkipField = False
                        End If
                        If aRow(Constants.FieldCaptionColumn) IsNot DBNull.Value Then
                            aDateField.FieldCaption = aRow(Constants.FieldCaptionColumn)
                        End If
                        If aRow(Constants.TabIndexColumn) IsNot DBNull.Value Then
                            aDateField.TabIndex = aRow(Constants.TabIndexColumn)
                        End If
                        If aRow(Constants.IsRequiredColumn) IsNot DBNull.Value Then
                            If aRow(Constants.IsRequiredColumn).ToString() = "Y" Then
                                aDateField.IsRequired = True
                            End If
                        End If
                        aDateField.FieldReadOnly = Data.IsFieldReadOnly(aDateField.FieldName, Me.QuestionID)
                        mFieldCollection.Add(aDateField)
                    Case SurveyFieldBase.FieldDataTypes.qdNumber
                        aNumberField = New SurveyFieldNumber()
                        aNumberField.FieldName = aRow(Constants.FieldNameColumn)
                        aNumberField.TableName = aRow(Constants.MappedTableNameColumn)
                        aNumberField.QuestionID = mQuestionID
                        If mResponseGroupID <> Constants.NonExistent Then
                            aNumberField.LoadResponses(mResponseGroupID)
                        End If
                        If aRow(Constants.IsSkipFieldColumn).ToString() = "1" Then
                            aNumberField.IsSkipField = True
                        Else
                            aNumberField.IsSkipField = False
                        End If
                        If aRow(Constants.NumberMaxColumn) IsNot DBNull.Value Then
                            aNumberField.Max = CType(aRow(Constants.NumberMaxColumn), Long)
                        End If
                        If aRow(Constants.NumberMinColumn) IsNot DBNull.Value Then
                            aNumberField.Min = CType(aRow(Constants.NumberMinColumn), Long)
                        End If
                        If aRow(Constants.FieldCaptionColumn) IsNot DBNull.Value Then
                            aNumberField.FieldCaption = aRow(Constants.FieldCaptionColumn)
                        End If
                        If aRow(Constants.TabIndexColumn) IsNot DBNull.Value Then
                            aNumberField.TabIndex = aRow(Constants.TabIndexColumn)
                        End If
                        If aRow(Constants.IsRequiredColumn) IsNot DBNull.Value Then
                            If aRow(Constants.IsRequiredColumn).ToString() = "Y" Then
                                aNumberField.IsRequired = True
                            End If
                        End If
                        aNumberField.FieldReadOnly = Data.IsFieldReadOnly(aNumberField.FieldName, Me.QuestionID)
                        mFieldCollection.Add(aNumberField)
                    Case SurveyFieldBase.FieldDataTypes.qdOptions
                        aNumberField = New SurveyFieldNumber()
                        aNumberField.FieldName = aRow(Constants.FieldNameColumn)
                        aNumberField.FieldType = SurveyFieldBase.FieldDataTypes.qdOptions
                        aNumberField.TableName = aRow(Constants.MappedTableNameColumn)
                        aNumberField.QuestionID = mQuestionID
                        If mResponseGroupID <> Constants.NonExistent Then
                            aNumberField.LoadResponses(mResponseGroupID)
                        End If
                        If aRow(Constants.IsSkipFieldColumn).ToString() = "1" Then
                            aNumberField.IsSkipField = True
                        Else
                            aNumberField.IsSkipField = False
                        End If
                        If aRow(Constants.FieldCaptionColumn) IsNot DBNull.Value Then
                            aNumberField.FieldCaption = aRow(Constants.FieldCaptionColumn)
                        End If
                        If aRow(Constants.TabIndexColumn) IsNot DBNull.Value Then
                            aNumberField.TabIndex = aRow(Constants.TabIndexColumn)
                        End If
                        If aRow(Constants.IsRequiredColumn) IsNot DBNull.Value Then
                            If aRow(Constants.IsRequiredColumn).ToString() = "Y" Then
                                aNumberField.IsRequired = True
                            End If
                        End If
                        aNumberField.FieldReadOnly = Data.IsFieldReadOnly(aNumberField.FieldName, Me.QuestionID)
                        mFieldCollection.Add(aNumberField)
                    Case SurveyFieldBase.FieldDataTypes.qdText
                        aTextField = New SurveyFieldText()
                        aTextField.FieldName = aRow(Constants.FieldNameColumn)
                        aTextField.TableName = aRow(Constants.MappedTableNameColumn)
                        aTextField.QuestionID = mQuestionID
                        If aRow(Constants.IsSkipFieldColumn).ToString() = "1" Then
                            aTextField.IsSkipField = True
                        Else
                            aTextField.IsSkipField = False
                        End If
                        If aRow(Constants.FieldCaptionColumn) IsNot DBNull.Value Then
                            aTextField.FieldCaption = aRow(Constants.FieldCaptionColumn)
                        End If
                        If aRow(Constants.TabIndexColumn) IsNot DBNull.Value Then
                            aTextField.TabIndex = aRow(Constants.TabIndexColumn)
                        End If
                        If aRow(Constants.IsRequiredColumn) IsNot DBNull.Value Then
                            If aRow(Constants.IsRequiredColumn).ToString() = "Y" Then
                                aTextField.IsRequired = True
                            End If
                        End If
                        aTextField.FieldReadOnly = Data.IsFieldReadOnly(aTextField.FieldName, Me.QuestionID)
                        mFieldCollection.Add(aTextField)
                    Case SurveyFieldBase.FieldDataTypes.qdStudyArea
                        aTextField = New SurveyFieldText()
                        aTextField.FieldName = aRow(Constants.FieldNameColumn)
                        aTextField.FieldType = SurveyFieldBase.FieldDataTypes.qdStudyArea
                        aTextField.TableName = aRow(Constants.MappedTableNameColumn)
                        aTextField.QuestionID = mQuestionID
                        If aRow(Constants.IsSkipFieldColumn).ToString() = "1" Then
                            aTextField.IsSkipField = True
                        Else
                            aTextField.IsSkipField = False
                        End If
                        If aRow(Constants.FieldCaptionColumn) IsNot DBNull.Value Then
                            aTextField.FieldCaption = aRow(Constants.FieldCaptionColumn)
                        End If
                        If aRow(Constants.TabIndexColumn) IsNot DBNull.Value Then
                            aTextField.TabIndex = aRow(Constants.TabIndexColumn)
                        End If
                        If aRow(Constants.IsRequiredColumn) IsNot DBNull.Value Then
                            If aRow(Constants.IsRequiredColumn).ToString() = "Y" Then
                                aTextField.IsRequired = True
                            End If
                        End If
                        aTextField.FieldReadOnly = Data.IsFieldReadOnly(aTextField.FieldName, Me.QuestionID)
                        mFieldCollection.Add(aTextField)
                    Case SurveyFieldBase.FieldDataTypes.qdOnOff
                        aOnOff = New SurveyFieldOnOff
                        aOnOff.FieldName = aRow(Constants.FieldNameColumn)
                        aOnOff.FieldType = SurveyFieldBase.FieldDataTypes.qdStudyArea
                        aOnOff.TableName = aRow(Constants.MappedTableNameColumn)
                        aOnOff.QuestionID = mQuestionID
                        aOnOff.FieldType = SurveyFieldBase.FieldDataTypes.qdOnOff
                        If aRow(Constants.IsSkipFieldColumn).ToString() = "1" Then
                            aOnOff.IsSkipField = True
                        Else
                            aOnOff.IsSkipField = False
                        End If
                        If aRow(Constants.FieldCaptionColumn) IsNot DBNull.Value Then
                            aOnOff.FieldCaption = aRow(Constants.FieldCaptionColumn)
                        End If
                        If aRow(Constants.TabIndexColumn) IsNot DBNull.Value Then
                            aOnOff.TabIndex = aRow(Constants.TabIndexColumn)
                        End If
                        If aRow(Constants.IsRequiredColumn) IsNot DBNull.Value Then
                            If aRow(Constants.IsRequiredColumn).ToString() = "Y" Then
                                aOnOff.IsRequired = True
                            End If
                        End If
                        aOnOff.FieldReadOnly = Data.IsFieldReadOnly(aOnOff.FieldName, Me.QuestionID)
                        mFieldCollection.Add(aOnOff)
                    Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                        aMultiTextField = New SurveyFieldMultipleText()
                        aMultiTextField.FieldName = aRow(Constants.FieldNameColumn)
                        aMultiTextField.TableName = aRow(Constants.MappedTableNameColumn)
                        aMultiTextField.QuestionID = mQuestionID
                        If mResponseGroupID <> Constants.NonExistent Then
                            aMultiTextField.LoadResponses(mResponseGroupID)
                        End If
                        If aRow(Constants.IsSkipFieldColumn).ToString() = "1" Then
                            aMultiTextField.IsSkipField = True
                        Else
                            aMultiTextField.IsSkipField = False
                        End If
                        If aRow(Constants.FieldCaptionColumn) IsNot DBNull.Value Then
                            aMultiTextField.FieldCaption = aRow(Constants.FieldCaptionColumn)
                        End If
                        If aRow(Constants.TabIndexColumn) IsNot DBNull.Value Then
                            aMultiTextField.TabIndex = aRow(Constants.TabIndexColumn)
                        End If
                        If aRow(Constants.IsRequiredColumn) IsNot DBNull.Value Then
                            If aRow(Constants.IsRequiredColumn).ToString() = "Y" Then
                                aMultiTextField.IsRequired = True
                            End If
                        End If
                        aMultiTextField.FieldReadOnly = Data.IsFieldReadOnly(aMultiTextField.FieldName, Me.QuestionID)
                        mFieldCollection.Add(aMultiTextField)
                    Case SurveyFieldBase.FieldDataTypes.qdMultipleDates
                        aMultiDateField = New SurveyFieldMultipleDates()
                        aMultiDateField.FieldName = aRow(Constants.FieldNameColumn)
                        aMultiDateField.FieldName = aRow(Constants.FieldNameColumn)
                        aMultiDateField.TableName = aRow(Constants.MappedTableNameColumn)
                        aMultiDateField.QuestionID = mQuestionID
                        If aRow(Constants.DateMaxColumn) IsNot DBNull.Value Then
                            aMultiDateField.Max = CType(aRow(Constants.DateMaxColumn), Date)
                        End If
                        If aRow(Constants.DateMinColumn) IsNot DBNull.Value Then
                            aMultiDateField.Min = CType(aRow(Constants.DateMinColumn), Date)
                        End If
                        If aRow(Constants.IsSkipFieldColumn).ToString() = "1" Then
                            aMultiDateField.IsSkipField = True
                        Else
                            aMultiDateField.IsSkipField = False
                        End If
                        If aRow(Constants.FieldCaptionColumn) IsNot DBNull.Value Then
                            aMultiDateField.FieldCaption = aRow(Constants.FieldCaptionColumn)
                        End If
                        If aRow(Constants.TabIndexColumn) IsNot DBNull.Value Then
                            aMultiDateField.TabIndex = aRow(Constants.TabIndexColumn)
                        End If
                        If aRow(Constants.IsRequiredColumn) IsNot DBNull.Value Then
                            If aRow(Constants.IsRequiredColumn).ToString() = "Y" Then
                                aMultiDateField.IsRequired = True
                            End If
                        End If
                        aMultiDateField.FieldReadOnly = Data.IsFieldReadOnly(aMultiDateField.FieldName, Me.QuestionID)
                        mFieldCollection.Add(aMultiDateField)
                    Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber
                        aMultiNumberField = New SurveyFieldMultipleNumbers()
                        aMultiNumberField.FieldName = aRow(Constants.FieldNameColumn)
                        aMultiNumberField.FieldName = aRow(Constants.FieldNameColumn)
                        aMultiNumberField.TableName = aRow(Constants.MappedTableNameColumn)
                        aMultiNumberField.QuestionID = mQuestionID
                        If mResponseGroupID <> Constants.NonExistent Then
                            aMultiNumberField.LoadResponses(mResponseGroupID)
                        End If
                        If aRow(Constants.IsSkipFieldColumn).ToString() = "1" Then
                            aMultiNumberField.IsSkipField = True
                        Else
                            aMultiNumberField.IsSkipField = False
                        End If
                        If aRow(Constants.NumberMaxColumn) IsNot DBNull.Value Then
                            aMultiNumberField.Max = CType(aRow(Constants.NumberMaxColumn), Long)
                        End If
                        If aRow(Constants.NumberMinColumn) IsNot DBNull.Value Then
                            aMultiNumberField.Min = CType(aRow(Constants.NumberMinColumn), Long)
                        End If
                        If aRow(Constants.FieldCaptionColumn) IsNot DBNull.Value Then
                            aMultiNumberField.FieldCaption = aRow(Constants.FieldCaptionColumn)
                        End If
                        If aRow(Constants.TabIndexColumn) IsNot DBNull.Value Then
                            aMultiNumberField.TabIndex = aRow(Constants.TabIndexColumn)
                        End If
                        If aRow(Constants.IsRequiredColumn) IsNot DBNull.Value Then
                            If aRow(Constants.IsRequiredColumn).ToString() = "Y" Then
                                aMultiNumberField.IsRequired = True
                            End If
                        End If
                        aMultiNumberField.FieldReadOnly = Data.IsFieldReadOnly(aMultiNumberField.FieldName, Me.QuestionID)
                        mFieldCollection.Add(aMultiNumberField)
                End Select
            Next

        End If
        dt.Dispose()
        GC.Collect()
    End Sub

#End Region
    Public Overrides Function ToString() As String
        Return mQuestionNumber & ". " & mQuestionText
    End Function
End Class
