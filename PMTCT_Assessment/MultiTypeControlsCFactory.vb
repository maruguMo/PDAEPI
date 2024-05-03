Public Class MultiTypeControlsCFactory
    Inherits System.Collections.CollectionBase
    Private ReadOnly Host As System.Windows.Forms.UserControl
    Private mFields As List(Of SurveyFieldBase)
    Public Property Fields() As List(Of SurveyFieldBase)
        Get
            Return mFields
        End Get
        Set(ByVal value As List(Of SurveyFieldBase))
            mFields = value
        End Set
    End Property
    Public Function AddTextBox(ByVal Caption As String, ByVal FieldName As String) As Windows.Forms.TextBox
        Dim aLabel As Windows.Forms.Label
        Dim aTextBox As Windows.Forms.TextBox

        aLabel = New Windows.Forms.Label()
        aTextBox = New Windows.Forms.TextBox()

        Me.List.Add(aLabel)
        Host.Controls.Add(aLabel)
        aLabel.Top = Count * 25
        aLabel.Left = 10
        aLabel.Text = Caption
        aLabel.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom

        Me.List.Add(aTextBox)
        Host.Controls.Add(aTextBox)
        aTextBox.Top = Count * 25
        aTextBox.Left = 10
        aTextBox.Tag = FieldName
        aTextBox.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
        Return aTextBox
    End Function
    Public Function AddDateTimePicker(ByVal Caption As String, ByVal FieldName As String, Optional ByVal MinDate As DateTime = Nothing, Optional ByVal MaxDate As DateTime = Nothing, Optional ByVal DateValue As DateTime = Nothing) As Windows.Forms.DateTimePicker
        Dim aLabel As Windows.Forms.Label
        Dim aDatePicker As Windows.Forms.DateTimePicker
        aLabel = New Windows.Forms.Label()
        aDatePicker = New Windows.Forms.DateTimePicker()

        Me.List.Add(aLabel)
        Host.Controls.Add(aLabel)
        aLabel.Top = Count * 25
        aLabel.Left = 10
        aLabel.Text = Caption
        aLabel.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom

        Me.List.Add(aDatePicker)
        Host.Controls.Add(aDatePicker)
        aDatePicker.Top = Count * 25
        aDatePicker.Left = 10
        aDatePicker.Tag = FieldName
        aDatePicker.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
        Try
            If MinDate <> Nothing Then
                aDatePicker.MinDate = MinDate
            End If
        Catch e As Exception

        End Try
        Try
            If MaxDate <> Nothing Then
                aDatePicker.MinDate = MaxDate
            End If
        Catch e As Exception

        End Try
        Try
            If DateValue <> Nothing Then
                aDatePicker.Value = DateValue
            End If
        Catch e As Exception

        End Try
        Return aDatePicker
    End Function
    Public Function AddComboBox(ByVal Caption As String, ByVal FieldName As String, ByVal FieldResponses As List(Of SurveyFieldBase.FieldResponses)) As Windows.Forms.ComboBox
        Dim aLabel As Windows.Forms.Label
        Dim aComboBox As Windows.Forms.ComboBox
        aLabel = New Windows.Forms.Label()
        aComboBox = New Windows.Forms.ComboBox()

        Me.List.Add(aLabel)
        Host.Controls.Add(aLabel)
        aLabel.Top = Count * 25
        aLabel.Left = 10
        aLabel.Text = Caption
        aLabel.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom

        Me.List.Add(aComboBox)
        Host.Controls.Add(aComboBox)
        aComboBox.Top = Count * 25
        aComboBox.Left = 10
        aComboBox.Tag = FieldName
        aComboBox.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
        'attempt to add responses
        Dim aFieldResponse As SurveyFieldBase.FieldResponses
        If FieldResponses IsNot Nothing Then
            For Each aFieldResponse In FieldResponses
                aComboBox.Items.Add(aFieldResponse)
            Next
        End If
        Return aComboBox
    End Function
    Public Function AddCheckBox(ByVal FieldName As String, ByVal ControlText As String) As Windows.Forms.CheckBox
        Dim aCheckBox As New System.Windows.Forms.CheckBox
        ' Add the button to the collection's internal list.
        Me.List.Add(aCheckBox)
        ' Add the button to the controls collection of the form 
        ' referenced by the HostForm field.
        Host.Controls.Add(aCheckBox)
        ' Set intial properties for the button object.
        aCheckBox.Top = Count * 25
        aCheckBox.Left = 10
        aCheckBox.Tag = FieldName
        aCheckBox.Text = ControlText
        aCheckBox.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
        Return aCheckBox
    End Function
    Public Sub New(ByVal ahost As System.Windows.Forms.UserControl)
        Host = ahost
    End Sub
    Default Public Overridable ReadOnly Property Item(ByVal Index As Integer) As  _
   System.Windows.Forms.Control
        Get
            Return Me.List.Item(Index)
        End Get
    End Property
    Public Sub Remove()
        ' Check to be sure there is a button to remove.
        If Me.Count > 0 Then
            ' Remove the last button added to the array from the host form 
            ' controls collection. Note the use of the default property in 
            ' accessing the array.
            Host.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
    Public Sub ClearControls()
        Me.List.Clear()
        Host.Controls.Clear()
    End Sub
End Class
