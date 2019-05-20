Imports System.Data.Odbc

Module mdlKoneksi

    Public cn As OdbcConnection
    Public drpenyakit As OdbcDataReader
    Public compenyakit As OdbcCommand
    Public dapenyakit As OdbcDataAdapter
    Public dtpenyakit As DataTable

    Public drgejala As OdbcDataReader
    Public comgejala As OdbcCommand
    Public dagejala As OdbcDataAdapter
    Public dtgejala As DataTable

    Public draturan As OdbcDataReader
    Public comaturan As OdbcCommand
    Public daaturan As OdbcDataAdapter
    Public dtaturan As DataTable

    Public draturan2 As OdbcDataReader
    Public comaturan2 As OdbcCommand
    Public daaturan2 As OdbcDataAdapter
    Public dtaturan2 As DataTable

    Public drkonsultasi As OdbcDataReader
    Public comkonsultasi As OdbcCommand
    Public dakonsultasi As OdbcDataAdapter
    Public dtkonsultasi As DataTable

    Sub koneksi()
        Dim db_name, db_server, db_port, db_user, db_pass As String

        db_name = "db_pakarmata"
        db_server = "localhost"
        db_port = "3306"
        db_user = "root"
        db_pass = ""

        Try
            'mencoba untuk koneksi
            Dim str As String
            str = "DRIVER={MySQL ODBC 3.51 Driver};SERVER=" & db_server & ";DATABASE=" & db_name & ";UID=" & db_user & ";PWD=" & db_pass & ";PORT=" & db_port & ";OPTION=3"
            cn = New OdbcConnection(str)
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
        Catch
            'jika koneksi gagal
            MsgBox("Koneksi Erorr", MsgBoxStyle.Information, "Info")
            End
        End Try

    End Sub

End Module
