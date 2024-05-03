Imports System.Collections
Imports System.Data
Imports System.Data.SqlServerCe
Public Enum QuestionnaireMode
    qModeDesign = 0
    qModeNewResults = 1
    qModeReviewResults = 2
End Enum
Public Class Questionnaire
    Public Structure QuestionSkip
        Public FieldValue As Object
        Public SkipToQuestionID As Integer
        Public IsExpression As Boolean
    End Structure
    Private mQuestions As New List(Of SurveyQuestion)
    Private BackNavigationStack As New Stack(Of SurveyQuestion)
    Private ForwardNavigationStack As New Stack(Of SurveyQuestion)
    Private mCurrentQuestion As New SurveyQuestion
    Private mQuestionnaireID As Integer
    Private mResultsID As String
    Private mBOQ As Boolean = False
    Private mEOQ As Boolean = False
    Private mQuestionnaireTitle As String
    Private mQuestionnaireMode As QuestionnaireMode
    Private mAssociatedTable As String
    Private mResultsQueryColumns As String
    Private StartTime As DateTime
    Private mResults As New DataTable("Results")

    Public Event NewResults(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event ReviewStarted(ByVal sendar As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event QuestionsReadingCompleted(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event BeforeNavigateForward(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event BeforeNavigateBackward(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event AfterNavigateForward(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event AfterNavigateBackward(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event BeforeSave(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event AfterSave(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event SaveFailed(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event EndOfQuestionnaire(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Event BeginningOfQuestionnaire(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Property ResultsQueryColumns() As String
        Get
            Return mResultsQueryColumns
        End Get
        Set(ByVal value As String)
            mResultsQueryColumns = value
        End Set
    End Property
    Public Property AssociatedTable() As String
        Get
            Return mAssociatedTable
        End Get
        Set(ByVal value As String)
            mAssociatedTable = value
        End Set
    End Property
    Public Property QuestionnaireMode() As QuestionnaireMode
        Get
            Return mQuestionnaireMode
        End Get
        Set(ByVal value As QuestionnaireMode)
            mQuestionnaireMode = value
        End Set
    End Property
    Public Property QuestionnaireTitle() As String
        Get
            Return mQuestionnaireTitle
        End Get
        Set(ByVal value As String)
            mQuestionnaireTitle = value
        End Set
    End Property
    Public ReadOnly Property BOQ() As Boolean
        Get
            Return mBOQ
        End Get
    End Property
    Public ReadOnly Property EOQ() As Boolean
        Get
            Return mEOQ
        End Get
    End Property
    Public Property QuestionnaireID() As Integer
        Get
            Return mQuestionnaireID
        End Get
        Set(ByVal value As Integer)
            mQuestionnaireID = value
        End Set
    End Property
    Public ReadOnly Property QuestionHitCount() As Integer
        Get
            Return BackNavigationStack.Count
        End Get
    End Property
    Public ReadOnly Property ResultsID() As String
        Get
            Return mResultsID
        End Get
    End Property
    Public Function LoadDisplayResults() As DataTable
        Return Data.SelectData(mResultsQueryColumns, mAssociatedTable)
    End Function
    Public Sub ReadQuestions()
        Dim SurveyQuestions As SqlCeDataReader
        Dim aQuestion As SurveyQuestion = Nothing
        Dim aForwardQuestion As SurveyQuestion = Nothing
        Dim aSection As Header
        Dim aSubsection As Header
        Dim aRow As DataRow = Nothing
        Dim e As New EventsNameSpace.EventArgs

        'Read the questions first
        If mQuestions.Count = 0 Then
            SurveyQuestions = Data.ReadDataR(My.Resources.QuestionsTable, Constants.QuestionnaireIDColumn & " = " & QuestionnaireID.ToString(), True, Constants.QuestionIDColumn, Data.SortEnum.Ascending)
            Do While SurveyQuestions.Read()
                aQuestion = New SurveyQuestion
                aQuestion.QuestionID = SurveyQuestions(Constants.QuestionIDColumn)
                aQuestion.QuestionNumber = SurveyQuestions(Constants.QuestionNoColumn)
                aQuestion.QuestionText = SurveyQuestions(Constants.QuestionTextColumn)
                If SurveyQuestions(Constants.QuestionInstructionsColumn) IsNot DBNull.Value Then
                    aQuestion.QuestionInstruction = SurveyQuestions(Constants.QuestionInstructionsColumn)
                End If
                If SurveyQuestions(Constants.ResponseGroupIDColumn) IsNot DBNull.Value Then
                    aQuestion.ResponseGroup = SurveyQuestions(Constants.ResponseGroupIDColumn)
                Else
                    aQuestion.ResponseGroup = Constants.NonExistent
                End If
                If SurveyQuestions(Constants.QuestionInstructionsColumn) IsNot DBNull.Value Then
                    aQuestion.QuestionInstruction = SurveyQuestions(Constants.QuestionInstructionsColumn)
                End If
                aSection = New Header
                aSection.HeaderID = ""
                aSection.HeaderInstructions = ""
                aSection.HeaderTitle = ""
                If SurveyQuestions(Constants.SectionIDColumn) IsNot DBNull.Value Then
                    aSection.HeaderID = SurveyQuestions(Constants.SectionIDColumn)
                End If
                aQuestion.Section = aSection
                aSubsection = New Header
                aSubsection.HeaderID = ""
                aSubsection.HeaderInstructions = ""
                aSection.HeaderTitle = ""
                If SurveyQuestions(Constants.SubSectionIDColumn) IsNot DBNull.Value Then
                    aSubsection = New Header
                    aSubsection.HeaderID = SurveyQuestions(Constants.SubSectionIDColumn)
                End If
                aQuestion.QStudyAreaType = SurveyQuestions(Constants.StudyAreaTypeColumn)
                aQuestion.Subsection = aSubsection
                aQuestion.QuestionControlType = SurveyQuestions(Constants.ControlTypeColumn)
                If SurveyQuestions(Constants.ControlNameColumn) IsNot DBNull.Value Then
                    aQuestion.ControlName = SurveyQuestions(Constants.ControlNameColumn)
                End If
                'If SurveyQuestions(Constants.HasOtherColumn) IsNot DBNull.Value Then
                '    aQuestion.HasOther = SurveyQuestions(Constants.HasOtherColumn)
                'End If
                'If SurveyQuestions(Constants.OtherFieldNameColumn) IsNot DBNull.Value Then
                '    aQuestion.OtherFieldName = SurveyQuestions(Constants.OtherFieldNameColumn)
                'End If
                mQuestions.Add(aQuestion)
            Loop
            RaiseEvent QuestionsReadingCompleted(Me, e)
            SurveyQuestions.Dispose()
        End If
    End Sub
    Public Sub PrepareQuestions()
        Dim aQuestion As SurveyQuestion
        For Each aQuestion In mQuestions
            aQuestion.Prepare()
        Next
    End Sub
    Public Function ProcessSkips(ByVal CurrentQuestion As SurveyQuestion) As Integer
        Dim nextQuestionID As Integer = 0
        Dim aTextField As SurveyFieldText
        Dim aNumberField As SurveyFieldNumber
        Dim aDateField As SurveyFieldDate
        Dim aOnOff As SurveyFieldOnOff
        Dim SkipsDR As SqlCeDataReader

        SkipsDR = Data.ReadDataR(My.Resources.SkipsTable, Constants.QuestionIDColumn & " = " & CurrentQuestion.QuestionID.ToString())
        For Each aQuestionField In CurrentQuestion.Fields
            If aQuestionField.IsSkipField Then
                Do While SkipsDR.Read()
                    If (SkipsDR(Constants.IsExpressionColumn).ToString().Trim() = Constants.ExpressionConstant) Then
                        If EvaluateExpression(SkipsDR(Constants.SkipFieldValueColumn), aQuestionField) = True Then
                            nextQuestionID = SkipsDR(Constants.SkipToQIDColumn)
                            Return nextQuestionID
                        Else
                            'continue processing
                        End If
                    Else
                        Select Case aQuestionField.FieldType
                            Case SurveyFieldBase.FieldDataTypes.qdDate
                                aDateField = aQuestionField
                                If aDateField.FieldValue.FieldValue = Convert.ToDateTime(SkipsDR(Constants.SkipFieldValueColumn)) Then
                                    nextQuestionID = SkipsDR(Constants.SkipToQIDColumn)
                                    Return nextQuestionID
                                End If
                            Case SurveyFieldBase.FieldDataTypes.qdNumber
                                aNumberField = aQuestionField
                                If aNumberField.FieldValue.FieldValue.ToString().Trim() = SkipsDR(Constants.SkipFieldValueColumn).ToString.Trim() Then
                                    nextQuestionID = SkipsDR(Constants.SkipToQIDColumn)
                                    Return nextQuestionID
                                End If
                            Case SurveyFieldBase.FieldDataTypes.qdOptions
                                aNumberField = aQuestionField
                                If aNumberField.FieldValue.FieldValue.ToString().Trim() = SkipsDR(Constants.SkipFieldValueColumn).ToString.Trim() Then
                                    nextQuestionID = SkipsDR(Constants.SkipToQIDColumn)
                                    Return nextQuestionID
                                End If
                            Case SurveyFieldBase.FieldDataTypes.qdText
                                aTextField = aQuestionField
                                If aTextField.FieldValue.FieldValue.Trim() = SkipsDR(Constants.SkipFieldValueColumn).ToString.Trim() Then
                                    nextQuestionID = SkipsDR(Constants.SkipToQIDColumn)
                                    Return nextQuestionID
                                End If
                            Case SurveyFieldBase.FieldDataTypes.qdOnOff
                                aOnOff = aQuestionField
                                If aOnOff.FieldValue.FieldValue.ToString().Trim() = SkipsDR(Constants.SkipFieldValueColumn).ToString.Trim() Then
                                    nextQuestionID = SkipsDR(Constants.SkipToQIDColumn)
                                    Return nextQuestionID
                                End If
                            Case Else
                                Exit For
                        End Select
                    End If
                Loop
            End If
        Next
        'SkipsDR.Close()
        SkipsDR.Dispose()
        Return nextQuestionID
    End Function
    Private Function EvaluateExpression(ByVal Expression As String, ByVal qFields As SurveyFieldBase) As Boolean
        'miss ndisha
        Dim aMultitext As SurveyFieldMultipleText
        Dim aMultiDates As SurveyFieldMultipleDates
        Dim aMultiNumber As SurveyFieldMultipleNumbers
        If Expression.StartsWith("COUNT") Then
            Select Case qFields.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber
                    aMultiNumber = qFields
                    If aMultiNumber.FieldValues.Count = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                    aMultitext = qFields
                    If aMultitext.FieldValues.Count = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdMultipleDates
                    aMultiDates = qFields
                    If aMultiDates.FieldValues.Count = 1 Then
                        Return True
                    Else
                        Return False
                    End If
            End Select
        End If
    End Function
    Public Sub AddQuestion(ByVal SurveyQuestion As SurveyQuestion)
        mQuestions.Add(SurveyQuestion)
    End Sub
    Private Sub RemoveQuestion(ByRef SurveyQuestion As SurveyQuestion)
        mQuestions.Remove(SurveyQuestion)
    End Sub
    Private Sub ClearQuestions()
        mQuestions.Clear()
    End Sub
    Public ReadOnly Property Questions()
        Get
            Return mQuestions
        End Get
    End Property
    Public Sub Save(ByVal EndTime As DateTime)
        Dim e As New EventsNameSpace.EventArgs
        RaiseEvent BeforeSave(Me, e)
        If Data.SaveResults(mAssociatedTable, ForwardNavigationStack, Constants.ResultsIDColumn, mResultsID, StartTime, EndTime, mQuestionnaireID) = True Then
            RaiseEvent AfterSave(Me, e)
        Else
            RaiseEvent SaveFailed(Me, e)
        End If
    End Sub
    Public Function SaveTimeStamp(ByVal EndTime As DateTime) As Boolean
        Data.SaveTimeStamp(mAssociatedTable, Constants.ResultsIDColumn, mResultsID, Constants.EndTimeColumn, EndTime, "Y")
        Return True
    End Function
    Public Sub SaveBackNavigationStack(ByVal EndTime As DateTime)
        Dim aSurveyQuestion As SurveyQuestion
        While BackNavigationStack.Count <> 0
            aSurveyQuestion = BackNavigationStack.Pop()
            SaveQuestion(aSurveyQuestion, EndTime)
        End While
    End Sub
    Public Sub SaveQuestion(ByVal Question As SurveyQuestion, ByVal EndTime As DateTime)
        Data.SaveQuestion(Question, Constants.ResultsIDColumn, mResultsID, Constants.QuestionIDColumn, Constants.ValueIndexColumn, StartTime, EndTime)
    End Sub
    Public Sub SaveQuestion(ByVal EndTime As DateTime)
        Data.SaveQuestion(Me.CurrentQuestion, Constants.ResultsIDColumn, mResultsID, Constants.QuestionIDColumn, Constants.ValueIndexColumn, StartTime, EndTime)
    End Sub
    Public Sub ResetSavedQuestionResults()
        Data.ResetQuestionResults(mAssociatedTable, Me.CurrentQuestion, Constants.ResultsIDColumn, mResultsID, Constants.QuestionIDColumn)
    End Sub
    Public Sub AddNewResults()
        '
        ResetQuestionFields()
        mResultsID = Data.CreateGUID()
        StartTime = Now
        FirstQuestion()
        BackNavigationStack.Clear()
        ForwardNavigationStack.Clear()
        Dim e As New EventsNameSpace.EventArgs
        mQuestionnaireMode = PDAEPI.QuestionnaireMode.qModeNewResults
        RaiseEvent NewResults(Me, e)
    End Sub
    Public Sub ReviewResults(ByVal ResultsID As String)
        Dim e As New EventsNameSpace.EventArgs
        mQuestionnaireMode = PDAEPI.QuestionnaireMode.qModeReviewResults
        mResultsID = ResultsID
        If ResultsID.Trim() = "" Then
            Exit Sub
        Else
            ResetQuestionFields()
            BackNavigationStack.Clear()
            ForwardNavigationStack.Clear()
            mResults.Rows.Clear()
            mResults.Columns.Clear()
            mResults = Data.ReadData(mAssociatedTable, Constants.ResultsIDColumn, ResultsID)
            FirstQuestion()
            RaiseEvent ReviewStarted(Me, e)
        End If
    End Sub
    Public Sub DiscardResults(ByVal ResultsID As String)
        Data.DiscardResults(Constants.ResultsIDColumn, ResultsID, Constants.QuestionIDColumn, mQuestionnaireID)
    End Sub
    Public Sub ResetQuestionFields()
        'clear the entered data in the fields
        Dim I As Integer
        For I = 0 To mQuestions.Count - 1
            mQuestions(I).ResetFields()
        Next
    End Sub
    Public Property CurrentQuestion() As SurveyQuestion
        Get
            Return mCurrentQuestion
        End Get
        Set(ByVal value As SurveyQuestion)
            mCurrentQuestion = value
        End Set
    End Property
    Public Function FirstQuestion() As SurveyQuestion
        Dim e As New EventsNameSpace.EventArgs
        If mQuestions.Count <> 0 Then
            mCurrentQuestion = mQuestions(0)
            mCurrentQuestion.Prepare()
        End If
        mBOQ = True
        mEOQ = False
        RaiseEvent BeginningOfQuestionnaire(Me, e)
        If mQuestionnaireMode = PDAEPI.QuestionnaireMode.qModeReviewResults Then
            GetQuestionResults()
        End If
        Return mCurrentQuestion
    End Function
    Private Sub GetQuestionResults()
        'fill the question
        For I = 0 To mCurrentQuestion.Fields.Count - 1
            If mCurrentQuestion.Fields(I).TableName.Trim() = mAssociatedTable.Trim() Then
                Select Case mCurrentQuestion.Fields(I).FieldType
                    Case SurveyFieldBase.FieldDataTypes.qdDate
                        Dim aDateField As SurveyFieldDate
                        Dim aDateValue As New DateFieldValue
                        aDateField = mCurrentQuestion.Fields(I)
                        If mResults.Rows(0)(aDateField.FieldName) IsNot DBNull.Value Then
                            aDateValue.FieldValue = mResults.Rows(0)(aDateField.FieldName)
                            aDateField.FieldValue = aDateValue
                        End If
                    Case SurveyFieldBase.FieldDataTypes.qdNumber, SurveyFieldBase.FieldDataTypes.qdOptions
                        Dim aNumberField As SurveyFieldNumber
                        Dim aNumberValue As New NumberFieldValue
                        aNumberField = mCurrentQuestion.Fields(I)
                        If mResults.Rows(0)(aNumberField.FieldName) IsNot DBNull.Value Then
                            aNumberValue.FieldValue = mResults.Rows(0)(aNumberField.FieldName)
                            aNumberField.FieldValue = aNumberValue
                        End If
                    Case SurveyFieldBase.FieldDataTypes.qdOnOff
                        Dim aOnOffField As SurveyFieldOnOff
                        Dim aOnOffValue As New OnOffFieldValue
                        aOnOffField = mCurrentQuestion.Fields(I)
                        If mResults.Rows(0)(aOnOffField.FieldName) IsNot DBNull.Value Then
                            aOnOffValue.FieldValue = mResults.Rows(0)(aOnOffField.FieldName)
                            aOnOffField.FieldValue = aOnOffValue
                        End If
                    Case SurveyFieldBase.FieldDataTypes.qdText, SurveyFieldBase.FieldDataTypes.qdStudyArea
                        Dim aTextField As SurveyFieldText
                        Dim aTextValue As New TextFieldValue
                        aTextField = mCurrentQuestion.Fields(I)
                        If mResults.Rows(0)(aTextField.FieldName) IsNot DBNull.Value Then
                            aTextValue.FieldValue = mResults.Rows(0)(aTextField.FieldName)
                            aTextField.FieldValue = aTextValue
                        End If
                End Select
            Else
                Dim RelatedData As New DataTable("RelatedData")
                Dim K As Integer
                RelatedData = Data.ReadRelatedData(mCurrentQuestion.Fields(I).TableName.Trim(), Constants.ResultsIDColumn, mResultsID, Constants.QuestionIDColumn, mCurrentQuestion.QuestionID)
                Select Case mCurrentQuestion.Fields(I).FieldType
                    Case SurveyFieldBase.FieldDataTypes.qdMultipleDates
                        Dim aMultiDate As SurveyFieldMultipleDates
                        Dim aDateValue As DateFieldValue
                        aMultiDate = mCurrentQuestion.Fields(I)
                        For K = 0 To RelatedData.Rows.Count - 1
                            If RelatedData.Rows(K)(aMultiDate.FieldName) IsNot DBNull.Value Then
                                aDateValue = New DateFieldValue
                                aDateValue.FieldValue = RelatedData.Rows(K)(aMultiDate.FieldName)
                                If RelatedData.Rows(K)(Constants.ValueIndexColumn) IsNot DBNull.Value Then
                                    aDateValue.ValueIndex = RelatedData.Rows(K)(Constants.ValueIndexColumn)
                                End If
                                aMultiDate.FieldValues.Add(aDateValue)
                            End If
                        Next
                    Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber
                        Dim aMultiNumber As SurveyFieldMultipleNumbers
                        Dim aNumberValue As NumberFieldValue
                        aMultiNumber = mCurrentQuestion.Fields(I)
                        For K = 0 To RelatedData.Rows.Count - 1
                            If RelatedData.Rows(K)(aMultiNumber.FieldName) IsNot DBNull.Value Then
                                aNumberValue = New NumberFieldValue
                                aNumberValue.FieldValue = RelatedData.Rows(K)(aMultiNumber.FieldName)
                                If RelatedData.Rows(K)(Constants.ValueIndexColumn) IsNot DBNull.Value Then
                                    aNumberValue.ValueIndex = RelatedData.Rows(K)(Constants.ValueIndexColumn)
                                End If
                                aMultiNumber.FieldValues.Add(aNumberValue)
                            End If
                        Next
                    Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                        Dim aMultiText As SurveyFieldMultipleText
                        Dim aTextValue As TextFieldValue
                        aMultiText = mCurrentQuestion.Fields(I)
                        For K = 0 To RelatedData.Rows.Count - 1
                            If RelatedData.Rows(K)(aMultiText.FieldName) IsNot DBNull.Value Then
                                aTextValue = New TextFieldValue
                                aTextValue.FieldValue = RelatedData.Rows(K)(aMultiText.FieldName)
                                If RelatedData.Rows(K)(Constants.ValueIndexColumn) IsNot DBNull.Value Then
                                    aTextValue.ValueIndex = RelatedData.Rows(K)(Constants.ValueIndexColumn)
                                End If
                                aMultiText.FieldValues.Add(aTextValue)
                            End If
                        Next
                End Select
            End If
        Next I
    End Sub
    Public Function NextQuestion() As SurveyQuestion
        Dim nextQuestionID As Integer
        Dim e As New EventsNameSpace.EventArgs
        Dim nNextIdx As Integer

        'push the current question to the navigation stack
        ForwardNavigationStack.Push(Me.mCurrentQuestion)
        If BackNavigationStack.Count <> 0 Then
            BackNavigationStack.Pop()
        End If
        'get the next question using skips and set it to be the next question
        RaiseEvent BeforeNavigateForward(Me, e)
        If e.Cancel = True Then
            Return Nothing
        End If
        nextQuestionID = ProcessSkips(mCurrentQuestion)
        'search the question collection for a question id with the the same id

        If nextQuestionID = My.Resources.EndOfQuestionnaire Then
            Me.mEOQ = True
            RaiseEvent EndOfQuestionnaire(Me, e)
        Else
            Me.mEOQ = False
            If nextQuestionID = 0 Then
                nNextIdx = mQuestions.IndexOf(mCurrentQuestion)
                nNextIdx += 1
                If nNextIdx = mQuestions.Count Then
                    nNextIdx -= 1
                    mCurrentQuestion = mQuestions(nNextIdx)
                    mEOQ = True
                    RaiseEvent EndOfQuestionnaire(Me, e)
                Else
                    mCurrentQuestion = mQuestions(nNextIdx)
                End If
            Else
                Dim I As Integer
                Dim StartFrom As Integer
                StartFrom = mQuestions.IndexOf(mCurrentQuestion)
                If StartFrom = mQuestions.Count - 1 Then
                    mEOQ = True
                    mBOQ = False
                    mCurrentQuestion = mQuestions(mQuestions.Count - 1)
                    mCurrentQuestion.Prepare()
                Else
                    For I = StartFrom To mQuestions.Count - 1
                        If nextQuestionID = mQuestions(I).QuestionID Then
                            mCurrentQuestion = mQuestions(I)
                            Exit For
                        End If
                    Next
                End If
            End If
        End If
        If mEOQ = False Then
            mCurrentQuestion.Prepare()
        End If
        If mEOQ <> True Then
            RaiseEvent AfterNavigateForward(Me, e)
        End If
        If mQuestionnaireMode = PDAEPI.QuestionnaireMode.qModeReviewResults Then
            GetQuestionResults()
        End If
        Return mCurrentQuestion
    End Function
    Public Function PreviousQuestion() As SurveyQuestion
        Dim e As New EventsNameSpace.EventArgs
        RaiseEvent BeforeNavigateBackward(Me, e)
        BackNavigationStack.Push(mCurrentQuestion)
        If ForwardNavigationStack.Count > 0 Then
            mCurrentQuestion = ForwardNavigationStack.Pop()
            mBOQ = False
        Else
            If mQuestions.Count <> 0 Then
                mCurrentQuestion = mQuestions(0)
            End If
            mBOQ = True
            RaiseEvent BeginningOfQuestionnaire(Me, e)
        End If
        If mBOQ <> True Then
            RaiseEvent AfterNavigateBackward(Me, e)
        End If
        Return mCurrentQuestion
    End Function
End Class
