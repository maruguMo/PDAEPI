<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class EditGrid
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
        Me.DGTable = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.SuspendLayout()
        '
        'DGTable
        '
        Me.DGTable.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGTable.Location = New System.Drawing.Point(0, 0)
        Me.DGTable.Name = "DGTable"
        Me.DGTable.Size = New System.Drawing.Size(217, 170)
        Me.DGTable.TabIndex = 0
        Me.DGTable.TableStyles.Add(Me.DataGridTableStyle1)
        '
        'EditGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.DGTable)
        Me.Name = "EditGrid"
        Me.Size = New System.Drawing.Size(217, 170)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGTable As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle

End Class
