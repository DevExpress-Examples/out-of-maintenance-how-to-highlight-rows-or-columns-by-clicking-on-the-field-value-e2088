Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.XtraPivotGrid
Imports DevExpress.Web.ASPxPivotGrid
Imports System.Drawing
Imports DevExpress.Web.ASPxEditors

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		pivot.FieldValueTemplate = New FieldValueTemplate()
	End Sub

	Private SelectedValue As String
	Private SelectedArea As PivotArea

	Protected Sub OnASPxPivotGridCustomCallback(ByVal sender As Object, ByVal e As PivotGridCustomCallbackEventArgs)
		Dim args() As String = e.Parameters.Split("|"c)
		If "SL" = args(0) Then
			If Nothing Is Session("SelectedValue") Then
				Session.Add("SelectedValue", args(1))
			Else
				Session("SelectedValue") = args(1)
			End If
			If Nothing Is Session("SelectedArea") Then
				Session.Add("SelectedArea", System.Enum.Parse(GetType(PivotArea), args(2)))
			Else
				Session("SelectedArea") = System.Enum.Parse(GetType(PivotArea), args(2))
			End If
		End If
	End Sub

	Protected Sub OnASPxPivotGridCustomCellStyle(ByVal sender As Object, ByVal e As PivotCustomCellStyleEventArgs)
		If Nothing Is Session("SelectedValue") OrElse Nothing Is Session("SelectedArea") Then
			e.CellStyle.BackColor = Color.White
		Else
			Dim selectedValue As String = CStr(Session("SelectedValue"))
			Dim selectedArea As PivotArea = CType(Session("SelectedArea"), PivotArea)
			If PivotArea.ColumnArea = selectedArea Then
				If e.ColumnValueType = PivotGridValueType.GrandTotal Then
					If "Grand Total" = selectedValue Then
						e.CellStyle.BackColor = Color.AliceBlue
					Else
						e.CellStyle.BackColor = Color.White
					End If
				Else
					Dim selected As Boolean = False
					For Each field As PivotGridField In e.GetColumnFields()
						If e.GetFieldValue(field).ToString() = selectedValue Then
							selected = True
							Exit For
						End If
					Next field
					If selected Then
						e.CellStyle.BackColor = Color.AliceBlue
					Else
						e.CellStyle.BackColor = Color.White
					End If
				End If
			ElseIf PivotArea.RowArea = selectedArea Then
				If e.RowValueType = PivotGridValueType.GrandTotal Then
					If "Grand Total" = selectedValue Then
						e.CellStyle.BackColor = Color.AliceBlue
					Else
						e.CellStyle.BackColor = Color.White
					End If
				Else
					Dim selected As Boolean = False
					For Each field As PivotGridField In e.GetRowFields()
						If e.GetFieldValue(field).ToString() = selectedValue Then
							selected = True
							Exit For
						End If
					Next field
					If selected Then
						e.CellStyle.BackColor = Color.AliceBlue
					Else
						e.CellStyle.BackColor = Color.White
					End If
				End If
			Else
				e.CellStyle.BackColor = Color.White
			End If
		End If
	End Sub

	Public Class FieldValueTemplate
		Implements ITemplate
		#Region "ITemplate Members"

		Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
			Dim c As PivotGridFieldValueTemplateContainer = CType(container, PivotGridFieldValueTemplateContainer)
			Dim label As New ASPxLabel()
			label.Text = c.Text
			label.JSProperties.Add("cpArea", c.ValueItem.Area.ToString())
			Dim val As String
			If PivotGridValueType.GrandTotal = c.ValueItem.ValueType Then
				val = "Grand Total"
			Else
				val = c.Value.ToString()
			End If
			label.JSProperties.Add("cpValue", val)
			label.ClientSideEvents.Click = "function(s, e) { pivot.PerformCallback('SL|' + s.cpValue + '|' + s.cpArea); }"
			label.EnableViewState = False
			c.Controls.Add(label)
		End Sub

		#End Region
	End Class
End Class
