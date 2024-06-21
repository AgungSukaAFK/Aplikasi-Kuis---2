Imports System.Data.Odbc

Public Class DashboardForm

    Private username As String

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

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Koneksi()
        labelUsername.Text = username

        Dim sql As String = $"SELECT highest_score FROM user WHERE username LIKE '{username}'"
        cmd = New OdbcCommand(sql, Conn)
        Rd = cmd.ExecuteReader()

        While Rd.Read()
            Dim highest_score = Rd("highest_score").ToString()
            labelHS.Text = highest_score
        End While


        Dim DaHist As New OdbcDataAdapter($"SELECT * FROM history WHERE username = '{username}'", Conn)
        Dim DsHist As New DataSet
        DaHist.Fill(DsHist, "history")
        DataGridView1.DataSource = DsHist.Tables("history")

        ' Set default sorting untuk kolom "score" dari yang tertinggi ke terendah
        DataGridView1.Sort(DataGridView1.Columns("score"), System.ComponentModel.ListSortDirection.Descending)


    End Sub

    Public Sub New(receivedUserId As String)
        InitializeComponent()

        username = receivedUserId
    End Sub
    Private Sub DashboardForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim kuisForm = New KuisForm(username)
        kuisForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LeaderboardForm.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Report.Show()
    End Sub
End Class