Public Class MultiTypeControls
    Public ReadOnly MultipleControls As New MultiTypeControlsCFactory(Me)
    Private Function GetAssociatedControl(ByVal FieldName As String) As Windows.Forms.Control
        Dim aControl As Windows.Forms.Control = Nothing
        For Each aControl In Me.Controls
            If aControl.Tag IsNot Nothing Then
                If aControl.Tag.ToString().Trim() = FieldName.Trim() Then
                    Exit For
                End If
            End If
        Next
        Return aControl
    End Function
    Public Function GetFieldValue(ByRef QuestionField As SurveyFieldBase) As Boolean
        Dim aCombo As Windows.Forms.ComboBox = Nothing
        Dim aCheckBox As Windows.Forms.CheckBox = Nothing
        Dim aTextBox As Windows.Forms.TextBox = Nothing
        Dim aDateTimePicker As Windows.Forms.DateTimePicker = Nothing
        Dim aControl As Windows.Forms.Control = Nothing
        Dim aResponse As SurveyFieldBase.FieldResponses
        Dim aTextField As SurveyFieldText
        Dim aNumberField As SurveyFieldNumber
        Dim aDateField As SurveyFieldDate
        Dim aOnOffField As SurveyFieldOnOff
        aControl = GetAssociatedControl(QuestionField.FieldName)
        If aControl Is Nothing Then
            Return False
        Else
            'cast the control to its real name
            Select Case QuestionField.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdDate
                    Dim aDateValue As New DateFieldValue
                    aDateTimePicker = aControl
                    aDateField = QuestionField
                    aDateValue.FieldValue = aDateTimePicker.Value
                    aDateField.FieldValue = aDateValue
                    Return True
                Case SurveyFieldBase.FieldDataTypes.qdNumber
                    Dim aNumberValue As New NumberFieldValue
                    aTextBox = aControl
                    If QuestionField.IsRequired = True Then
                        If aTextBox.Text.Trim() = "" Then
                            MsgBox("The variable '" & QuestionField.FieldCaption & "' cannot be empty", MsgBoxStyle.Exclamation)
                            aTextBox.Focus()
                            Return False
                        End If
                    Else
                        If ValidateNumerics(aControl) = False Then
                            MsgBox("The variable '" & QuestionField.FieldCaption & "' must be a number", MsgBoxStyle.Exclamation)
                            aTextBox.Focus()
                            Return False
                        End If
                    End If
                    aNumberField = QuestionField
                    aNumberValue.FieldValue = CInt(Val(aTextBox.Text.Trim()))
                    aNumberField.FieldValue = aNumberValue
                    Return True
                Case SurveyFieldBase.FieldDataTypes.qdOnOff
                    Dim aOnOffValue As New OnOffFieldValue
                    aCheckBox = aControl
                    aOnOffField = QuestionField
                    If aCheckBox.Checked = True Then
                        aOnOffValue.FieldValue = OnOffFieldValue.OnOffValues.dChecked
                    Else
                        aOnOffValue.FieldValue = OnOffFieldValue.OnOffValues.dUnchecked
                    End If
                    aOnOffField.FieldValue = aOnOffValue
                    Return True
                Case SurveyFieldBase.FieldDataTypes.qdOptions
                    Dim aNumberValue As New NumberFieldValue
                    aCombo = aControl
                    If QuestionField.IsRequired = True Then
                        If aCombo.SelectedItem Is Nothing Then
                            MsgBox("The variable '" & QuestionField.FieldCaption & "' cannot be empty", MsgBoxStyle.Exclamation)
                            aCombo.Focus()
                            Return False
                        End If
                    End If
                    aResponse = aCombo.SelectedItem
                    aNumberField = QuestionField
                    aNumberValue.FieldValue = aResponse.CodedValue
                    aNumberField.FieldValue = aNumberValue
                    Return True
                Case SurveyFieldBase.FieldDataTypes.qdText
                    Dim aTextValue As New TextFieldValue
                    aTextBox = aControl
                    If QuestionField.IsRequired = True Then
                        If aTextBox.Text.Trim() = "" Then
                            MsgBox("The variable '" & QuestionField.FieldCaption & "' cannot be empty", MsgBoxStyle.Exclamation)
                            aTextBox.Focus()
                            Return False
                        End If
                    End If
                    aTextField = QuestionField
                    aTextValue.FieldValue = aTextBox.Text.Trim()
                    aTextField.FieldValue = aTextValue
                    Return True
            End Select
        End If
    End Function
    Public Sub FillFieldValue(ByVal QuestionField As SurveyFieldBase)
        Dim aCombo As Windows.Forms.ComboBox = Nothing
        Dim aCheckBox As Windows.Forms.CheckBox = Nothing
        Dim aTextBox As Windows.Forms.TextBox = Nothing
        Dim aDateTimePicker As Windows.Forms.DateTimePicker = Nothing
        Dim aControl As Windows.Forms.Control = Nothing
        Dim aResponse As SurveyFieldBase.FieldResponses
        Dim aTextField As SurveyFieldText
        Dim aNumberField As SurveyFieldNumber
        Dim aDateField As SurveyFieldDate
        Dim aOnOffField As SurveyFieldOnOff
        aControl = GetAssociatedControl(QuestionField.FieldName)
        If aControl Is Nothing Then
            Exit Sub
        Else
            'cast the control to its real name
            Select Case QuestionField.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdDate
                    aDateTimePicker = aControl
                    aDateField = QuestionField
                    If aDateField.FieldValue IsNot Nothing Then
                        aDateTimePicker.Value = aDateField.FieldValue.FieldValue
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdNumber
                    aTextBox = aControl
                    aNumberField = QuestionField
                    If aNumberField.FieldValue IsNot Nothing Then
                        aTextBox.Text = aNumberField.FieldValue.FieldValue.ToString()
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdOnOff
                    aCheckBox = aControl
                    aOnOffField = QuestionField
                    If aOnOffField.FieldValue IsNot Nothing Then
                        If aOnOffField.FieldValue.FieldValue = OnOffFieldValue.OnOffValues.dChecked Then
                            aCheckBox.Checked = True
                        ElseIf aOnOffField.FieldValue.FieldValue = OnOffFieldValue.OnOffValues.dUnchecked Then
                            aCheckBox.Checked = False
                        End If
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdOptions
                    aCombo = aControl
                    aNumberField = QuestionField
                    If aNumberField.FieldValue IsNot Nothing Then
                        'search for the response
                        For Each aResponse In aCombo.Items
                            If aResponse.CodedValue = aNumberField.FieldValue.FieldValue Then
                                aCombo.SelectedItem = aResponse
                            End If
                        Next
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdText
                    aTextBox = aControl
                    aTextField = QuestionField
                    If aTextField.FieldValue IsNot Nothing Then
                        aTextBox.Text = aTextField.FieldValue.FieldValue
                    End If
            End Select
        End If
    End Sub
    Private Function ValidateNumerics(ByVal aControl As Windows.Forms.TextBox) As Boolean
        If Not IsNumeric(aControl.Text.Trim()) Then
            Return False
        Else
            Return True
        End If
    End Function
End Class
