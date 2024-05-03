Imports System.Collections
Public Class MultiSelectSingleFieldCFactory
    Inherits System.Collections.CollectionBase
    Private ReadOnly Host As System.Windows.Forms.UserControl
    Private mFieldName As String
    Public Property FieldName() As String
        Get
            Return mFieldName
        End Get
        Set(ByVal value As String)
            mFieldName = value
        End Set
    End Property

    Public Function AddCheckBox(ByVal CodedValue As String, ByVal ControlText As String) As System.Windows.Forms.CheckBox
        ' Create a new instance of the Button class.

        Dim aCheckBox As New System.Windows.Forms.CheckBox
        ' Add the button to the collection's internal list.
        Me.List.Add(aCheckBox)
        ' Add the button to the controls collection of the form 
        ' referenced by the HostForm field.
        Host.Controls.Add(aCheckBox)
        ' Set intial properties for the button object.
        aCheckBox.Top = Count * 25
        aCheckBox.Left = 10
        aCheckBox.Tag = CodedValue
        aCheckBox.Text = ControlText
        aCheckBox.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
        Return aCheckBox
    End Function
    Public Sub New(ByVal ahost As System.Windows.Forms.UserControl)
        Host = ahost
    End Sub
    Public Sub CreateControls(ByVal FieldResponses As List(Of SurveyFieldBase.FieldResponses))
        Dim aFieldResponse As SurveyFieldBase.FieldResponses
        Try
            If Host.Controls IsNot Nothing Then
                Host.Controls.Clear()
            End If
        Catch e As Exception

        End Try
        If Me.Count > 0 Then
            Me.Clear()
        End If
        For Each aFieldResponse In FieldResponses
            AddCheckBox(aFieldResponse.CodedValue, aFieldResponse.ResponseText)
        Next
    End Sub
    Default Public Overridable ReadOnly Property Item(ByVal Index As Integer) As  _
   System.Windows.Forms.Control
        Get
            Return CType(Me.List.Item(Index), System.Windows.Forms.CheckBox)
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
End Class
