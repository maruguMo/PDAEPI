Imports System.Collections
Imports System.Data
Public Class Province
    Private mProvID As String
    Private mProvinceID As String
    Private mProvinceName As String
    Private mSites As New List(Of Site)
    Private mDistricts As New List(Of District)
    Public ReadOnly Property Districts() As List(Of District)
        Get
            Return mDistricts
        End Get
    End Property
    Public ReadOnly Property Sites() As List(Of Site)
        Get
            Return mSites
        End Get
    End Property
    Public Property ProvinceName() As String
        Get
            Return mProvinceName
        End Get
        Set(ByVal value As String)
            mProvinceName = value
        End Set
    End Property
    Public Property ProvID() As String
        Get
            Return mProvID
        End Get
        Set(ByVal value As String)
            mProvID = value
        End Set
    End Property
    Public Property ProvinceID() As String
        Get
            Return mProvinceID
        End Get
        Set(ByVal value As String)
            mProvinceID = value
        End Set
    End Property
    Public Sub LoadDistricts(Optional ByVal ProvID As Integer = 0)
        Dim DistrictsTable As New DataTable(My.Resources.DistrictsTable)
        Dim aDistrict As District
        Dim sRow As DataRow
        Dim sWhere As String
        If ProvID <> 0 Then
            sWhere = Constants.DistrictsProvinceIDColumn & "=" & ProvID
        Else
            sWhere = Constants.DistrictsProvinceIDColumn & "=" & mProvinceID
        End If
        sWhere &= " ORDER BY " & Constants.DistrictNameColumn
        DistrictsTable = Data.ReadData(My.Resources.DistrictsTable, sWhere)
        If mDistricts.Count <> 0 Then
            mDistricts.Clear()
        End If
        If DistrictsTable.Rows.Count > 0 Then
            For Each sRow In DistrictsTable.Rows
                aDistrict = New District
                aDistrict.DistrictID = sRow(Constants.DistrictIDColumn)
                aDistrict.DistrictName=sRow(Constants.DistrictNameColumn)
                aDistrict.ProvinceID = sRow(Constants.DistrictsProvinceIDColumn)
                mDistricts.Add(aDistrict)
            Next
        Else
            MsgBox("There was an error populating the list of districts", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Sub LoadSites(Optional ByVal ProvID As Integer = 0)
        Dim SitesTable As New DataTable(My.Resources.SitesTable)
        Dim sRow As DataRow
        Dim aSite As Site
        Dim sWhere As String
        If ProvID <> 0 Then
            sWhere = Constants.SiteProvIDColumn & "=" & ProvID
        Else
            sWhere = Constants.SiteProvIDColumn & "=" & mProvinceID
        End If
        SitesTable = Data.ReadData(My.Resources.SitesTable, sWhere)
        If mSites.Count <> 0 Then
            mSites.Clear()
        End If
        If SitesTable.Rows.Count > 0 Then
            For Each sRow In SitesTable.Rows
                aSite = New Site
                aSite.SiteID = sRow(Constants.SiteIDColumn)
                aSite.SiteName = sRow(Constants.SiteNameColumn)
                aSite.ProvinceID = sRow(Constants.SiteProvIDColumn)
                mSites.Add(aSite)
            Next
        Else
            MsgBox("There was an error populating the list of facilities", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Public Overrides Function ToString() As String
        Return mProvinceName
    End Function
End Class
