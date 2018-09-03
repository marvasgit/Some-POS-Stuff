<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOS))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.lblInvoice = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnQuantity = New System.Windows.Forms.Button()
        Me.btnDiscount = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSettlepayment = New System.Windows.Forms.Button()
        Me.btnRemoveItem = New System.Windows.Forms.Button()
        Me.btnNewTran = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblVAT = New System.Windows.Forms.Label()
        Me.lblTotalItems = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblCustName = New System.Windows.Forms.Label()
        Me.lblCustNo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgw = New System.Windows.Forms.DataGridView()
        Me.ProductNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Discount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblTtime = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.lblStaffID = New System.Windows.Forms.Label()
        Me.lblVatPercent = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel11)
        Me.Panel1.Controls.Add(Me.Panel9)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(16, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(968, 629)
        Me.Panel1.TabIndex = 1
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Location = New System.Drawing.Point(685, 98)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(272, 64)
        Me.Panel11.TabIndex = 49
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel12.Controls.Add(Me.lblInvoice)
        Me.Panel12.Controls.Add(Me.Label6)
        Me.Panel12.Location = New System.Drawing.Point(5, 5)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(262, 54)
        Me.Panel12.TabIndex = 0
        '
        'lblInvoice
        '
        Me.lblInvoice.BackColor = System.Drawing.Color.Transparent
        Me.lblInvoice.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoice.ForeColor = System.Drawing.Color.White
        Me.lblInvoice.Location = New System.Drawing.Point(105, 15)
        Me.lblInvoice.Name = "lblInvoice"
        Me.lblInvoice.Size = New System.Drawing.Size(150, 26)
        Me.lblInvoice.TabIndex = 2
        Me.lblInvoice.Text = "10001000010000"
        Me.lblInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 26)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Invoice No :"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Location = New System.Drawing.Point(8, 98)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(671, 64)
        Me.Panel9.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel10.Controls.Add(Me.txtItemDesc)
        Me.Panel10.Controls.Add(Me.txtItemCode)
        Me.Panel10.Controls.Add(Me.Label3)
        Me.Panel10.Controls.Add(Me.Label2)
        Me.Panel10.Controls.Add(Me.Label5)
        Me.Panel10.Controls.Add(Me.Label4)
        Me.Panel10.Controls.Add(Me.Label1)
        Me.Panel10.Controls.Add(Me.txtBarcode)
        Me.Panel10.Controls.Add(Me.txtTotal)
        Me.Panel10.Controls.Add(Me.txtPrice)
        Me.Panel10.Controls.Add(Me.txtQuantity)
        Me.Panel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel10.ForeColor = System.Drawing.Color.White
        Me.Panel10.Location = New System.Drawing.Point(6, 5)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(660, 54)
        Me.Panel10.TabIndex = 0
        '
        'txtItemCode
        '
        Me.txtItemCode.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtItemCode.Location = New System.Drawing.Point(116, 28)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(15, 21)
        Me.txtItemCode.TabIndex = 22
        Me.txtItemCode.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(116, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Item Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(10, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Product Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(595, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Total "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(468, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 15)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Price"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(530, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Quantity"
        '
        'txtItemDesc
        '
        Me.txtItemDesc.BackColor = System.Drawing.Color.White
        Me.txtItemDesc.Enabled = False
        Me.txtItemDesc.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtItemDesc.Location = New System.Drawing.Point(116, 28)
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(326, 21)
        Me.txtItemDesc.TabIndex = 14
        '
        'txtBarcode
        '
        Me.txtBarcode.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtBarcode.Location = New System.Drawing.Point(7, 28)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(106, 21)
        Me.txtBarcode.TabIndex = 0
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Enabled = False
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtTotal.Location = New System.Drawing.Point(573, 28)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(75, 21)
        Me.txtTotal.TabIndex = 12
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice
        '
        Me.txtPrice.BackColor = System.Drawing.Color.White
        Me.txtPrice.Enabled = False
        Me.txtPrice.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtPrice.Location = New System.Drawing.Point(446, 28)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(59, 21)
        Me.txtPrice.TabIndex = 16
        Me.txtPrice.Text = "0.00"
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantity
        '
        Me.txtQuantity.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtQuantity.Location = New System.Drawing.Point(510, 28)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(59, 21)
        Me.txtQuantity.TabIndex = 1
        Me.txtQuantity.Text = "1"
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel8.Controls.Add(Me.btnQuantity)
        Me.Panel8.Controls.Add(Me.btnDiscount)
        Me.Panel8.Controls.Add(Me.btnClose)
        Me.Panel8.Controls.Add(Me.btnSettlepayment)
        Me.Panel8.Controls.Add(Me.btnRemoveItem)
        Me.Panel8.Controls.Add(Me.btnNewTran)
        Me.Panel8.Location = New System.Drawing.Point(685, 402)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(273, 217)
        Me.Panel8.TabIndex = 1
        '
        'btnQuantity
        '
        Me.btnQuantity.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnQuantity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuantity.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnQuantity.Image = CType(resources.GetObject("btnQuantity.Image"), System.Drawing.Image)
        Me.btnQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuantity.Location = New System.Drawing.Point(6, 145)
        Me.btnQuantity.Name = "btnQuantity"
        Me.btnQuantity.Size = New System.Drawing.Size(261, 33)
        Me.btnQuantity.TabIndex = 8
        Me.btnQuantity.Text = "Enter &Quantity [F5]"
        Me.btnQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuantity.UseVisualStyleBackColor = False
        '
        'btnDiscount
        '
        Me.btnDiscount.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnDiscount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiscount.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnDiscount.Image = CType(resources.GetObject("btnDiscount.Image"), System.Drawing.Image)
        Me.btnDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDiscount.Location = New System.Drawing.Point(6, 110)
        Me.btnDiscount.Name = "btnDiscount"
        Me.btnDiscount.Size = New System.Drawing.Size(261, 33)
        Me.btnDiscount.TabIndex = 7
        Me.btnDiscount.Text = "&Discount [F4]"
        Me.btnDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDiscount.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(8, 180)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(261, 33)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "&Close [F6]"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSettlepayment
        '
        Me.btnSettlepayment.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnSettlepayment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettlepayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSettlepayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettlepayment.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnSettlepayment.Image = CType(resources.GetObject("btnSettlepayment.Image"), System.Drawing.Image)
        Me.btnSettlepayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSettlepayment.Location = New System.Drawing.Point(6, 75)
        Me.btnSettlepayment.Name = "btnSettlepayment"
        Me.btnSettlepayment.Size = New System.Drawing.Size(261, 33)
        Me.btnSettlepayment.TabIndex = 4
        Me.btnSettlepayment.Text = "&Settle Payment [F3]"
        Me.btnSettlepayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSettlepayment.UseVisualStyleBackColor = False
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnRemoveItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemoveItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveItem.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnRemoveItem.Image = CType(resources.GetObject("btnRemoveItem.Image"), System.Drawing.Image)
        Me.btnRemoveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveItem.Location = New System.Drawing.Point(6, 40)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(261, 33)
        Me.btnRemoveItem.TabIndex = 3
        Me.btnRemoveItem.Text = "&Remove Item [F2]"
        Me.btnRemoveItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemoveItem.UseVisualStyleBackColor = False
        '
        'btnNewTran
        '
        Me.btnNewTran.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnNewTran.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNewTran.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewTran.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewTran.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnNewTran.Image = CType(resources.GetObject("btnNewTran.Image"), System.Drawing.Image)
        Me.btnNewTran.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewTran.Location = New System.Drawing.Point(6, 5)
        Me.btnNewTran.Name = "btnNewTran"
        Me.btnNewTran.Size = New System.Drawing.Size(261, 33)
        Me.btnNewTran.TabIndex = 0
        Me.btnNewTran.Text = "&New Transaction [F1]"
        Me.btnNewTran.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNewTran.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Location = New System.Drawing.Point(686, 263)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(273, 135)
        Me.Panel5.TabIndex = 46
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel7.Controls.Add(Me.lblTotalAmount)
        Me.Panel7.Controls.Add(Me.lblSubTotal)
        Me.Panel7.Controls.Add(Me.Label20)
        Me.Panel7.Controls.Add(Me.lblVAT)
        Me.Panel7.Controls.Add(Me.lblTotalItems)
        Me.Panel7.Controls.Add(Me.Label22)
        Me.Panel7.Controls.Add(Me.Label17)
        Me.Panel7.Controls.Add(Me.Label18)
        Me.Panel7.Controls.Add(Me.Label19)
        Me.Panel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Panel7.Location = New System.Drawing.Point(6, 8)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(262, 120)
        Me.Panel7.TabIndex = 0
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.Location = New System.Drawing.Point(111, 87)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(143, 30)
        Me.lblTotalAmount.TabIndex = 10
        Me.lblTotalAmount.Text = "0.00"
        Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSubTotal
        '
        Me.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSubTotal.Location = New System.Drawing.Point(135, 64)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(118, 20)
        Me.lblSubTotal.TabIndex = 10
        Me.lblSubTotal.Text = "0.00"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 95)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(107, 16)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Total Amount :"
        '
        'lblVAT
        '
        Me.lblVAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVAT.Location = New System.Drawing.Point(135, 41)
        Me.lblVAT.Name = "lblVAT"
        Me.lblVAT.Size = New System.Drawing.Size(118, 20)
        Me.lblVAT.TabIndex = 11
        Me.lblVAT.Text = "0.00"
        Me.lblVAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalItems
        '
        Me.lblTotalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalItems.Location = New System.Drawing.Point(135, 18)
        Me.lblTotalItems.Name = "lblTotalItems"
        Me.lblTotalItems.Size = New System.Drawing.Size(118, 20)
        Me.lblTotalItems.TabIndex = 11
        Me.lblTotalItems.Text = "0"
        Me.lblTotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 44)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 15)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "Vat :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 15)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Sub Total :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 15)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Total Items :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(5, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(127, 15)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Basket Information"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(685, 166)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(273, 93)
        Me.Panel3.TabIndex = 46
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel6.Controls.Add(Me.lblCustName)
        Me.Panel6.Controls.Add(Me.lblCustNo)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Panel6.Location = New System.Drawing.Point(5, 5)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(263, 83)
        Me.Panel6.TabIndex = 0
        '
        'lblCustName
        '
        Me.lblCustName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustName.Location = New System.Drawing.Point(113, 50)
        Me.lblCustName.Name = "lblCustName"
        Me.lblCustName.Size = New System.Drawing.Size(142, 20)
        Me.lblCustName.TabIndex = 5
        Me.lblCustName.Text = "Juan dela Cruz"
        Me.lblCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCustNo
        '
        Me.lblCustNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCustNo.Location = New System.Drawing.Point(113, 26)
        Me.lblCustNo.Name = "lblCustNo"
        Me.lblCustNo.Size = New System.Drawing.Size(142, 20)
        Me.lblCustNo.TabIndex = 6
        Me.lblCustNo.Text = "ADMIN"
        Me.lblCustNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 15)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Name :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Position :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Staff Information"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.dgw)
        Me.Panel4.Location = New System.Drawing.Point(9, 166)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(670, 453)
        Me.Panel4.TabIndex = 43
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.dgw.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw.BackgroundColor = System.Drawing.Color.White
        Me.dgw.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.NavajoWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw.ColumnHeadersHeight = 24
        Me.dgw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductNo, Me.ItemCode, Me.ProdName, Me.UnitPrice, Me.Quantity, Me.Total, Me.Discount})
        Me.dgw.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgw.EnableHeadersVisualStyles = False
        Me.dgw.GridColor = System.Drawing.Color.White
        Me.dgw.Location = New System.Drawing.Point(8, 7)
        Me.dgw.MultiSelect = False
        Me.dgw.Name = "dgw"
        Me.dgw.ReadOnly = True
        Me.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.NavajoWhite
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkSalmon
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgw.RowHeadersVisible = False
        Me.dgw.RowHeadersWidth = 25
        Me.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SandyBrown
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        Me.dgw.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgw.RowTemplate.Height = 18
        Me.dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw.Size = New System.Drawing.Size(654, 437)
        Me.dgw.TabIndex = 42
        '
        'ProductNo
        '
        Me.ProductNo.HeaderText = "Product No"
        Me.ProductNo.Name = "ProductNo"
        Me.ProductNo.ReadOnly = True
        Me.ProductNo.Visible = False
        '
        'ItemCode
        '
        Me.ItemCode.HeaderText = "Item Code"
        Me.ItemCode.Name = "ItemCode"
        Me.ItemCode.ReadOnly = True
        Me.ItemCode.Width = 120
        '
        'ProdName
        '
        Me.ProdName.HeaderText = "Item Description"
        Me.ProdName.Name = "ProdName"
        Me.ProdName.ReadOnly = True
        Me.ProdName.Width = 263
        '
        'UnitPrice
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.UnitPrice.DefaultCellStyle = DataGridViewCellStyle3
        Me.UnitPrice.HeaderText = "Price"
        Me.UnitPrice.Name = "UnitPrice"
        Me.UnitPrice.ReadOnly = True
        Me.UnitPrice.Width = 65
        '
        'Quantity
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 55
        '
        'Total
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle5
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 83
        '
        'Discount
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Discount.DefaultCellStyle = DataGridViewCellStyle6
        Me.Discount.HeaderText = "Discount"
        Me.Discount.Name = "Discount"
        Me.Discount.ReadOnly = True
        Me.Discount.Width = 60
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblDiscount)
        Me.Panel2.Controls.Add(Me.lblDay)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.lblTtime)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Panel13)
        Me.Panel2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Location = New System.Drawing.Point(7, 7)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(950, 86)
        Me.Panel2.TabIndex = 0
        '
        'lblDiscount
        '
        Me.lblDiscount.AutoSize = True
        Me.lblDiscount.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblDiscount.Location = New System.Drawing.Point(730, 13)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(0, 13)
        Me.lblDiscount.TabIndex = 3
        Me.lblDiscount.Visible = False
        '
        'lblDay
        '
        Me.lblDay.BackColor = System.Drawing.Color.White
        Me.lblDay.Font = New System.Drawing.Font("Impact", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDay.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblDay.Location = New System.Drawing.Point(816, 43)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(118, 32)
        Me.lblDay.TabIndex = 2
        Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.White
        Me.Label24.Font = New System.Drawing.Font("Impact", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label24.Location = New System.Drawing.Point(862, 27)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 21)
        Me.Label24.TabIndex = 2
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTtime
        '
        Me.lblTtime.BackColor = System.Drawing.Color.White
        Me.lblTtime.Font = New System.Drawing.Font("Impact", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTtime.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblTtime.Location = New System.Drawing.Point(853, 6)
        Me.lblTtime.Name = "lblTtime"
        Me.lblTtime.Size = New System.Drawing.Size(81, 21)
        Me.lblTtime.TabIndex = 2
        Me.lblTtime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("Impact", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Teal
        Me.Label13.Location = New System.Drawing.Point(320, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(269, 60)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Point of Sale"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.White
        Me.Panel13.Controls.Add(Me.lblStaffID)
        Me.Panel13.Controls.Add(Me.lblVatPercent)
        Me.Panel13.Location = New System.Drawing.Point(7, 5)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(938, 75)
        Me.Panel13.TabIndex = 58
        '
        'lblStaffID
        '
        Me.lblStaffID.AutoSize = True
        Me.lblStaffID.BackColor = System.Drawing.Color.Transparent
        Me.lblStaffID.Location = New System.Drawing.Point(632, 38)
        Me.lblStaffID.Name = "lblStaffID"
        Me.lblStaffID.Size = New System.Drawing.Size(54, 13)
        Me.lblStaffID.TabIndex = 20
        Me.lblStaffID.Text = "STAFF ID"
        Me.lblStaffID.Visible = False
        '
        'lblVatPercent
        '
        Me.lblVatPercent.AutoSize = True
        Me.lblVatPercent.BackColor = System.Drawing.Color.Transparent
        Me.lblVatPercent.Location = New System.Drawing.Point(631, 22)
        Me.lblVatPercent.Name = "lblVatPercent"
        Me.lblVatPercent.Size = New System.Drawing.Size(28, 13)
        Me.lblVatPercent.TabIndex = 19
        Me.lblVatPercent.Text = "VAT"
        Me.lblVatPercent.Visible = False
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSlateGray
        Me.ClientSize = New System.Drawing.Size(1053, 642)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmPOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents lblInvoice As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnQuantity As System.Windows.Forms.Button
    Friend WithEvents btnDiscount As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSettlepayment As System.Windows.Forms.Button
    Friend WithEvents btnRemoveItem As System.Windows.Forms.Button
    Friend WithEvents btnNewTran As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblSubTotal As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblVAT As System.Windows.Forms.Label
    Friend WithEvents lblTotalItems As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblCustName As System.Windows.Forms.Label
    Friend WithEvents lblCustNo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents dgw As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblDiscount As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblTtime As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents lblVatPercent As System.Windows.Forms.Label
    Friend WithEvents ProductNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Discount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblStaffID As System.Windows.Forms.Label
End Class
