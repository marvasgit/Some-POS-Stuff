
Imports MySql.Data.MySqlClient

Public Class frmPOS

    '----Basket Information
    Dim totalNumberOfItems As Integer
    Dim totalAmountOfItems As Double

    '----Discount
    Dim isDiscount As Boolean
    Dim discountPercent As Double

    '----Quantity
    Dim isQuantity As Boolean
    Dim noOfItems As Integer

    Private Sub GetVAT()
        Try
            sqL = "SELECT VatPercent FROm VatSetting"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader
            If dr.Read = True Then
                lblVatPercent.Text = dr(0) / 100
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetInvoiceNo()
        Try
            sqL = "SELECT InvoiceNo FROM Transactions ORDER BY InvoiceNO DESC"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            If dr.Read = True Then
                lblInvoice.Text = dr("InvoiceNo") + 1
            Else
                lblInvoice.Text = 100100000
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
        txtBarcode.Focus()
    End Sub

    Private Sub GetProductInfo()

        If IsValidQuantity(txtBarcode.Text) = True Then
            If stocksOnhand < Val(txtQuantity.Text) Then
                MsgBox("Not Enough Stocks!!", MsgBoxStyle.Exclamation, "Warning")
                txtBarcode.Text = ""
                Exit Sub
            End If

        End If

        Dim discountAmount As Double
        Try
            sqL = "SELECT ProductCode, Description, UnitPrice, ProductNo FROM Product WHERE Barcode = '" & txtBarcode.Text & "'"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            If dr.Read = True Then
                txtItemCode.Text = dr("ProductCOde")
                txtItemDesc.Text = dr("Description")

                'Validate Discount
                If isDiscount = True Then
                    discountAmount = Val(dr("UnitPrice")) * (Val(discountPercent) / 100)
                    txtPrice.Text = Val(dr("UnitPrice")) - discountAmount
                Else
                    txtPrice.Text = dr("UnitPrice")
                    discountAmount = 0
                End If

                'Validate Quantity
                If isQuantity = True Then
                    txtQuantity.Text = noOfItems
                Else
                    txtQuantity.Text = 1
                End If
                txtTotal.Text = Val(txtPrice.Text.Replace(",", "")) * Val(txtQuantity.Text)

                'Adding Item to Gridview to Display
                dgw.Rows.Add(dr("ProductNo"), dr("ProductCode"), dr("Description"), txtPrice.Text, txtQuantity.Text, txtTotal.Text, discountAmount * Val(txtQuantity.Text))

                '-Get Basket Info
                BasketInformation()

                'Clear Barcode text field
                txtBarcode.Clear()

                'et Discount to Zero
                discountPercent = 0
                isDiscount = False

                'Set Quantity to False
                isQuantity = False
                noOfItems = 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub BasketInformation()
        'Total number of Items
        totalNumberOfItems += Val(txtQuantity.Text)
        lblTotalItems.Text = totalNumberOfItems

        'Compute total Amount and Display
        totalAmountOfItems += Val(txtTotal.Text.Replace(",", ""))
        lblTotalAmount.Text = totalAmountOfItems

        'Get Vat Amount and Display
        Dim vatAmount As Double
        vatAmount = totalAmountOfItems * Val(lblVatPercent.Text)
        lblVAT.Text = vatAmount

        'GET SubtotalAmount
        Dim subTotalAmount As Double
        subTotalAmount = totalAmountOfItems - vatAmount
        lblSubTotal.Text = subTotalAmount
    End Sub

    Public Sub NewTransaction()
        txtItemCode.Text = ""
        txtItemDesc.Text = ""
        txtPrice.Text = "0.00"
        txtQuantity.Text = 1
        txtTotal.Text = "0.00"

        totalAmountOfItems = 0
        totalNumberOfItems = 0

        lblTotalItems.Text = "0"
        lblVAT.Text = "0.00"
        lblSubTotal.Text = "0.00"
        lblTotalAmount.Text = "0.00"

        dgw.Rows.Clear()
        GetInvoiceNo()
    End Sub

    Dim stocksOnhand As Integer = 0

    Private Function IsValidQuantity(ByVal barcode As String)
        Dim ret As Boolean
        Try
            sqL = "SELECT * FROM PRODUCT WHERE barcode = '" & barcode & "'"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader
            If dr.Read = True Then
                ret = True
                stocksOnhand = dr("StocksOnHand")
            Else
                ret = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
        Return ret
    End Function

    Private Sub RemoveItem()
        '-----------------DECREASE BASKETINFORMATION-------------------------'
        'Total number of Items
        totalNumberOfItems -= dgw.CurrentRow.Cells(4).Value
        lblTotalItems.Text = totalNumberOfItems

        'Compute total Amount and Display
        totalAmountOfItems -= dgw.CurrentRow.Cells(5).Value
        lblTotalAmount.Text = totalAmountOfItems

        'Get Vat Amount and Display 
        Dim vatAmount As Double
        vatAmount = totalAmountOfItems * Val(lblVatPercent.Text)
        lblVAT.Text = vatAmount

        'GET SubtotalAmount
        Dim subTotalAmount As Double
        subTotalAmount = totalAmountOfItems - vatAmount
        lblSubTotal.Text = subTotalAmount


        dgw.Rows.Remove(dgw.SelectedRows.Item(0))
        txtBarcode.Focus()
    End Sub

    Public Sub AddTransaction()
        Try
            sqL = "INSERT INTO Transactions(InvoiceNo, TDate, TTime, NonVatTotal, VatAmount, TotalAmount, StaffID) VALUES('" & lblInvoice.Text & "', '" & Date.Now.ToString("MM/dd/yyyy") & "', '" & Date.Now.ToString("hh:mm:ss") & "', '" & lblSubTotal.Text.Replace(",", "") & "', '" & lblVAT.Text.Replace(",", "") & "', '" & lblTotalAmount.Text & "', '" & lblStaffID.Text & "')"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub AddTransactionDetails()
        Try
            sqL = "INSERT INTO TransactionDetails(InvoiceNo, ProductNo, ItemPrice, Quantity, Discount) VALUES(@InvoiceNo, @ProductNo, @ItemPrice, @Quantity, @Discount)"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            cmd.Parameters.Add("InvoiceNo", MySql.Data.MySqlClient.MySqlDbType.VarChar)
            cmd.Parameters.Add("ProductNo", MySql.Data.MySqlClient.MySqlDbType.Int32)
            cmd.Parameters.Add("ItemPrice", MySql.Data.MySqlClient.MySqlDbType.Double)
            cmd.Parameters.Add("Quantity", MySql.Data.MySqlClient.MySqlDbType.UInt32)
            cmd.Parameters.Add("Discount", MySql.Data.MySqlClient.MySqlDbType.Double)

            For i As Integer = 0 To dgw.Rows.Count - 1
                cmd.Parameters("InvoiceNo").Value = lblInvoice.Text
                cmd.Parameters("ProductNo").Value = dgw.Rows(i).Cells(0).Value
                cmd.Parameters("ItemPrice").Value = CDbl(dgw.Rows(i).Cells(3).Value.ToString.Replace(",", ""))
                cmd.Parameters("Quantity").Value = dgw.Rows(i).Cells(4).Value
                cmd.Parameters("Discount").Value = CDbl(dgw.Rows(i).Cells(6).Value.ToString.Replace(",", ""))
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    'Decrease product's stocks on hand
    Public Sub UpdateProductQuantity()
        Try
            sqL = "UPDATE Product SET StocksOnHand = StocksOnHand - @Quantity WHERE ProductNo = @ProductNo"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            cmd.Parameters.Add("ProductNo", MySql.Data.MySqlClient.MySqlDbType.Int32)
            cmd.Parameters.Add("Quantity", MySql.Data.MySqlClient.MySqlDbType.Int32)

            For i As Integer = 0 To dgw.Rows.Count - 1
                cmd.Parameters("ProductNo").Value = dgw.Rows(i).Cells(0).Value
                cmd.Parameters("Quantity").Value = CInt(dgw.Rows(i).Cells(4).Value)
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If frmLogin.isCashier = True Then

            frmLogin.Show()
            frmLogin.txtUsername.Text = ""

            frmLogin.txtPassword.Text = ""
            frmLogin.txtUsername.Focus()
            Me.Close()
        End If

        Me.Close()
    End Sub

    Private Sub frmPOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnNewTran.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            btnRemoveItem.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            btnSettlepayment.PerformClick()
        ElseIf e.KeyCode = Keys.F4 Then
            btnDiscount.PerformClick()
        ElseIf e.KeyCode = Keys.F5 Then
            btnQuantity.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            btnClose.PerformClick()
        End If
    End Sub

    Private Sub getStaffInfo()
        Try
            sqL = "SELECT CONCAT(lastname, ', ', Firstname, ' ', MI) as StaffName, Role FROM Staff WHERE StaffID = '" & lblStaffID.Text & "'"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            If dr.Read = True Then
                lblCustNo.Text = dr("Role")
                lblCustName.Text = dr("Staffname")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try

    End Sub

    Private Function hasStocks(ByVal barcode As String) As Boolean
        Dim ret As Boolean
        Try
            sqL = "SELECT * FROM PRODUCTS WHERE StocksOnHand >= " & txtQuantity.Text & "' AND BArcode = '" & barcode & "'"
            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            If dr.Read = True Then
                ret = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try

        Return ret
    End Function

    Private Sub frmPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmLogin.isAdmin = True Then
            lblStaffID.Text = frmMain.tsslUser.Tag
        Else
            lblStaffID.Text = frmLogin.strCashierID
        End If

        Me.Panel1.Location = New Point(190, 70)


        getStaffInfo()
        GetVAT()
        GetInvoiceNo()

    End Sub

    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
        GetProductInfo()
    End Sub

    Private Sub btnNewTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewTran.Click
        NewTransaction()
    End Sub

    Private Sub btnRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveItem.Click
        If dgw.Rows.Count < 1 Then
            MsgBox("No item to delete", MsgBoxStyle.Exclamation, "delete")
            Exit Sub
        End If

        RemoveItem()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuantity.Click
        Try
            isQuantity = True
            noOfItems = InputBox("ENTER QUANTITY :", "Quantity")
            txtQuantity.Text = noOfItems
            txtBarcode.Focus()
        Catch ex As Exception
            MsgBox("Quantity is set to default value.", MsgBoxStyle.Exclamation, "Quantity")
            txtBarcode.Focus()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiscount.Click
        Try
            isDiscount = True
            discountPercent = InputBox("ENTER DISCOUNT : ", "Discount")
            txtBarcode.Focus()
        Catch ex As Exception
            MsgBox("Item(s) has " & discountPercent & " percent discount.", MsgBoxStyle.Exclamation, "Discount")
            txtBarcode.Focus()
        End Try
    End Sub

    Private Sub btnSettlepayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettlepayment.Click
        If Val(lblTotalAmount.Text.Replace(",", "")) < 1 Then
            MsgBox("No transaction to be paid.", MsgBoxStyle.Exclamation, "Payment")
            txtBarcode.Focus()
            Exit Sub
        End If
        frmPayment.ShowDialog()
    End Sub
End Class