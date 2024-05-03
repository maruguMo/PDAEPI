<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MultiSelectMultiFields
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
        Me.lblSpecify = New System.Windows.Forms.Label
        Me.txtNumber = New System.Windows.Forms.TextBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblFieldCaption = New System.Windows.Forms.Label
        Me.cboSelection = New System.Windows.Forms.ComboBox
        Me.lvItems = New System.Windows.Forms.ListView
        Me.colSelection = New System.Windows.Forms.ColumnHeader
        Me.colNumberTrained = New System.Windows.Forms.ColumnHeader
        Me.colIdx = New System.Windows.Forms.ColumnHeader
        Me.contextListMenu = New System.Windows.Forms.ContextMenu
        Me.mnuRemove = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuClear = New System.Windows.Forms.MenuItem
        Me.lblTrainingType = New System.Windows.Forms.Label
        Me.txtTrainingType = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lblSpecify
        '
        Me.lblSpecify.BackColor = System.Drawing.Color.Gainsboro
        Me.lblSpecify.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblSpecify.Location = New System.Drawing.Point(6, 57)
        Me.lblSpecify.Name = "lblSpecify"
        Me.lblSpecify.Size = New System.Drawing.Size(57, 20)
        Me.lblSpecify.Text = "Number"
        '
        'txtNumber
        '
        Me.txtNumber.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular)
        Me.txtNumber.Location = New System.Drawing.Point(70, 57)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(117, 21)
        Me.txtNumber.TabIndex = 28
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(193, 57)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(27, 21)
        Me.btnAdd.TabIndex = 27
        Me.btnAdd.Text = " +"
        '
        'lblFieldCaption
        '
        Me.lblFieldCaption.BackColor = System.Drawing.Color.Gainsboro
        Me.lblFieldCaption.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblFieldCaption.Location = New System.Drawing.Point(6, 3)
        Me.lblFieldCaption.Name = "lblFieldCaption"
        Me.lblFieldCaption.Size = New System.Drawing.Size(58, 22)
        Me.lblFieldCaption.Text = "Select"
        '
        'cboSelection
        '
        Me.cboSelection.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular)
        Me.cboSelection.Location = New System.Drawing.Point(70, 3)
        Me.cboSelection.Name = "cboSelection"
        Me.cboSelection.Size = New System.Drawing.Size(150, 22)
        Me.cboSelection.TabIndex = 24
        '
        'lvItems
        '
        Me.lvItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvItems.Columns.Add(Me.colSelection)
        Me.lvItems.Columns.Add(Me.colNumberTrained)
        Me.lvItems.Columns.Add(Me.colIdx)
        Me.lvItems.ContextMenu = Me.contextListMenu
        Me.lvItems.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lvItems.FullRowSelect = True
        Me.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvItems.Location = New System.Drawing.Point(4, 84)
        Me.lvItems.Name = "lvItems"
        Me.lvItems.Size = New System.Drawing.Size(222, 97)
        Me.lvItems.TabIndex = 23
        Me.lvItems.View = System.Windows.Forms.View.Details
        '
        'colSelection
        '
        Me.colSelection.Text = "Selection"
        Me.colSelection.Width = 167
        '
        'colNumberTrained
        '
        Me.colNumberTrained.Text = "Number"
        Me.colNumberTrained.Width = 54
        '
        'colIdx
        '
        Me.colIdx.Text = "Index"
        Me.colIdx.Width = 41
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
        'lblTrainingType
        '
        Me.lblTrainingType.BackColor = System.Drawing.Color.Gainsboro
        Me.lblTrainingType.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblTrainingType.Location = New System.Drawing.Point(5, 29)
        Me.lblTrainingType.Name = "lblTrainingType"
        Me.lblTrainingType.Size = New System.Drawing.Size(59, 20)
        Me.lblTrainingType.Text = "Type"
        Me.lblTrainingType.Visible = False
        '
        'txtTrainingType
        '
        Me.txtTrainingType.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular)
        Me.txtTrainingType.Location = New System.Drawing.Point(69, 29)
        Me.txtTrainingType.Name = "txtTrainingType"
        Me.txtTrainingType.Size = New System.Drawing.Size(151, 21)
        Me.txtTrainingType.TabIndex = 31
        Me.txtTrainingType.Visible = False
        '
        'MultiSelectMultiFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.lblTrainingType)
        Me.Controls.Add(Me.txtTrainingType)
        Me.Controls.Add(Me.lblSpecify)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblFieldCaption)
        Me.Controls.Add(Me.cboSelection)
        Me.Controls.Add(Me.lvItems)
        Me.Name = "MultiSelectMultiFields"
        Me.Size = New System.Drawing.Size(231, 184)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSpecify As System.Windows.Forms.Label
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblFieldCaption As System.Windows.Forms.Label
    Friend WithEvents cboSelection As System.Windows.Forms.ComboBox
    Friend WithEvents lvItems As System.Windows.Forms.ListView
    Friend WithEvents colSelection As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdx As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNumberTrained As System.Windows.Forms.ColumnHeader
    Friend WithEvents contextListMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuRemove As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClear As System.Windows.Forms.MenuItem
    Friend WithEvents lblTrainingType As System.Windows.Forms.Label
    Friend WithEvents txtTrainingType As System.Windows.Forms.TextBox

End Class
