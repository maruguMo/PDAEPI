<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MultiSelectSingleField
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
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblFieldCaption = New System.Windows.Forms.Label
        Me.cboSelection = New System.Windows.Forms.ComboBox
        Me.lvItems = New System.Windows.Forms.ListView
        Me.colSelection = New System.Windows.Forms.ColumnHeader
        Me.colIdx = New System.Windows.Forms.ColumnHeader
        Me.contextListMenu = New System.Windows.Forms.ContextMenu
        Me.mnuRemove = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuClear = New System.Windows.Forms.MenuItem
        Me.txtOther = New System.Windows.Forms.TextBox
        Me.lblSpecify = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(198, 31)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(27, 21)
        Me.btnAdd.TabIndex = 17
        Me.btnAdd.Text = " +"
        '
        'lblFieldCaption
        '
        Me.lblFieldCaption.BackColor = System.Drawing.Color.Gainsboro
        Me.lblFieldCaption.Location = New System.Drawing.Point(5, 3)
        Me.lblFieldCaption.Name = "lblFieldCaption"
        Me.lblFieldCaption.Size = New System.Drawing.Size(58, 22)
        Me.lblFieldCaption.Text = "Select"
        '
        'cboSelection
        '
        Me.cboSelection.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.cboSelection.Location = New System.Drawing.Point(69, 3)
        Me.cboSelection.Name = "cboSelection"
        Me.cboSelection.Size = New System.Drawing.Size(156, 20)
        Me.cboSelection.TabIndex = 13
        '
        'lvItems
        '
        Me.lvItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvItems.Columns.Add(Me.colSelection)
        Me.lvItems.Columns.Add(Me.colIdx)
        Me.lvItems.ContextMenu = Me.contextListMenu
        Me.lvItems.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lvItems.FullRowSelect = True
        Me.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvItems.Location = New System.Drawing.Point(3, 58)
        Me.lvItems.Name = "lvItems"
        Me.lvItems.Size = New System.Drawing.Size(222, 123)
        Me.lvItems.TabIndex = 12
        Me.lvItems.View = System.Windows.Forms.View.Details
        '
        'colSelection
        '
        Me.colSelection.Text = "Selection"
        Me.colSelection.Width = 185
        '
        'colIdx
        '
        Me.colIdx.Text = "Index"
        Me.colIdx.Width = 34
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
        'txtOther
        '
        Me.txtOther.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtOther.Location = New System.Drawing.Point(69, 31)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(117, 19)
        Me.txtOther.TabIndex = 20
        Me.txtOther.Visible = False
        '
        'lblSpecify
        '
        Me.lblSpecify.BackColor = System.Drawing.Color.Gainsboro
        Me.lblSpecify.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblSpecify.Location = New System.Drawing.Point(5, 31)
        Me.lblSpecify.Name = "lblSpecify"
        Me.lblSpecify.Size = New System.Drawing.Size(57, 20)
        Me.lblSpecify.Text = "Specify"
        Me.lblSpecify.Visible = False
        '
        'MultiSelectSingleField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.lblSpecify)
        Me.Controls.Add(Me.txtOther)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblFieldCaption)
        Me.Controls.Add(Me.cboSelection)
        Me.Controls.Add(Me.lvItems)
        Me.Name = "MultiSelectSingleField"
        Me.Size = New System.Drawing.Size(231, 184)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblFieldCaption As System.Windows.Forms.Label
    Friend WithEvents cboSelection As System.Windows.Forms.ComboBox
    Friend WithEvents lvItems As System.Windows.Forms.ListView
    Friend WithEvents colSelection As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtOther As System.Windows.Forms.TextBox
    Friend WithEvents lblSpecify As System.Windows.Forms.Label
    Friend WithEvents colIdx As System.Windows.Forms.ColumnHeader
    Friend WithEvents contextListMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuRemove As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClear As System.Windows.Forms.MenuItem

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
