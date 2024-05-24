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

// Class consisting of the parts in a package. (I also break a C# rule by camelCasing the public fields, it's to prevent problems from overlapping variables etc)
public class Package
{
    public RequestType requestType { get; set; }
    public string data { get; set; }
    public string userID { get; set; }
    public string password { get; set; }
    public string loginResult { get; set; }
}

// Closes application when called (I.E when a program window is closed)
public static class ApplicationExitHandler
{
    public static void OnWindowClosing(object sender, FormClosingEventArgs e)
    {
        Application.Exit();
    }
}