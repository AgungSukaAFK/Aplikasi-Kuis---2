Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class LeaderboardForm

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
    Private Sub LeaderboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Koneksi()
        Dim DaHist As New OdbcDataAdapter($"SELECT username, highest_score FROM user", Conn)
        Dim DsHist As New DataSet
        DaHist.Fill(DsHist, "user")
        DataGridView1.DataSource = DsHist.Tables("user")
        ' Set default sorting untuk kolom "score" dari yang tertinggi ke terendah
        DataGridView1.Sort(DataGridView1.Columns("highest_score"), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        ' Menggambar nomor urut pada setiap baris DataGridView
        Dim grid As DataGridView = CType(sender, DataGridView)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()

        ' Mengambil ukuran font untuk mengatur posisi nomor urut
        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Center
        centerFormat.LineAlignment = StringAlignment.Center

        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)
        e.Graphics.DrawString(rowIdx, Me.Font, SystemBrushes.ControlText, headerBounds, centerFormat)
    End Sub

End Class