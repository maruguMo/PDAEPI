Imports System.Collections
Imports System.Data
Public Class Site
    Private mSiteName As String
    Private mProvinceID As String
    Private mSiteID As String
    Private mDistrictID As String
    Public Property DistrictID() As String
        Get
            Return mDistrictID
        End Get
        Set(ByVal value As String)
            mDistrictID = value
        End Set
    End Property
    Public Property SiteID() As String
        Get
            Return mSiteID
        End Get
        Set(ByVal value As String)
            mSiteID = value
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
    Public Property SiteName() As String
        Get
            Return mSiteName
        End Get
        Set(ByVal value As String)
            mSiteName = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return mSiteName
    End Function
End Class
