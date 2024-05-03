Imports System.Collections
Imports System.Data
Public Class StudyArea
    Private mProvinces As New List(Of Province)
    Public Sub New()
        If mProvinces.Count = 0 Then
            LoadProvinces()
        End If
    End Sub
    Public ReadOnly Property Provinces() As List(Of Province)
        Get
            Return mProvinces
        End Get
    End Property
    Public Sub LoadProvinces()
        Dim ProvincesTable As New DataTable(My.Resources.ProvincesTable)
        Dim pRow As DataRow
        Dim aProvince As Province
        ProvincesTable = Data.ReadData(My.Resources.ProvincesTable)
        If ProvincesTable.Rows.Count > 0 Then
            For Each pRow In ProvincesTable.Rows
                aProvince = New Province
                aProvince.ProvID = pRow(Constants.ProvinceIDColumn)
                aProvince.ProvinceName = pRow(Constants.ProvinceNameColumn)
                aProvince.ProvinceID = pRow(Constants.ProvincesProvIDColumn)
                mProvinces.Add(aProvince)
            Next
        Else
            MsgBox("There was an error starting Provinces", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class
