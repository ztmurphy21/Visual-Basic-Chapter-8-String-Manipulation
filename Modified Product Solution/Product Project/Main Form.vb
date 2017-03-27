﻿' Name:         Product Project
' Purpose:      Displays the product IDs entered by the user
' Programmer:   Zach Murphy on 3-27-2017
Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtId_Enter(sender As Object, e As EventArgs) Handles txtId.Enter
        txtId.SelectAll()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' adds a product ID to a list

        Dim strId As String

        ' remove any leading and trailing spaces
        ' and then convert to uppercase
        strId = txtId.Text.Trim.ToUpper
        ' verify that the ID contains 3 letters followed by 2 numbers 
        If strId Like "[A-Z][A-Z][A-Z]##" Then
            lstId.Items.Add(strId)
        Else
            MessageBox.Show("Invalid product ID",
                            "Product ID", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If
        txtId.Focus()
    End Sub

End Class
