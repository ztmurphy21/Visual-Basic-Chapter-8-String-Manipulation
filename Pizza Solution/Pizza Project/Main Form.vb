' Name:         Pizza Project
' Purpose:      A game that allows the user to guess a
'               word letter-by-letter
' Programmer:   Zach Murphy on 3-27-2017

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain

    Private strWord As String
    Private intIncorrect As Integer

    Private Sub AssignImage()
        ' assign appropriate image

        Select Case intIncorrect
            Case 1
                picPizzaStatus.Image = pic6Slices.Image
            Case 2
                picPizzaStatus.Image = pic5Slices.Image
            Case 3
                picPizzaStatus.Image = pic4Slices.Image
            Case 4
                picPizzaStatus.Image = pic3Slices.Image
            Case 5
                picPizzaStatus.Image = pic2Slices.Image
            Case 6
                picPizzaStatus.Image = pic1Slice.Image
            Case Else
                picPizzaStatus.Image = picTray.Image
        End Select
    End Sub

    Private Sub DetermineGameOver(ByVal blnADashWasReplaced As Boolean)
        ' determine whether the game is over and
        ' take the appropriate action

        If blnADashWasReplaced Then
            ' if the word does not contain any dashes, the game
            ' is over because player 2 guessed the word
            If lblWord.Text.Contains("-") = False Then
                MessageBox.Show("Great guessing!", "Game Over",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                btnCheck.Enabled = False
            End If
        Else
            ' if 7 incorrect guesses, the game is over
            If intIncorrect = 7 Then
                MessageBox.Show("Sorry, the word is " &
                                strWord & ".", "Game Over",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                btnCheck.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        ' check if the letter appears in the word

        Dim strLetter As String
        Dim blnDashReplaced As Boolean

        strLetter = txtLetter.Text

        ' look at each letter in the word
        For intIndex As Integer = 0 To 5
            If strWord.Substring(intIndex, 1) = strLetter Then
                'if the letter appears in the word replace
                'the corresponding dash with the letter
                lblWord.Text = lblWord.Text.Remove(intIndex, 1)
                lblWord.Text = lblWord.Text.Insert(intIndex, strLetter)
                blnDashReplaced = True
            End If
        Next intIndex

        If blnDashReplaced Then
            Call DetermineGameOver(blnDashReplaced)
        Else  ' no dash was replaced
            lblIncorrect.Text =
                lblIncorrect.Text & " " & strLetter
            intIncorrect += 1
            Call AssignImage()
            Call DetermineGameOver(blnDashReplaced)
        End If

        ' clear text box and set focus
        txtLetter.Text = String.Empty
        txtLetter.Focus()
    End Sub

    Private Sub txtLetter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLetter.KeyPress
        ' allows only letters and the Backspace key
        If e.KeyChar Like "[!A-Za-z]" AndAlso
            e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If


    End Sub

    Private Sub EitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        'close program
        Me.Close()
    End Sub

    Private Sub mnuFileNew_Click(sender As Object, e As EventArgs) Handles mnuFileNew.Click
        'start new game

        lblWord.Text = String.Empty
        lblIncorrect.Text = String.Empty
        txtLetter.Text = String.Empty

        intIncorrect = 0

        'get a 6-letter word from player 1
        'trim and convert to uppercase
        strWord = InputBox("Enter a 6-letter word:", "Pizza Game").Trim.ToUpper

        'determine whether the word contains 6 letters
        If strWord Like "[A-Z][A-Z][A-Z][A-Z][A-Z][A-Z]" Then
            'display the full pizzaimage
            picPizzaStatus.Image = picFullPizza.Image
            'display 6 dashes
            lblWord.Text = "------"
            'enable and set the focus
            btnCheck.Enabled = True
            txtLetter.Focus()

        Else
            MessageBox.Show("6 letters are required", "Pizza Game", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnCheck.Enabled = False
        End If
    End Sub
End Class
