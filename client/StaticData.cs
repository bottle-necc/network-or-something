using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

// Enumerator of all types of requests
public enum RequestType
{
    Broadcast,
    Whisper,
    Login,
    Register,
    Command
}

// Closes application when called (I.E when a program window is closed)
public static class ApplicationExitHandler
{
    public static void OnWindowClosing(object sender, FormClosingEventArgs e)
    {
        Application.Exit();
    }
}