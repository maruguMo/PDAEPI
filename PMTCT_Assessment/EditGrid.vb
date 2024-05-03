Imports DataGridCustomColumns
Imports System.Data.SqlServerCe
Imports PDAEPI.Data
Public Class EditGrid
    Private dt As New System.Data.DataTable()
    Public Sub Prepare(ByVal SurveyQuestion As SurveyQuestion, ByVal ResultsID As String)
        Dim strSQL As String
        Dim strSQLb As String = ""
        Dim strSQLc As String = ""
        Dim aField As SurveyFieldBase
        Dim sTableName As String = ""
        Dim dr As SqlCeDataReader
        Dim PopulateColumn As String = ""
        ' 1. Clear the table's data source
        DGTable.DataSource = Nothing
        'dt.Rows.Clear()
        'dt.Columns.Clear()

        ' 2. Get the tablename and fill the grid and fill if there is data
        Dim I As Integer = 0
        Dim iMax As Integer = 0
        dr = Data.ReadDataR(My.Resources.QTablesTable, Constants.QuestionIDColumn & " = " & SurveyQuestion.QuestionID)
        Do While dr.Read()
            sTableName = dr(Constants.MappedTableNameColumn).ToString()

            If I > 0 Then
                strSQLc &= "," & dr(Constants.FieldNameColumn)
            Else
                strSQLc = dr(Constants.FieldNameColumn).ToString()
            End If
            I += 1
            'Load responses into the appropriate fields
            If dr(Constants.ResponseGroupIDColumn) IsNot DBNull.Value Then
                aField = GetField(dr(Constants.FieldNameColumn), SurveyQuestion.Fields)
                aField.LoadResponses(dr(Constants.ResponseGroupIDColumn))
            End If
            If dr(Constants.RowPopulationColumn).ToString().Trim() = "1" Then
                PopulateColumn = dr(Constants.FieldNameColumn).ToString().Trim()
            End If
        Loop
        'check if there is data for a particular result id,
        aField = Nothing
        strSQL = ""

        If Data.CheckIfRecordExists(sTableName, Constants.ResultsIDColumn, ResultsID) = False Then
            'Prepare table
            aField = GetField(PopulateColumn, SurveyQuestion.Fields)
            Dim aResponse As SurveyFieldBase.FieldResponses
            Dim aColVal As ColumnAndValue
            Dim J As Integer = 1
            Select Case aField.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber, SurveyFieldBase.FieldDataTypes.qdMultipleText, SurveyFieldBase.FieldDataTypes.qdMultipleDates
                    For Each aResponse In aField.Responses
                        aColVal.ColumnToUpdate = PopulateColumn
                        aColVal.ColumnValue = aResponse.ResponseText
                        aColVal.Index = J
                        J += 1
                        Data.UpdateTable(sTableName, Constants.ResultsIDColumn, ResultsID, aColVal.ColumnToUpdate, aColVal.ColumnValue, True, J)
                    Next
                Case Else
                    'do nothing
            End Select
        End If
        'Execute sql to load data
        strSQL = " SELECT " & strSQLc & "," & Constants.ValueIndexColumn & _
                 " FROM " & sTableName & _
                 " WHERE " & Constants.ResultsIDColumn & "= @" & Constants.ResultsIDColumn & _
                 " AND " & Constants.QuestionIDColumn & " = @" & Constants.QuestionIDColumn
        dt = Data.ReadRelatedData(sTableName, Constants.ResultsIDColumn, ResultsID, Constants.QuestionIDColumn, SurveyQuestion.QuestionID, strSQL)

        ' 4. Set up columns types
        'Dim gridCols As GridColumnStylesCollection
        Dim alternatingColor As Color = SystemColors.ControlDark

        'Dim dgUpDown As New DataGridCustomUpDownColumn
        'Dim dgCheck As New DataGridCustomCheckBoxColumn

        'gridCols = DGTable.TableStyles(0).GridColumnStyles
        For Each aField In SurveyQuestion.Fields
            'gridCols(aField.FieldName).HeaderText = aField.FieldCaption
            Select Case aField.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdDate, SurveyFieldBase.FieldDataTypes.qdDate
                    Dim dgDateCol As New DataGridCustomColumns.DataGridCustomDateTimePickerColumn
                    With dgDateCol
                        .Owner = Me.DGTable
                        .MappingName = ""
                        .HeaderText = aField.FieldCaption
                        .MappingName = aField.FieldName.ToString().Trim()
                        .NullText = "-Unknown-"
                        .NullValue = New DateTime(1899, 1, 1)
                        .Width = Me.DGTable.Width * 30 / 100
                        .Alignment = HorizontalAlignment.Left
                        .AlternatingBackColor = alternatingColor
                    End With
                    Me.DataGridTableStyle1.GridColumnStyles.Add(dgDateCol)
                Case SurveyFieldBase.FieldDataTypes.qdMonth, SurveyFieldBase.FieldDataTypes.qdOptions
                    Dim dgCombo As New DataGridCustomComboBoxColumn
                    With dgCombo
                        .Owner = Me.DGTable
                        .MappingName = ""
                        .HeaderText = aField.FieldCaption
                        .MappingName = aField.FieldName.ToString().Trim()
                        .NullText = "-Choose-"
                        .Width = Me.DGTable.Width * 40 / 100
                        .Alignment = HorizontalAlignment.Right
                        .AlternatingBackColor = alternatingColor
                    End With
                    Me.DataGridTableStyle1.GridColumnStyles.Add(dgCombo)
                    Dim cb As ComboBox = CType(dgCombo.HostedControl, ComboBox)
                    cb.DataSource = aField.Responses
                    cb.DisplayMember = "ResponseText"
                    cb.ValueMember = "CodedValue"
                Case SurveyFieldBase.FieldDataTypes.qdMultipleText, SurveyFieldBase.FieldDataTypes.qdText
                    Dim dgText As New DataGridCustomTextBoxColumn
                    With dgText
                        .Owner = Me.DGTable
                        .MappingName = ""
                        .HeaderText = aField.FieldCaption
                        .MappingName = aField.FieldName.ToString().Trim()
                        .NullText = "-Unknown-"
                        .Width = Me.DGTable.Width * 40 / 100
                        .Alignment = HorizontalAlignment.Right
                        .AlternatingBackColor = alternatingColor
                    End With
                    Me.DataGridTableStyle1.GridColumnStyles.Add(dgText)
                Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber, SurveyFieldBase.FieldDataTypes.qdNumber
                    Dim dgNumber As New DataGridCustomTextBoxColumn
                    With dgNumber
                        .Owner = Me.DGTable
                        .MappingName = ""
                        .HeaderText = aField.FieldCaption.ToString().Trim()
                        .MappingName = aField.FieldName
                        .FormatInfo = Nothing
                        .Width = Me.DGTable.Width * 10 / 100
                        .AlternatingBackColor = alternatingColor
                    End With
                    Me.DataGridTableStyle1.GridColumnStyles.Add(dgNumber)
            End Select
        Next
        'Resize the grid accordingly
        DGTable.DataSource = dt
        SizingDataGridColumns.SizeDGColumns.SizeColumnsToContent(Me.DGTable)
    End Sub
    Private Function GetField(ByVal FieldName As String, ByVal Fields As List(Of SurveyFieldBase)) As SurveyFieldBase
        Dim aField As SurveyFieldBase = Nothing
        For Each aField In Fields
            If aField.FieldName.Trim() = FieldName.Trim() Then
                Exit For
            End If
        Next
        Return aField
    End Function
    Private Function GetFieldCaption(ByVal Fields As List(Of SurveyFieldBase), ByVal SearchField As String) As String
        Dim sCaption As String = ""
        Dim aField As SurveyFieldBase
        For Each aField In Fields
            If SearchField = aField.FieldCaption Then
                If aField.FieldCaption.Trim() <> "" Then
                    sCaption = aField.FieldCaption
                Else
                    sCaption = aField.ToString()
                End If
            End If
        Next
        Return sCaption
    End Function
End Class
