Imports System.Data.Odbc

Public Class LoginForm

    Dim Conn As OdbcConnection
    Dim cmd As OdbcCommand
    Dim Ds As DataSet
    Dim Da As OdbcDataAdapter
    Dim Rd As OdbcDataReader
    Dim MyDB As String
    Sub Koneksi()
        MyDB = "DSN=DSDbGudang;Driver={MySQL ODBC 3.51 Driver};Database=dbkuis;server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Koneksi()
    End Sub

    Private Sub login()
        Dim inputUsername As String = txtUsername.Text
        Dim inputPassword As String = txtPassword.Text

        Dim sql As String = $"SELECT password FROM user WHERE username LIKE '{inputUsername}'"
        cmd = New OdbcCommand(sql, Conn)
        Rd = cmd.ExecuteReader()

        If Rd.HasRows Then
            While Rd.Read()
                Dim pass As String = Rd("password").ToString()
                If (inputPassword = pass) Then
                    MsgBox("BERHASIL LOGIN")
                    Dim Dashboard = New DashboardForm(txtUsername.Text)
                    Dashboard.Show()
                    Me.Hide()
                    Form1.Hide()
                Else
                    MsgBox("Password Salah!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Pemberitahuan")
                End If

            End While
        Else
            MsgBox("Akun tidak ditemukan!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Pemberitahuan")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RegisterForm.Show()
        Me.Hide()
    End Sub
End Class