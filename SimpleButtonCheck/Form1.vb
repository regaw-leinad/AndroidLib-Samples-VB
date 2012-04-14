Imports RegawMOD.Android

Public Class Form1

    Dim android As AndroidController
    Dim device As Device

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Usually, you want to load this at startup, may take up to 5 seconds to initialize/set up resources/start server
        android = AndroidController.Instance
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim serial As String

        'Always call UpdateDeviceList() before using AndroidController on devices to get the most updated list
        android.UpdateDeviceList()

        If (android.HasConnectedDevices) Then
            serial = android.ConnectedDevices(0)
            device = android.GetConnectedDevice(serial)
            TextBox1.Text = device.SerialNumber
        Else
            TextBox1.Text = "Error - No Devices Connected"
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'ALWAYS remember to call this when you're done with AndroidController.  It removes the resources used by this library!
        android.Dispose()
    End Sub
End Class
