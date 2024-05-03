Imports System.Reflection
Imports OpenNETCF.Media
Public Class DeviceStatus
    Dim forceHide As Boolean = False
    Private m_autoHide As Boolean = True
    Public Property AutoHide() As Boolean
        Get
            Return m_autoHide
        End Get
        Set(ByVal value As Boolean)
            m_autoHide = value
        End Set
    End Property
    Private Sub tmTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmTimer.Tick
        Dim CurrentPower As Integer = CInt(Device.GetMainPowerStatus)
        Dim aSysSound As New SoundPlayer()

        pbPower.Value = CurrentPower
        lblPowerStatus.Text = "Current charge: " & String.Format("{0}%", CurrentPower)
        lblActiveSynch.Text = Device.ActiveSyncConnection
        If forceHide = False Then
            If CurrentPower < 20 Then
                m_autoHide = True
                Me.Visible = True
                lblPowerStatus.ForeColor = Color.Red
                aSysSound.SoundLocation = "Windows\LowBatt.wma"
                aSysSound.Play()
            Else
                If m_autoHide = True Then
                    Me.Visible = False
                End If
            End If
        Else
            If m_autoHide = True Then
                Me.Visible = False
            End If
            forceHide = False
            End If
    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        Me.Visible = False
        forceHide = True
    End Sub
End Class
