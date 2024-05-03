Imports System.IO
Imports System
Imports Microsoft.WindowsMobile.Status
Public Class Device
    'VB
    <Runtime.InteropServices.DllImport("coredll")> _
    Private Shared Function GetSystemPowerStatusEx( _
      ByVal lpSystemPowerStatus As SYSTEM_POWER_STATUS_EX, _
      ByVal fUpdate As Boolean) As System.UInt32
    End Function
    <Runtime.InteropServices.DllImport("coredll")> _
    Private Shared Function GetSystemPowerStatusEx2(ByVal _
      lpSystemPowerStatus As SYSTEM_POWER_STATUS_EX2, _
      ByVal dwLen As System.UInt32, ByVal fUpdate As Boolean) _
      As System.UInt32
    End Function

    Private Sub BackUpData()
        If Data.IsConnected = True Then
            Data.CloseConnection()
        End If
    End Sub
    Public Shared Function GetBackUpPowerStatus() As String
        Dim retByte As Byte
        Dim status2 As New SYSTEM_POWER_STATUS_EX2
        If Convert.ToInt32(GetSystemPowerStatusEx2(status2, Convert.ToUInt32(Runtime.InteropServices.Marshal.SizeOf(status2)), False)) = _
            Runtime.InteropServices.Marshal.SizeOf(status2) Then
            retByte = status2.BackupBatteryLifePercent
        End If
        Return retByte
    End Function
    Public Shared Function GetMainPowerStatus() As Byte
        Dim retByte As Byte
        Dim status As New SYSTEM_POWER_STATUS_EX


        If Convert.ToInt32(GetSystemPowerStatusEx(status, False)) = 1 Then
            retByte = status.BatteryLifePercent
        End If
        Return retByte
    End Function
    Public Shared Function ActiveSyncConnection() As String
        Select Case SystemState.ActiveSyncStatus
            Case ActiveSyncStatus.Error
                Return "Error connecting ActiveSync"
            Case ActiveSyncStatus.None
                Return "No ActiveSync connection"
            Case ActiveSyncStatus.Synchronizing
                Return "ActiveSync synchronizing"
            Case Else
                Return "No ActiveSync connection"
        End Select
    End Function
End Class

Public Class SYSTEM_POWER_STATUS_EX2
    Public ACLineStatus As Byte
    Public BatteryFlag As Byte
    Public BatteryLifePercent As Byte
    Public Reserved1 As Byte
    Public BatteryLifeTime As System.UInt32
    Public BatteryFullLifeTime As System.UInt32
    Public Reserved2 As Byte
    Public BackupBatteryFlag As Byte
    Public BackupBatteryLifePercent As Byte
    Public Reserved3 As Byte
    Public BackupBatteryLifeTime As System.UInt32
    Public BackupBatteryFullLifeTime As System.UInt32
    Public BatteryVoltage As System.UInt32
    Public BatteryCurrent As System.UInt32
    Public BatteryAverageCurrent As System.UInt32
    Public BatteryAverageInterval As System.UInt32
    Public BatterymAHourConsumed As System.UInt32
    Public BatteryTemperature As System.UInt32
    Public BackupBatteryVoltage As System.UInt32
    Public BatteryChemistry As Byte
End Class 'SYSTEM_POWER_STATUS_EX2

Public Class SYSTEM_POWER_STATUS_EX
    Public ACLineStatus As Byte
    Public BatteryFlag As Byte
    Public BatteryLifePercent As Byte
    Public Reserved1 As Byte
    Public BatteryLifeTime As System.UInt32
    Public BatteryFullLifeTime As System.UInt32
    Public Reserved2 As Byte
    Public BackupBatteryFlag As Byte
    Public BackupBatteryLifePercent As Byte
    Public Reserved3 As Byte
    Public BackupBatteryLifeTime As System.UInt32
    Public BackupBatteryFullLifeTime As System.UInt32
End Class 'SYSTEM_POWER_STATUS_EX
Public Class Sound
    Private m_soundBytes() As Byte
    Private m_fileName As String

    Public Declare Function WCE_PlaySound Lib "CoreDll.dll" Alias "PlaySound" (ByVal szSound As String, ByVal hMod As IntPtr, ByVal flags As Integer) As Integer
    Public Declare Function WCE_PlaySoundBytes Lib "CoreDll.dll" Alias "PlaySound" (ByVal szSound() As Byte, ByVal hMod As IntPtr, ByVal flags As Integer) As Integer



    Private Enum Flags
        SND_SYNC = &H0 ' play synchronously (default) 
        SND_ASYNC = &H1 ' play asynchronously 
        SND_NODEFAULT = &H2 ' silence (!default) if sound not found 
        SND_MEMORY = &H4 ' pszSound points to a memory file 
        SND_LOOP = &H8 ' loop the sound until next sndPlaySound 
        SND_NOSTOP = &H10 ' don't stop any currently playing sound 
        SND_NOWAIT = &H2000 ' don't wait if the driver is busy 
        SND_ALIAS = &H10000 ' name is a registry alias 
        SND_ALIAS_ID = &H110000 ' alias is a predefined ID 
        SND_FILENAME = &H20000 ' name is file name 
        SND_RESOURCE = &H40004 ' name is resource name or atom 
    End Enum
    ' Construct the Sound object to play sound data from the specified file.
    Public Sub New(ByVal fileName As String)
        m_fileName = fileName
    End Sub

    ' Construct the Sound object to play sound data from the specified stream.
    Public Sub New(ByVal stream As Stream)
        ' read the data from the stream
        m_soundBytes = New Byte(stream.Length) {}
        stream.Read(m_soundBytes, 0, Fix(stream.Length))
    End Sub 'New


    ' Play the sound
    Public Sub Play()
        ' If a file name has been registered, call WCE_PlaySound, 
        ' otherwise call WCE_PlaySoundBytes.
        If Not (m_fileName Is Nothing) Then
            WCE_PlaySound(m_fileName, IntPtr.Zero, Fix(Flags.SND_ASYNC Or Flags.SND_FILENAME))
        Else
            WCE_PlaySoundBytes(m_soundBytes, IntPtr.Zero, Fix(Flags.SND_ASYNC Or Flags.SND_MEMORY))
        End If
    End Sub
End Class

