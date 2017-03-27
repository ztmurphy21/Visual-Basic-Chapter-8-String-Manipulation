﻿' Name:         Net Pay Project
' Purpose:      Display the net pay with a dollar sign, two decimal places, and asterisks
' Programmer:   Zach Murphy on 3-27-2017

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtNetPay_Enter(sender As Object, e As EventArgs) Handles txtNetPay.Enter
        txtNetPay.SelectAll()
    End Sub

    Private Sub txtNetPay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNetPay.KeyPress
        ' accept only numbers, the period, and the Backspace

        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> "." AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNetPay_TextChanged(sender As Object, e As EventArgs) Handles txtNetPay.TextChanged
        lblFormatted.Text = String.Empty
    End Sub

    Private Sub btnFormat_Click(sender As Object, e As EventArgs) Handles btnFormat.Click
        ' format the net pay with two decimal places, then 
        ' pad with asterisks and insert a dollar sign as the 
        ' first character

        Dim decNet As Decimal
        Dim strFormatted As String

        Decimal.TryParse(txtNetPay.Text, decNet)
        ' format the net pay with two decimal places
        strFormatted = decNet.ToString("n2")
        ' pad the net pay with asterisks until its length is 10
        strFormatted = strFormatted.PadLeft(10, "*"c)
        ' insert a dollar sign as the first character
        strFormatted = strFormatted.Insert(0, "$")
        ' display the net pay, then set the focus
        lblFormatted.Text = strFormatted
        txtNetPay.Focus()
    End Sub
End Class
