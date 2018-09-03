Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmReportSales

    Private Sub frmReportSales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        LoadReport()
    End Sub
    Private Sub LoadReport()
        Try
            'SELECT ProductCode, P.Description, TDate, SUM(TD.Quantity) as totalQuantity, TD.ItemPrice FROM Product as P, Transactions as T, TransactionDetails as TD WHERE P.ProductNo = TD.ProductNo AND TD.InvoiceNo = T.InvoiceNo AND
            sqL = "SELECT ProductCode, Description, TDate as SalesDate, SUM(TD.Quantity) as Quantity, TD.ItemPrice as ItemPrice, (SUM(TD.Quantity) * TD.ItemPrice) as TotalAmount FROM Product as P, Transactions as T, TransactionDetails as TD WHERE P.ProductNo = TD.ProductNo AND TD.InvoiceNo = T.InvoiceNo AND STR_TO_DATE(REPLACE(TDATE, '-', '/'), '%m/%d/%Y') BETWEEN '" & Format(frmFilterDailySales.dtpStartDate.Value, "yyyy-MM-dd") & "' AND '" & Format(frmFilterDailySales.dtpEndDate.Value, "yyyy-MM-dd") & "' GROUP BY P.ProductNo, TDATE,ProductCode,  TDate, Quantity, TD.ItemPrice ORDER BY TDATE, P.Description "

            ConnDB()
            cmd = New MySqlCommand(sqL, conn)
            da = New MySqlDataAdapter(cmd)

            Me.dsReport.SalesReport.Clear()
            da.Fill(Me.dsReport.SalesReport)

            Dim startDate = New ReportParameter("StartDate", frmFilterDailySales.dtpStartDate.Value)
            Dim endDate = New ReportParameter("EndDate", frmFilterDailySales.dtpEndDate.Value)

            Dim HeaderParams As ReportParameter() = {startDate, endDate}

            For Each param As ReportParameter In HeaderParams
                ReportViewer1.LocalReport.SetParameters(param)
            Next

            Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            Me.ReportViewer1.ZoomPercent = 90
            Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent

            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class