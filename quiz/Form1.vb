Imports System.Security.Cryptography

Public Class Form1
    Dim a(5, 5) As Button
    Dim b(5, 5) As Button
    Dim block As Image = CType(My.Resources.ResourceManager.GetObject("box"), Image)
    Dim counter As Integer = 1
    Public Row = 4
    Public Col = 4
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i, j As Integer
        For i = 0 To Row
            For j = 0 To Col
                b(i, j) = New Button
                Me.Controls.Add(b(i, j))
                b(i, j).Location = New System.Drawing.Point(220 + j * 40, 10 + i * 40)
                b(i, j).Size = New System.Drawing.Size(40, 40)
                b(i, j).FlatStyle = FlatStyle.Flat
            Next
        Next

        getnumber()

        For i = 0 To Row
            For j = 0 To Col
                a(i, j) = New Button
                Me.Controls.Add(a(i, j))
                a(i, j).Location = New System.Drawing.Point(10 + j * 40, 10 + i * 40)
                a(i, j).Size = New System.Drawing.Size(40, 40)
                a(i, j).Text = counter
                a(i, j).FlatStyle = FlatStyle.Flat
                AddHandler a(i, j).Click, AddressOf handling
                counter += 1
            Next
        Next
    End Sub

    Private Sub getnumber()
        Dim r As Random
        Dim Number, No1, No2, temp1, temp2 As Integer
        Dim n As Integer = 1

        For i = 0 To Row
            For j = 0 To Col
                b(i, j).Tag = n
                b(i, j).BackgroundImage = block
                b(i, j).BackgroundImageLayout = ImageLayout.Stretch
                n += 1
            Next
        Next

        r = New Random()
        For i = 0 To Row
            For j = 0 To Col
                Number = r.Next((Row + 1) * (Col + 1) - 1)
                No1 = Number \ (Row + 1)
                No2 = Number Mod (Col + 1)

                temp1 = b(i, j).Tag
                temp2 = b(No1, No2).Tag
                b(i, j).Tag = temp2
                b(No1, No2).Tag = temp1
            Next
        Next

    End Sub

    Private Sub handling(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i, j, n As Integer
        Dim btn = CType(sender, Button)
        n = btn.Text
        btn.Enabled = False

        For i = 0 To Row
            For j = 0 To Col
                If b(i, j).Tag = n Then
                    b(i, j).BackgroundImage = Nothing
                    b(i, j).Text = b(i, j).Tag
                    b(i, j).ForeColor = Color.Red
                    b(i, j).FlatAppearance.BorderColor = Color.Red
                End If
            Next
        Next
    End Sub
End Class

