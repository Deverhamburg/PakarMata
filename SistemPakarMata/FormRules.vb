
Imports System.Data.Odbc

Public Class FormRules

    Dim idaturan, idgejala, idpenyakit As String
    Dim status As String

    Sub gridTampil()

        daaturan = New OdbcDataAdapter("SELECT daturan.idaturan, daturan.idgejala, gejala.nmgejala FROM daturan INNER JOIN gejala ON daturan.idgejala = gejala.idgejala where idaturan='" & idaturan & "'", cn)
        dtaturan = New DataTable
        daaturan.Fill(dtaturan)
        dgaturan.DataSource = dtaturan

        dgaturan.Columns(0).HeaderText = ""
        dgaturan.Columns(1).HeaderText = "ID Gejala"
        dgaturan.Columns(2).HeaderText = "Nama Gejala"

        dgaturan.Columns(0).Width = 0
        dgaturan.Columns(1).Width = 100
        dgaturan.Columns(2).Width = 470

    End Sub

    Sub idOtomatis()

        comaturan = New OdbcCommand("select * from aturan order by idaturan desc", cn)
        draturan = comaturan.ExecuteReader

        If draturan.HasRows Then
            idaturan = "R" & Microsoft.VisualBasic.Right("00" & Trim(Str(Val(Microsoft.VisualBasic.Right(draturan.Item(0), 2)) + 1)), 2)
        Else
            idaturan = "R01"
        End If

    End Sub

    Sub isiCombo()

        compenyakit = New OdbcCommand("select * from penyakit", cn)
        drpenyakit = compenyakit.ExecuteReader

        cmbpenyakit.Items.Clear()
        While drpenyakit.Read()
            cmbpenyakit.Items.Add(drpenyakit("nmpenyakit"))
        End While

        comgejala = New OdbcCommand("select * from gejala", cn)
        drgejala = comgejala.ExecuteReader

        cmbgejala.Items.Clear()
        While drgejala.Read()
            cmbgejala.Items.Add(drgejala("nmgejala"))
        End While

    End Sub

    Private Sub FormRules_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        koneksi()
        idOtomatis()
        gridTampil()
        isiCombo()

        btnhapus.Enabled = False

    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If cmbpenyakit.Text = "" Then
            MsgBox("Masukkan Penyakit", , "Info")
            Return
        End If

        'cek validasi penyakit'
        compenyakit = New OdbcCommand("select * from penyakit where nmpenyakit='" & cmbpenyakit.Text & "'", cn)
        drpenyakit = compenyakit.ExecuteReader

        If drpenyakit.HasRows Then
            idpenyakit = drpenyakit.Item(0)

            comaturan = New OdbcCommand("select * from aturan where idpenyakit='" & idpenyakit & "'", cn)
            draturan = comaturan.ExecuteReader

            If draturan.HasRows Then
                MsgBox("Data Penyakit Sudah Ada", , "Info")
                Return
            End If

        End If
        'akhir validasi penyakit'

        'cek validasi gejala'
        comgejala = New OdbcCommand("select * from gejala where nmgejala='" & cmbgejala.Text & "'", cn)
        drgejala = comgejala.ExecuteReader

        If drgejala.HasRows Then
            idgejala = drgejala.Item(0)

            comaturan = New OdbcCommand("select * from daturan where idaturan='" & idaturan & "' and idgejala='" & idgejala & "'", cn)
            draturan = comaturan.ExecuteReader

            If draturan.HasRows Then
                MsgBox("Data Gejala Sudah Ada", , "Info")
                Return
            End If

        End If
        'akhir validasi gejala'

        If cmbgejala.Text = "" Then
            MsgBox("Masukkan Gejala", , "Info")
            Return
        End If

        comgejala = New OdbcCommand("select * from gejala where nmgejala='" & cmbgejala.Text & "'", cn)
        drgejala = comgejala.ExecuteReader

        If drgejala.HasRows Then
            idgejala = drgejala.Item(0)
        End If

        comaturan = New OdbcCommand("insert into daturan values('" & idaturan & "','" & idgejala & "')", cn)
        comaturan.ExecuteNonQuery()

        gridTampil()

        cmbgejala.Text = ""
        cmbpenyakit.Enabled = False
        btnkeluar.Enabled = False
        btncari.Enabled = False

    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click

        If status = "c" Then
            idOtomatis()
            gridTampil()

            cmbpenyakit.Text = ""
            cmbgejala.Text = ""

            cmbpenyakit.Enabled = True
            btnkeluar.Enabled = True
            btncari.Enabled = True

            status = "s"

            Return
        End If

        compenyakit = New OdbcCommand("select * from penyakit where nmpenyakit='" & cmbpenyakit.Text & "'", cn)
        drpenyakit = compenyakit.ExecuteReader

        If drpenyakit.HasRows Then
            idpenyakit = drpenyakit.Item(0)
        End If

        comaturan = New OdbcCommand("insert into aturan values('" & idaturan & "','" & idpenyakit & "')", cn)
        comaturan.ExecuteNonQuery()

        idOtomatis()
        gridTampil()

        cmbpenyakit.Text = ""
        cmbgejala.Text = ""

        cmbpenyakit.Enabled = True
        btnkeluar.Enabled = True
        btncari.Enabled = True

    End Sub

    Private Sub dgaturan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgaturan.CellContentClick

    End Sub

    Private Sub dgaturan_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgaturan.CellMouseClick

        Dim baris As Integer
        baris = e.RowIndex
        If e.RowIndex >= 0 Then
            With dgaturan
                idaturan = .Item(0, baris).Value
                idgejala = .Item(1, baris).Value
                cmbgejala.Text = .Item(2, baris).Value
            End With
        End If

        cmbgejala.Enabled = False
        btnhapus.Enabled = True
        btnadd.Enabled = False

    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click

        Dim x As Integer

        x = MsgBox("Yakin Menghapus Data Ini?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Info")

        If x = MsgBoxResult.Yes Then
            comaturan = New OdbcCommand("delete from daturan where idaturan='" & idaturan & "' and idgejala='" & idgejala & "'", cn)
            comaturan.ExecuteNonQuery()

            gridTampil()
        End If

        cmbgejala.Text = ""
        cmbgejala.Enabled = True
        btnadd.Enabled = True
        btnhapus.Enabled = False

    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click

        If status = "c" Then
            idOtomatis()
            gridTampil()

            cmbpenyakit.Text = ""
            cmbgejala.Text = ""

            cmbpenyakit.Enabled = True
            btnkeluar.Enabled = True
            btncari.Enabled = True

            status = "s"

            Return
        End If

        Dim x As Integer

        x = MsgBox("Yakin Membatalkan Data Ini?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Info")

        If x = MsgBoxResult.Yes Then
            comaturan = New OdbcCommand("delete from daturan where idaturan='" & idaturan & "'", cn)
            comaturan.ExecuteNonQuery()

            idOtomatis()
            gridTampil()

            cmbpenyakit.Text = ""
            cmbgejala.Text = ""

            cmbpenyakit.Enabled = True
            btnkeluar.Enabled = True
            btncari.Enabled = True
        End If

    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click

        If cmbpenyakit.Text = "" Then
            MsgBox("Masukkan Penyakit", , "Info")
            Return
        End If

        'Mendapatkan ID Penyakit'
        compenyakit = New OdbcCommand("select * from penyakit where nmpenyakit='" & cmbpenyakit.Text & "'", cn)
        drpenyakit = compenyakit.ExecuteReader

        If drpenyakit.HasRows Then
            idpenyakit = drpenyakit.Item(0)

            'Mendapatkan ID Aturan'
            comaturan = New OdbcCommand("select * from aturan where idpenyakit='" & idpenyakit & "'", cn)
            draturan = comaturan.ExecuteReader

            If draturan.HasRows Then
                idaturan = draturan.Item(0)
            Else
                MsgBox("Data Tidak di Temukan", , "Info")
                Return
            End If
            'Akhir Mendapatkan ID Aturan'
        End If
        'Akhir Mendapatkan ID Penyakit'

        gridTampil()

        cmbpenyakit.Enabled = False
        btncari.Enabled = False
        btnkeluar.Enabled = False

        status = "c"

    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click

        Close()

    End Sub
End Class