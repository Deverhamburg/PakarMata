Imports System.Data.Odbc

Public Class FormGejala


    Sub gridTampil()

        dagejala = New OdbcDataAdapter("SELECT * FROM gejala", cn)
        dtgejala = New DataTable
        dagejala.Fill(dtgejala)
        dggejala.DataSource = dtgejala

        dggejala.Columns(0).HeaderText = "ID Gejala"
        dggejala.Columns(1).HeaderText = "Nama Gejala"

        dggejala.Columns(0).Width = 100
        dggejala.Columns(1).Width = 451

    End Sub


    Sub gridFilter()

        dagejala = New OdbcDataAdapter("SELECT * FROM gejala WHERE nmgejala LIKE '" & txtcari.Text & "%'", cn)
        dtgejala = New DataTable
        dagejala.Fill(dtgejala)
        dggejala.DataSource = dtgejala

        dggejala.Columns(0).HeaderText = "ID Gejala"
        dggejala.Columns(1).HeaderText = "Nama Gejala"

        dggejala.Columns(0).Width = 100
        dggejala.Columns(1).Width = 451

    End Sub


    Sub kodeOtomatis()

        comgejala = New OdbcCommand("select * from gejala order by idgejala desc", cn)
        drgejala = comgejala.ExecuteReader
        If drgejala.HasRows Then
            txtid.Text = "G" & Microsoft.VisualBasic.Right("00" & Trim(Str(Val(Microsoft.VisualBasic.Right(drgejala.Item(0), 2)) + 1)), 2)
        Else
            txtid.Text = "G01"
        End If

    End Sub

    Sub tampilanAwal()

        gridTampil()

        txtid.Text = ""
        txtnama.Text = ""

        kodeOtomatis()

        btnsimpan.Text = "Simpan"
        btnhapus.Enabled = False

    End Sub

    Private Sub FormGejala_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        koneksi()
        gridTampil()
        kodeOtomatis()

        btnhapus.Enabled = False

    End Sub

    Private Sub dggejala_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dggejala.CellContentClick

    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click

        If txtnama.Text = "" Then
            MsgBox("Masukkan Nama Gejala", , "Info")
            Return
        End If

        If btnsimpan.Text = "Simpan" Then
            'proses simpan'
            comgejala = New OdbcCommand("insert into gejala values('" & txtid.Text & "','" & txtnama.Text & "')", cn)
            comgejala.ExecuteNonQuery()
        Else
            'proses update'
            comgejala = New OdbcCommand("update gejala set nmgejala='" & txtnama.Text & "' where idgejala='" & txtid.Text & "'", cn)
            comgejala.ExecuteNonQuery()
        End If

        tampilanAwal()

    End Sub

    Private Sub dggejala_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dggejala.CellMouseClick

        Dim baris As Integer
        baris = e.RowIndex
        If e.RowIndex >= 0 Then
            With dggejala
                txtid.Text = .Item(0, baris).Value
                txtnama.Text = .Item(1, baris).Value
            End With
        End If

        btnsimpan.Text = "Update"
        btnhapus.Enabled = True

    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click

        tampilanAwal()

    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click

        Dim x As Integer

        x = MsgBox("Yakin Menghapus Data Ini?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Info")

        If x = MsgBoxResult.Yes Then
            comgejala = New OdbcCommand("delete from gejala where idgejala='" & txtid.Text & "'", cn)
            comgejala.ExecuteNonQuery()
        End If

        tampilanAwal()

    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged

        gridFilter()

    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click

        Close()

    End Sub
End Class