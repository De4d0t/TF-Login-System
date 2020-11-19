Imports System.Net
Imports System.Threading
Public Class Form1
    'Coded : @de4dot 
    'instagram : @de4dot 

    'Dont forget send /start to bot!

    Dim Code As String = Gen_Random_Code(10)
    Dim Expaire_OFF As Boolean

    Dim Bot_Token As String = "Your_Bot_Token" 'Get it from @Botfather in telegram
    Dim Telegram_User_ID As String = "Your_Telegram_ID" 'Get it from @myidbot in telegram
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Code = Gen_Random_Code(5)
        Task.Factory.StartNew(Sub() Send_Code_To_Telegram(Code))
        Task.Factory.StartNew(Sub() Code_Expaire())
    End Sub
    Function Gen_Random_Code(Length As Integer) As String
        Dim str As String = Nothing
        Dim rnd As New Random
        For i As Integer = 0 To Length - 1
            Dim chrInt As Integer = 0
            Do
                chrInt = rnd.Next(30, 122)
                If (chrInt >= 48 And chrInt <= 57) Then
                    Exit Do
                End If
            Loop
            str &= Chr(chrInt)
        Next
        Return str
    End Function
    Sub Send_Code_To_Telegram(code As String)
        Try
            ServicePointManager.SecurityProtocol = 3072
            Dim webClient As New WebClient
            Dim result As String = webClient.DownloadString("https://api.telegram.org/bot" & Bot_Token & "/sendMessage?chat_id=" & Telegram_User_ID & "&text=Code : " & code)
        Catch ex As Exception
            MsgBox(ex.Message,, "Login System - @de4dot")
        End Try
    End Sub
    Sub Code_Expaire()
        For i As Integer = 0 To 60
            Thread.Sleep(1000)
            Invoke(Sub() Label1.Text += 1)
            If Expaire_OFF = True Then Exit Sub
        Next
        Invoke(Sub() Label1.Text = 0)
        Code = Gen_Random_Code(15)
        MsgBox("Code Expaire",, "Login System - @de4dot")
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = Code Then
            Expaire_OFF = True
            MsgBox("Login Done",, "Login System - @de4dot")
        Else
            MsgBox("Login Failed", , "Login System - @de4dot")
        End If
    End Sub
End Class
