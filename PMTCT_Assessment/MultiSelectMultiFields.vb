Public Class MultiSelectMultiFields
    Private Sub cboSelection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSelection.SelectedIndexChanged
        If cboSelection.SelectedItem IsNot Nothing Then
            Select Case cboSelection.SelectedItem.ToString().Trim()
                Case Constants.OtherString
                    txtNumber.Text = ""
                    txtNumber.Visible = True
                    lblSpecify.Visible = True
                    txtTrainingType.Text = ""
                    lblTrainingType.Visible = True
                    txtTrainingType.Visible = True
                Case Constants.UnknownString.Trim()
                    txtNumber.Text = ""
                    txtNumber.Visible = False
                    lblSpecify.Visible = False
                    txtTrainingType.Text = ""
                    lblTrainingType.Visible = False
                    txtTrainingType.Visible = False
                Case Else
                    txtNumber.Text = ""
                    txtNumber.Visible = True
                    lblSpecify.Visible = True
                    txtTrainingType.Text = ""
                    lblTrainingType.Visible = False
                    txtTrainingType.Visible = False
            End Select
        End If
    End Sub
    Public Function GetFieldValues(ByVal SurveyQuestion As SurveyQuestion) As Boolean
        Dim aSurveyField As SurveyFieldBase
        Dim lvItem As ListViewItem
        If lvItems.Items.Count = 0 Then
            Return False
        End If
        For Each aSurveyField In SurveyQuestion.Fields
            Select Case aSurveyField.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber
                    Dim aMultiNumber As SurveyFieldMultipleNumbers
                    aMultiNumber = aSurveyField
                    Dim aNumberValue As NumberFieldValue
                    If aMultiNumber.FieldValues IsNot Nothing Then
                        If aMultiNumber.FieldValues.Count <> 0 Then
                            aMultiNumber.FieldValues.Clear()
                        End If
                    End If
                    Select Case aMultiNumber.FieldName
                        Case Constants.NumberTrainedColumn
                            For Each lvItem In lvItems.Items
                                aNumberValue = New NumberFieldValue
                                aNumberValue.FieldValue = CInt(Val(lvItem.SubItems(1).Text))
                                aNumberValue.ValueIndex = CInt(Val(lvItem.SubItems(2).Text))
                                aMultiNumber.FieldValues.Add(aNumberValue)
                            Next
                    End Select
                Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                    Dim aMutiText As SurveyFieldMultipleText
                    aMutiText = aSurveyField
                    If aMutiText.FieldValues.Count <> 0 Then
                        aMutiText.FieldValues.Clear()
                    End If
                    Dim aTextValue As TextFieldValue
                    Select Case aMutiText.FieldName
                        Case Constants.TrainingTypeColumn
                            For Each lvItem In lvItems.Items
                                aTextValue = New TextFieldValue
                                aTextValue.FieldValue = lvItem.Text.Trim()
                                aTextValue.ValueIndex = CInt(Val(lvItem.SubItems(2).Text))
                                aMutiText.FieldValues.Add(aTextValue)
                            Next
                    End Select
            End Select
        Next
        Return True
    End Function
    Public Sub FillListView(ByVal SurveyQuestion As SurveyQuestion)
        'fill the control with data
        Dim aSurveyField As SurveyFieldBase
        Dim aMultiText As SurveyFieldMultipleText
        Dim aListViewItem As ListViewItem
        Dim aTextValue As TextFieldValue
        lvItems.Items.Clear()

        For Each aSurveyField In SurveyQuestion.Fields
            If aSurveyField.FieldName = Constants.TrainingTypeColumn Then
                aMultiText = aSurveyField
                If aMultiText.FieldValues IsNot Nothing Then
                    For Each aTextValue In aMultiText.FieldValues
                        aListViewItem = New ListViewItem(aTextValue.FieldValue)
                        lvItems.Items.Add(aListViewItem)
                        aListViewItem.SubItems.Add("")
                        aListViewItem.SubItems.Add(aTextValue.ValueIndex.ToString())
                    Next
                End If
                Exit For
            End If
        Next
        For Each aSurveyField In SurveyQuestion.Fields
            If aSurveyField.FieldName = Constants.NumberTrainedColumn Then
                Dim aMultiNumber As SurveyFieldMultipleNumbers
                aMultiNumber = aSurveyField
                Dim aNumberValue As NumberFieldValue
                If aMultiNumber.FieldValues IsNot Nothing Then
                    For Each aNumberValue In aMultiNumber.FieldValues
                        For Each aListViewItem In lvItems.Items
                            If aListViewItem.SubItems(2).Text.Trim() = aNumberValue.ValueIndex.ToString().Trim() Then
                                aListViewItem.SubItems(1).Text = aNumberValue.FieldValue.ToString()
                            End If
                        Next
                    Next
                End If
            End If
        Next
    End Sub
    Public Sub PrepareControl(ByVal SurveyField As SurveyFieldBase)
        'lvItems.Items.Clear()
        cboSelection.Items.Clear()
        'fill the responses
        For Each aResponse In SurveyField.Responses
            cboSelection.Items.Add(aResponse)
        Next
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim aListViewItem As ListViewItem
        Dim aResponse As SurveyFieldBase.FieldResponses
        If cboSelection.SelectedItem Is Nothing Then
            MsgBox("Please select an option", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If txtTrainingType.Visible = True Then
            If txtTrainingType.Text.Trim() = "" Then
                MsgBox("Please specify the training type", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        If txtNumber.Visible = True Then
            If txtNumber.Text.Trim() = "" Then
                MsgBox("Please enter a value for 'Number' field", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If Not IsNumeric(txtNumber.Text.Trim()) Then
                MsgBox("Please enter a number value for 'Number' field", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        'seek the selected item in the list using the 
        aResponse = cboSelection.SelectedItem
        If lvItems.Items.Count = 0 Then
            If txtTrainingType.Visible = True Then
                aListViewItem = New ListViewItem(txtTrainingType.Text.Trim())
            Else
                aListViewItem = New ListViewItem(aResponse.ResponseText)
            End If
            lvItems.Items.Add(aListViewItem)
            If txtNumber.Visible = False Then
                aListViewItem.SubItems.Add("0")
            Else
                aListViewItem.SubItems.Add(txtNumber.Text.Trim())
            End If
            aListViewItem.SubItems.Add(aResponse.CodedValue.ToString())
            txtNumber.Text = ""
            cboSelection.SelectedItem = Nothing
        Else
            'seek the item in the listview and update it
            For Each aListViewItem In lvItems.Items
                If aListViewItem.SubItems(2).Text.Trim() = aResponse.CodedValue.ToString() Then
                    If txtTrainingType.Visible = True Then
                        aListViewItem.Text = txtTrainingType.Text.Trim()
                    Else
                        aListViewItem.Text = aResponse.ResponseText
                    End If
                    If txtNumber.Visible = False Then
                        aListViewItem.SubItems(1).Text = "-1"
                    Else
                        aListViewItem.SubItems(1).Text = txtNumber.Text.Trim()
                    End If
                    aListViewItem.SubItems(2).Text = aResponse.CodedValue.ToString()
                    Exit Sub
                End If
            Next
            If txtTrainingType.Visible = True Then
                aListViewItem = New ListViewItem(txtTrainingType.Text)
            Else
                aListViewItem = New ListViewItem(aResponse.ResponseText)
            End If
            lvItems.Items.Add(aListViewItem)
            If txtNumber.Visible = False Then
                aListViewItem.SubItems.Add("-1")
            Else
                aListViewItem.SubItems.Add(txtNumber.Text.Trim())
            End If
            aListViewItem.SubItems.Add(aResponse.CodedValue.ToString())
            txtNumber.Text = ""
            cboSelection.SelectedItem = Nothing
        End If
    End Sub
    Private Sub mnuRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRemove.Click
        If lvItems.Items.Count <> 0 Then
            If lvItems.FocusedItem IsNot Nothing Then
                If MsgBox("Are you sure you want to remove this item?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    lvItems.Items.Remove(lvItems.FocusedItem)
                End If
            End If
        End If
    End Sub

    Private Sub mnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClear.Click
        If lvItems.Items.Count <> 0 Then
            If MsgBox("Are you sure you want to clear all items?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                lvItems.Items.Clear()
            End If
        End If
    End Sub
End Class
