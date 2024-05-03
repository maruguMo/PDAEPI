<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MultiMonthAndCheck
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
        Me.lvItems = New System.Windows.Forms.ListView
        Me.colMonth = New System.Windows.Forms.ColumnHeader
        Me.colDurationType = New System.Windows.Forms.ColumnHeader
        Me.ColDuration = New System.Windows.Forms.ColumnHeader
        Me.colIdx = New System.Windows.Forms.ColumnHeader
        Me.contextListMenu = New System.Windows.Forms.ContextMenu
        Me.mnuRemove = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuClear = New System.Windows.Forms.MenuItem
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.cboDurationType = New System.Windows.Forms.ComboBox
        Me.nudDuration = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lvItems
        '
        Me.lvItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvItems.Columns.Add(Me.colMonth)
        Me.lvItems.Columns.Add(Me.colDurationType)
        Me.lvItems.Columns.Add(Me.ColDuration)
        Me.lvItems.Columns.Add(Me.colIdx)
        Me.lvItems.ContextMenu = Me.contextListMenu
        Me.lvItems.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lvItems.FullRowSelect = True
        Me.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvItems.Location = New System.Drawing.Point(0, 49)
        Me.lvItems.Name = "lvItems"
        Me.lvItems.Size = New System.Drawing.Size(210, 152)
        Me.lvItems.TabIndex = 0
        Me.lvItems.View = System.Windows.Forms.View.Details
        '
        'colMonth
        '
        Me.colMonth.Text = "Month"
        Me.colMonth.Width = 60
        '
        'colDurationType
        '
        Me.colDurationType.Text = "Days/Weeks/Month"
        Me.colDurationType.Width = 124
        '
        'ColDuration
        '
        Me.ColDuration.Text = "Duration"
        Me.ColDuration.Width = 59
        '
        'colIdx
        '
        Me.colIdx.Text = "Index"
        Me.colIdx.Width = 49
        '
        'contextListMenu
        '
        Me.contextListMenu.MenuItems.Add(Me.mnuRemove)
        Me.contextListMenu.MenuItems.Add(Me.MenuItem2)
        Me.contextListMenu.MenuItems.Add(Me.mnuClear)
        '
        'mnuRemove
        '
        Me.mnuRemove.Text = "Remove"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "-"
        '
        'mnuClear
        '
        Me.mnuClear.Text = "Clear"
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.cboMonth.Location = New System.Drawing.Point(3, 21)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(60, 20)
        Me.cboMonth.TabIndex = 1
        '
        'cboDurationType
        '
        Me.cboDurationType.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.cboDurationType.Items.Add("D")
        Me.cboDurationType.Items.Add("W")
        Me.cboDurationType.Items.Add("M")
        Me.cboDurationType.Location = New System.Drawing.Point(69, 21)
        Me.cboDurationType.Name = "cboDurationType"
        Me.cboDurationType.Size = New System.Drawing.Size(40, 20)
        Me.cboDurationType.TabIndex = 5
        '
        'nudDuration
        '
        Me.nudDuration.BackColor = System.Drawing.Color.WhiteSmoke
        Me.nudDuration.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.nudDuration.Location = New System.Drawing.Point(115, 21)
        Me.nudDuration.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.nudDuration.Name = "nudDuration"
        Me.nudDuration.Size = New System.Drawing.Size(62, 20)
        Me.nudDuration.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(5, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.Text = "Month"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(69, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 17)
        Me.Label2.Text = "Duration unavailable"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(183, 20)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(27, 23)
        Me.btnAdd.TabIndex = 9
        Me.btnAdd.Text = "+"
        '
        'MultiMonthAndCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoScrollMargin = New System.Drawing.Size(1, 1)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudDuration)
        Me.Controls.Add(Me.cboDurationType)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.lvItems)
        Me.Name = "MultiMonthAndCheck"
        Me.Size = New System.Drawing.Size(214, 204)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvItems As System.Windows.Forms.ListView
    Friend WithEvents colMonth As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColDuration As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDurationType As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdx As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboDurationType As System.Windows.Forms.ComboBox
    Friend WithEvents nudDuration As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents contextListMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuRemove As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClear As System.Windows.Forms.MenuItem

End Class
