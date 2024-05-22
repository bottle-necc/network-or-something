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

public static class ServerConnection
{
    public static TcpClient Client { get; set; }
}

public enum RequestType
{
    // Sends message to all connected clients
    Message,

    // Sends message to specified client
    Whisper,

    // Sent while a client logs in
    Login,
    LoginSuccess,
    LoginError,

    // Sent while a client registers
    Register,
    RegisterSuccess,
    RegisterError,

    // Commands

}