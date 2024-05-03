Public Class SelectAction
    Public Enum ActionType
        Indeterminate = 0
        FillNewResult = 1
        ResultsList = 2
        QuestionnaireList = 3
    End Enum
    Public Event ActionChanged(ByVal Sender As Object, ByVal SelectedAction As ActionType)
    Private Sub lblNewResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNewResult.Click
        Dim mSelectedAction As ActionType
        mSelectedAction = ActionType.FillNewResult
        RaiseEvent ActionChanged(Me, ActionType.FillNewResult)
    End Sub
    Private Sub lblResultsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblResultsList.Click
        Dim mSelectedAction As ActionType
        mSelectedAction = ActionType.ResultsList
        RaiseEvent ActionChanged(Me, ActionType.ResultsList)
    End Sub
    Private Sub lblQuestionnaireList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblQuestionnaireList.Click
        Dim mSelectedAction As ActionType
        mSelectedAction = ActionType.QuestionnaireList
        RaiseEvent ActionChanged(Me, ActionType.QuestionnaireList)
    End Sub
End Class
