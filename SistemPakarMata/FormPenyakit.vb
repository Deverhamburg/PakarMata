Imports System.Data.Odbc

Public Class FormPenyakit


    Sub gridTampil()

        dapenyakit = New OdbcDataAdapter("SELECT * FROM penyakit", cn)
        dtpenyakit = New DataTable
        dapenyakit.Fill(dtpenyakit)
        dgpenyakit.DataSource = dtpenyakit

        dgpenyakit.Columns(0).HeaderText = "ID Penyakit"
        dgpenyakit.Columns(1).HeaderText = "Nama Penyakit"

        dgpenyakit.Columns(0).Width = 100
        dgpenyakit.Columns(1).Width = 450

    End Sub


    Sub gridFilter()

        dapenyakit = New OdbcDataAdapter("SELECT * FROM penyakit WHERE nmpenyakit LIKE '" & txtcari.Text & "%'", cn)
        dtpenyakit = New DataTable
        dapenyakit.Fill(dtpenyakit)
        dgpenyakit.DataSource = dtpenyakit

        dgpenyakit.Columns(0).HeaderText = "ID Penyakit"
        dgpenyakit.Columns(1).HeaderText = "Nama Penyakit"

        dgpenyakit.Columns(0).Width = 100
        dgpenyakit.Columns(1).Width = 450

    End Sub


    Sub noOtomatis()

        compenyakit = New OdbcCommand("select * from penyakit order by idpenyakit desc", cn)
        drpenyakit = compenyakit.ExecuteReader

        If drpenyakit.HasRows Then
            txtid.Text = "P" & Microsoft.VisualBasic.Right("00" & Trim(Str(Val(Microsoft.VisualBasic.Right(drpenyakit.Item(0), 2)) + 1)), 2)
        Else
            txtid.Text = "P01"
        End If

    End Sub

    Sub tampilanAwal()

        gridTampil()

        txtid.Text = ""
        txtnama.Text = ""

        noOtomatis()

        btnhapus.Enabled = False
        btnsimpan.Text = "Simpan"

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub FormPenyakit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        koneksi()
        gridTampil()
        noOtomatis()

        btnhapus.Enabled = False

    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click

        If txtnama.Text = "" Then
            MsgBox("Masukkan Nama Penyakit", , "Info")
            Return
        End If

        If btnsimpan.Text = "Simpan" Then
            'Fungsi Simpan'
            compenyakit = New OdbcCommand("insert into penyakit values('" & txtid.Text & "','" & txtnama.Text & "')", cn)
            compenyakit.ExecuteNonQuery()
        Else
            'Fungsi Edit'
            compenyakit = New OdbcCommand("update penyakit set nmpenyakit='" & txtnama.Text & "' where idpenyakit='" & txtid.Text & "'", cn)
            compenyakit.ExecuteNonQuery()
        End If

        tampilanAwal()

    End Sub

    Private Sub dgpenyakit_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgpenyakit.CellContentClick

    End Sub

    Private Sub dgpenyakit_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgpenyakit.CellMouseClick

        Dim baris As Integer
        baris = e.RowIndex
        If e.RowIndex >= 0 Then
            With dgpenyakit
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
            compenyakit = New OdbcCommand("delete from penyakit where idpenyakit='" & txtid.Text & "'", cn)
            compenyakit.ExecuteNonQuery()
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
