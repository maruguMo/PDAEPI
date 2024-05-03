Imports System.Collections
Imports System.Data
Public Class District
    Private mProvinceID As String
    Private mDistrictName As String
    Private mDistrictID As String
    Private mSites As New List(Of Site)
    Public Property ProvinceID() As String
        Get
            Return mProvinceID
        End Get
        Set(ByVal value As String)
            mProvinceID = value
        End Set
    End Property

    Public ReadOnly Property Sites() As List(Of Site)
        Get
            Return mSites
        End Get
    End Property

    Public Property DistrictName() As String
        Get
            Return mDistrictName
        End Get
        Set(ByVal value As String)
            mDistrictName = value
        End Set
    End Property
    Public Property DistrictID() As String
        Get
            Return mDistrictID
        End Get
        Set(ByVal value As String)
            mDistrictID = value
        End Set
    End Property
    Public Sub LoadSites(Optional ByVal DistrictID As Integer = 0)
        Dim SitesTable As New DataTable(My.Resources.SitesTable)
        Dim sRow As DataRow
        Dim aSite As Site
        Dim sWhere As String
        If DistrictID <> 0 Then
            sWhere = Constants.DistrictIDColumn & "=" & DistrictID
        Else
            sWhere = Constants.DistrictIDColumn & "=" & mDistrictID
        End If
        sWhere &= " ORDER BY " & Constants.SiteNameColumn
        SitesTable = Data.ReadData(My.Resources.SitesTable, sWhere)
        If mSites.Count <> 0 Then
            mSites.Clear()
        End If
        For Each sRow In SitesTable.Rows
            aSite = New Site
            aSite.SiteID = sRow(Constants.SiteIDColumn)
            aSite.SiteName = sRow(Constants.SiteNameColumn)
            aSite.ProvinceID = sRow(Constants.SiteProvIDColumn)
            aSite.DistrictID = sRow(Constants.DistrictIDColumn)
            mSites.Add(aSite)
        Next

        'MsgBox("There was an error starting Sites", MsgBoxStyle.Exclamation)
    End Sub
    Public Overrides Function ToString() As String
        Return mDistrictName
    End Function
End Class
