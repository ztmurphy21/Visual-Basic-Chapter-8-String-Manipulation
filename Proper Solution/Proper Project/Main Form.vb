' Name:         Proper Project
' Purpose:      Displays the name using proper case
' Programmer:   Zach Murphy on 3-27-2017

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnProper_Click(sender As Object, e As EventArgs) Handles btnProper.Click
        'variables
        Dim inputName As String
        Dim outputName As String


        inputName = txtName.Text

        'conver to proper case
        outputName = StrConv(inputName, VbStrConv.ProperCase)

        'output
        lblName.Text = outputName

    End Sub

    Private Sub txtName_Enter(sender As Object, e As EventArgs) Handles txtName.Enter
        txtName.SelectAll()
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        lblName.Text = String.Empty
    End Sub



End Class
