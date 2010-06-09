<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemBrowser
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.VScrl = New System.Windows.Forms.VScrollBar
        Me.SuspendLayout()
        '
        'VScrl
        '
        Me.VScrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrl.Location = New System.Drawing.Point(123, 0)
        Me.VScrl.Name = "VScrl"
        Me.VScrl.Size = New System.Drawing.Size(17, 339)
        Me.VScrl.TabIndex = 0
        '
        'ItemBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.VScrl)
        Me.DoubleBuffered = True
        Me.Name = "ItemBrowser"
        Me.Size = New System.Drawing.Size(140, 339)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VScrl As System.Windows.Forms.VScrollBar

End Class
