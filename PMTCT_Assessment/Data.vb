Imports System.Data
Imports System.Data.SqlServerCe
Public Class Data
    Public Enum SortEnum
        Ascending = 1
        Descending = 2
    End Enum
    Public Structure ColumnAndValue
        Public ColumnToUpdate As String
        Public ColumnValue As Object
        Public Index As Integer
    End Structure
    Public Shared objSQLCEConnection As New SqlCeConnection(My.Resources.connectionString)
    Private Shared mConnected As Boolean
    Public Shared ReadOnly Property IsConnected() As Integer
        Get
            Return mConnected
        End Get
    End Property
    Public Sub New()
        If Connect() = True Then
            mConnected = True
        Else
            mConnected = False
        End If
    End Sub
    Public Shared Sub CloseConnection()
        objSQLCEConnection.Close()
        mConnected = False
    End Sub
    Public Shared Function Connect() As Boolean
        Select Case objSQLCEConnection.State
            Case ConnectionState.Broken
                objSQLCEConnection.Open()
            Case ConnectionState.Closed
                objSQLCEConnection.Open()
            Case ConnectionState.Executing
            Case ConnectionState.Fetching
            Case ConnectionState.Open
        End Select
        Return True
    End Function
    Public Shared Function SelectData(ByVal ColumnsToSelect As String, ByVal TableName As String, Optional ByVal WhereClause As String = "") As DataTable
        Dim dt As New DataTable(TableName)
        Dim strSQL As String
        If WhereClause.Trim() = "" Then
            strSQL = " SELECT " & ColumnsToSelect & " FROM " & TableName & " WHERE RecordDeleted = 'N'"
        Else
            strSQL = " SELECT " & ColumnsToSelect & " FROM " & TableName & " WHERE RecordDeleted = 'N' AND " & WhereClause
        End If
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            Dim da As New SqlCeDataAdapter(com)
            da.Fill(dt)
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
        Return dt
    End Function
    Public Shared Function ReadRelatedData(ByVal TableName As String, ByVal ResultsIDColumn As String, ByVal ResultsID As String, ByVal QuestionIDColumn As String, ByVal QuestionID As String, Optional ByVal SQLString As String = "") As DataTable
        Dim strSQL As String
        Dim dt As New DataTable()
        If SQLString.Trim() <> "" Then
            strSQL = SQLString
        Else
            strSQL = " SELECT * FROM [" & TableName & "] WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn & _
                     " AND " & QuestionIDColumn & " = @" & QuestionIDColumn & _
                     " ORDER BY " & Constants.ValueIndexColumn.Trim() & " ASC"

        End If
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            com.Prepare()
            com.Parameters.Clear()
            com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
            com.Parameters.Add("@" & QuestionIDColumn, QuestionID)
            Dim da As New SqlCeDataAdapter(com)
            da.Fill(dt)
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
        Return dt
    End Function
    Public Shared Function ReadData(ByVal AssociatedTableName As String, ByVal ResultsIDColumn As String, ByVal ResultsID As String) As DataTable
        Dim strSQL As String
        Dim dt As New DataTable()
        strSQL = " SELECT * FROM [" & AssociatedTableName & "] WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            com.Prepare()
            com.Parameters.Clear()
            com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
            Dim da As New SqlCeDataAdapter(com)
            da.Fill(dt)
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
        Return dt
    End Function
    Public Shared Function ReadDataQuery(ByVal strSQL As String) As DataTable
        Dim dt As New DataTable()
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            com.Prepare()
            Dim da As New SqlCeDataAdapter(com)
            da.Fill(dt)
        Else
            MsgBox("Errors occured while connecting data", MsgBoxStyle.Exclamation)
        End If
        Return dt
    End Function
    Public Shared Function ReadData(ByVal TableName As String, Optional ByVal WhereClause As String = "", Optional ByVal Sort As Boolean = True, Optional ByVal SortColumn As String = "", Optional ByVal SortOrder As SortEnum = SortEnum.Ascending) As DataTable
        Dim strSQL As String
        Dim dt As New DataTable()
        If WhereClause.Trim() = "" Then
            strSQL = " SELECT * FROM [" & TableName & "]"
        Else
            strSQL = " SELECT * FROM [" & TableName & "] WHERE " & WhereClause
        End If
        If Sort = True Then
            If SortColumn.Trim() <> "" Then
                Select Case SortOrder
                    Case SortEnum.Ascending
                        strSQL += " ORDER BY " & SortColumn.Trim() & " ASC"
                    Case SortEnum.Descending
                        strSQL += " ORDER BY " & SortColumn.Trim() & " DESC"
                End Select
            End If
        End If
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            Dim da As New SqlCeDataAdapter(com)
            da.SelectCommand.ExecuteReader()
            da.Fill(dt)
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
        Return dt
    End Function
    Public Shared Function ReadDataR(ByVal TableName As String, Optional ByVal WhereClause As String = "", Optional ByVal Sort As Boolean = True, Optional ByVal SortColumn As String = "", Optional ByVal SortOrder As SortEnum = SortEnum.Ascending) As SqlCeDataReader
        Dim strSQL As String
        Dim dr As SqlCeDataReader = Nothing
        If WhereClause.Trim() = "" Then
            strSQL = " SELECT * FROM [" & TableName & "]"
        Else
            strSQL = " SELECT * FROM [" & TableName & "] WHERE " & WhereClause
        End If
        If Sort = True Then
            If SortColumn.Trim() <> "" Then
                Select Case SortOrder
                    Case SortEnum.Ascending
                        strSQL += " ORDER BY " & SortColumn.Trim() & " ASC"
                    Case SortEnum.Descending
                        strSQL += " ORDER BY " & SortColumn.Trim() & " DESC"
                End Select
            End If
        End If
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            dr = com.ExecuteReader()
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
        Return dr
    End Function

    Public Shared Function CreateGUID() As String
        Dim strSQL As String
        strSQL = " SELECT NewID()"
        Dim resGUID As String = ""
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            resGUID = com.ExecuteScalar().ToString()
            'create the time stamp in the associated table, by default the start time and endtime will be the same at the beginning of each questionnaire
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
        Return resGUID
    End Function
    Public Shared Sub UpdateTable(ByVal TableName As String, ByVal UniqueColName As String, ByVal UniqueID As String, ByVal ColumnToUpdate As String, ByVal ColumnValue As Object, Optional ByVal MultiField As Boolean = False, Optional ByVal ValueIdx As Integer = 0)
        Dim strSQL As String = ""
        Dim com As New SqlCeCommand()
        com.Parameters.Clear()
        If Connect() = True Then
            com.Connection = objSQLCEConnection
            If CheckIfRecordExists(TableName, UniqueColName, UniqueID) = True Then
                'update a particular column
                strSQL = " UPDATE " & TableName.Trim() & " SET " & ColumnToUpdate & " = @" & ColumnToUpdate & _
                             " WHERE " & UniqueColName & "= @" & UniqueColName
            Else
                'insert a new column
                If MultiField = True And ValueIdx <> 0 Then
                    strSQL = " INSERT INTO " & TableName & _
                             "(" & UniqueColName & "," & ColumnToUpdate & "," & Constants.ValueIndexColumn & _
                             ") VALUES (@" & UniqueColName & ",@" & ColumnToUpdate & ",@" & Constants.ValueIndexColumn & ")"
                Else
                    strSQL = " INSERT INTO " & TableName & _
                             "(" & UniqueColName & "," & ColumnToUpdate & _
                             ") VALUES (@" & UniqueColName & ",@" & ColumnToUpdate & ")"
                End If

            End If
            com.CommandText = strSQL
            com.Prepare()
            com.Parameters.Add("@" & ColumnToUpdate, ColumnValue)
            com.Parameters.Add("@" & UniqueColName, UniqueID)
            If MultiField = True And ValueIdx <> 0 Then
                com.Parameters.Add("@" & Constants.ValueIndexColumn, ValueIdx)
            End If
            com.ExecuteNonQuery()
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
            End If
    End Sub
    Public Shared Sub UpdateTable(ByVal TableName As String, ByVal UniqueColName As String, ByVal UniqueID As String, ByVal ColumnsAndValues As List(Of ColumnAndValue))
        Dim strSQL As String = ""
        Dim com As New SqlCeCommand()
        Dim aColAndValue As ColumnAndValue
        com.Parameters.Clear()
        If Connect() = True Then
            com.Connection = objSQLCEConnection
            If CheckIfRecordExists(TableName, UniqueColName, UniqueID) = True Then
                'update a particular column
                strSQL = " UPDATE " & TableName.Trim() & " SET "
                For Each aColAndValue In ColumnsAndValues
                    strSQL += aColAndValue.ColumnToUpdate & " = @" & aColAndValue.ColumnToUpdate & ","
                Next
                strSQL = Mid(strSQL, 1, Len(strSQL.Trim()) - 1)
                strSQL += " WHERE " & UniqueColName & "= @" & UniqueColName
            Else
                'insert a new column

                strSQL = " INSERT INTO " & TableName & "("
                For Each aColAndValue In ColumnsAndValues
                    strSQL += aColAndValue.ColumnToUpdate & ","
                Next
                strSQL.Remove(strSQL.Length - 1, 1)
                strSQL += ") VALUES ("
                For Each aColAndValue In ColumnsAndValues
                    strSQL += "@" & aColAndValue.ColumnToUpdate & ","
                Next
                strSQL = Mid(strSQL, 1, Len(strSQL.Trim()) - 1)
                strSQL += ")"
            End If
            com.Parameters.Add("@UniqueColName", UniqueID)
            For Each aColAndValue In ColumnsAndValues
                com.Parameters.Add("@" & aColAndValue.ColumnToUpdate, aColAndValue.ColumnValue)
            Next
            com.ExecuteNonQuery()
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Shared Sub SaveTimeStamp(ByVal AssociatedTable As String, ByVal ResultsIDColumn As String, ByVal ResultsID As String, ByVal EndTimeColumn As String, ByVal EndTime As DateTime, ByVal RecordComplete As String)
        Connect()
        Dim strSQL As String = " UPDATE " & AssociatedTable & _
                               " SET " & EndTimeColumn & " = @" & EndTimeColumn & "," & _
                               Constants.RecordCompleteColumn & " = @" & Constants.RecordCompleteColumn & _
                               " WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn
        Dim sqlcecom As New SqlCeCommand(strSQL, objSQLCEConnection)
        sqlcecom.Prepare()
        sqlcecom.Parameters.Clear()
        sqlcecom.Parameters.Add("@" & EndTimeColumn, EndTime)
        sqlcecom.Parameters.Add("@" & Constants.RecordCompleteColumn, RecordComplete)
        sqlcecom.Parameters.Add("@" & ResultsIDColumn, ResultsID)
        Try
            sqlcecom.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Function SaveResults(ByVal AssociatedTable As String, ByVal Questions As Stack(Of SurveyQuestion), ByVal ResultsIDColumn As String, ByVal ResultsID As String, ByVal StartTime As DateTime, ByVal EndTime As DateTime, ByVal QuestionnaireID As Integer) As Boolean
        Dim dt As New DataTable("Tables")
        Dim aRow As DataRow
        Connect()
        Dim strSQL As String = " DELETE FROM " & AssociatedTable & _
                               " WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn
        Dim sqlcecom As New SqlCeCommand(strSQL, objSQLCEConnection)
        sqlcecom.Prepare()
        sqlcecom.Parameters.Clear()
        sqlcecom.Parameters.Add("@" & ResultsIDColumn, ResultsID)
        Try
            sqlcecom.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        'get a list of all tables and remove the result in that table
        strSQL = " SELECT DISTINCT TableName FROM " & My.Resources.TableFieldMappingTable & _
                 " WHERE " & Constants.QuestionnaireIDColumn & " = " & QuestionnaireID
        sqlcecom.CommandText = strSQL
        Dim da As New SqlCeDataAdapter(sqlcecom)
        da.Fill(dt)
        For Each aRow In dt.Rows
            If aRow(0) IsNot DBNull.Value Then
                strSQL = " DELETE FROM " & aRow(0).ToString() & _
                         " WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn
                sqlcecom.CommandText = strSQL
                sqlcecom.Parameters.Clear()
                sqlcecom.Prepare()
                sqlcecom.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                Try
                    sqlcecom.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try
            End If
        Next
        'create the record in the associated table and call the update method 
        strSQL = " INSERT INTO " & AssociatedTable & " (" & ResultsIDColumn & "," & Constants.StartTimeColumn & "," & Constants.EndTimeColumn & ")" & _
                 " VALUES (@" & ResultsIDColumn & ",@" & Constants.StartTimeColumn & ",@" & Constants.EndTimeColumn & ")"
        sqlcecom.CommandText = strSQL
        sqlcecom.Parameters.Clear()
        sqlcecom.Prepare()
        sqlcecom.Parameters.Add("@" & ResultsIDColumn, ResultsID)
        sqlcecom.Parameters.Add("@" & Constants.StartTimeColumn, StartTime)
        sqlcecom.Parameters.Add("@" & Constants.EndTimeColumn, EndTime)
        sqlcecom.ExecuteNonQuery()

        'update the tables with the results
        Dim I As Integer
        Try
            For I = 0 To Questions.Count - 1
                SaveQuestion(Questions(I), ResultsIDColumn, ResultsID, Constants.QuestionIDColumn, Constants.ValueIndexColumn, StartTime, EndTime)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function
    Public Shared Sub DiscardResults(ByVal ResultsIDColumn As String, ByVal ResultsID As String, ByVal QuestionnaireIDColumn As String, ByVal QuestionnaireID As String)
        Dim dt As New DataTable("Tables")
        Dim aRow As DataRow
        Connect()
        Dim strSQL As String = ""
        Dim sqlcecom As New SqlCeCommand()
        'get a list of all tables and remove the result in that table
        strSQL = " SELECT DISTINCT TableName FROM " & My.Resources.TableFieldMappingTable & _
                 " WHERE " & Constants.QuestionnaireIDColumn & " = " & QuestionnaireID
        sqlcecom.CommandText = strSQL
        sqlcecom.Connection = objSQLCEConnection
        Dim da As New SqlCeDataAdapter(sqlcecom)
        Try
            da.Fill(dt)
            For Each aRow In dt.Rows
                If aRow(0) IsNot DBNull.Value Then
                    strSQL = " UPDATE " & aRow(0).ToString() & " SET " & Constants.RecordDeletedColumn & " = @" & Constants.RecordDeletedColumn & _
                             " WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn
                    sqlcecom.CommandText = strSQL
                    sqlcecom.Parameters.Clear()
                    sqlcecom.Prepare()
                    sqlcecom.Parameters.Add("@" & Constants.RecordDeletedColumn, "Y")
                    sqlcecom.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                    Try
                        sqlcecom.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Catch ex As Exception
            'watefer
        End Try
    End Sub
    Public Shared Sub ResetQuestionResults(ByVal AssociatedTable As String, ByVal SurveyQuestion As SurveyQuestion, ByVal ResultsIDColumn As String, ByVal ResultsID As String, ByVal QuestionIDColumn As String)
        Dim I As Integer
        Dim strSQL As String = ""
        Dim com As New SqlCeCommand()
        If Connect() = True Then
            com.Connection = objSQLCEConnection
        Else
            MsgBox("Could not connect to data during saving", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        For I = 0 To SurveyQuestion.Fields.Count - 1
            Select Case SurveyQuestion.Fields(I).FieldType
                'single fields
                Case SurveyFieldBase.FieldDataTypes.qdDate, _
                    SurveyFieldBase.FieldDataTypes.qdNumber, _
                    SurveyFieldBase.FieldDataTypes.qdOptions, _
                    SurveyFieldBase.FieldDataTypes.qdStudyArea, _
                    SurveyFieldBase.FieldDataTypes.qdText

                    strSQL = " UPDATE " & SurveyQuestion.Fields(I).TableName & " SET " & SurveyQuestion.Fields(I).FieldName & " = NULL " & _
                             " WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn
                    com.CommandText = strSQL
                    com.Prepare()
                    com.Parameters.Clear()
                    com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                    Try
                        com.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Case SurveyFieldBase.FieldDataTypes.qdMultipleDates, _
                     SurveyFieldBase.FieldDataTypes.qdMultipleNumber, _
                     SurveyFieldBase.FieldDataTypes.qdMultipleText

                    strSQL = " DELETE FROM " & SurveyQuestion.Fields(I).TableName & _
                             " WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn & _
                             " AND " & QuestionIDColumn & " = @" & QuestionIDColumn
                    com.CommandText = strSQL
                    com.Prepare()
                    com.Parameters.Clear()
                    com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                    com.Parameters.Add("@" & QuestionIDColumn, SurveyQuestion.QuestionID)
                    Try
                        com.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
            End Select
        Next I
        strSQL = " UPDATE " & AssociatedTable & " SET " & Constants.RecordCompleteColumn & " = @" & Constants.RecordCompleteColumn & _
                 " WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn

        com.CommandText = strSQL
        com.Prepare()
        com.Parameters.Clear()
        com.Parameters.Add("@" & Constants.RecordCompleteColumn, "N")
        com.Parameters.Add("@" & ResultsIDColumn, ResultsID)

        Try
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Shared Sub SaveQuestion(ByVal SurveyQuestion As SurveyQuestion, ByVal ResultsIDColumn As String, ByVal ResultsID As String, ByVal QuestionIDColumn As String, ByVal ValueIndexColumn As String, ByVal StartTime As DateTime, ByVal EndTime As DateTime)
        Dim I As Integer
        For I = 0 To SurveyQuestion.Fields.Count - 1
            Select Case SurveyQuestion.Fields(I).FieldType
                'single fields
                Case SurveyFieldBase.FieldDataTypes.qdDate, _
                    SurveyFieldBase.FieldDataTypes.qdNumber, _
                    SurveyFieldBase.FieldDataTypes.qdOptions, _
                    SurveyFieldBase.FieldDataTypes.qdStudyArea, _
                    SurveyFieldBase.FieldDataTypes.qdText

                    UpdateSingleField(SurveyQuestion.Fields(I), ResultsIDColumn, ResultsID, StartTime, EndTime)

                Case SurveyFieldBase.FieldDataTypes.qdMultipleDates, _
                     SurveyFieldBase.FieldDataTypes.qdMultipleNumber, _
                     SurveyFieldBase.FieldDataTypes.qdMultipleText
                    UpdateMultiField(SurveyQuestion.Fields(I), ResultsIDColumn, ResultsID, SurveyQuestion.QuestionNumber, EndTime)
            End Select
        Next I
    End Sub
    Private Shared Sub UpdateMultiField(ByVal SurveyField As SurveyFieldBase, ByVal ResultsIDColumn As String, ByVal ResultsID As String, ByVal QuestionNo As String, ByVal EndTime As DateTime)
        Dim strSQL As String = ""
        Dim com As New SqlCeCommand()
        If Connect() = True Then
            com.Connection = objSQLCEConnection
        Else
            MsgBox("Could not connect to data during saving", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Select Case SurveyField.FieldType
            Case SurveyFieldBase.FieldDataTypes.qdMultipleDates
                Dim aMultiDate As SurveyFieldMultipleDates
                aMultiDate = SurveyField
                Dim aDateValue As DateFieldValue
                If aMultiDate.FieldValues IsNot Nothing Then
                    If aMultiDate.FieldValues.Count <> 0 Then
                        For Each aDateValue In aMultiDate.FieldValues
                            If CheckRecordIfExists(aMultiDate.TableName, ResultsIDColumn, ResultsID, Constants.QuestionIDColumn, aMultiDate.QuestionID, Constants.ValueIndexColumn, aDateValue.ValueIndex) = True Then
                                strSQL = " UPDATE " & aMultiDate.TableName & _
                                         " SET " & aMultiDate.FieldName & " = @" & aMultiDate.FieldName & "," & _
                                          Constants.SynchFlagColumn & " = @" & Constants.SynchFlagColumn & _
                                         " WHERE " & Constants.ValueIndexColumn & " = @" & Constants.ValueIndexColumn & _
                                         " AND " & Constants.QuestionIDColumn & " = @" & Constants.QuestionIDColumn & _
                                         " AND " & ResultsIDColumn & " = @" & ResultsIDColumn
                                com.CommandText = strSQL
                                com.Prepare()
                                com.Parameters.Clear()
                                com.Parameters.Add("@" & aMultiDate.FieldName, aDateValue.FieldValue)
                                com.Parameters.Add("@" & Constants.SynchFlagColumn, "N")
                                com.Parameters.Add("@" & Constants.ValueIndexColumn, aDateValue.ValueIndex)
                                com.Parameters.Add("@" & Constants.QuestionIDColumn, aMultiDate.QuestionID)
                                com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                                Try
                                    com.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            Else
                                strSQL = " INSERT INTO " & aMultiDate.TableName & _
                                         " (" & ResultsIDColumn & "," & _
                                         Constants.SynchFlagColumn & "," & _
                                         Constants.QuestionIDColumn & "," & _
                                         Constants.ValueIndexColumn & "," & _
                                         Constants.QuestionNoColumn & "," & _
                                         aMultiDate.FieldName & "," & _
                                         Constants.RecordDeletedColumn & ")" & _
                                         " VALUES ( @" & ResultsIDColumn & ",@" & _
                                                    Constants.SynchFlagColumn & ",@" & _
                                                    Constants.QuestionIDColumn & ",@" & _
                                                    Constants.ValueIndexColumn & ",@" & _
                                                    Constants.QuestionNoColumn & ",@" & _
                                                    aMultiDate.FieldName & ",@" & _
                                                    Constants.RecordDeletedColumn & ")"
                                com.CommandText = strSQL
                                com.Parameters.Clear()
                                com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                                com.Parameters.Add("@" & Constants.SynchFlagColumn, "N")
                                com.Parameters.Add("@" & Constants.QuestionIDColumn, aMultiDate.QuestionID)
                                com.Parameters.Add("@" & Constants.ValueIndexColumn, aDateValue.ValueIndex)
                                com.Parameters.Add("@" & Constants.QuestionNoColumn, QuestionNo)
                                com.Parameters.Add("@" & aMultiDate.FieldName, aDateValue.FieldValue)
                                com.Parameters.Add("@" & Constants.RecordDeletedColumn, "N")
                                Try
                                    com.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            End If
                        Next
                    End If
                End If
            Case SurveyFieldBase.FieldDataTypes.qdMultipleNumber
                Dim aMultiNumber As SurveyFieldMultipleNumbers
                aMultiNumber = SurveyField
                Dim aNumberValue As NumberFieldValue
                If aMultiNumber.FieldValues IsNot Nothing Then
                    If aMultiNumber.FieldValues.Count <> 0 Then
                        For Each aNumberValue In aMultiNumber.FieldValues
                            If CheckRecordIfExists(aMultiNumber.TableName, ResultsIDColumn, ResultsID, Constants.QuestionIDColumn, aMultiNumber.QuestionID, Constants.ValueIndexColumn, aNumberValue.ValueIndex) = True Then
                                strSQL = " UPDATE " & aMultiNumber.TableName & _
                                         " SET " & aMultiNumber.FieldName & " = @" & aMultiNumber.FieldName & "," & _
                                          Constants.SynchFlagColumn & " = @" & Constants.SynchFlagColumn & _
                                         " WHERE " & Constants.ValueIndexColumn & " = @" & Constants.ValueIndexColumn & _
                                         " AND " & Constants.QuestionIDColumn & " = @" & Constants.QuestionIDColumn & _
                                         " AND " & ResultsIDColumn & " = @" & ResultsIDColumn
                                com.CommandText = strSQL
                                com.Prepare()
                                com.Parameters.Clear()
                                com.Parameters.Add("@" & aMultiNumber.FieldName, aNumberValue.FieldValue)
                                com.Parameters.Add("@" & Constants.SynchFlagColumn, "N")
                                com.Parameters.Add("@" & Constants.ValueIndexColumn, aNumberValue.ValueIndex)
                                com.Parameters.Add("@" & Constants.QuestionIDColumn, aMultiNumber.QuestionID)
                                com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                                Try
                                    com.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            Else
                                strSQL = " INSERT INTO " & aMultiNumber.TableName & _
                                         " (" & ResultsIDColumn & "," & _
                                         Constants.SynchFlagColumn & "," & _
                                         Constants.QuestionIDColumn & "," & _
                                         Constants.ValueIndexColumn & "," & _
                                         Constants.QuestionNoColumn & "," & _
                                         aMultiNumber.FieldName & "," & _
                                         Constants.RecordDeletedColumn & ")" & _
                                         " VALUES ( @" & ResultsIDColumn & ",@" & _
                                                    Constants.SynchFlagColumn & ",@" & _
                                                    Constants.QuestionIDColumn & ",@" & _
                                                    Constants.ValueIndexColumn & ",@" & _
                                                    Constants.QuestionNoColumn & ",@" & _
                                                    aMultiNumber.FieldName & ",@" & _
                                                    Constants.RecordDeletedColumn & ")"
                                com.CommandText = strSQL
                                com.Parameters.Clear()
                                com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                                com.Parameters.Add("@" & Constants.SynchFlagColumn, "N")
                                com.Parameters.Add("@" & Constants.QuestionIDColumn, aMultiNumber.QuestionID)
                                com.Parameters.Add("@" & Constants.ValueIndexColumn, aNumberValue.ValueIndex)
                                com.Parameters.Add("@" & Constants.QuestionNoColumn, QuestionNo)
                                com.Parameters.Add("@" & aMultiNumber.FieldName, aNumberValue.FieldValue)
                                com.Parameters.Add("@" & Constants.RecordDeletedColumn, "N")
                                Try
                                    com.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            End If
                        Next
                    End If
                End If
            Case SurveyFieldBase.FieldDataTypes.qdMultipleText
                Dim aMultiText As SurveyFieldMultipleText
                aMultiText = SurveyField
                Dim aTextValue As TextFieldValue
                If aMultiText.FieldValues IsNot Nothing Then
                    If aMultiText.FieldValues.Count <> 0 Then
                        For Each aTextValue In aMultiText.FieldValues
                            If CheckRecordIfExists(aMultiText.TableName, ResultsIDColumn, ResultsID, Constants.QuestionIDColumn, aMultiText.QuestionID, Constants.ValueIndexColumn, aTextValue.ValueIndex) = True Then
                                strSQL = " UPDATE " & aMultiText.TableName & _
                                         " SET " & aMultiText.FieldName & " = @" & aMultiText.FieldName & "," & _
                                          Constants.SynchFlagColumn & " = @" & Constants.SynchFlagColumn & _
                                         " WHERE " & Constants.ValueIndexColumn & " = @" & Constants.ValueIndexColumn & _
                                         " AND " & Constants.QuestionIDColumn & " = @" & Constants.QuestionIDColumn & _
                                         " AND " & ResultsIDColumn & " = @" & ResultsIDColumn
                                com.CommandText = strSQL
                                com.Prepare()
                                com.Parameters.Clear()
                                com.Parameters.Add("@" & aMultiText.FieldName, aTextValue.FieldValue)
                                com.Parameters.Add("@" & Constants.SynchFlagColumn, "N")
                                com.Parameters.Add("@" & Constants.ValueIndexColumn, aTextValue.ValueIndex)
                                com.Parameters.Add("@" & Constants.QuestionIDColumn, aMultiText.QuestionID)
                                com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                                Try
                                    com.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            Else
                                strSQL = " INSERT INTO " & aMultiText.TableName & _
                                         " (" & ResultsIDColumn & "," & _
                                         Constants.SynchFlagColumn & "," & _
                                         Constants.QuestionIDColumn & "," & _
                                         Constants.ValueIndexColumn & "," & _
                                         Constants.QuestionNoColumn & "," & _
                                         aMultiText.FieldName & "," & _
                                         Constants.RecordDeletedColumn & ")" & _
                                         " VALUES ( @" & ResultsIDColumn & ",@" & _
                                                    Constants.SynchFlagColumn & ",@" & _
                                                    Constants.QuestionIDColumn & ",@" & _
                                                    Constants.ValueIndexColumn & ",@" & _
                                                    Constants.QuestionNoColumn & ",@" & _
                                                    aMultiText.FieldName & ",@" & _
                                                    Constants.RecordDeletedColumn & ")"
                                com.CommandText = strSQL
                                com.Parameters.Clear()
                                com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                                com.Parameters.Add("@" & Constants.SynchFlagColumn, "N")
                                com.Parameters.Add("@" & Constants.QuestionIDColumn, aMultiText.QuestionID)
                                com.Parameters.Add("@" & Constants.ValueIndexColumn, aTextValue.ValueIndex)
                                com.Parameters.Add("@" & Constants.QuestionNoColumn, QuestionNo)
                                com.Parameters.Add("@" & aMultiText.FieldName, aTextValue.FieldValue)
                                com.Parameters.Add("@" & Constants.RecordDeletedColumn, "N")
                                Try
                                    com.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            End If
                        Next
                    End If
                End If
        End Select
    End Sub
    Private Shared Sub UpdateSingleField(ByVal SurveyField As SurveyFieldBase, ByVal ResultsIDColumn As String, ByVal ResultsID As String, ByVal StartTime As DateTime, ByVal EndTime As DateTime)
        Dim strSQL As String = ""
        Dim com As New SqlCeCommand()
        Dim bRecordExists As Boolean = False
        If Connect() = True Then
            com.Connection = objSQLCEConnection
        Else
            MsgBox("Could not connect to data during saving", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If CheckIfRecordExists(SurveyField.TableName, ResultsIDColumn, ResultsID) = True Then
            strSQL = " UPDATE " & SurveyField.TableName & _
                     " SET " & SurveyField.FieldName & " = @" & SurveyField.FieldName & ", " & _
                       Constants.EndTimeColumn & " = @" & Constants.EndTimeColumn & _
                     " WHERE " & ResultsIDColumn & " = @" & ResultsIDColumn
            Select Case SurveyField.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdDate
                    Dim aDateField As SurveyFieldDate
                    aDateField = SurveyField
                    If aDateField.FieldValue IsNot Nothing Then
                        'set the parameters
                        com.CommandText = strSQL
                        com.Prepare()
                        com.Parameters.Clear()
                        com.Parameters.Add("@" & aDateField.FieldName, aDateField.FieldValue.FieldValue)
                        com.Parameters.Add("@" & Constants.EndTimeColumn, EndTime)
                        com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                        Try
                            com.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdText, SurveyFieldBase.FieldDataTypes.qdStudyArea
                    Dim aTextField As SurveyFieldText
                    aTextField = SurveyField
                    If aTextField.FieldValue IsNot Nothing Then
                        'set the parameters
                        com.CommandText = strSQL
                        com.Prepare()
                        com.Parameters.Clear()
                        com.Parameters.Add("@" & aTextField.FieldName, aTextField.FieldValue.FieldValue)
                        com.Parameters.Add("@" & Constants.EndTimeColumn, EndTime)
                        com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                        Try
                            com.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdNumber, SurveyFieldBase.FieldDataTypes.qdOnOff, SurveyFieldBase.FieldDataTypes.qdOptions
                    Dim aNumberField As SurveyFieldNumber = SurveyField
                    If aNumberField.FieldValue IsNot Nothing Then
                        com.CommandText = strSQL
                        com.Prepare()
                        com.Parameters.Clear()
                        com.Parameters.Add("@" & aNumberField.FieldName, aNumberField.FieldValue.FieldValue)
                        com.Parameters.Add("@" & Constants.EndTimeColumn, EndTime)
                        com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                        Try
                            com.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
            End Select
        Else
            strSQL = " INSERT INTO " & SurveyField.TableName & "(" & ResultsIDColumn & "," & _
                                                                  Constants.StartTimeColumn & "," & _
                                                                  Constants.EndTimeColumn & "," & _
                                                                  SurveyField.FieldName & ")" & _
                                                                  " VALUES ( @" & ResultsIDColumn & ",@" & _
                                                                  Constants.StartTimeColumn & ", @" & _
                                                                  Constants.EndTimeColumn & ", @" & _
                                                                  SurveyField.FieldName & ")"
            Select Case SurveyField.FieldType
                Case SurveyFieldBase.FieldDataTypes.qdDate
                    Dim aDateField As SurveyFieldDate
                    aDateField = SurveyField
                    If aDateField.FieldValue IsNot Nothing Then
                        'set the parameters
                        com.CommandText = strSQL
                        com.Prepare()
                        com.Parameters.Clear()
                        com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                        com.Parameters.Add("@" & Constants.StartTimeColumn, StartTime)
                        com.Parameters.Add("@" & Constants.EndTimeColumn, EndTime)
                        com.Parameters.Add("@" & aDateField.FieldName, aDateField.FieldValue.FieldValue)
                        Try
                            com.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdText, SurveyFieldBase.FieldDataTypes.qdStudyArea
                    Dim aTextField As SurveyFieldText
                    aTextField = SurveyField
                    If aTextField.FieldValue IsNot Nothing Then
                        'set the parameters
                        com.CommandText = strSQL
                        com.Prepare()
                        com.Parameters.Clear()
                        com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                        com.Parameters.Add("@" & Constants.StartTimeColumn, StartTime)
                        com.Parameters.Add("@" & Constants.EndTimeColumn, EndTime)
                        com.Parameters.Add("@" & aTextField.FieldName, aTextField.FieldValue.FieldValue)
                        Try
                            com.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Case SurveyFieldBase.FieldDataTypes.qdNumber, SurveyFieldBase.FieldDataTypes.qdOnOff, SurveyFieldBase.FieldDataTypes.qdOptions
                    Dim aNumberField As SurveyFieldNumber = SurveyField
                    If aNumberField.FieldValue IsNot Nothing Then
                        com.CommandText = strSQL
                        com.Prepare()
                        com.Parameters.Clear()
                        com.Parameters.Add("@" & ResultsIDColumn, ResultsID)
                        com.Parameters.Add("@" & Constants.StartTimeColumn, StartTime)
                        com.Parameters.Add("@" & Constants.EndTimeColumn, EndTime)
                        com.Parameters.Add("@" & aNumberField.FieldName, aNumberField.FieldValue.FieldValue)
                        Try
                            com.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
            End Select

        End If
    End Sub
    Public Shared Function CheckIfRecordExists(ByVal TableName As String, ByVal UniqueColName As String, ByVal UniqueID As String) As Boolean
        'Check if record exists
        Dim strSQL As String
        Dim oRes As Object = Nothing
        strSQL = " SELECT COUNT(*) " & _
                 " FROM " & TableName.Trim() & _
                 " WHERE " & UniqueColName.Trim() & " = @" & UniqueColName
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            com.Parameters.Clear()
            com.Parameters.Add("@" & UniqueColName.Trim(), UniqueID)
            oRes = com.ExecuteScalar()
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
        If Convert.ToInt32(oRes) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Shared Function CheckRecordIfExists(ByVal TableName As String, ByVal UniqueColName As String, ByVal UniqueID As String, ByVal QuestionIDColumn As String, ByVal QuestionID As Integer, ByVal ValueIdxColumn As String, ByVal ValueIdx As Integer) As Boolean
        Dim strSQL As String
        Dim oRes As Object = Nothing
        strSQL = " SELECT COUNT(*) " & _
                 " FROM " & TableName.Trim() & _
                 " WHERE " & UniqueColName.Trim() & " = @" & UniqueColName & _
                 " AND " & QuestionIDColumn.Trim() & "  = @" & QuestionIDColumn.Trim() & _
                 " AND " & ValueIdxColumn.Trim() & " = @" & ValueIdxColumn
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            com.Parameters.Clear()
            com.Parameters.Add("@" & UniqueColName.Trim(), UniqueID)
            com.Parameters.Add("@" & QuestionIDColumn.Trim(), QuestionID)
            com.Parameters.Add("@" & ValueIdxColumn.Trim(), ValueIdx)
            oRes = com.ExecuteScalar()
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
        If Convert.ToInt32(oRes) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function IsFieldReadOnly(ByVal FieldName As String, ByVal QuestionID As Integer) As Boolean
        Dim oRes As Object = Nothing
        Dim strSQL As String
        strSQL = " SELECT " & Constants.RowPopulationColumn & _
                 " FROM " & My.Resources.QTablesTable & _
                 " WHERE " & Constants.QuestionIDColumn & " = @" & Constants.QuestionIDColumn & _
                 " AND " & Constants.FieldNameColumn & " =@" & Constants.FieldNameColumn
        If Connect() = True Then
            Dim com As New SqlCeCommand(strSQL, objSQLCEConnection)
            com.Parameters.Clear()
            com.Parameters.Add("@" & Constants.QuestionIDColumn, QuestionID)
            com.Parameters.Add("@" & Constants.FieldNameColumn, FieldName)
            oRes = com.ExecuteScalar()
        Else
            MsgBox("Errors occured while connecting to the data", MsgBoxStyle.Exclamation)
        End If
        If Convert.IsDBNull(oRes) = True Then
            Return False
        Else
            If Convert.ToInt32(oRes) > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
End Class
