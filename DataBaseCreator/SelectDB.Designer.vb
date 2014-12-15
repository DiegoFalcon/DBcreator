<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDB
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
        Me.Listbox_Databases = New System.Windows.Forms.ListBox()
        Me.Button_Acept = New System.Windows.Forms.Button()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Listbox_Databases
        '
        Me.Listbox_Databases.FormattingEnabled = True
        Me.Listbox_Databases.ItemHeight = 16
        Me.Listbox_Databases.Location = New System.Drawing.Point(12, 53)
        Me.Listbox_Databases.Name = "Listbox_Databases"
        Me.Listbox_Databases.Size = New System.Drawing.Size(400, 276)
        Me.Listbox_Databases.TabIndex = 0
        '
        'Button_Acept
        '
        Me.Button_Acept.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_Acept.Location = New System.Drawing.Point(252, 337)
        Me.Button_Acept.Name = "Button_Acept"
        Me.Button_Acept.Size = New System.Drawing.Size(75, 23)
        Me.Button_Acept.TabIndex = 1
        Me.Button_Acept.Text = "Acept"
        Me.Button_Acept.UseVisualStyleBackColor = True
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Location = New System.Drawing.Point(337, 337)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancel.TabIndex = 2
        Me.Button_Cancel.Text = "Cancel"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select the DataBase you want to use:"
        '
        'SelectDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(424, 372)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_Acept)
        Me.Controls.Add(Me.Listbox_Databases)
        Me.Name = "SelectDB"
        Me.Text = "SelectDB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Listbox_Databases As System.Windows.Forms.ListBox
    Friend WithEvents Button_Acept As System.Windows.Forms.Button
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
