Public Class Constants
    Public Shared ReadOnly Property QuestionnaireIDColumn() As String
        Get
            Return "QuestionnaireID"
        End Get
    End Property
    Public Shared ReadOnly Property StudyTitleColumn() As String
        Get
            Return "StudyTitle"
        End Get
    End Property
    Public Shared ReadOnly Property QuestionnaireTitleColumn() As String
        Get
            Return "QuestionnaireTitle"
        End Get
    End Property
    Public Shared ReadOnly Property AssociatedTableColumn() As String
        Get
            Return "AssociatedTable"
        End Get
    End Property
    Public Shared ReadOnly Property ResultsQueryColumn() As String
        Get
            Return "ResultsQueryColumns"
        End Get
    End Property
    Public Shared ReadOnly Property RecordDeletedColumn() As String
        Get
            Return "RecordDeleted"
        End Get
    End Property
    Public Shared ReadOnly Property RecordCompleteColumn() As String
        Get
            Return "RecordCompleted"
        End Get
    End Property
    Public Shared ReadOnly Property StudyAreaTypeColumn() As String
        Get
            Return "StudyAreaType"
        End Get
    End Property
    Public Shared ReadOnly Property StartTimeColumn() As String
        Get
            Return "StartTime"
        End Get
    End Property
    Public Shared ReadOnly Property EndTimeColumn() As String
        Get
            Return "EndTime"
        End Get
    End Property
    Public Shared ReadOnly Property ResultsIDColumn() As String
        Get
            Return "ResultsID"
        End Get
    End Property
    Public Shared ReadOnly Property QuestionIDColumn() As String
        Get
            Return "SubQID"
        End Get
    End Property
    Public Shared ReadOnly Property QuestionNoColumn() As String
        Get
            Return "QuestionNo"
        End Get
    End Property
    Public Shared ReadOnly Property QuestionTextColumn() As String
        Get
            Return "QuestionText"
        End Get
    End Property
    Public Shared ReadOnly Property QuestionInstructionsColumn() As String
        Get
            Return "Instructions"
        End Get
    End Property
    Public Shared ReadOnly Property SectionIDColumn() As String
        Get
            Return "SectionID"
        End Get
    End Property
    Public Shared ReadOnly Property SubSectionIDColumn() As String
        Get
            Return "SubSectionID"
        End Get
    End Property
    Public Shared ReadOnly Property SectionTitleColumn() As String
        Get
            Return "SectionTitle"
        End Get
    End Property
    Public Shared ReadOnly Property SectionInstructionColumn() As String
        Get
            Return "Instructions"
        End Get
    End Property
    Public Shared ReadOnly Property SubSectionTitleColumn() As String
        Get
            Return "SubSectionTitle"
        End Get
    End Property
    Public Shared ReadOnly Property SubsectionInstructionColumn() As String
        Get
            Return "Instructions"
        End Get
    End Property
    Public Shared ReadOnly Property ControlTypeColumn() As String
        Get
            Return "ControlType"
        End Get
    End Property
    Public Shared ReadOnly Property ControlNameColumn() As String
        Get
            Return "ControlName"
        End Get
    End Property
    Public Shared ReadOnly Property HasOtherColumn() As String
        Get
            Return "HasOther"
        End Get
    End Property
    Public Shared ReadOnly Property OtherFieldNameColumn() As String
        Get
            Return "OtherFieldName"
        End Get
    End Property
    Public Shared ReadOnly Property ControlNameNone() As String
        Get
            Return "NONE"
        End Get
    End Property
    Public Shared ReadOnly Property ResponseGroupIDColumn() As String
        Get
            Return "ResponseGroupID"
        End Get
    End Property
    Public Shared ReadOnly Property ResponseTextColumn() As String
        Get
            Return "ResponseText"
        End Get
    End Property
    Public Shared ReadOnly Property ResponseIDColumn() As String
        Get
            Return "ResponseID"
        End Get
    End Property
    Public Shared ReadOnly Property NonExistent() As Integer
        Get
            Return -1
        End Get
    End Property
    Public Shared ReadOnly Property CodedValueColumn() As String
        Get
            Return "CodedValue"
        End Get
    End Property
    Public Shared ReadOnly Property FieldTypeColumn() As String
        Get
            Return "FieldType"
        End Get
    End Property
    Public Shared ReadOnly Property FieldNameColumn() As String
        Get
            Return "FieldName"
        End Get
    End Property
    Public Shared ReadOnly Property TabIndexColumn() As String
        Get
            Return "TabIndex"
        End Get
    End Property
    Public Shared ReadOnly Property FieldCaptionColumn() As String
        Get
            Return "FieldCaption"
        End Get
    End Property
    Public Shared ReadOnly Property DateMinColumn() As String
        Get
            Return "DateMin"
        End Get
    End Property
    Public Shared ReadOnly Property DateMaxColumn() As String
        Get
            Return "DateMax"
        End Get
    End Property
    Public Shared ReadOnly Property NumberMinColumn() As String
        Get
            Return "NumberMin"
        End Get
    End Property
    Public Shared ReadOnly Property NumberMaxColumn() As String
        Get
            Return "NumberMax"
        End Get
    End Property
    Public Shared ReadOnly Property MappedTableNameColumn() As String
        Get
            Return "TableName"
        End Get
    End Property
    Public Shared ReadOnly Property IsSkipFieldColumn() As String
        Get
            Return "IsSkipField"
        End Get
    End Property
    Public Shared ReadOnly Property IsRequiredColumn() As String
        Get
            Return "Mandatory"
        End Get
    End Property
    Public Shared ReadOnly Property SkipFieldValueColumn() As String
        Get
            Return "FieldValue"
        End Get
    End Property
    Public Shared ReadOnly Property SkipToQIDColumn() As String
        Get
            Return "SkipToQID"
        End Get
    End Property
    Public Shared ReadOnly Property IsExpressionColumn() As String
        Get
            Return "IsExpression"
        End Get
    End Property
    'ndisha doing her thing thing
    Public Shared ReadOnly Property ProvinceIDColumn() As String
        Get
            Return "ID"
        End Get
    End Property
    Public Shared ReadOnly Property ProvincesProvIDColumn() As String
        Get
            Return "ProvinceID"
        End Get
    End Property
    Public Shared ReadOnly Property ProvinceNameColumn() As String
        Get
            Return "ProvinceName"
        End Get
    End Property
    Public Shared ReadOnly Property SiteIDColumn() As String
        Get
            Return "ID"
        End Get
    End Property
    Public Shared ReadOnly Property SiteNameColumn() As String
        Get
            Return "SiteName"
        End Get
    End Property
    Public Shared ReadOnly Property SiteProvIDColumn() As String
        Get
            Return "ProvID"
        End Get
    End Property
    Public Shared ReadOnly Property DistrictIDColumn() As String
        Get
            Return "DistrictID"
        End Get
    End Property
    Public Shared ReadOnly Property DistrictsProvinceIDColumn() As String
        Get
            Return "ProvinceID"
        End Get
    End Property
    Public Shared ReadOnly Property DistrictNameColumn() As String
        Get
            Return "DistrictName"
        End Get
    End Property
    Public Shared ReadOnly Property SynchFlagColumn() As String
        Get
            Return "SYNCH_FLAG"
        End Get
    End Property
    Public Shared ReadOnly Property ValueIndexColumn() As String
        Get
            Return "ValueIdx"
        End Get
    End Property
    'durations specifics
    Public Shared ReadOnly Property SelectedMonthColumn() As String
        'this is also the value index column
        Get

            Return "SelectedMonth"
        End Get
    End Property
    Public Shared ReadOnly Property DurationColumn() As String
        Get
            Return "Duration"
        End Get
    End Property
    Public Shared ReadOnly Property DurationTypeColumn() As String
        Get
            Return "DurationType"
        End Get
    End Property
    Public Shared ReadOnly Property TrainingTypeColumn() As String
        Get
            Return "TrainingType"
        End Get
    End Property
    Public Shared ReadOnly Property NumberTrainedColumn() As String
        Get
            Return "NumberTrained"
        End Get
    End Property
    Public Shared ReadOnly Property RowPopulationColumn() As String
        Get
            Return "ColPop"
        End Get
    End Property

#Region "Control Names"
    Public Shared ReadOnly Property MultiSelectAndMonthControl() As String
        Get
            Return "MultiMonthSelect"
        End Get
    End Property
    Public Shared ReadOnly Property MultiSelectSingleField() As String
        Get
            Return "MultiSelectSingleField"
        End Get
    End Property
    Public Shared ReadOnly Property MultiSelectMultiField() As String
        Get
            Return "MultiSelectMultiFields"
        End Get
    End Property
    Public Shared ReadOnly Property GridControl() As String
        Get
            Return "EditGrid"
        End Get
    End Property
#End Region
    Public Shared ReadOnly Property OtherString() As String
        Get
            Return "Other"
        End Get
    End Property
    Public Shared ReadOnly Property OtherSpecify() As String
        Get
            Return "Specify no. of weeks"
        End Get
    End Property
    Public Shared ReadOnly Property UnknownString() As String
        Get
            Return "Unknown"
        End Get
    End Property
    Public Shared ReadOnly Property ExpressionConstant() As String
        Get
            Return "E"
        End Get
    End Property
    Public Shared ReadOnly Property ValueConstant() As String
        Get
            Return "V"
        End Get
    End Property
End Class
