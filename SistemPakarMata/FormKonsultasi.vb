
Imports System.Data.Odbc

Public Class FormKonsultasi

    Dim idkonsultasi, idgejala, idpenyakit, nmpenyakit As String
    Dim tanggal As Date
    Dim jgejala, jyes As Integer

    Sub kodeOtomatis()

        comkonsultasi = New OdbcCommand("select * from konsultasi order by idkonsultasi desc", cn)
        drkonsultasi = comkonsultasi.ExecuteReader

        If drkonsultasi.HasRows Then
            idkonsultasi = "K" & Microsoft.VisualBasic.Right("00" & Trim(Str(Val(Microsoft.VisualBasic.Right(drkonsultasi.Item(0), 2)) + 1)), 2)
        Else
            idkonsultasi = "K01"
        End If

    End Sub


    Sub gridTampil()

        Dim ch As New DataGridViewCheckBoxColumn

        dagejala = New OdbcDataAdapter("SELECT * FROM gejala ORDER BY idgejala ASC", cn)
        dtgejala = New DataTable
        dagejala.Fill(dtgejala)
        dgkonsultasi.DataSource = dtgejala

        dgkonsultasi.Columns.Add(ch)

        dgkonsultasi.Columns(0).HeaderText = "ID Gejala"
        dgkonsultasi.Columns(1).HeaderText = "Nama Gejala"
        dgkonsultasi.Columns(2).HeaderText = ""

        dgkonsultasi.Columns(0).Width = 80
        dgkonsultasi.Columns(1).Width = 370
        dgkonsultasi.Columns(2).Width = 80

    End Sub


    Private Sub FormKonsultasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        koneksi()
        kodeOtomatis()

        tanggal = Now.Date

        gridTampil()

    End Sub

    Private Sub btnproses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnproses.Click

        If txtnama.Text = "" Then
            MsgBox("Masukkan Nama", , "Info")
            Return
        End If

        Dim i As Integer

        For i = 0 To dgkonsultasi.Rows.Count - 1
            Dim c As Boolean

            c = dgkonsultasi.Rows(i).Cells(2).Value

            If c = True Then
                idgejala = dgkonsultasi.Rows(i).Cells(0).Value

                comkonsultasi = New OdbcCommand("insert into dkonsultasi values('" & idkonsultasi & "','" & idgejala & "')", cn)
                comkonsultasi.ExecuteNonQuery()
            End If
        Next

        'Proses Mencari Jumlah Gejala Pada Konsultasi'
        comkonsultasi = New OdbcCommand("select count(idgejala) from dkonsultasi where idkonsultasi='" & idkonsultasi & "'", cn)
        drkonsultasi = comkonsultasi.ExecuteReader

        If drkonsultasi.HasRows Then
            jgejala = drkonsultasi.Item(0)
        End If

        'Proses Mencari Gejala Yang Sama Pada Saat Konsultasi'
        comaturan = New OdbcCommand("select idpenyakit,nmpenyakit from vaturan GROUP BY nmpenyakit having count(idgejala)='" & jgejala & "'", cn)
        draturan = comaturan.ExecuteReader

        If draturan.HasRows Then
            Do While draturan.Read
                idpenyakit = draturan.Item(0)
                nmpenyakit = draturan.Item(1)

                jyes = 0

                'Mencari Gejala Berdasarkan Penyakit'
                comaturan2 = New OdbcCommand("select idgejala from vaturan where idpenyakit='" & idpenyakit & "'", cn)
                draturan2 = comaturan2.ExecuteReader

                If draturan2.HasRows Then
                    Do While draturan2.Read
                        idgejala = draturan2.Item(0)

                        comkonsultasi = New OdbcCommand("select*from dkonsultasi where idkonsultasi='" & idkonsultasi & "' and idgejala='" & idgejala & "'", cn)
                        drkonsultasi = comkonsultasi.ExecuteReader

                        If drkonsultasi.HasRows Then
                            jyes = jyes + 1
                        End If

                        'Proses Membandingkan'
                        If jyes = jgejala Then
                            'Proses Simpan Jika Data Di Temukan'
                            comkonsultasi = New OdbcCommand("insert into konsultasi values('" & idkonsultasi & "','" & Format(tanggal, "yyyy-MM-dd") & "','" & txtnama.Text & "','" & nmpenyakit & "')", cn)
                            comkonsultasi.ExecuteNonQuery()

                            GoTo SELESAI
                        End If

                    Loop

                    draturan2.NextResult()

                End If
            Loop

            draturan.NextResult()

            'Proses Menyimpan Data Yang Tidak Di Temukan'
            comkonsultasi = New OdbcCommand("insert into konsultasi values('" & idkonsultasi & "','" & Format(tanggal, "yyyy-MM-dd") & "','" & txtnama.Text & "','Tidak Di Temukan')", cn)
            comkonsultasi.ExecuteNonQuery()

        Else
            MsgBox("Penyakit Tidak Di Temukan", , "Info")
            Return
        End If

SELESAI:

        comkonsultasi = New OdbcCommand("select hasil from konsultasi where idkonsultasi='" & idkonsultasi & "'", cn)
        drkonsultasi = comkonsultasi.ExecuteReader

        If drkonsultasi.HasRows Then
            MsgBox("Anda Mengalami Penyakit : " & drkonsultasi.Item(0))
        End If

        Close()


    End Sub
End Class