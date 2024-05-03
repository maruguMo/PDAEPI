<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmListResults
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
    Private mnuMain As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mnuMain = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuNew = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.mnuReview = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuDiscard = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuBack = New System.Windows.Forms.MenuItem
        Me.dgResults = New System.Windows.Forms.DataGrid
        Me.lblQuestionnaireTitle = New System.Windows.Forms.Label
        Me.DeviceStatus = New PDAEPI.DeviceStatus
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.mnuNew)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem3)
        Me.MenuItem1.MenuItems.Add(Me.mnuReview)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem5)
        Me.MenuItem1.MenuItems.Add(Me.mnuDiscard)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.MenuItems.Add(Me.mnuBack)
        Me.MenuItem1.Text = "Menu"
        '
        'mnuNew
        '
        Me.mnuNew.Text = "New results"
        '
        'MenuItem3
        '
        Me.MenuItem3.Text = "-"
        '
        'mnuReview
        '
        Me.mnuReview.Text = "Review results"
        '
        'MenuItem5
        '
        Me.MenuItem5.Text = "-"
        '
        'mnuDiscard
        '
        Me.mnuDiscard.Text = "Discard Results"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "-"
        '
        'mnuBack
        '
        Me.mnuBack.Text = "Back"
        '
        'dgResults
        '
        Me.dgResults.BackgroundColor = System.Drawing.Color.White
        Me.dgResults.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.dgResults.Location = New System.Drawing.Point(3, 41)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.Size = New System.Drawing.Size(234, 224)
        Me.dgResults.TabIndex = 0
        '
        'lblQuestionnaireTitle
        '
        Me.lblQuestionnaireTitle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQuestionnaireTitle.Location = New System.Drawing.Point(3, 6)
        Me.lblQuestionnaireTitle.Name = "lblQuestionnaireTitle"
        Me.lblQuestionnaireTitle.Size = New System.Drawing.Size(233, 28)
        Me.lblQuestionnaireTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DeviceStatus
        '
        Me.DeviceStatus.Location = New System.Drawing.Point(3, 100)
        Me.DeviceStatus.Name = "DeviceStatus"
        Me.DeviceStatus.Size = New System.Drawing.Size(233, 99)
        Me.DeviceStatus.TabIndex = 9
        Me.DeviceStatus.Visible = False
        '
        'frmListResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.DeviceStatus)
        Me.Controls.Add(Me.lblQuestionnaireTitle)
        Me.Controls.Add(Me.dgResults)
        Me.Menu = Me.mnuMain
        Me.Name = "frmListResults"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReview As System.Windows.Forms.MenuItem
    Friend WithEvents dgResults As System.Windows.Forms.DataGrid
    Friend WithEvents lblQuestionnaireTitle As System.Windows.Forms.Label
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDiscard As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuBack As System.Windows.Forms.MenuItem
    Friend WithEvents DeviceStatus As PDAEPI.DeviceStatus
End Class
