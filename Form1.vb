Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab

Public Class Form1
    Private items As New List(Of String)()
    Private total As Decimal = 0D
    Private Sub btnAmount_Click(sender As Object, e As EventArgs) Handles btnAmount.Click
        'calculate amount of each item
        Dim qty1 As Decimal = CDec(txtQty1.Text)
        Dim qty2 As Decimal = CDec(txtQty2.Text)
        Dim qty3 As Decimal = CDec(txtQty3.Text)
        Dim qty4 As Decimal = CDec(txtQty4.Text)
        Dim price1 As Decimal = CDec(txtPrice1.Text)
        Dim price2 As Decimal = CDec(txtPrice2.Text)
        Dim price3 As Decimal = CDec(txtPrice3.Text)
        Dim price4 As Decimal = CDec(txtPrice4.Text)
        Dim amount1 As Decimal = (qty1 * price1)
        Dim amount2 As Decimal = (qty2 * price2)
        Dim amount3 As Decimal = (qty3 * price3)
        Dim amount4 As Decimal = (qty4 * price4)
        'display results in the amount4 textbox
        txtAmount1.Text = amount1.ToString()
        txtAmount2.Text = amount2.ToString()
        txtAmount3.Text = amount3.ToString()
        txtAmount4.Text = amount4.ToString()
    End Sub

    Private Sub btnSubTotal_Click(sender As Object, e As EventArgs) Handles btnSubTotal.Click
        Dim qty1 As Decimal = CDec(txtQty1.Text)
        Dim qty2 As Decimal = CDec(txtQty2.Text)
        Dim qty3 As Decimal = CDec(txtQty3.Text)
        Dim qty4 As Decimal = CDec(txtQty4.Text)
        Dim price1 As Decimal = CDec(txtPrice1.Text)
        Dim price2 As Decimal = CDec(txtPrice2.Text)
        Dim price3 As Decimal = CDec(txtPrice3.Text)
        Dim price4 As Decimal = CDec(txtPrice4.Text)
        Dim amount1 As Decimal = (qty1 * price1)
        Dim amount2 As Decimal = (qty2 * price2)
        Dim amount3 As Decimal = (qty3 * price3)
        Dim amount4 As Decimal = (qty4 * price4)
        'calculate the subtatal
        Dim subtotal = (amount1 + amount2 + amount3 + amount4)
        'display subtotal results
        txtSubTotal.Text = subtotal.ToString()
    End Sub

    Private Sub btnVat_Click(sender As Object, e As EventArgs) Handles btnVat.Click
        Dim qty1 As Decimal = txtQty1.Text
        Dim qty2 As Decimal = txtQty2.Text
        Dim qty3 As Decimal = txtQty3.Text
        Dim qty4 As Decimal = txtQty4.Text
        Dim price1 As Decimal = txtPrice1.Text
        Dim price2 As Decimal = txtPrice2.Text
        Dim price3 As Decimal = txtPrice3.Text
        Dim price4 As Decimal = txtPrice4.Text
        Dim amount1 = qty1 * price1
        Dim amount2 = qty2 * price2
        Dim amount3 = qty3 * price3
        Dim amount4 = qty4 * price4
        Dim subtotal = amount1 + amount2 + amount3 + amount4
        Dim vat As Decimal = 0.18 * subtotal
        'diplay vat results
        txtVat.Text = vat.ToString()
    End Sub

    Private Sub btnAddItems_Click(sender As Object, e As EventArgs) Handles btnAddItems.Click
        Dim itemName As String = txtItem.Text
        Dim itemPrice As Decimal

        If Decimal.TryParse(txtPrice.Text, itemPrice) Then
            items.Add(itemName & " - shs" & itemPrice.ToString("F2"))
            total += itemPrice

            ' Update the receipt display
            txtReceipt.Text &= itemName & " - shs" & itemPrice.ToString("F2") & Environment.NewLine
            txtTotal.Text = total.ToString("F2")

            ' Clear input fields
            txtItem.Clear()
            txtPrice.Clear()
            txtItem.Focus()
        Else
            MessageBox.Show("Please enter a valid price.")
        End If
    End Sub


    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        MessageBox.Show("Total Amount: shs" & total.ToString("F2"))
    End Sub



    Private Sub PrintReceipt()
        Dim printDialog As New PrintDialog()
        printDialog.Document = PrintDocument1

        If printDialog.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub printDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font As New Font("Arial", 12)
        Dim x As Single = 100
        Dim y As Single = 100

        ' Print each item in the receipt
        For Each item As String In items
            e.Graphics.DrawString(item, font, Brushes.Black, x, y)
            y += font.GetHeight(e.Graphics) ' Move down for the next line
        Next
    End Sub

    Private Sub btnTamount_Click(sender As Object, e As EventArgs) Handles btnTamount.Click
        Dim qty1 As Decimal = txtQty1.Text
        Dim qty2 As Decimal = txtQty2.Text
        Dim qty3 As Decimal = txtQty3.Text
        Dim qty4 As Decimal = txtQty4.Text
        Dim price1 As Decimal = txtPrice1.Text
        Dim price2 As Decimal = txtPrice2.Text
        Dim price3 As Decimal = txtPrice3.Text
        Dim price4 As Decimal = txtPrice4.Text
        Dim amount1 = qty1 * price1
        Dim amount2 = qty2 * price2
        Dim amount3 = qty3 * price3
        Dim amount4 = qty4 * price4
        Dim subtotal = amount1 + amount2 + amount3 + amount4
        Dim discount As Decimal = (0.1 * subtotal)
        Dim tamount As Decimal = (subtotal - discount)
        'displaydiscount
        txtTamount.Text = tamount.ToString()
    End Sub

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        Dim qty1 As Decimal = txtQty1.Text
        Dim qty2 As Decimal = txtQty2.Text
        Dim qty3 As Decimal = txtQty3.Text
        Dim qty4 As Decimal = txtQty4.Text
        Dim price1 As Decimal = txtPrice1.Text
        Dim price2 As Decimal = txtPrice2.Text
        Dim price3 As Decimal = txtPrice3.Text
        Dim price4 As Decimal = txtPrice4.Text
        Dim amount1 = qty1 * price1
        Dim amount2 = qty2 * price2
        Dim amount3 = qty3 * price3
        Dim amount4 = qty4 * price4
        Dim subtotal = amount1 + amount2 + amount3 + amount4
        Dim discount As Decimal = (0.1 * subtotal)
        'displaydiscount
        txtDiscount.Text = discount.ToString()
    End Sub




    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim printDialog As New PrintDialog()
        printDialog.Document = PrintDocument1
        txtTransId.Text = Guid.NewGuid().ToString

        If printDialog.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Set the font and other properties
        Dim font As New Font("Arial", 12)
        Dim brush As New SolidBrush(Color.Black)

        ' Define the receipt content
        Dim receiptContent As String = "CHINA TOWN  STORE  RECEIPT" & Environment.NewLine &
                                    "----------------------------------------" & Environment.NewLine &
                                    " First Come First Serve" & Environment.NewLine &
                                   "0784891238 0753176738" & Environment.NewLine &
                                   "ChinaTown200@gmail.com" & Environment.NewLine &
                                   "Transaction ID: " & txtTransId.Text & Environment.NewLine &
                                   "Receipt No: " & txtReceiptno.Text & Environment.NewLine &
                                   "Date: " & DateTime.Now.ToString("dddd, d MMMM yyyy") & Environment.NewLine &
                                   "Customer Name:" & Environment.NewLine &
                                   "Name:" & txtClient.Text & Environment.NewLine &
                                   "----------------------------------------" & Environment.NewLine &
                                   "ITEMS:" & Environment.NewLine &
                                    "1." & txtItem1.Text & "  " & txtQty1.Text & "pcs" & Environment.NewLine &
                                    "2." & txtItem2.Text & "  " & txtQty2.Text & "pcs" & Environment.NewLine &
                                    "3." & txtItem3.Text & "  " & txtQty3.Text & "pcs" & Environment.NewLine &
                                    "4." & txtItem4.Text & "  " & txtQty4.Text & "pcs" & Environment.NewLine

        receiptContent &= "----------------------------------------" & Environment.NewLine &
                          "Subtotal: " & txtSubTotal.Text & Environment.NewLine &
                          "VAT: " & txtVat.Text & Environment.NewLine &
                          "Discount: " & txtDiscount.Text & Environment.NewLine &
                          "Total Amount: " & txtTamount.Text & Environment.NewLine &
                          "----------------------------------------" & Environment.NewLine &
                          "Payment Method: " & cboPaymentMethod.Text & Environment.NewLine &
                          "Served By: " & txtServedBy.Text

        ' Print the content
        e.Graphics.DrawString(receiptContent, font, brush, 10, 10)


    End Sub


End Class