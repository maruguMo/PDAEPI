Public Class frmInterfaceEng
    Const BACK_TO_RESULTS_LIST = "Results list"
    Const END_OF_QUESTIONNAIRE_MENU = "Menu"
    Const BACK_STRING = "Back"
    Const NEXT_STRING = "Next"
    Dim WithEvents CurrentQuestionnaire As Questionnaire = Globals.PDAEPIStudy.CurrentQuestionnaire
    Dim WithEvents CurrentQuestion As SurveyQuestion = CurrentQuestionnaire.CurrentQuestion
    Dim NavigationForwardCancelled As Boolean = False
    Private Sub frmInterfaceEng_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        CurrentQuestionnaire = Globals.PDAEPIStudy.CurrentQuestionnaire
        Me.Text = CurrentQuestionnaire.QuestionnaireTitle
        CurrentQuestion = CurrentQuestionnaire.CurrentQuestion
        ShowQuestionDetails(False)
    End Sub
    Private Sub frmInterfaceEng_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = CurrentQuestionnaire.QuestionnaireTitle
        CurrentQuestion = CurrentQuestionnaire.CurrentQuestion
        'ShowQuestionDetails(False)
    End Sub
    Private Sub HideControls()
        txtNumber.Visible = False
        txtTextEntry.Visible = False
        cboOptions.Visible = False
        cmdRangeDisplay.Visible = False
        MultiMonthSelect.Visible = False
        MultiFields.Visible = False
        MultiSelectMultiFields.Visible = False
        MultiSelectSingleField.Visible = False
        dtDatePicker.Visible = False
        MultiFields.Controls.Clear()
        MultiFields.MultipleControls.Clear()
        studyProvincesAndSites.Visible = False
        selectAction.Visible = False
        editGrid.Visible = False
        txtNumber.Text = ""
        txtTextEntry.Text = ""
        DeviceStatus.Visible = False
    End Sub
    Private Function ShowControl(ByVal ControlName As String) As Windows.Forms.Control
        Dim aControl As Control = Nothing
        For Each aControl In pnlControls.Controls
            If aControl.Name = ControlName Then
                aControl.Visible = True
                Exit For
            End If
        Next
        Return aControl
    End Function
    Private Sub ShowQuestionDetails(ByVal NavigatingBack As Boolean)

        Dim aSurveyField As SurveyFieldBase
        Dim aTextField As SurveyFieldText
        Dim aNumberField As SurveyFieldNumber
        Dim aDateField As SurveyFieldDate
        Dim aOnOffField As SurveyFieldOnOff


        HideControls()

        lblSection.Text = CurrentQuestion.Section.HeaderTitle
        txtQuestion.Text = CurrentQuestion.ToString()
        lblSubsection.Text = CurrentQuestion.Subsection.HeaderTitle

        If CurrentQuestion.Section.HeaderInstructions.Trim() <> "" Then
            cmdSectionInstructions.Visible = True
        Else
            cmdSectionInstructions.Visible = False
        End If
        If CurrentQuestion.QuestionInstruction.Trim() <> "" Then
            cmdQuestionInstructions.Visible = True
        Else
            cmdQuestionInstructions.Visible = False
        End If
        Select Case CurrentQuestion.QuestionControlType
            Case SurveyQuestion.ControlType.ctCustom
                '
                Select Case CurrentQuestion.ControlName
                    Case Constants.MultiSelectAndMonthControl
                        ShowControl(CurrentQuestion.ControlName)
                        If NavigationForwardCancelled = False Then
                            MultiMonthSelect.PrepareControl()
                        End If
                        MultiMonthSelect.FillListView(CurrentQuestion)
                    Case Constants.MultiSelectSingleField
                        MultiSelectSingleField.Visible = True
                        If NavigationForwardCancelled = False Then
                            MultiSelectSingleField.PrepareControl(CurrentQuestion.Fields(0))
                        End If
                        MultiSelectSingleField.FillListView(CurrentQuestion.Fields(0))
                    Case Constants.MultiSelectMultiField
                        MultiSelectMultiFields.Visible = True
                        If NavigationForwardCancelled = False Then
                            MultiSelectMultiFields.PrepareControl(CurrentQuestion.Fields(0))
                        End If
                        MultiSelectMultiFields.FillListView(CurrentQuestion)
                    Case Constants.GridControl

                        editGrid.Prepare(CurrentQuestion, CurrentQuestionnaire.ResultsID)
                        editGrid.Show()
                        If NavigationForwardCancelled = False Then

                        End If
                        'editGrid.
                End Select
            Case SurveyQuestion.ControlType.ctGenerate
                MultiFields.Visible = True
                For Each aSurveyField In CurrentQuestion.Fields
                    Select Case aSurveyField.FieldType
                        Case SurveyFieldBase.FieldDataTypes.qdDate
                            aDateField = aSurveyField
                            MultiFields.MultipleControls.AddDateTimePicker(aDateField.FieldCaption, aDateField.FieldName, aDateField.Min, aDateField.Max)
                        Case SurveyFieldBase.FieldDataTypes.qdNumber
                            aNumberField = aSurveyField
                            MultiFields.MultipleControls.AddTextBox(aNumberField.FieldCaption, aNumberField.FieldName)
                        Case SurveyFieldBase.FieldDataTypes.qdOptions
                            aNumberField = aSurveyField
                            MultiFields.MultipleControls.AddComboBox(aNumberField.FieldCaption, aNumberField.FieldName, aNumberField.Responses)
                        Case SurveyFieldBase.FieldDataTypes.qdText
                            aTextField = aSurveyField
                            MultiFields.MultipleControls.AddTextBox(aTextField.FieldCaption, aTextField.FieldName)
                        Case SurveyFieldBase.FieldDataTypes.qdOnOff
                            aOnOffField = aSurveyField
                            MultiFields.MultipleControls.AddCheckBox(aOnOffField.FieldName, aOnOffField.FieldCaption)
                    End Select
                Next
                For Each aSurveyField In CurrentQuestion.Fields
                    MultiFields.FillFieldValue(aSurveyField)
                Next
            Case SurveyQuestion.ControlType.ctInbuilt
                Select Case CurrentQuestion.Fields(0).FieldType
                    Case SurveyFieldBase.FieldDataTypes.qdDate
                        aDateField = CurrentQuestion.Fields(0)
                        dtDatePicker.Visible = True
                        cmdRangeDisplay.Visible = True
                        If aDateField.Min <> Nothing Then
                            dtDatePicker.MinDate = aDateField.Min
                        End If
                        If aDateField.Max <> Nothing Then
                            dtDatePicker.MaxDate = aDateField.Max
                        End If
                        aDateField = CurrentQuestion.Fields(0)
                        If aDateField.FieldValue.FieldValue <> Nothing Then
                            dtDatePicker.Value = aDateField.FieldValue.FieldValue
                        End If
                    Case SurveyFieldBase.FieldDataTypes.qdNumber
                        txtNumber.Visible = True
                        cmdRangeDisplay.Visible = True
                        aNumberField = CurrentQuestion.Fields(0)
                        If aNumberField.FieldValue IsNot Nothing Then
                            txtNumber.Text = aNumberField.FieldValue.FieldValue.ToString()
                        End If
                    Case SurveyFieldBase.FieldDataTypes.qdOnOff
                        '?
                        aOnOffField = CurrentQuestion.Fields(0)
                        If aOnOffField.FieldValue IsNot Nothing Then
                            If aOnOffField.FieldValue.FieldValue = OnOffFieldValue.OnOffValues.dChecked Then
                                'code for the check box
                            Else
                                'code for the checkbox
                            End If
                        End If
                    Case SurveyFieldBase.FieldDataTypes.qdOptions
                        Dim aResponse As SurveyFieldBase.FieldResponses
                        cboOptions.Items.Clear()
                        For Each aResponse In CurrentQuestion.Fields(0).Responses
                            cboOptions.Items.Add(aResponse)
                        Next
                        cboOptions.Visible = True
                        cmdRangeDisplay.Visible = True
                        aNumberField = CurrentQuestion.Fields(0)
                        If aNumberField.FieldValue IsNot Nothing Then
                            For Each aResponse In cboOptions.Items
                                If aResponse.CodedValue = aNumberField.FieldValue.FieldValue Then
                                    cboOptions.SelectedItem = aResponse
                                    Exit For
                                End If
                            Next
                        End If
                    Case SurveyFieldBase.FieldDataTypes.qdStudyArea
                        studyProvincesAndSites.Visible = True
                        aTextField = CurrentQuestion.Fields(0)
                        Dim aProvince As Province
                        Dim aSite As Site
                        Dim aDistrict As District
                        If aTextField.FieldValue IsNot Nothing Then
                            If CurrentQuestion.QStudyAreaType = SurveyQuestion.StudyAreaType.studyAreaProvince Then
                                For Each aProvince In studyProvincesAndSites.cboProvinces.Items
                                    If aTextField.FieldValue.FieldValue.Trim() <> "" Then
                                        If aProvince.ProvinceName.Trim() = aTextField.FieldValue.FieldValue Then
                                            studyProvincesAndSites.cboProvinces.SelectedItem = aProvince
                                            Exit For
                                        End If
                                    End If
                                Next
                            End If
                            If CurrentQuestion.QStudyAreaType = SurveyQuestion.StudyAreaType.studyAreaSite Then
                                For Each aSite In studyProvincesAndSites.cboSites.Items
                                    If aTextField.FieldValue.FieldValue.Trim() <> "" Then
                                        If aSite.SiteName.Trim() = aTextField.FieldValue.FieldValue.Trim() Then
                                            studyProvincesAndSites.cboSites.SelectedItem = aSite
                                            Exit For
                                        End If
                                    End If
                                Next
                            End If
                            If CurrentQuestion.QStudyAreaType = SurveyQuestion.StudyAreaType.studyAreaDistrict Then
                                For Each aDistrict In studyProvincesAndSites.cboDistricts.Items
                                    If aTextField.FieldValue.FieldValue.Trim() <> "" Then
                                        If aDistrict.DistrictName.Trim() = aTextField.FieldValue.FieldValue.Trim() Then
                                            studyProvincesAndSites.cboDistricts.SelectedItem = aDistrict
                                            Exit For
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Case SurveyFieldBase.FieldDataTypes.qdText
                        txtTextEntry.Visible = True
                        aTextField = CurrentQuestion.Fields(0)
                        If aTextField.FieldValue IsNot Nothing Then
                            txtTextEntry.Text = aTextField.FieldValue.FieldValue.Trim()
                        End If
                End Select
        End Select
    End Sub
    Private Sub cmdSectionInstructions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSectionInstructions.Click
        SectionInstructionNotify.Caption = CurrentQuestion.Section.HeaderTitle
        SectionInstructionNotify.Text = CurrentQuestion.Section.HeaderInstructions
        SectionInstructionNotify.Visible = True
    End Sub
    Private Sub cmdQuestionInstructions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuestionInstructions.Click
        SectionInstructionNotify.Caption = "Question Instructions"
        SectionInstructionNotify.Text = CurrentQuestion.QuestionInstruction
        SectionInstructionNotify.Visible = True
    End Sub
    Private Sub mnuNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNext.Click
        Dim aSite As Site
        Dim aFieldValue As New TextFieldValue
        NavigationForwardCancelled = False
        Cursor.Current = Cursors.WaitCursor
        CurrentQuestionnaire.NextQuestion()
        Cursor.Current = Cursors.Default
        CurrentQuestion = CurrentQuestionnaire.CurrentQuestion
        If CurrentQuestion.QStudyAreaType = SurveyQuestion.StudyAreaType.studyAreaSite Then
            If studyProvincesAndSites.selectedSite IsNot Nothing Then
                aSite = studyProvincesAndSites.selectedSite
                aFieldValue.FieldValue = aSite.SiteName
                Dim aTextField As SurveyFieldText
                aTextField = CurrentQuestion.Fields(0)
                aTextField.FieldValue = aFieldValue
                CurrentQuestionnaire.NextQuestion()
                CurrentQuestion = CurrentQuestionnaire.CurrentQuestion
            End If
        End If
        If CurrentQuestionnaire.EOQ = False Then
            If NavigationForwardCancelled = False Then
                ShowQuestionDetails(False)
            End If
        End If
    End Sub
    Private Sub mnuBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBack.Click
        If mnuBack.Text.Trim() = BACK_TO_RESULTS_LIST Then
            If CurrentQuestionnaire.QuestionHitCount > 0 Then
                If MsgBox("You have made changes to the results in the current questionnaire. This action will cause them to be discarded. Would you like to save these results  instead and mark the record as incomplete?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                    Cursor.Current = Cursors.WaitCursor
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf CurrentQuestionnaire.SaveBackNavigationStack, Now)
                    'CurrentQuestionnaire.SaveBackNavigationStack(Now)
                    Cursor.Current = Cursors.Default
                Else
                    CurrentQuestionnaire.DiscardResults(CurrentQuestionnaire.ResultsID)
                End If
            End If
            frmListResults.Show()
            Me.Hide()
        Else
            CurrentQuestionnaire.PreviousQuestion()
            CurrentQuestion = CurrentQuestionnaire.CurrentQuestion
            ShowQuestionDetails(True)
        End If
    End Sub

    Private Sub CurrentQuestionnaire_AfterNavigateBackward(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs) Handles CurrentQuestionnaire.AfterNavigateBackward

    End Sub

    Private Sub CurrentQuestionnaire_AfterNavigateForward(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs) Handles CurrentQuestionnaire.AfterNavigateForward

    End Sub

    Private Sub CurrentQuestionnaire_AfterSave(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs) Handles CurrentQuestionnaire.AfterSave

    End Sub
    Private Sub CurrentQuestionnaire_BeforeNavigateBackward(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs) Handles CurrentQuestionnaire.BeforeNavigateBackward
        CurrentQuestionnaire.ResetSavedQuestionResults()
        mnuNext.Text = NEXT_STRING
    End Sub
    Private Sub CurrentQuestionnaire_BeforeNavigateForward(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs) Handles CurrentQuestionnaire.BeforeNavigateForward
        mnuBack.Text = BACK_STRING

        Dim aProvince As Province
        Dim aSite As Site
        Dim aDistrict As District

        Dim aResponse As SurveyFieldBase.FieldResponses

        Dim aSurveyField As SurveyFieldBase
        Dim aTextField As SurveyFieldText
        Dim aNumberField As SurveyFieldNumber
        Dim aDateField As SurveyFieldDate
        Dim aOnOffField As SurveyFieldOnOff

        Dim aNumberValue As New NumberFieldValue
        Dim aTextValue As New TextFieldValue

        Dim aMultiMonthNCheck As MultiMonthAndCheck

        Select Case CurrentQuestion.QuestionControlType
            Case SurveyQuestion.ControlType.ctCustom
                'custom controls should expose values
                Select Case CurrentQuestion.ControlName
                    Case Constants.MultiSelectAndMonthControl
                        aMultiMonthNCheck = ShowControl(CurrentQuestion.ControlName)
                        aMultiMonthNCheck.GetFieldValues(CurrentQuestion)
                    Case Constants.MultiSelectSingleField
                        MultiSelectSingleField.Visible = True
                        MultiSelectSingleField.GetFieldValues(CurrentQuestion.Fields(0))
                    Case Constants.MultiSelectMultiField
                        MultiSelectMultiFields.Visible = True
                        MultiSelectMultiFields.GetFieldValues(CurrentQuestion)
                End Select

            Case SurveyQuestion.ControlType.ctGenerate
                For Each aSurveyField In CurrentQuestion.Fields
                    If MultiFields.GetFieldValue(aSurveyField) = False Then
                        NavigationForwardCancelled = True
                        e.Cancel = True
                        Exit Sub
                    End If
                Next
            Case SurveyQuestion.ControlType.ctInbuilt
                Select Case CurrentQuestion.Fields(0).FieldType
                    Case SurveyFieldBase.FieldDataTypes.qdDate
                        Dim aDateValue As New DateFieldValue
                        aDateField = CurrentQuestion.Fields(0)
                        aDateValue.FieldValue = dtDatePicker.Value
                        aDateField.FieldValue = aDateValue
                    Case SurveyFieldBase.FieldDataTypes.qdNumber
                        aNumberField = CurrentQuestion.Fields(0)
                        aNumberValue.FieldValue = CInt(Val(txtNumber.Text.Trim()))
                        aNumberField.FieldValue = aNumberValue
                    Case SurveyFieldBase.FieldDataTypes.qdOnOff
                        'control to handle this
                        aOnOffField = CurrentQuestion.Fields(0)
                    Case SurveyFieldBase.FieldDataTypes.qdOptions
                        aNumberField = CurrentQuestion.Fields(0)
                        aResponse = cboOptions.SelectedItem
                        aNumberValue.FieldValue = aResponse.CodedValue
                        aNumberField.FieldValue = aNumberValue
                    Case SurveyFieldBase.FieldDataTypes.qdStudyArea
                        aProvince = studyProvincesAndSites.selectedProvince
                        aSite = studyProvincesAndSites.selectedSite
                        aTextField = CurrentQuestion.Fields(0)
                        If CurrentQuestion.QStudyAreaType = SurveyQuestion.StudyAreaType.studyAreaProvince Then
                            If aProvince IsNot Nothing Then
                                aTextValue.FieldValue = aProvince.ProvinceName
                                aTextField.FieldValue = aTextValue
                            End If
                        End If
                        If CurrentQuestion.QStudyAreaType = SurveyQuestion.StudyAreaType.studyAreaDistrict Then
                            aProvince = studyProvincesAndSites.selectedProvince
                            aDistrict = studyProvincesAndSites.selectedDistrict
                            aTextValue.FieldValue = aDistrict.DistrictName
                            aTextField = CurrentQuestion.Fields(0)
                            If CurrentQuestion.QStudyAreaType = SurveyQuestion.StudyAreaType.studyAreaDistrict Then
                                If aDistrict IsNot Nothing Then
                                    aTextValue.FieldValue = aDistrict.DistrictName
                                    aTextField.FieldValue = aTextValue
                                End If
                            End If
                        End If
                        If CurrentQuestion.QStudyAreaType = SurveyQuestion.StudyAreaType.studyAreaSite Then
                            If aSite IsNot Nothing Then
                                aTextValue.FieldValue = aSite.SiteName
                                aTextField.FieldValue = aTextValue
                            End If
                        End If
                    Case SurveyFieldBase.FieldDataTypes.qdText
                            aTextField = CurrentQuestion.Fields(0)
                            aTextValue.FieldValue = txtTextEntry.Text.Trim()
                            aTextField.FieldValue = aTextValue
                End Select
        End Select
        If CurrentQuestion.ValidateFields() = False Then
            'show an error message
            MsgBox("This question is either not filled in, or the data is invalid or out of range", MsgBoxStyle.Exclamation)
            NavigationForwardCancelled = True
            e.Cancel = True
        Else
            'code to check
            ' REMEMBER TO COMMENT
            CurrentQuestionnaire.SaveQuestion(Now)
        End If
    End Sub

    Private Sub CurrentQuestionnaire_BeforeSave(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs) Handles CurrentQuestionnaire.BeforeSave

    End Sub
    Private Sub CurrentQuestionnaire_BeginningOfQuestionnaire(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs) Handles CurrentQuestionnaire.BeginningOfQuestionnaire
        mnuBack.Text = BACK_TO_RESULTS_LIST
        Me.Text = CurrentQuestionnaire.QuestionnaireTitle
        CurrentQuestion = CurrentQuestionnaire.CurrentQuestion
        ShowQuestionDetails(False)
    End Sub

    Private Sub CurrentQuestionnaire_EndOfQuestionnaire(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs) Handles CurrentQuestionnaire.EndOfQuestionnaire

        If MsgBox("You have reached the end of the questionnaire. Would you like to save?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Cursor.Current = Cursors.WaitCursor
            CurrentQuestionnaire.SaveTimeStamp(Now)
            Cursor.Current = Cursors.Default
            HideControls()
            selectAction.Visible = True
        End If
    End Sub
    Private Sub selectedAction_ActionChanged(ByVal Sender As Object, ByVal SelectedAction As SelectAction.ActionType) Handles selectAction.ActionChanged
        Select Case SelectedAction
            Case selectAction.ActionType.FillNewResult
                Cursor.Current = Cursors.WaitCursor
                CurrentQuestionnaire.AddNewResults()
                Me.Text = CurrentQuestionnaire.QuestionnaireTitle
                Cursor.Current = Cursors.Default
                CurrentQuestion = CurrentQuestionnaire.CurrentQuestion
                ShowQuestionDetails(False)
                selectAction.Visible = False
            Case selectAction.ActionType.QuestionnaireList
                frmQuestionnaires.Show()
                Me.Hide()
            Case selectAction.ActionType.ResultsList
                frmListResults.Show()
                Me.Hide()
        End Select
    End Sub
    Private Sub cmdRangeDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRangeDisplay.Click
        Select Case CurrentQuestion.Fields(0).FieldType
            Case SurveyFieldBase.FieldDataTypes.qdDate
                Dim aDateField As SurveyFieldDate
                aDateField = CurrentQuestion.Fields(0)
                If (aDateField.Min = Nothing) And (aDateField.Max = Nothing) Then
                Else
                    SectionInstructionNotify.Caption = "Range"
                    SectionInstructionNotify.Text = "The range for this variable is: " & Format(aDateField.Min, "dd/MMM/yyyy").ToString() & " - " & Format(aDateField.Max, "dd/MMM/yyyy").ToString()
                    SectionInstructionNotify.Visible = True
                End If
            Case SurveyFieldBase.FieldDataTypes.qdOptions
                If cboOptions.SelectedItem IsNot Nothing Then
                    SectionInstructionNotify.Caption = "Option selected"

                    SectionInstructionNotify.Text = cboOptions.SelectedItem.ToString()
                    SectionInstructionNotify.Visible = True
                End If
            Case SurveyFieldBase.FieldDataTypes.qdNumber
                Dim aNumberField As SurveyFieldNumber
                aNumberField = CurrentQuestion.Fields(0)
                If (aNumberField.Min = 0) And (aNumberField.Max = 0) Then
                Else
                    SectionInstructionNotify.Caption = "Range"
                    SectionInstructionNotify.Text = aNumberField.Min.ToString() & " TO " & aNumberField.Max.ToString()
                    SectionInstructionNotify.Visible = True
                End If
        End Select
    End Sub

    Private Sub cboOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOptions.SelectedIndexChanged
        Dim oResponse As SurveyFieldBase.FieldResponses
        oResponse = cboOptions.SelectedItem
        Select Case oResponse.ResponseText.Trim()
            Case Constants.OtherString, Constants.OtherSpecify
                txtOther.Visible = True
                lblOtherSpecify.Visible = True
            Case Else
                'do nothing
                txtOther.Visible = False
                lblOtherSpecify.Visible = False
        End Select
    End Sub
End Class
