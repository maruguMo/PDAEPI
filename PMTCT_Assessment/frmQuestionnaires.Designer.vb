<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmQuestionnaires
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.lvwQuestionnaires = New System.Windows.Forms.ListView
        Me.QuestionnaireID = New System.Windows.Forms.ColumnHeader
        Me.QuestionnaireTitle = New System.Windows.Forms.ColumnHeader
        Me.conStart = New System.Windows.Forms.ContextMenu
        Me.contxtStart = New System.Windows.Forms.MenuItem
        Me.lblStudyTitle = New System.Windows.Forms.Label
        Me.DeviceStatus = New PDAEPI.DeviceStatus
        Me.mnuMain = New System.Windows.Forms.MainMenu
        Me.mnuMenu = New System.Windows.Forms.MenuItem
        Me.mnuStart = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuDeviceStatus = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-3, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 21)
        Me.Label1.Text = "Select a questionnaire below"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvwQuestionnaires
        '
        Me.lvwQuestionnaires.Columns.Add(Me.QuestionnaireID)
        Me.lvwQuestionnaires.Columns.Add(Me.QuestionnaireTitle)
        Me.lvwQuestionnaires.ContextMenu = Me.conStart
        Me.lvwQuestionnaires.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lvwQuestionnaires.FullRowSelect = True
        Me.lvwQuestionnaires.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwQuestionnaires.Location = New System.Drawing.Point(3, 75)
        Me.lvwQuestionnaires.Name = "lvwQuestionnaires"
        Me.lvwQuestionnaires.Size = New System.Drawing.Size(234, 185)
        Me.lvwQuestionnaires.TabIndex = 1
        Me.lvwQuestionnaires.View = System.Windows.Forms.View.Details
        '
        'QuestionnaireID
        '
        Me.QuestionnaireID.Text = "ID"
        Me.QuestionnaireID.Width = 31
        '
        'QuestionnaireTitle
        '
        Me.QuestionnaireTitle.Text = "Title"
        Me.QuestionnaireTitle.Width = 200
        '
        'conStart
        '
        Me.conStart.MenuItems.Add(Me.contxtStart)
        '
        'contxtStart
        '
        Me.contxtStart.Text = "Start"
        '
        'lblStudyTitle
        '
        Me.lblStudyTitle.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudyTitle.Location = New System.Drawing.Point(0, 5)
        Me.lblStudyTitle.Name = "lblStudyTitle"
        Me.lblStudyTitle.Size = New System.Drawing.Size(240, 36)
        Me.lblStudyTitle.Text = "Study Title"
        Me.lblStudyTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DeviceStatus
        '
        Me.DeviceStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.DeviceStatus.Location = New System.Drawing.Point(5, 77)
        Me.DeviceStatus.Name = "DeviceStatus"
        Me.DeviceStatus.Size = New System.Drawing.Size(230, 140)
        Me.DeviceStatus.TabIndex = 8
        Me.DeviceStatus.Visible = False
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.Add(Me.mnuMenu)
        '
        'mnuMenu
        '
        Me.mnuMenu.MenuItems.Add(Me.mnuStart)
        Me.mnuMenu.MenuItems.Add(Me.MenuItem2)
        Me.mnuMenu.MenuItems.Add(Me.mnuDeviceStatus)
        Me.mnuMenu.MenuItems.Add(Me.MenuItem4)
        Me.mnuMenu.MenuItems.Add(Me.mnuExit)
        Me.mnuMenu.Text = "Menu"
        '
        'mnuStart
        '
        Me.mnuStart.Text = "Start"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "-"
        '
        'mnuDeviceStatus
        '
        Me.mnuDeviceStatus.Text = "Device Status"
        '
        'MenuItem4
        '
        Me.MenuItem4.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Text = "Exit"
        '
        'frmQuestionnaires
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(257, 285)
        Me.Controls.Add(Me.DeviceStatus)
        Me.Controls.Add(Me.lblStudyTitle)
        Me.Controls.Add(Me.lvwQuestionnaires)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mnuMain
        Me.Name = "frmQuestionnaires"
        Me.Text = "Select questionnaire"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvwQuestionnaires As System.Windows.Forms.ListView
    Friend WithEvents QuestionnaireID As System.Windows.Forms.ColumnHeader
    Friend WithEvents QuestionnaireTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblStudyTitle As System.Windows.Forms.Label
    Friend WithEvents DeviceStatus As PDAEPI.DeviceStatus
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuMenu As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStart As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeviceStatus As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents conStart As System.Windows.Forms.ContextMenu
    Friend WithEvents contxtStart As System.Windows.Forms.MenuItem
End Class
