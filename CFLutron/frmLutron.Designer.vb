<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLutron
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
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.lblSelectFile = New System.Windows.Forms.Label
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog
        Me.grpStats = New System.Windows.Forms.GroupBox
        Me.lblFeedback = New System.Windows.Forms.Label
        Me.lblCommands = New System.Windows.Forms.Label
        Me.lblDevices = New System.Windows.Forms.Label
        Me.lblZones = New System.Windows.Forms.Label
        Me.cboSystem = New System.Windows.Forms.ComboBox
        Me.lblSystem = New System.Windows.Forms.Label
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.grpStats.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(139, 23)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(77, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblSelectFile
        '
        Me.lblSelectFile.AutoSize = True
        Me.lblSelectFile.Location = New System.Drawing.Point(12, 9)
        Me.lblSelectFile.Name = "lblSelectFile"
        Me.lblSelectFile.Size = New System.Drawing.Size(171, 13)
        Me.lblSelectFile.TabIndex = 1
        Me.lblSelectFile.Text = "Select Lutron integration report file:"
        '
        'txtFile
        '
        Me.txtFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFile.Location = New System.Drawing.Point(12, 25)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(121, 20)
        Me.txtFile.TabIndex = 2
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.Filter = "Lutron Reports|*.csv"
        '
        'grpStats
        '
        Me.grpStats.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStats.Controls.Add(Me.lblFeedback)
        Me.grpStats.Controls.Add(Me.lblCommands)
        Me.grpStats.Controls.Add(Me.lblDevices)
        Me.grpStats.Controls.Add(Me.lblZones)
        Me.grpStats.Location = New System.Drawing.Point(12, 52)
        Me.grpStats.Name = "grpStats"
        Me.grpStats.Size = New System.Drawing.Size(202, 76)
        Me.grpStats.TabIndex = 3
        Me.grpStats.TabStop = False
        Me.grpStats.Text = "Statistics"
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoSize = True
        Me.lblFeedback.Location = New System.Drawing.Point(109, 48)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(58, 13)
        Me.lblFeedback.TabIndex = 3
        Me.lblFeedback.Text = "Feedback:"
        '
        'lblCommands
        '
        Me.lblCommands.AutoSize = True
        Me.lblCommands.Location = New System.Drawing.Point(6, 48)
        Me.lblCommands.Name = "lblCommands"
        Me.lblCommands.Size = New System.Drawing.Size(62, 13)
        Me.lblCommands.TabIndex = 2
        Me.lblCommands.Text = "Commands:"
        '
        'lblDevices
        '
        Me.lblDevices.AutoSize = True
        Me.lblDevices.Location = New System.Drawing.Point(118, 23)
        Me.lblDevices.Name = "lblDevices"
        Me.lblDevices.Size = New System.Drawing.Size(49, 13)
        Me.lblDevices.TabIndex = 1
        Me.lblDevices.Text = "Devices:"
        '
        'lblZones
        '
        Me.lblZones.AutoSize = True
        Me.lblZones.Location = New System.Drawing.Point(28, 23)
        Me.lblZones.Name = "lblZones"
        Me.lblZones.Size = New System.Drawing.Size(40, 13)
        Me.lblZones.TabIndex = 0
        Me.lblZones.Text = "Zones:"
        '
        'cboSystem
        '
        Me.cboSystem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSystem.FormattingEnabled = True
        Me.cboSystem.Location = New System.Drawing.Point(12, 147)
        Me.cboSystem.Name = "cboSystem"
        Me.cboSystem.Size = New System.Drawing.Size(204, 21)
        Me.cboSystem.TabIndex = 4
        '
        'lblSystem
        '
        Me.lblSystem.AutoSize = True
        Me.lblSystem.Location = New System.Drawing.Point(9, 131)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(199, 13)
        Me.lblSystem.TabIndex = 5
        Me.lblSystem.Text = "Select the system to apply commands to:"
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(137, 174)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(77, 23)
        Me.btnApply.TabIndex = 6
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(12, 174)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(77, 23)
        Me.btnRefresh.TabIndex = 7
        Me.btnRefresh.Text = "Refresh List"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'frmLutron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(228, 207)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.lblSystem)
        Me.Controls.Add(Me.cboSystem)
        Me.Controls.Add(Me.grpStats)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.lblSelectFile)
        Me.Controls.Add(Me.btnBrowse)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(228, 207)
        Me.Name = "frmLutron"
        Me.Text = "Lutron Plugin"
        Me.grpStats.ResumeLayout(False)
        Me.grpStats.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblSelectFile As System.Windows.Forms.Label
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents grpStats As System.Windows.Forms.GroupBox
    Friend WithEvents lblZones As System.Windows.Forms.Label
    Friend WithEvents lblDevices As System.Windows.Forms.Label
    Friend WithEvents cboSystem As System.Windows.Forms.ComboBox
    Friend WithEvents lblSystem As System.Windows.Forms.Label
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents lblCommands As System.Windows.Forms.Label
End Class
