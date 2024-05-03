Imports SizingDataGridColumns
Imports System.Data
Public Class frmListResults
    Dim ColumnCount As Integer
    Private Sub frmListResults_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Dim dt As DataTable
        lblQuestionnaireTitle.Text = Globals.PDAEPIStudy.CurrentQuestionnaire.QuestionnaireTitle
        dt = Globals.PDAEPIStudy.CurrentQuestionnaire.LoadDisplayResults()
        dgResults.DataSource = dt
        ColumnCount = dt.Columns.Count
        SizeDGColumns.SizeColumnsToContent(dgResults)
    End Sub
    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        Cursor.Current = Cursors.WaitCursor
        Globals.PDAEPIStudy.CurrentQuestionnaire.AddNewResults()
        frmInterfaceEng.Show()
        Me.Hide()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuReview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReview.Click
        If dgResults.CurrentRowIndex < 0 Then
            MsgBox("There are no results added yet. This action cannot be completed", MsgBoxStyle.Exclamation)
        Else
            Cursor.Current = Cursors.WaitCursor
            Globals.PDAEPIStudy.CurrentQuestionnaire.ReviewResults(dgResults(dgResults.CurrentCell.RowNumber, ColumnCount - 1).ToString())
            Cursor.Current = Cursors.Default
            frmInterfaceEng.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub mnuBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBack.Click
        frmQuestionnaires.Show()
        Me.Hide()
    End Sub

    Private Sub mnuDiscard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDiscard.Click
        Dim dt As DataTable
        If dgResults.CurrentRowIndex < 0 Then
            MsgBox("There are no results added yet. This action cannot be completed", MsgBoxStyle.Exclamation)
        Else
            Globals.PDAEPIStudy.CurrentQuestionnaire.DiscardResults(dgResults(dgResults.CurrentCell.RowNumber, ColumnCount - 1).ToString())
            dt = Globals.PDAEPIStudy.CurrentQuestionnaire.LoadDisplayResults()
            dgResults.DataSource = dt
        End If
    End Sub
End Class