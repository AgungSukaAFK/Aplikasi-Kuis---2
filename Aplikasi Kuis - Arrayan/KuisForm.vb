Imports System.Data.Odbc

Public Class KuisForm

    Private username As String

    Dim questions As New List(Of Dictionary(Of String, String))
    Dim answers As New List(Of String)()
    Dim indeksPertanyaan As Integer = 0
    Dim maksPertanyaan As Integer = 10

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
    Private Sub KuisForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Koneksi()

        Dim sql As String = $"
        (
            SELECT * FROM pertanyaan 
            WHERE skor = 10 
            ORDER BY RAND() 
            LIMIT 4
        )
    UNION ALL
        (
            SELECT * FROM pertanyaan 
            WHERE skor = 20 
            ORDER BY RAND() 
            LIMIT 3
        )
    UNION ALL
        (
            SELECT * FROM pertanyaan 
            WHERE skor = 30 
            ORDER BY RAND() 
            LIMIT 3
        );
"
        cmd = New OdbcCommand(sql, Conn)
        Rd = cmd.ExecuteReader()

        While Rd.Read()
            Dim question As New Dictionary(Of String, String)()
            question("id") = Rd("id").ToString()
            question("soal") = Rd("soal").ToString()
            question("opsi_a") = Rd("opsi_a").ToString()
            question("opsi_b") = Rd("opsi_b").ToString()
            question("opsi_c") = Rd("opsi_c").ToString()
            question("jawaban") = Rd("jawaban").ToString()
            question("skor") = Rd("skor").ToString()
            questions.Add(question)
        End While

        ' Menutup DataReader
        Rd.Close()

        For i As Integer = 0 To questions.Count - 1
            answers.Add("belum")
        Next

        DisplayQuestion(indeksPertanyaan)

        labIndex.Text = $"{indeksPertanyaan + 1} / {maksPertanyaan}"
    End Sub

    Private Sub DisplayQuestion(index As Integer)
        If index >= 0 AndAlso index < questions.Count Then
            Dim question As Dictionary(Of String, String) = questions(index)
            'Console.WriteLine("ID: " & question("id"))
            boxPertanyaan.Text = "Soal: " & question("soal")
            opsiA.Text = ("Opsi A: " & question("opsi_a"))
            opsiB.Text = ("Opsi B: " & question("opsi_b"))
            opsiC.Text = ("Opsi C: " & question("opsi_c"))
            'Console.WriteLine("Jawaban: " & question("jawaban"))
            'Console.WriteLine("Skor: " & question("skor"))

            ' Reset RadioButton
            opsiA.Checked = False
            opsiB.Checked = False
            opsiC.Checked = False

            ' Set RadioButton berdasarkan jawaban yang telah disimpan
            Select Case answers(index)
                Case "a"
                    opsiA.Checked = True
                Case "b"
                    opsiB.Checked = True
                Case "c"
                    opsiC.Checked = True
            End Select
        End If
    End Sub

    Public Sub New(receivedUserId As String)
        InitializeComponent()

        username = receivedUserId
    End Sub

    Private Sub SaveAnswer()
        If indeksPertanyaan >= 0 AndAlso indeksPertanyaan < questions.Count Then
            If opsiA.Checked Then
                answers(indeksPertanyaan) = "a"
            ElseIf opsiB.Checked Then
                answers(indeksPertanyaan) = "b"
            ElseIf opsiC.Checked Then
                answers(indeksPertanyaan) = "c"
            Else
                answers(indeksPertanyaan) = "belum"
            End If
        End If
    End Sub
    Private Sub NextQuestion()
        SaveAnswer()
        If indeksPertanyaan < questions.Count - 1 Then
            indeksPertanyaan += 1
            DisplayQuestion(indeksPertanyaan)
            labIndex.Text = $"{indeksPertanyaan + 1} / {maksPertanyaan}"
            'btnSelesai.Visible = False
            'btnSelesai.Enabled = False
        End If
    End Sub

    Private Sub PreviousQuestion()
        SaveAnswer()
        If indeksPertanyaan > 0 Then
            indeksPertanyaan -= 1
            DisplayQuestion(indeksPertanyaan)
            labIndex.Text = $"{indeksPertanyaan + 1} / {maksPertanyaan}"
            btnSelesai.Visible = False
            btnSelesai.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviousQuestion()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NextQuestion()
        If indeksPertanyaan = questions.Count - 1 Then
            btnSelesai.Visible = True
            btnSelesai.Enabled = True
        End If
    End Sub

    Private Sub KuisForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Dim dashboard = New DashboardForm(username)
        dashboard.Show()
    End Sub

    Private Sub btnSelesai_Click(sender As Object, e As EventArgs) Handles btnSelesai.Click
        SaveAnswer()

        ' Cek apakah ada pertanyaan yang belum dijawab
        Dim unansweredCount As Integer = 0
        For Each answer In answers
            If answer = "belum" Then
                unansweredCount += 1
            End If
        Next

        If unansweredCount > 0 Then
            ' Tampilkan pesan konfirmasi
            Dim result As DialogResult = MessageBox.Show("Ada " & unansweredCount & " pertanyaan yang belum dijawab. Apakah Anda yakin ingin menyelesaikan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' Jika user memilih "No", keluar dari sub
            If result = DialogResult.No Then
                Return
            End If
        End If

        Dim answeredCount As Integer = 0
        Dim correctCount As Integer = 0
        Dim totalScore As Integer = 0
        Dim maxScore As Integer = 0

        For i As Integer = 0 To questions.Count - 1
            If answers(i) <> "belum" Then
                answeredCount += 1
                If answers(i) = questions(i)("jawaban") Then
                    correctCount += 1
                    totalScore += Convert.ToInt32(questions(i)("skor"))
                End If
            End If
            maxScore += Convert.ToInt32(questions(i)("skor"))
        Next

        'Simpen ke database
        SimpenData(totalScore)

        MessageBox.Show("Hasil akhir" & vbCrLf &
                        "Pertanyaan terjawab: " & answeredCount & "/" & questions.Count & vbCrLf &
                        "Jawaban benar: " & correctCount & "/" & questions.Count & vbCrLf &
                        "Skor: " & totalScore & vbCrLf &
                        "Skor maksimal yang bisa dicapai: " & maxScore)

        Dim dash = New DashboardForm(username)
        dash.Show()
        Me.Hide()
    End Sub

    Public Sub SimpenData(totalScore As Integer)
        ' Ambil highest_score saat ini untuk username tertentu
        Dim sqlCheckHighestScore As String = $"SELECT highest_score FROM user WHERE username = '{username}'"
        cmd = New OdbcCommand(sqlCheckHighestScore, Conn)
        Dim currentHighestScore As Integer = Convert.ToInt32(cmd.ExecuteScalar())

        ' Periksa apakah totalScore lebih besar dari highest_score saat ini
        If totalScore > currentHighestScore Then
            ' Update highest_score jika totalScore baru lebih besar
            Dim sqlUpdateHighestScore As String = $"UPDATE user SET highest_score = {totalScore} WHERE username = '{username}'"
            cmd = New OdbcCommand(sqlUpdateHighestScore, Conn)
            cmd.ExecuteNonQuery()
        End If

        ' Simpan skor ke tabel history
        Dim sqlInsertHistory As String = $"INSERT INTO history (username, score) VALUES ('{username}', {totalScore})"
        cmd = New OdbcCommand(sqlInsertHistory, Conn)
        cmd.ExecuteNonQuery()
    End Sub

End Class