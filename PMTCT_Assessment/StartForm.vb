Public Class StartForm
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure you want to exit the system", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        lblWait.Visible = True
        Cursor.Current = Cursors.WaitCursor
        frmQuestionnaires.Show()
        Cursor.Current = Cursors.Default
        Me.Hide()
    End Sub
    Private Sub StartForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblWait.Visible = False
    End Sub

    Private Sub label2_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label2.ParentChanged

    End Sub
End Class