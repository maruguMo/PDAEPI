<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SelectAction
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
        Me.lblNewResult = New System.Windows.Forms.LinkLabel
        Me.lblResultsList = New System.Windows.Forms.LinkLabel
        Me.lblQuestionnaireList = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblNewResult
        '
        Me.lblNewResult.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Underline)
        Me.lblNewResult.Location = New System.Drawing.Point(13, 28)
        Me.lblNewResult.Name = "lblNewResult"
        Me.lblNewResult.Size = New System.Drawing.Size(127, 25)
        Me.lblNewResult.TabIndex = 0
        Me.lblNewResult.Text = "Fill new result"
        '
        'lblResultsList
        '
        Me.lblResultsList.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Underline)
        Me.lblResultsList.Location = New System.Drawing.Point(13, 65)
        Me.lblResultsList.Name = "lblResultsList"
        Me.lblResultsList.Size = New System.Drawing.Size(127, 25)
        Me.lblResultsList.TabIndex = 1
        Me.lblResultsList.Text = "Results list"
        '
        'lblQuestionnaireList
        '
        Me.lblQuestionnaireList.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Underline)
        Me.lblQuestionnaireList.Location = New System.Drawing.Point(13, 102)
        Me.lblQuestionnaireList.Name = "lblQuestionnaireList"
        Me.lblQuestionnaireList.Size = New System.Drawing.Size(127, 25)
        Me.lblQuestionnaireList.TabIndex = 2
        Me.lblQuestionnaireList.Text = "Questionnaire list"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 24)
        Me.Label1.Text = "What would you like to do?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SelectAction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblQuestionnaireList)
        Me.Controls.Add(Me.lblResultsList)
        Me.Controls.Add(Me.lblNewResult)
        Me.Name = "SelectAction"
        Me.Size = New System.Drawing.Size(211, 132)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblNewResult As System.Windows.Forms.LinkLabel
    Friend WithEvents lblResultsList As System.Windows.Forms.LinkLabel
    Friend WithEvents lblQuestionnaireList As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
