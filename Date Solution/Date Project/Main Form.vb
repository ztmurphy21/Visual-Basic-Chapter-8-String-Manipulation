' Name:         Date Project
' Purpose:      Verifies a date's format and changes the year number 
'               from "yy" to "20yy"
' Programmer:   Zach Murphy on 3-27-2017
Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Dim num As Integer
        Dim dateNumbers As String
        Dim finalDate As String
        Dim dateArray() As String

        Integer.TryParse(txtDate.Text, num)
        dateNumbers = num.ToString
        If dateNumbers Like "##[/]##[/]##" Then
            dateArray = Split(dateNumbers, "/")
            finalDate = dateArray(0) & "/" + dateArray(1) & "/20" & dateArray(2)
            lblDate.Text = finalDate
        End If



    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtDate_Enter(sender As Object, e As EventArgs) Handles txtDate.Enter
        txtDate.SelectAll()
    End Sub

    Private Sub txtDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDate.KeyPress



        ' allows only numbers, the slash, and the Backspace key


        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> "/" AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub
End Class

