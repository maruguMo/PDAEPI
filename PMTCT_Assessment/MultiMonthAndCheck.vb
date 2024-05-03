Public Class MultiMonthAndCheck
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Dim MonthsIdxs As New MonthsAndIndices()
        'populate the combo
        Dim aMonthIdx As MonthAndIndex
        cboMonth.Items.Clear()
        For Each aMonthIdx In MonthsIdxs
            cboMonth.Items.Add(aMonthIdx)
        Next
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
                        Case Constants.DurationColumn
                            'for loop

                            For Each lvItem In lvItems.Items
                                aNumberValue = New NumberFieldValue
                                aNumberValue.FieldValue = CInt(Val(lvItem.SubItems(2).Text))
                                aNumberValue.ValueIndex = CInt(Val(lvItem.SubItems(3).Text))
                                aMultiNumber.FieldValues.Add(aNumberValue)
                            Next
                        Case Constants.SelectedMonthColumn
                            For Each lvItem In lvItems.Items
                                aNumberValue = New NumberFieldValue
                                aNumberValue.FieldValue = CInt(Val(lvItem.SubItems(3).Text))
                                aNumberValue.ValueIndex = CInt(Val(lvItem.SubItems(3).Text))
                                aMultiNumber.FieldValues.Add(aNumberValue)
                            Next
                    End Select
                Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                    Dim aMultiText As SurveyFieldMultipleText
                    Dim aTextValue As TextFieldValue
                    aMultiText = aSurveyField
                    If aMultiText.FieldName = Constants.DurationTypeColumn Then
                        'fill this
                        If aMultiText.FieldValues IsNot Nothing Then
                            If aMultiText.FieldValues.Count <> 0 Then
                                aMultiText.FieldValues.Clear()
                            End If
                        End If
                        For Each lvItem In lvItems.Items
                            aTextValue = New TextFieldValue
                            aTextValue.FieldValue = lvItem.SubItems(2).Text
                            aTextValue.ValueIndex = CInt(Val(lvItem.SubItems(3).Text))
                            aMultiText.FieldValues.Add(aTextValue)
                        Next
                    End If
                Case Else
                    'ignore
            End Select
        Next
        Return True
    End Function
    Public Sub FillListView(ByVal SurveyQuestion As SurveyQuestion)
        'fill the control with data
        Dim aSurveyField As SurveyFieldBase
        Dim aMultiNumber As SurveyFieldMultipleNumbers
        Dim aMultiText As SurveyFieldMultipleText
        Dim aListViewItem As ListViewItem
        Dim aNumberValue As NumberFieldValue
        lvItems.Items.Clear()

        For Each aSurveyField In SurveyQuestion.Fields
            If aSurveyField.FieldName = Constants.SelectedMonthColumn Then
                aMultiNumber = aSurveyField
                If aMultiNumber.FieldValues IsNot Nothing Then
                    For Each aNumberValue In aMultiNumber.FieldValues
                        'translate the monthname
                        aListViewItem = New ListViewItem(MonthName(aNumberValue.FieldValue, True))
                        lvItems.Items.Add(aListViewItem)
                        aListViewItem.SubItems.Add(" ")
                        aListViewItem.SubItems.Add(" ")
                        aListViewItem.SubItems.Add(aNumberValue.FieldValue.ToString())
                    Next
                End If
            End If
        Next
        For Each aSurveyField In SurveyQuestion.Fields
            If aSurveyField.FieldName = Constants.DurationColumn Then
                aMultiNumber = aSurveyField
                If aMultiNumber.FieldValues IsNot Nothing Then
                    For Each aNumberValue In aMultiNumber.FieldValues
                        For Each aListViewItem In lvItems.Items
                            If aListViewItem.SubItems(3).Text = aNumberValue.ValueIndex.ToString() Then
                                aListViewItem.SubItems(2).Text = aNumberValue.FieldValue.ToString()
                            End If
                        Next
                    Next
                End If
            End If
        Next
        Dim aTextValue As TextFieldValue
        For Each aSurveyField In SurveyQuestion.Fields
            If aSurveyField.FieldName = Constants.DurationTypeColumn Then
                aMultiText = aSurveyField
                If aMultiText.FieldValues IsNot Nothing Then
                    For Each aTextValue In aMultiText.FieldValues
                        For Each aListViewItem In lvItems.Items
                            If aListViewItem.SubItems(3).Text = aTextValue.ValueIndex.ToString() Then
                                aListViewItem.SubItems(2).Text = aTextValue.FieldValue.ToString()
                            End If
                        Next
                    Next
                End If
            End If
        Next
    End Sub
    Public Sub PrepareControl()
        lvItems.Items.Clear()
    End Sub
    Private Sub cboDurationType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDurationType.SelectedIndexChanged
        If cboDurationType.SelectedItem IsNot Nothing Then
            Select Case cboDurationType.SelectedItem
                Case "D"
                    Dim aMonthIndex As MonthAndIndex
                    nudDuration.Minimum = 1
                    If cboMonth.SelectedItem IsNot Nothing Then
                        aMonthIndex = cboMonth.SelectedItem
                        nudDuration.Maximum = Date.DaysInMonth(2010, aMonthIndex.MonthIndex)
                    Else
                        nudDuration.Maximum = 31
                    End If
                Case "W"
                    nudDuration.Minimum = 1
                    nudDuration.Maximum = 4
                Case "M"
                    nudDuration.Minimum = 1
                    nudDuration.Maximum = 1
            End Select
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If cboMonth.SelectedItem Is Nothing Then
            MsgBox("Please select a month", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If cboDurationType.SelectedItem Is Nothing Then
            MsgBox("Please select a duration type", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If cboDurationType.SelectedItem IsNot Nothing Then
            If nudDuration.Value = Nothing Then
                MsgBox("Please specify a duration", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If
        Dim aMonth As MonthAndIndex
        aMonth = cboMonth.SelectedItem()
        'check if the items are added
        Dim aListViewItem As ListViewItem
        For Each aListViewItem In lvItems.Items
            If aListViewItem.Text.Trim() = aMonth.Month.Trim() Then
                aListViewItem.Text = aMonth.Month
                aListViewItem.SubItems(1).Text = cboDurationType.SelectedItem.ToString()
                aListViewItem.SubItems(2).Text = aMonth.MonthIndex.ToString()
                aListViewItem.SubItems(3).Text = nudDuration.Value.ToString()
                cboMonth.SelectedItem = Nothing
                cboDurationType.SelectedItem = Nothing
                nudDuration.Value = nudDuration.Minimum
                Exit Sub
            End If
        Next
        Dim aSubItem As ListViewItem.ListViewSubItem
        aListViewItem = New ListViewItem(aMonth.Month)
        lvItems.Items.Add(aListViewItem)
        aSubItem = New ListViewItem.ListViewSubItem
        aSubItem.Text = cboDurationType.SelectedItem.ToString()
        aListViewItem.SubItems.Add(aSubItem)
        aSubItem = New ListViewItem.ListViewSubItem
        aSubItem.Text = nudDuration.Value.ToString()
        aListViewItem.SubItems.Add(aSubItem)
        aSubItem = New ListViewItem.ListViewSubItem
        aSubItem.Text = aMonth.MonthIndex.ToString()
        aListViewItem.SubItems.Add(aSubItem)
        cboMonth.SelectedItem = Nothing
        cboDurationType.SelectedItem = Nothing
        nudDuration.Value = nudDuration.Minimum
    End Sub
    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged

        Select Case cboDurationType.SelectedItem
            Case "D"
                Dim aMonthIndex As MonthAndIndex
                nudDuration.Minimum = 1
                If cboMonth.SelectedItem IsNot Nothing Then
                    aMonthIndex = cboMonth.SelectedItem
                    nudDuration.Maximum = Date.DaysInMonth(2010, aMonthIndex.MonthIndex)
                Else
                    nudDuration.Maximum = 31
                End If
            Case "W"
                nudDuration.Minimum = 1
                nudDuration.Maximum = 4
            Case "M"
                nudDuration.Minimum = 1
                nudDuration.Maximum = 1
            Case Else
                Dim aMonthIndex As MonthAndIndex
                nudDuration.Minimum = 1
                If cboMonth.SelectedItem IsNot Nothing Then
                    aMonthIndex = cboMonth.SelectedItem
                    nudDuration.Maximum = Date.DaysInMonth(2010, aMonthIndex.MonthIndex)
                Else
                    nudDuration.Maximum = 31
                End If
        End Select
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
Public Class MonthAndIndex
    Private mMonth As String
    Private mMonthIndex As Integer
    Public Property Month() As String
        Get
            Return mMonth
        End Get
        Set(ByVal value As String)
            mMonth = value
        End Set
    End Property
    Public Property MonthIndex() As Integer
        Get
            Return mMonthIndex
        End Get
        Set(ByVal value As Integer)
            mMonthIndex = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return mMonth
    End Function
End Class
Public Class MonthsAndIndices
    Inherits List(Of MonthAndIndex)
    Public Sub New()
        'prepare the months 
        Dim aMonth As New MonthAndIndex
        aMonth.Month = "Jan"
        aMonth.MonthIndex = 1
        Me.Add(aMonth)

        aMonth = New MonthAndIndex
        aMonth.Month = "Feb"
        aMonth.MonthIndex = 2
        Me.Add(aMonth)

        aMonth = New MonthAndIndex
        aMonth.Month = "Mar"
        aMonth.MonthIndex = 3
        Me.Add(aMonth)

        aMonth = New MonthAndIndex
        aMonth.Month = "Apr"
        aMonth.MonthIndex = 4
        Me.Add(aMonth)

        aMonth = New MonthAndIndex
        aMonth.Month = "May"
        aMonth.MonthIndex = 5
        Me.Add(aMonth)

        aMonth = New MonthAndIndex
        aMonth.Month = "Jun"
        aMonth.MonthIndex = 6
        Me.Add(aMonth)

        aMonth = New MonthAndIndex
        aMonth.Month = "Jul"
        aMonth.MonthIndex = 7
        Me.Add(aMonth)

        aMonth = New MonthAndIndex
        aMonth.Month = "Aug"
        aMonth.MonthIndex = 8
        Me.Add(aMonth)

    End Sub
End Class