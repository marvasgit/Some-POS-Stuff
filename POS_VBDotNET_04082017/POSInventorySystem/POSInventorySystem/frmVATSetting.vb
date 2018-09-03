Imports MySql.Data.MySqlClient
Public Class frmVATSetting

    Dim hasData As Boolean

    Private Sub frmVATSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        GetVATInfo()

    End Sub




    Public Sub AddEditVAT(ByVal isAdding As Boolean)

        Try
            If isAdding = True Then
                sqL = "INSERT INTO VATSetting(VatPercent) VALUES(@VatPercent)"
            Else
                sqL = "UPDATE VATSetting SET VatPercent=@VatPercent"
            End If
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)

            cmd.Parameters.AddWithValue("@VatPercent", txtPercent.Text)

            If isAdding = False Then
                cmd.Parameters.AddWithValue("@VATID", txtPercent.Tag)
            End If

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                If isAdding = True Then
                    MsgBox("VAT Information Successfully Added", MsgBoxStyle.Information, "Adding VAT")
                Else
                    MsgBox("VAT Information Successfully Updated", MsgBoxStyle.Information, "Editing VAT")
                End If

            Else
                MsgBox("Saving VAT Information Failed", MsgBoxStyle.Exclamation, "Failed")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetVATInfo()
        Try
            sqL = "SELECT VatNo, VatPercent FROM VATSetting"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            If dr.Read Then

                txtPercent.Tag = dr(0)
                txtPercent.Text = dr(1)
                hasData = True

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If hasData = False Then
            AddEditVAT(True)
        Else
            AddEditVAT(False)
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class