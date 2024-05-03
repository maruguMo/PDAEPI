<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class StudyAreaCtrl
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
        Me.cboSites = New System.Windows.Forms.ComboBox
        Me.cboProvinces = New System.Windows.Forms.ComboBox
        Me.lbnTitle = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDistricts = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'cboSites
        '
        Me.cboSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSites.Location = New System.Drawing.Point(2, 125)
        Me.cboSites.Name = "cboSites"
        Me.cboSites.Size = New System.Drawing.Size(197, 22)
        Me.cboSites.TabIndex = 5
        '
        'cboProvinces
        '
        Me.cboProvinces.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboProvinces.Location = New System.Drawing.Point(2, 39)
        Me.cboProvinces.Name = "cboProvinces"
        Me.cboProvinces.Size = New System.Drawing.Size(197, 22)
        Me.cboProvinces.TabIndex = 4
        '
        'lbnTitle
        '
        Me.lbnTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbnTitle.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lbnTitle.ForeColor = System.Drawing.Color.White
        Me.lbnTitle.Location = New System.Drawing.Point(0, 0)
        Me.lbnTitle.Name = "lbnTitle"
        Me.lbnTitle.Size = New System.Drawing.Size(202, 15)
        Me.lbnTitle.Text = "Select province, district then facility"
        Me.lbnTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(2, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 16)
        Me.Label1.Text = "Province"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(2, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(196, 18)
        Me.Label2.Text = "Facility"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(2, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 18)
        Me.Label3.Text = "District"
        '
        'cboDistricts
        '
        Me.cboDistricts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDistricts.Location = New System.Drawing.Point(2, 82)
        Me.cboDistricts.Name = "cboDistricts"
        Me.cboDistricts.Size = New System.Drawing.Size(197, 22)
        Me.cboDistricts.TabIndex = 8
        '
        'StudyAreaCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboDistricts)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSites)
        Me.Controls.Add(Me.cboProvinces)
        Me.Controls.Add(Me.lbnTitle)
        Me.Name = "StudyAreaCtrl"
        Me.Size = New System.Drawing.Size(202, 147)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboSites As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvinces As System.Windows.Forms.ComboBox
    Friend WithEvents lbnTitle As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDistricts As System.Windows.Forms.ComboBox

End Class
