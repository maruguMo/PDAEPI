<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInterfaceEng
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
        Me.mnuBack = New System.Windows.Forms.MenuItem
        Me.mnuNext = New System.Windows.Forms.MenuItem
        Me.lblSection = New System.Windows.Forms.Label
        Me.lblSubsection = New System.Windows.Forms.Label
        Me.SectionInstructionNotify = New Microsoft.WindowsCE.Forms.Notification
        Me.cmdSectionInstructions = New System.Windows.Forms.Button
        Me.cmdQuestionInstructions = New System.Windows.Forms.Button
        Me.pnlControls = New System.Windows.Forms.Panel
        Me.editGrid = New PDAEPI.EditGrid
        Me.lblOtherSpecify = New System.Windows.Forms.Label
        Me.txtOther = New System.Windows.Forms.TextBox
        Me.cmdRangeDisplay = New System.Windows.Forms.Button
        Me.cboOptions = New System.Windows.Forms.ComboBox
        Me.txtNumber = New System.Windows.Forms.TextBox
        Me.MultiSelectMultiFields = New PDAEPI.MultiSelectMultiFields
        Me.txtTextEntry = New System.Windows.Forms.TextBox
        Me.MultiMonthSelect = New PDAEPI.MultiMonthAndCheck
        Me.studyProvincesAndSites = New PDAEPI.StudyAreaCtrl
        Me.MultiFields = New PDAEPI.MultiTypeControls
        Me.MultiSelectSingleField = New PDAEPI.MultiSelectSingleField
        Me.selectAction = New PDAEPI.SelectAction
        Me.DeviceStatus = New PDAEPI.DeviceStatus
        Me.dtDatePicker = New System.Windows.Forms.DateTimePicker
        Me.txtQuestion = New System.Windows.Forms.TextBox
        Me.pnlControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.Add(Me.mnuBack)
        Me.mnuMain.MenuItems.Add(Me.mnuNext)
        '
        'mnuBack
        '
        Me.mnuBack.Text = "Back"
        '
        'mnuNext
        '
        Me.mnuNext.Text = "Next"
        '
        'lblSection
        '
        Me.lblSection.BackColor = System.Drawing.Color.SkyBlue
        Me.lblSection.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSection.ForeColor = System.Drawing.Color.White
        Me.lblSection.Location = New System.Drawing.Point(0, 0)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(240, 17)
        Me.lblSection.Text = "A. SECTION"
        '
        'lblSubsection
        '
        Me.lblSubsection.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblSubsection.Location = New System.Drawing.Point(1, 19)
        Me.lblSubsection.Name = "lblSubsection"
        Me.lblSubsection.Size = New System.Drawing.Size(239, 31)
        Me.lblSubsection.Text = "Sub section"
        Me.lblSubsection.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SectionInstructionNotify
        '
        Me.SectionInstructionNotify.Caption = "Section Instruction"
        Me.SectionInstructionNotify.Text = "Section Instructions"
        '
        'cmdSectionInstructions
        '
        Me.cmdSectionInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.cmdSectionInstructions.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.cmdSectionInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.cmdSectionInstructions.Location = New System.Drawing.Point(219, 1)
        Me.cmdSectionInstructions.Name = "cmdSectionInstructions"
        Me.cmdSectionInstructions.Size = New System.Drawing.Size(21, 16)
        Me.cmdSectionInstructions.TabIndex = 7
        Me.cmdSectionInstructions.Text = " ?"
        Me.cmdSectionInstructions.Visible = False
        '
        'cmdQuestionInstructions
        '
        Me.cmdQuestionInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.cmdQuestionInstructions.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.cmdQuestionInstructions.ForeColor = System.Drawing.Color.Blue
        Me.cmdQuestionInstructions.Location = New System.Drawing.Point(3, 53)
        Me.cmdQuestionInstructions.Name = "cmdQuestionInstructions"
        Me.cmdQuestionInstructions.Size = New System.Drawing.Size(16, 14)
        Me.cmdQuestionInstructions.TabIndex = 8
        Me.cmdQuestionInstructions.Text = "?"
        Me.cmdQuestionInstructions.Visible = False
        '
        'pnlControls
        '
        Me.pnlControls.Controls.Add(Me.editGrid)
        Me.pnlControls.Controls.Add(Me.lblOtherSpecify)
        Me.pnlControls.Controls.Add(Me.txtOther)
        Me.pnlControls.Controls.Add(Me.cmdRangeDisplay)
        Me.pnlControls.Controls.Add(Me.cboOptions)
        Me.pnlControls.Controls.Add(Me.txtNumber)
        Me.pnlControls.Controls.Add(Me.MultiSelectMultiFields)
        Me.pnlControls.Controls.Add(Me.txtTextEntry)
        Me.pnlControls.Controls.Add(Me.MultiMonthSelect)
        Me.pnlControls.Controls.Add(Me.studyProvincesAndSites)
        Me.pnlControls.Controls.Add(Me.MultiFields)
        Me.pnlControls.Controls.Add(Me.MultiSelectSingleField)
        Me.pnlControls.Controls.Add(Me.selectAction)
        Me.pnlControls.Controls.Add(Me.DeviceStatus)
        Me.pnlControls.Controls.Add(Me.dtDatePicker)
        Me.pnlControls.Location = New System.Drawing.Point(-2, 119)
        Me.pnlControls.Name = "pnlControls"
        Me.pnlControls.Size = New System.Drawing.Size(238, 146)
        '
        'editGrid
        '
        Me.editGrid.Location = New System.Drawing.Point(0, 0)
        Me.editGrid.Name = "editGrid"
        Me.editGrid.Size = New System.Drawing.Size(242, 146)
        Me.editGrid.TabIndex = 33
        '
        'lblOtherSpecify
        '
        Me.lblOtherSpecify.Location = New System.Drawing.Point(4, 27)
        Me.lblOtherSpecify.Name = "lblOtherSpecify"
        Me.lblOtherSpecify.Size = New System.Drawing.Size(203, 22)
        Me.lblOtherSpecify.Text = "Other specify"
        Me.lblOtherSpecify.Visible = False
        '
        'txtOther
        '
        Me.txtOther.Location = New System.Drawing.Point(4, 52)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(205, 21)
        Me.txtOther.TabIndex = 32
        Me.txtOther.Visible = False
        '
        'cmdRangeDisplay
        '
        Me.cmdRangeDisplay.BackColor = System.Drawing.SystemColors.Info
        Me.cmdRangeDisplay.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.cmdRangeDisplay.ForeColor = System.Drawing.Color.Blue
        Me.cmdRangeDisplay.Location = New System.Drawing.Point(212, 1)
        Me.cmdRangeDisplay.Name = "cmdRangeDisplay"
        Me.cmdRangeDisplay.Size = New System.Drawing.Size(22, 20)
        Me.cmdRangeDisplay.TabIndex = 29
        Me.cmdRangeDisplay.Text = " ?"
        Me.cmdRangeDisplay.Visible = False
        '
        'cboOptions
        '
        Me.cboOptions.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.cboOptions.Location = New System.Drawing.Point(5, 3)
        Me.cboOptions.Name = "cboOptions"
        Me.cboOptions.Size = New System.Drawing.Size(203, 20)
        Me.cboOptions.TabIndex = 19
        Me.cboOptions.Visible = False
        '
        'txtNumber
        '
        Me.txtNumber.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtNumber.Location = New System.Drawing.Point(4, 2)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(204, 19)
        Me.txtNumber.TabIndex = 25
        '
        'MultiSelectMultiFields
        '
        Me.MultiSelectMultiFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.MultiSelectMultiFields.Location = New System.Drawing.Point(3, 1)
        Me.MultiSelectMultiFields.Name = "MultiSelectMultiFields"
        Me.MultiSelectMultiFields.Size = New System.Drawing.Size(233, 141)
        Me.MultiSelectMultiFields.TabIndex = 28
        '
        'txtTextEntry
        '
        Me.txtTextEntry.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtTextEntry.Location = New System.Drawing.Point(5, 3)
        Me.txtTextEntry.MaxLength = 1000
        Me.txtTextEntry.Multiline = True
        Me.txtTextEntry.Name = "txtTextEntry"
        Me.txtTextEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTextEntry.Size = New System.Drawing.Size(226, 83)
        Me.txtTextEntry.TabIndex = 21
        Me.txtTextEntry.Visible = False
        '
        'MultiMonthSelect
        '
        Me.MultiMonthSelect.AutoScroll = True
        Me.MultiMonthSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.MultiMonthSelect.Location = New System.Drawing.Point(2, 2)
        Me.MultiMonthSelect.Name = "MultiMonthSelect"
        Me.MultiMonthSelect.Size = New System.Drawing.Size(233, 140)
        Me.MultiMonthSelect.TabIndex = 26
        '
        'studyProvincesAndSites
        '
        Me.studyProvincesAndSites.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.studyProvincesAndSites.Location = New System.Drawing.Point(2, 1)
        Me.studyProvincesAndSites.Name = "studyProvincesAndSites"
        Me.studyProvincesAndSites.Size = New System.Drawing.Size(234, 141)
        Me.studyProvincesAndSites.TabIndex = 22
        Me.studyProvincesAndSites.Visible = False
        '
        'MultiFields
        '
        Me.MultiFields.AutoScroll = True
        Me.MultiFields.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.MultiFields.Location = New System.Drawing.Point(3, 2)
        Me.MultiFields.Name = "MultiFields"
        Me.MultiFields.Size = New System.Drawing.Size(231, 140)
        Me.MultiFields.TabIndex = 24
        '
        'MultiSelectSingleField
        '
        Me.MultiSelectSingleField.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.MultiSelectSingleField.Location = New System.Drawing.Point(4, 2)
        Me.MultiSelectSingleField.Name = "MultiSelectSingleField"
        Me.MultiSelectSingleField.Size = New System.Drawing.Size(231, 140)
        Me.MultiSelectSingleField.TabIndex = 27
        '
        'selectAction
        '
        Me.selectAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.selectAction.Location = New System.Drawing.Point(5, 3)
        Me.selectAction.Name = "selectAction"
        Me.selectAction.Size = New System.Drawing.Size(226, 139)
        Me.selectAction.TabIndex = 30
        '
        'DeviceStatus
        '
        Me.DeviceStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.DeviceStatus.Location = New System.Drawing.Point(4, 3)
        Me.DeviceStatus.Name = "DeviceStatus"
        Me.DeviceStatus.Size = New System.Drawing.Size(230, 140)
        Me.DeviceStatus.TabIndex = 31
        '
        'dtDatePicker
        '
        Me.dtDatePicker.CustomFormat = "dd/MMM/yyyy"
        Me.dtDatePicker.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular)
        Me.dtDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDatePicker.Location = New System.Drawing.Point(2, 2)
        Me.dtDatePicker.Name = "dtDatePicker"
        Me.dtDatePicker.Size = New System.Drawing.Size(207, 20)
        Me.dtDatePicker.TabIndex = 20
        Me.dtDatePicker.Visible = False
        '
        'txtQuestion
        '
        Me.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQuestion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.txtQuestion.ForeColor = System.Drawing.Color.Black
        Me.txtQuestion.Location = New System.Drawing.Point(1, 55)
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.ReadOnly = True
        Me.txtQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuestion.Size = New System.Drawing.Size(239, 62)
        Me.txtQuestion.TabIndex = 12
        Me.txtQuestion.Text = "Sample"
        Me.txtQuestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmInterfaceEng
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.cmdQuestionInstructions)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.pnlControls)
        Me.Controls.Add(Me.cmdSectionInstructions)
        Me.Controls.Add(Me.lblSubsection)
        Me.Controls.Add(Me.lblSection)
        Me.Menu = Me.mnuMain
        Me.Name = "frmInterfaceEng"
        Me.Text = "Questionnaire Title"
        Me.pnlControls.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mnuBack As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNext As System.Windows.Forms.MenuItem
    Friend WithEvents lblSection As System.Windows.Forms.Label
    Friend WithEvents lblSubsection As System.Windows.Forms.Label
    Friend WithEvents SectionInstructionNotify As Microsoft.WindowsCE.Forms.Notification
    Friend WithEvents cmdSectionInstructions As System.Windows.Forms.Button
    Friend WithEvents cmdQuestionInstructions As System.Windows.Forms.Button
    Friend WithEvents pnlControls As System.Windows.Forms.Panel
    Friend WithEvents MultiFields As PDAEPI.MultiTypeControls
    Friend WithEvents txtTextEntry As System.Windows.Forms.TextBox
    Friend WithEvents dtDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboOptions As System.Windows.Forms.ComboBox
    Friend WithEvents studyProvincesAndSites As PDAEPI.StudyAreaCtrl
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents MultiMonthSelect As PDAEPI.MultiMonthAndCheck
    Friend WithEvents txtQuestion As System.Windows.Forms.TextBox
    Friend WithEvents MultiSelectSingleField As PDAEPI.MultiSelectSingleField
    Friend WithEvents MultiSelectMultiFields As PDAEPI.MultiSelectMultiFields
    Friend WithEvents cmdRangeDisplay As System.Windows.Forms.Button
    Friend WithEvents selectAction As PDAEPI.SelectAction
    Friend WithEvents DeviceStatus As PDAEPI.DeviceStatus
    Friend WithEvents txtOther As System.Windows.Forms.TextBox
    Friend WithEvents lblOtherSpecify As System.Windows.Forms.Label
    Friend WithEvents editGrid As PDAEPI.EditGrid

End Class
