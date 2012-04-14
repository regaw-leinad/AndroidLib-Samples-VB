Imports RegawMOD.Android

Public Class Form1

    Dim android As AndroidController
    Dim device As Device

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Usually, you want to load this at startup, may take up to 5 seconds to initialize/set up resources/start server
        android = AndroidController.Instance
    End Sub

    Private Sub Form1_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'ALWAYS remember to call this when you're done with AndroidController.  It removes used resources
        android.Dispose()
    End Sub

    Private Sub button1_Click(sender As System.Object, e As System.EventArgs) Handles button1.Click
        Dim serial As String

        'Always call UpdateDeviceList() before using AndroidController on devices to get the most updated list
        android.UpdateDeviceList()

        listBox1.Items.Clear()

        label2.Text = "-null-"

        If android.HasConnectedDevices Then
            serial = android.ConnectedDevices(0)
            device = android.GetConnectedDevice(serial)

            'Adds all of the build.prop keys to the listbox
            listBox1.Items.AddRange(device.BuildProp.Keys.ToArray)

            'So no items are selected right away
            listBox1.SelectedIndex = -1

        End If
    End Sub

    Private Sub listBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles listBox1.SelectedIndexChanged
        label2.Text = device.BuildProp.GetProp(listBox1.SelectedItem.ToString())
    End Sub
End Class