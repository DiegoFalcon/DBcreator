Public Class SelectDB
    Dim Dbs() As String

    Sub New(Databases As List(Of String))

       
        InitializeComponent()
        For Each Db As String In Databases
            Listbox_Databases.Items.Add(Db)
        Next
    End Sub

    Sub New()
        InitializeComponent()
    End Sub


    Private Sub Button_Acept_Click(sender As Object, e As EventArgs) Handles Button_Acept.Click

    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub
End Class