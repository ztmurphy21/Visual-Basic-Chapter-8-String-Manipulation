﻿' Name:         City State Project
' Purpose:      Displays the index of the comma in a string
' Programmer:   Zach Murphy

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtCityState_Enter(sender As Object, e As EventArgs) Handles txtCityState.Enter
        txtCityState.SelectAll()
    End Sub

    Private Sub txtCityState_TextChanged(sender As Object, e As EventArgs) Handles txtCityState.TextChanged
        lblCommaIndex.Text = String.Empty
    End Sub

    Private Sub btnLocate_Click(sender As Object, e As EventArgs) Handles btnLocate.Click
        ' displays the index of the comma in a string

        Dim strCityState As String
        Dim intCommaIndex As Integer

        strCityState = txtCityState.Text
        ' determine the comma's index
        intCommaIndex = strCityState.IndexOf(",")
        lblCommaIndex.Text = intCommaIndex.ToString
        txtCityState.Focus()
    End Sub

End Class
