Imports System.IO

Public Class frmLutron
    Implements CommandFusion.CFPlugin

    Public Event AddCommand(ByVal sender As CommandFusion.CFPlugin, ByVal newCommand As CommandFusion.SystemCommand) Implements CommandFusion.CFPlugin.AddCommand
    Public Event AddFeedback(ByVal sender As CommandFusion.CFPlugin, ByVal newFB As CommandFusion.SystemFeedback) Implements CommandFusion.CFPlugin.AddFeedback
    Public Event AddMacro(ByVal sender As CommandFusion.CFPlugin, ByVal newMacro As CommandFusion.SystemMacro) Implements CommandFusion.CFPlugin.AddMacro
    Public Event AddMacros(ByVal sender As CommandFusion.CFPlugin, ByVal newMacros As System.Collections.Generic.List(Of CommandFusion.SystemMacro)) Implements CommandFusion.CFPlugin.AddMacros
    Public Event AddSystem(ByVal sender As CommandFusion.CFPlugin, ByVal newSystem As CommandFusion.SystemClass) Implements CommandFusion.CFPlugin.AddSystem
    Public Event AppendSystem(ByVal sender As CommandFusion.CFPlugin, ByVal newSystem As CommandFusion.SystemClass) Implements CommandFusion.CFPlugin.AppendSystem
    Public Event RequestSystemList(ByVal sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.RequestSystemList
    Public Event ToggleWindow(ByVal sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.ToggleWindow
    Public Event WriteToLog(ByVal sender As CommandFusion.CFPlugin, ByVal msg As String) Implements CommandFusion.CFPlugin.WriteToLog
    Public Event RequestMacroList(ByVal sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.RequestMacroList
    Public Event RequestProjectFileInfo(ByVal sender As CommandFusion.CFPlugin) Implements CommandFusion.CFPlugin.RequestProjectFileInfo
    Public Event AddScript(ByVal sender As CommandFusion.CFPlugin, ByVal ScriptRelativePathToProject As String) Implements CommandFusion.CFPlugin.AddScript
    Public Event EditMacro(ByVal sender As CommandFusion.CFPlugin, ByVal existingMacro As String, ByVal newMacro As CommandFusion.SystemMacro) Implements CommandFusion.CFPlugin.EditMacro

    Private theCSV As String
    Private localSystems As List(Of CommandFusion.SystemClass)
    Private commandList As New List(Of CommandFusion.SystemCommand)
    Private feedbackList As New List(Of CommandFusion.SystemFeedback)

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If My.Settings.LastDir <> "" Then
            dlgOpenFile.InitialDirectory = My.Settings.LastDir
        End If
        If dlgOpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' Get the file opened
            theCSV = dlgOpenFile.FileName
            txtFile.Text = theCSV
            My.Settings.LastDir = New FileInfo(theCSV).Directory.FullName
        End If

        ParseCSV()
    End Sub

    Public Sub ParseCSV()
        Try

            ' First check if the CSV file has been selected
            If theCSV = "" Then
                Exit Sub
            End If

            ' Open the CSV file and check for zone names and zone rooms
            If Not File.Exists(theCSV) Then
                MsgBox("File does not exist!")
                Exit Sub
            End If

            Dim stream_reader As StreamReader

            Dim theCSVContents As String
            Try
                stream_reader = New StreamReader(theCSV)
                theCSVContents = stream_reader.ReadToEnd()
            Catch ex As Exception
                MsgBox("Could not open file! Make sure it is not already in use.")
                Exit Sub
            End Try

            stream_reader.Close()
            stream_reader.Dispose()

            theCSVContents.Replace(vbCrLf, vbCr)
            Dim rows As String() = Split(theCSVContents, vbCr)
            ' Start at row 3 (first two rows of report are header information
            Dim DeviceRoom As String = "", DeviceLocation As String = "", DeviceName As String = "", ID As String = "", Component As String = "", ComponentNumber As String = "", Name As String = ""
            Dim ZoneRoom As String = "", ZoneName As String = "", ZoneID As String = ""

            ' Create the list of commands and feedback
            commandList.Clear()
            feedbackList.Clear()
            Dim deviceCount = 0, zoneCount As Integer = 0
            For i As Integer = 2 To rows.Length - 1
                ' First split the row into each value
                Dim values As String() = Split(rows(i), ",")
                ' Next check to see what sort of row we are parsing
                If values.Length = 6 Then
                    If values(0).Trim = "Device Room" Then
                        ' Skip the header row
                        Continue For
                    End If

                    ' Parsing a device row
                    If values(0).Trim <> "" Then
                        DeviceRoom = values(0).Trim
                    End If
                    If values(1).Trim <> "" Then
                        DeviceLocation = values(1).Trim
                    End If
                    If values(2).Trim <> "" Then
                        DeviceName = values(2).Trim
                    End If
                    If values(3).Trim <> "" Then
                        ID = values(3).Trim
                    End If
                    If values(4).Trim <> "" Then
                        Component = values(4).Trim
                    End If
                    If values(5).Trim <> "" Then
                        ComponentNumber = values(5).Trim
                    End If
                    'If values(6).Trim <> "" Then
                    '    Name = values(6)
                    'End If

                    ' Use captured data to create commands and feedback
                    If Component.StartsWith("Button") Then
                        Dim newCmd As New CommandFusion.SystemCommand
                        newCmd.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_Press"
                        newCmd.Value = "#DEVICE," & ID & "," & ComponentNumber & "," & 3 & "\x0D\x0A"
                        commandList.Add(newCmd)
                        Dim newCmd2 As New CommandFusion.SystemCommand
                        newCmd2.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_Release"
                        newCmd2.Value = "#DEVICE," & ID & "," & ComponentNumber & "," & 4 & "\x0D\x0A"
                        commandList.Add(newCmd2)
                    ElseIf Component.StartsWith("Led") Then
                        Dim newCmd As New CommandFusion.SystemCommand
                        newCmd.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_Get"
                        newCmd.Value = "?DEVICE," & ID & "," & ComponentNumber & "," & 9 & "\x0D\x0A"
                        commandList.Add(newCmd)
                        Dim newCmd2 As New CommandFusion.SystemCommand
                        newCmd2.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_SetON"
                        newCmd2.Value = "#DEVICE," & ID & "," & ComponentNumber & "," & 9 & ",1" & "\x0D\x0A"
                        commandList.Add(newCmd2)
                        Dim newCmd3 As New CommandFusion.SystemCommand
                        newCmd3.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_SetOFF"
                        newCmd3.Value = "#DEVICE," & ID & "," & ComponentNumber & "," & 9 & ",0" & "\x0D\x0A"
                        commandList.Add(newCmd3)
                        Dim newFB As New CommandFusion.SystemFeedback
                        newFB.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_Status"
                        newFB.Value = "~DEVICE," & ID & "," & ComponentNumber & ",9,(.)\x0D\x0A"
                        Dim newFBGroup As New CommandFusion.SystemFeedbackElement
                        newFBGroup.Name = "status"
                        newFBGroup.CaptureIndex = 1
                        newFBGroup.DataType = "d"
                        newFBGroup.TargetType = "d"
                        newFBGroup.Join = "0"
                        newFB.DataElements.Add(newFBGroup)
                        feedbackList.Add(newFB)
                    End If

                    deviceCount += 1
                ElseIf values.Length = 4 Then
                    If ZoneRoom = "Zone Room" Then
                        ' Skip the header row
                        Continue For
                    End If

                    ' Parsing a zone row
                    ZoneRoom = values(0)
                    ZoneName = values(1)
                    ZoneID = values(2)

                    ' Use captured data to create commands and feedback
                    Dim newCmd As New CommandFusion.SystemCommand
                    newCmd.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_Get"
                    newCmd.Value = "?OUTPUT," & ZoneID & ",1\x0D\x0A"
                    commandList.Add(newCmd)
                    Dim newCmd2 As New CommandFusion.SystemCommand
                    newCmd2.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_SetSlider"
                    newCmd2.Value = "#OUTPUT," & ZoneID & ",1,[sliderval]\x0D\x0A"
                    commandList.Add(newCmd2)
                    Dim newCmd3 As New CommandFusion.SystemCommand
                    newCmd3.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_SetON"
                    newCmd3.Value = "#OUTPUT," & ZoneID & ",1,100\x0D\x0A"
                    commandList.Add(newCmd3)
                    Dim newCmd4 As New CommandFusion.SystemCommand
                    newCmd4.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_SetOFF"
                    newCmd4.Value = "#OUTPUT," & ZoneID & ",1,0\x0D\x0A"
                    commandList.Add(newCmd4)
                    Dim newFB As New CommandFusion.SystemFeedback
                    newFB.Name = CleanString(DeviceRoom) & "_" & CleanString(DeviceLocation) & "_" & CleanString(Component) & "_Level"
                    newFB.Value = "~OUTPUT," & ZoneID & ",1,(.*?)\x0D\x0A"
                    Dim newFBGroup As New CommandFusion.SystemFeedbackElement
                    newFBGroup.Name = "level"
                    newFBGroup.CaptureIndex = 1
                    newFBGroup.DataType = "a"
                    newFBGroup.TargetType = "a"
                    newFBGroup.MinValue = 0
                    newFBGroup.MaxValue = 100
                    newFBGroup.Join = "0"
                    newFB.DataElements.Add(newFBGroup)
                    feedbackList.Add(newFB)
                    zoneCount += 1
                End If
            Next

            lblDevices.Text = "Devices: " & deviceCount
            lblZones.Text = "Zones: " & zoneCount
            lblCommands.Text = "Commands: " & commandList.Count
            lblFeedback.Text = "Feedback: " & feedbackList.Count
        Catch ex As Exception
            RaiseEvent WriteToLog(Me, ex.ToString)
        End Try
    End Sub

    Private Function CleanString(ByVal StringToClean As String) As String
        ' TODO - clean any unwanted characters from command names.

        ' Remove spaces in strings
        Return StringToClean.Replace(" ", "")

        'Return StringToClean
    End Function

    Public Sub ProjectSelected(ByVal selected As Boolean) Implements CommandFusion.CFPlugin.ProjectSelected
        If selected Then
            ' Can add to current project
            RaiseEvent RequestSystemList(Me)
        Else
            ' Cannot add commands/systems to current project because none is selected in guiDesigner, so dont allow it
            btnApply.Enabled = False
        End If
    End Sub

    Public Sub UpdateSystemList(ByVal systemList As System.Collections.Generic.List(Of CommandFusion.SystemClass)) Implements CommandFusion.CFPlugin.UpdateSystemList
        ' System list has been received
        cboSystem.Items.Clear()

        For Each aSystem As CommandFusion.SystemClass In systemList
            cboSystem.Items.Add(aSystem.Name)
        Next
        If cboSystem.Items.Count Then
            cboSystem.SelectedIndex = 0
            btnApply.Enabled = True
        Else
            btnApply.Enabled = False
        End If

        localSystems = systemList
    End Sub

    Private Function GetSystem(ByVal sysName As String) As CommandFusion.SystemClass
        For Each aSys As CommandFusion.SystemClass In localSystems
            If aSys.Name = sysName Then
                Return aSys
            End If
        Next
        Return Nothing
    End Function

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If cboSystem.SelectedIndex >= 0 Then
            ' Get the selected system by its name
            Dim theSystem As CommandFusion.SystemClass = GetSystem(cboSystem.SelectedItem).Clone

            For Each aCmd As CommandFusion.SystemCommand In commandList
                aCmd.System = theSystem
                theSystem.Commands.Add(aCmd)
            Next
            For Each aFB As CommandFusion.SystemFeedback In feedbackList
                aFB.System = theSystem
                theSystem.Feedback.Add(aFB)
            Next

            RaiseEvent AppendSystem(Me, theSystem)
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RaiseEvent RequestSystemList(Me)
    End Sub

#Region "Plugin Interface"

    Public ReadOnly Property Author() As String Implements CommandFusion.CFPlugin.Author
        Get
            Return "CommandFusion"
        End Get
    End Property

    Public Sub DisposePlugin() Implements CommandFusion.CFPlugin.DisposePlugin
        ' Anything need disposing? Not in this plugin
        ' Usually used to close any network connections, etc.
    End Sub

    Public ReadOnly Property Form() As System.Windows.Forms.Form Implements CommandFusion.CFPlugin.Form
        Get
            Return Me
        End Get
    End Property

    Public Sub Init(ByVal menu As System.Windows.Forms.MainMenu) Implements CommandFusion.CFPlugin.Init
        Dim pluginMenu As New System.Windows.Forms.MenuItem(Me.PluginName)
        Dim showHideMenu As New System.Windows.Forms.MenuItem("Toggle Window")
        AddHandler showHideMenu.Click, AddressOf DoToggleWindow
        pluginMenu.MenuItems.Add(showHideMenu)
        menu.MenuItems.Add(pluginMenu)
    End Sub

    Private Sub DoToggleWindow(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent ToggleWindow(Me)
    End Sub

    Public ReadOnly Property PluginName() As String Implements CommandFusion.CFPlugin.Name
        Get
            Return "Lutron RadioRA2"
        End Get
    End Property

    Public Sub GetProjectFileInfo(ByVal ProjectFile As System.IO.FileInfo) Implements CommandFusion.CFPlugin.GetProjectFileInfo

    End Sub

    Public Sub UpdateMacroList(ByVal systemList As System.Collections.Generic.List(Of CommandFusion.SystemMacro)) Implements CommandFusion.CFPlugin.UpdateMacroList

    End Sub
#End Region


End Class