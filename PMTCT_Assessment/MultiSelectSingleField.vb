Public Class MultiSelectSingleField
    Private mFieldName As String
    Private mQID As Integer = 0
    Public Property FieldName() As String
        Get
            Return mFieldName
        End Get
        Set(ByVal value As String)
            mFieldName = value
        End Set
    End Property
    Private Sub cboSelection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSelection.SelectedIndexChanged
        If cboSelection.SelectedItem IsNot Nothing Then
            If cboSelection.SelectedItem.ToString().Trim() = Constants.OtherString Then
                txtOther.Visible = True
                lblSpecify.Visible = True
            Else
                AddToList()
                txtOther.Text = ""
                txtOther.Visible = False
                lblSpecify.Visible = False
            End If
        End If
    End Sub
    Public Sub PrepareControl(ByVal SurveyField As SurveyFieldBase)
        If mQID = SurveyField.QuestionID Then
            'dont clear the list view
        Else
            lvItems.Items.Clear()
            mQID = SurveyField.QuestionID
        End If

        cboSelection.Items.Clear()
        mFieldName = FieldName
        lblSpecify.Visible = False
        txtOther.Visible = False
        'fill the responses
        For Each aResponse In SurveyField.Responses
            cboSelection.Items.Add(aResponse)
        Next
    End Sub
    Public Function GetFieldValues(ByVal SurveyField As SurveyFieldBase) As Boolean
        Dim lvItem As ListViewItem
        Dim aMultiNumber As SurveyFieldMultipleNumbers
        Dim aMultiText As SurveyFieldMultipleText
        If lvItems.Items.Count = 0 Then
            Return False
        End If

        Select Case SurveyField.FieldType
            Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber
                aMultiNumber = SurveyField
                If aMultiNumber.FieldValues IsNot Nothing Then
                    aMultiNumber.FieldValues.Clear()
                End If
                Dim aNumberValue As NumberFieldValue
                For Each lvItem In lvItems.Items
                    aNumberValue = New NumberFieldValue
                    aNumberValue.FieldValue = CInt(Val(lvItem.SubItems(1).Text))
                    aNumberValue.ValueIndex = CInt(Val(lvItem.SubItems(1).Text))
                    aMultiNumber.FieldValues.Add(aNumberValue)
                Next
            Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                aMultiText = SurveyField
                If aMultiText.FieldValues IsNot Nothing Then
                    aMultiText.FieldValues.Clear()
                End If
                Dim aTextValue As TextFieldValue
                For Each lvItem In lvItems.Items
                    aTextValue = New TextFieldValue
                    aTextValue.FieldValue = lvItem.Text
                    aTextValue.ValueIndex = CInt(Val(lvItem.SubItems(1).Text.ToString()))
                    aMultiText.FieldValues.Add(aTextValue)
                Next
            Case SurveyFieldBase.FieldDataTypes.qdMultipleDates
                'to be done later
        End Select
        Return True
    End Function
    Public Sub FillListView(ByVal SurveyField As SurveyFieldBase)
        Dim aResponse As SurveyFieldBase.FieldResponses
        Dim aListViewItem As ListViewItem
        Dim aMultiNumber As SurveyFieldMultipleNumbers
        Dim aMultiText As SurveyFieldMultipleText
        lvItems.Items.Clear()
        Select Case SurveyField.FieldType
            Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber
                Dim aNumberValue As NumberFieldValue
                aMultiNumber = SurveyField
                If aMultiNumber.FieldValues IsNot Nothing Then
                    For Each aNumberValue In aMultiNumber.FieldValues
                        For Each aResponse In cboSelection.Items
                            If aResponse.CodedValue = aNumberValue.FieldValue Then
                                aListViewItem = New ListViewItem(aResponse.ResponseText)
                                lvItems.Items.Add(aListViewItem)
                                aListViewItem.SubItems.Add(aResponse.CodedValue.ToString())
                            End If
                        Next
                    Next
                End If
            Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                Dim aTextValue As TextFieldValue
                aMultiText = SurveyField
                If aMultiText.FieldValues IsNot Nothing Then
                    For Each aTextValue In aMultiText.FieldValues
                        For Each aResponse In cboSelection.Items
                            If aResponse.ResponseText.Trim() = aTextValue.FieldValue.Trim() Then
                                aListViewItem = New ListViewItem(aResponse.ResponseText)
                                lvItems.Items.Add(aListViewItem)
                                aListViewItem.SubItems.Add(aResponse.CodedValue.ToString())
                            End If
                        Next
                    Next
                End If
            Case SurveyFieldBase.FieldDataTypes.qdDate
                'to deal with later
        End Select
    End Sub
    Private Sub AddToList()
        Dim aListViewItem As ListViewItem
        Dim aResponse As SurveyFieldBase.FieldResponses
        'seek the selected item in the list using the 
        aResponse = cboSelection.SelectedItem
        If lvItems.Items.Count = 0 Then
            If cboSelection.SelectedItem.ToString() = Constants.OtherString Then
                aListViewItem = New ListViewItem(txtOther.Text.Trim())
            Else
                aListViewItem = New ListViewItem(aResponse.ResponseText)
            End If
            lvItems.Items.Add(aListViewItem)
            aListViewItem.SubItems.Add(aResponse.CodedValue.ToString())
            txtOther.Text = ""
            cboSelection.SelectedItem = Nothing
        Else
            'seek the item in the listview and update it
            For Each aListViewItem In lvItems.Items
                If aListViewItem.SubItems(1).Text.Trim() = aResponse.CodedValue.ToString() Then
                    If cboSelection.SelectedItem.ToString() = Constants.OtherString Then
                        aListViewItem.Text = txtOther.Text
                    Else
                        aListViewItem.Text = aResponse.ResponseText
                    End If
                    aListViewItem.SubItems(1).Text = aResponse.CodedValue.ToString()
                    Exit Sub
                End If
            Next
            If cboSelection.SelectedItem.ToString() = Constants.OtherString Then
                aListViewItem = New ListViewItem(txtOther.Text.Trim())
            Else
                aListViewItem = New ListViewItem(aResponse.ResponseText)
            End If
            lvItems.Items.Add(aListViewItem)
            aListViewItem.SubItems.Add(aResponse.CodedValue.ToString())
            txtOther.Text = ""
            'cboSelection.SelectedItem = Nothing
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If cboSelection.SelectedItem Is Nothing Then
            MsgBox("Please select an option", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If txtOther.Visible = True Then
            If txtOther.Text.Trim() = "" Then
                MsgBox("Please enter a value for 'Other' field", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        AddToList()
    End Sub

    Private Sub mnuRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRemove.Click
        Dim aFocusedItem As ListViewItem
        If lvItems.Items.Count <> 0 Then
            If lvItems.FocusedItem IsNot Nothing Then
                aFocusedItem = lvItems.FocusedItem
                If MsgBox("Are you sure you want to remove this item?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    lvItems.Items.Remove(aFocusedItem)
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
