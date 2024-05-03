<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class DeviceStatus
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tmTimer = New System.Windows.Forms.Timer
        Me.tbDevice = New System.Windows.Forms.TabControl
        Me.tbpPower = New System.Windows.Forms.TabPage
        Me.lblActiveSynch = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPowerStatus = New System.Windows.Forms.Label
        Me.pbPower = New System.Windows.Forms.ProgressBar
        Me.tbpBackup = New System.Windows.Forms.TabPage
        Me.btnHide = New System.Windows.Forms.Button
        Me.tbDevice.SuspendLayout()
        Me.tbpPower.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmTimer
        '
        Me.tmTimer.Enabled = True
        Me.tmTimer.Interval = 10000
        '
        'tbDevice
        '
        Me.tbDevice.Controls.Add(Me.tbpPower)
        Me.tbDevice.Controls.Add(Me.tbpBackup)
        Me.tbDevice.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.tbDevice.Location = New System.Drawing.Point(0, 0)
        Me.tbDevice.Name = "tbDevice"
        Me.tbDevice.SelectedIndex = 0
        Me.tbDevice.Size = New System.Drawing.Size(229, 108)
        Me.tbDevice.TabIndex = 0
        '
        'tbpPower
        '
        Me.tbpPower.Controls.Add(Me.lblActiveSynch)
        Me.tbpPower.Controls.Add(Me.Label3)
        Me.tbpPower.Controls.Add(Me.Label2)
        Me.tbpPower.Controls.Add(Me.Label1)
        Me.tbpPower.Controls.Add(Me.lblPowerStatus)
        Me.tbpPower.Controls.Add(Me.pbPower)
        Me.tbpPower.Location = New System.Drawing.Point(0, 0)
        Me.tbpPower.Name = "tbpPower"
        Me.tbpPower.Size = New System.Drawing.Size(229, 85)
        Me.tbpPower.Text = "Power"
        '
        'lblActiveSynch
        '
        Me.lblActiveSynch.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblActiveSynch.ForeColor = System.Drawing.Color.Blue
        Me.lblActiveSynch.Location = New System.Drawing.Point(20, 64)
        Me.lblActiveSynch.Name = "lblActiveSynch"
        Me.lblActiveSynch.Size = New System.Drawing.Size(206, 19)
        Me.lblActiveSynch.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(20, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 14)
        Me.Label3.Text = "Power: Main battery"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(193, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 14)
        Me.Label2.Text = "100"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(2, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 12)
        Me.Label1.Text = "0"
        '
        'lblPowerStatus
        '
        Me.lblPowerStatus.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPowerStatus.ForeColor = System.Drawing.Color.Black
        Me.lblPowerStatus.Location = New System.Drawing.Point(20, 42)
        Me.lblPowerStatus.Name = "lblPowerStatus"
        Me.lblPowerStatus.Size = New System.Drawing.Size(167, 15)
        '
        'pbPower
        '
        Me.pbPower.Location = New System.Drawing.Point(20, 21)
        Me.pbPower.Name = "pbPower"
        Me.pbPower.Size = New System.Drawing.Size(167, 16)
        '
        'tbpBackup
        '
        Me.tbpBackup.Location = New System.Drawing.Point(0, 0)
        Me.tbpBackup.Name = "tbpBackup"
        Me.tbpBackup.Size = New System.Drawing.Size(221, 101)
        Me.tbpBackup.Text = "Data back up"
        '
        'btnHide
        '
        Me.btnHide.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnHide.Location = New System.Drawing.Point(0, 109)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(47, 24)
        Me.btnHide.TabIndex = 6
        Me.btnHide.Text = "Hide"
        '
        'DeviceStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.btnHide)
        Me.Controls.Add(Me.tbDevice)
        Me.Name = "DeviceStatus"
        Me.Size = New System.Drawing.Size(229, 133)
        Me.tbDevice.ResumeLayout(False)
        Me.tbpPower.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmTimer As System.Windows.Forms.Timer
    Friend WithEvents tbDevice As System.Windows.Forms.TabControl
    Friend WithEvents tbpBackup As System.Windows.Forms.TabPage
    Friend WithEvents tbpPower As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPowerStatus As System.Windows.Forms.Label
    Friend WithEvents pbPower As System.Windows.Forms.ProgressBar
    Friend WithEvents btnHide As System.Windows.Forms.Button

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Dim CurrentPower As Integer = CInt(Device.GetMainPowerStatus)
        pbPower.Value = CurrentPower
        lblPowerStatus.Text = "Current charge: " & String.Format("{0}%", CurrentPower)
        lblActiveSynch.Text = Device.ActiveSyncConnection


    End Sub
    Friend WithEvents lblActiveSynch As System.Windows.Forms.Label
End Class
