Imports System.Collections
Imports System.Data
Public Class Study
    Friend Questionnaires As New List(Of Questionnaire)
    Private mCurrentQuestionnaire As Questionnaire
    Private mStudyTitle As String
    Public StudyArea As New StudyArea()
    Public Event ReadingCompleted(ByVal sender As Object, ByVal e As EventsNameSpace.EventArgs)
    Public Property StudyTitle() As String
        Get
            Return mStudyTitle
        End Get
        Set(ByVal value As String)
            mStudyTitle = value
        End Set
    End Property

    Public Property CurrentQuestionnaire() As Questionnaire
        Get
            Return mCurrentQuestionnaire
        End Get
        Set(ByVal value As Questionnaire)
            mCurrentQuestionnaire = value
        End Set
    End Property
    Public Sub ReadQuestionnaires()
        Dim StudyTable As New DataTable(My.Resources.StudyTable)
        Dim aQuestionnaire As Questionnaire
        Dim aRow As DataRow
        Dim e As New EventsNameSpace.EventArgs
        Questionnaires.Clear()
        StudyTable = Data.ReadData(My.Resources.StudyTable)
        If StudyTable.Rows.Count > 0 Then
            e.StatusValue = CType(StudyTable.Rows.Count, Integer)
            Me.mStudyTitle = StudyTable(1)(Constants.StudyTitleColumn).ToString()
            For Each aRow In StudyTable.Rows
                aQuestionnaire = New Questionnaire
                aQuestionnaire.QuestionnaireID = aRow(Constants.QuestionnaireIDColumn)
                aQuestionnaire.QuestionnaireTitle = aRow(Constants.QuestionnaireTitleColumn)
                aQuestionnaire.AssociatedTable = aRow(Constants.AssociatedTableColumn)
                aQuestionnaire.ResultsQueryColumns = aRow(Constants.ResultsQueryColumn)
                Questionnaires.Add(aQuestionnaire)
            Next
            RaiseEvent ReadingCompleted(Me, e)
        Else
            MsgBox("There was an error starting questionnaires", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class
