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
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

// IMPORTANT INFO: WHEN SERVER IS FULLY DONE, SWITCH THE PROJECT FROM A CONSOLE PROJECT TO A WINDOWS PROJECT!

// TODO: Revamp the client list and turn it into a class that stores both the tcp and the user id for future use
// Each client is an object of that class

namespace server
{
    public partial class Server : Form
    {
        private TcpListener _listener;
        private List<ConnectedClient> _clientList = new List<ConnectedClient>();
        private int _port = 12345;

        public Server()
        {
            InitializeComponent();
        }

        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, _port);
                _listener.Start();
            

                btnStartServer.Enabled = false;

                while (true)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();

                    ConnectedClient connectedClient = new ConnectedClient(client);

                    // Prevents multiple threads from running this code block at the same time
                    lock (_clientList) 
                    {
                        _clientList.Add(connectedClient);
                    }

                    // Runs a new thread with the assigned client
                    await Task.Run(() => StartListening(connectedClient));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        // Listens for new messages
        public async void StartListening(ConnectedClient client)
        {
            try
            {
                using (StreamReader reader = new StreamReader(client.Client.GetStream(), Encoding.Unicode))
                {
                    while (client.Client.Connected)
                    {
                        // Collects package and prepares it for interpretation
                        string delivery = await reader.ReadLineAsync();
                        var package = JsonConvert.DeserializeObject<Package>(delivery);
                        string message = package.data.ToString();

                        // If the client sent a broadcast package, broadcast the data inside
                        if (package.requestType == RequestType.Broadcast)
                        {
                            Broadcast(message);
                        }                        

                        // if the package is null (i.e client disconnected) then safely handle the disconnect
                        if (message == null)
                        {
                            tbxInbox.Text = "Client Disconnected";

                            lock (_clientList)
                            {
                                _clientList.Remove(client);
                            }

                            break;
                        }

                        tbxInbox.Text += message + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Reading Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        // Sends a message to every connected client, including the one that sent the message
        public async void Broadcast(string message)
        {
            try
            {
                foreach (ConnectedClient client in _clientList)
                {
                    await client.Writer.WriteLineAsync(message);
                    client.Writer.Flush();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Broadcasting Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }
    }

    // Class consisting of common client properties and functions
    public class ConnectedClient
    {
        public TcpClient Client;
        public StreamWriter Writer;
        //public string UserID;

        public ConnectedClient(TcpClient client/*, string userID*/)
        {
            Client = client;
            Writer = new StreamWriter(Client.GetStream(), Encoding.Unicode);
            //UserID = userID;
        }
    }

    // Class consisting of the parts in a package. (I also break a C# rule by camelCasing the public fields, it's to prevent problems from overlapping variables etc)
    public class Package
    {
        public string data {  get; set; }
        public RequestType requestType { get; set; }
        public string loginResult { get; set; }
    }

    // Enumerator of all types of requests
    public enum RequestType
    {
        Broadcast,
        Whisper,
        Login,
        Register,
        Command
    }
}