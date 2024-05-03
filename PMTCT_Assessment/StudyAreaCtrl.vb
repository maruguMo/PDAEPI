Imports System.Data
Imports System.Collections
Public Class StudyAreaCtrl
    Private mStudyArea As StudyArea
    Public Property StudyArea() As StudyArea
        Get
            Return mStudyArea
        End Get
        Set(ByVal value As StudyArea)
            mStudyArea = value
        End Set
    End Property
    Public ReadOnly Property selectedProvince() As Province
        Get
            If cboProvinces.SelectedItem Is Nothing Then
                Return Nothing
            Else
                Return cboProvinces.SelectedItem
            End If
        End Get
    End Property
    Public ReadOnly Property selectedDistrict() As District
        Get
            If cboDistricts.SelectedItem Is Nothing Then
                Return Nothing
            Else
                Return cboDistricts.SelectedItem
            End If
        End Get
    End Property
    Public ReadOnly Property selectedSite() As Site
        Get
            If cboSites.SelectedItem Is Nothing Then
                Return Nothing
            Else
                Return cboSites.SelectedItem
            End If
        End Get
    End Property
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Dim pProvince As Province
        cboProvinces.Items.Clear()
        For Each pProvince In Globals.PDAEPIStudy.StudyArea.Provinces
            With cboProvinces
                .Items.Add(pProvince)
            End With
        Next
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cboProvinces_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvinces.SelectedIndexChanged
        Dim aProvince As Province = Nothing
        Dim aSite As Site
        Dim aDistrict As District
        aProvince = cboProvinces.SelectedItem()
        If aProvince IsNot Nothing Then
            aProvince.LoadDistricts()
            cboDistricts.Items.Clear()
            For Each aDistrict In aProvince.Districts
                cboDistricts.Items.Add(aDistrict)
            Next
            aProvince.LoadSites()
            'now i load the selected sites
            cboSites.Items.Clear()
            For Each aSite In aProvince.Sites
                cboSites.Items.Add(aSite)
            Next
        End If
    End Sub

    Private Sub cboDistricts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistricts.SelectedIndexChanged
        Dim aDistrict As District = Nothing
        Dim aSite As Site
        aDistrict = cboDistricts.SelectedItem
        If aDistrict IsNot Nothing Then
            aDistrict.LoadSites()
            cboSites.Items.Clear()
            For Each aSite In aDistrict.Sites
                cboSites.Items.Add(aSite)
            Next
        End If
    End Sub
End Class
