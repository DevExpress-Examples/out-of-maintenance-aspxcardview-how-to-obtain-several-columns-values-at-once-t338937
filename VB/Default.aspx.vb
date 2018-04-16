Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        GetSelectedValues()
        PrintSelectedValues()
    End Sub
    Private selectedValues As List(Of Object)

    Private Sub GetSelectedValues()
        Dim fieldNames As New List(Of String)()
        For Each column As CardViewColumn In ASPxCardView1.Columns
            If TypeOf column Is CardViewColumn Then
                fieldNames.Add(CType(column, CardViewColumn).FieldName)
            End If
        Next column
        selectedValues = ASPxCardView1.GetSelectedFieldValues(fieldNames.ToArray())
    End Sub

    Private Sub PrintSelectedValues()
        If selectedValues Is Nothing Then
            Return
        End If
        Dim result As String = ""
        For Each item As Object() In selectedValues
            For Each value As Object In item
                result &= String.Format("{0}    ", value)
            Next value
            result &= "</br>"
        Next item
        Literal1.Text = result
    End Sub
End Class