Imports System.Globalization
Public Class frmQuestionnaires
    Dim WithEvents PDAEPIStudy As Study = Globals.PDAEPIStudy
    Dim WithEvents CurrentQuestionnaire As Questionnaire
    Private Sub frmQuestionnaires_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim aListViewItem As ListViewItem
        Dim aQuestionnaire As Questionnaire

        PDAEPIStudy.ReadQuestionnaires()
        lblStudyTitle.Text = PDAEPIStudy.StudyTitle
        Dim I As Integer
        Dim QCount As Integer = PDAEPIStudy.Questionnaires.Count
        For I = 0 To QCount - 1
            With lvwQuestionnaires
                aListViewItem = New ListViewItem
                aQuestionnaire = PDAEPIStudy.Questionnaires(I)
                aListViewItem.Text = aQuestionnaire.QuestionnaireID
                .Items.Add(aListViewItem)
                aListViewItem.SubItems.Add(aQuestionnaire.QuestionnaireTitle)
            End With
        Next I

    End Sub
    Private Sub Proceed()
        Dim aQuestionnaire As Questionnaire
        Dim QuestionnaireID As Integer
        If lvwQuestionnaires.FocusedItem Is Nothing Then
            MsgBox("Please select a questionnaire", MsgBoxStyle.Exclamation)
        Else
            If lvwQuestionnaires.Items.Count > 0 Then
                Cursor.Current = Cursors.WaitCursor
                With lvwQuestionnaires.FocusedItem
                    QuestionnaireID = CType(Val(.Text.Trim()), Integer)
                    For Each aQuestionnaire In PDAEPIStudy.Questionnaires
                        If QuestionnaireID = aQuestionnaire.QuestionnaireID Then
                            PDAEPIStudy.CurrentQuestionnaire = aQuestionnaire
                            PDAEPIStudy.CurrentQuestionnaire.ReadQuestions()
                            Exit For
                        End If
                    Next
                End With
                'create a thread to start preparing questions
                Dim tPrepQuestions As New Threading.Thread(AddressOf PDAEPIStudy.CurrentQuestionnaire.PrepareQuestions)
                tPrepQuestions.IsBackground = True
                tPrepQuestions.Start()
                frmListResults.Show()
                Me.Hide()
                Cursor.Current = Cursors.Default
            Else
                MsgBox("There are no questionnaires loaded. This action cannot be completed", MsgBoxStyle.Exclamation)
            End If
            Cursor.Current = Cursors.Default
            aQuestionnaire = Nothing
        End If
    End Sub
    Private Sub PMTCTStudy_ReadingCompleted(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs) Handles PDAEPIStudy.ReadingCompleted
        PDAEPIStudy.CurrentQuestionnaire = PDAEPIStudy.Questionnaires(1)
        Globals.CurrentQuestionnaire = PDAEPIStudy.CurrentQuestionnaire
    End Sub

    Private Sub mnuStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStart.Click
        Proceed()
    End Sub
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        If MsgBox("Are you sure you want to quit", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Exit") = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub mnuDeviceStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeviceStatus.Click
        DeviceStatus.Visible = True
        DeviceStatus.AutoHide = False
    End Sub

    Private Sub contxtStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contxtStart.Click
        Proceed()
    End Sub
End Class