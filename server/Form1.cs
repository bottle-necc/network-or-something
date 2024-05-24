﻿using System;
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
using Newtonsoft.Json.Linq;

// IMPORTANT INFO: WHEN SERVER IS FULLY DONE, SWITCH THE PROJECT FROM A CONSOLE PROJECT TO A WINDOWS PROJECT!

namespace server
{
    public partial class Server : Form
    {
        private TcpListener _listener;
        private List<ConnectedClient> _clientList = new List<ConnectedClient>();
        private string _loginDataPath = $"{Directory.GetCurrentDirectory()}/loginData.json";
        private int _port = 12345;
        private JObject _loginData = new JObject();

        public Server()
        {
            InitializeComponent();
            CheckForJson();
        }

        // Checks and loads the loginData file. Creates a new one if its missing.
        public void CheckForJson()
        {
            try
            {
                if (File.Exists(_loginDataPath))
                {
                    // Reads all the data in the file and stores it
                    string strData = File.ReadAllText(_loginDataPath);
                    _loginData = JObject.Parse(strData);
                }
                else
                {
                    // If the file is missing, create a new one
                    MessageBox.Show("There was a problem loading the login data file. It may have been moved, corrupted or destroyed. A new one will be generated", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter w = new StreamWriter(_loginDataPath)) { w.Write("{}"); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
        }

        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, _port);
                _listener.Start();
            

                btnStartServer.Enabled = false;

                // Accepts new client connections and runs a new thread for the specific client
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

        // Listens for new messages from assigned client
        public async void StartListening(ConnectedClient client)
        {
            try
            {
                using (StreamReader reader = new StreamReader(client.Client.GetStream(), Encoding.Unicode))
                {
                    while (client.Client.Connected)
                    {
                        string message = "";

                        // Collects package and prepares it for interpretation
                        string delivery = await reader.ReadLineAsync();

                        // Removes a faulty character that appears for whatever reason
                        if (delivery[0] != '{')
                        {
                            delivery = delivery.Substring(1);
                        }

                        Package package = JsonConvert.DeserializeObject<Package>(delivery);

                        // Checks if the package includes any data before 
                        if (package.data != null)
                        {
                           message = package.data.ToString();
                        }

                        // If the client sent a broadcast package, broadcast the data inside
                        if (package.requestType == RequestType.Broadcast)
                        {
                            Broadcast(message, client);
                        }
                        else if (package.requestType == RequestType.Login)
                        {
                            Login(client, package.userID, package.password);
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
        public async void Broadcast(string message, ConnectedClient client)
        {
            try
            {
                // Creates a broadcast package
                var package = new
                {
                    requestType = RequestType.Broadcast,
                    data = $"{client.UserID}: {message}",
                };

                // Prepares it for delivery
                string delivery = JsonConvert.SerializeObject(package);

                // Delivers the package to all connected clients
                foreach (ConnectedClient connectedClient in _clientList)
                {
                    await connectedClient.Writer.WriteLineAsync(delivery);
                    connectedClient.Writer.Flush();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Broadcasting Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        // Handles the client login procedure
        public async void Login(ConnectedClient client, string userID, string password)
        {
            try
            {
                if (!_loginData.ContainsKey(userID))
                {
                    // Preparing the package with response
                    Package package = new Package
                    {
                        requestType = RequestType.Login,
                        loginResult = "Incorrect",
                    };
                    string delivery = JsonConvert.SerializeObject(package);

                    // Sending to client
                    await client.Writer.WriteLineAsync(delivery);
                    client.Writer.Flush();
                }
                else if (_loginData[userID].ToString() != password)
                {
                    // Preparing the package with response
                    Package package = new Package
                    {
                        requestType = RequestType.Login,
                        loginResult = "Incorrect",
                    };
                    string delivery = JsonConvert.SerializeObject(package);

                    // Sending to client
                    await client.Writer.WriteLineAsync(delivery);
                    client.Writer.Flush();
                }
                else if (_loginData[userID].ToString() == password)
                {
                    // Prepares the package with response
                    Package package = new Package
                    {
                        requestType = RequestType.Login,
                        loginResult = "Correct",
                    };
                    string delivery = JsonConvert.SerializeObject(package);

                    // Sending to client
                    await client.Writer.WriteLineAsync(delivery);
                    client.Writer.Flush();

                    // Adds the userID to the client object
                    client.UserID = userID;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            // Compare the given values with the ones in the json file. if they are the same then send a success ping. else send a fail ping and ask for a retry

        }

        // Handles the client register procedure
        public async void Register(ConnectedClient client, string userID, string password)
        {
            // Check if there is an userID in the json or not
            // If so then alert the user that the account already exists
            // Otherwise create the new account with the given password
        }
    }

    // Class consisting of common client properties and functions
    public class ConnectedClient
    {
        public TcpClient Client;
        public StreamWriter Writer;
        public string UserID {  get; set; }

        public ConnectedClient(TcpClient client)
        {
            Client = client;
            Writer = new StreamWriter(Client.GetStream(), Encoding.Unicode);
        }
    }

    // Class consisting of the parts in a package.
    public class Package
    {
        public RequestType requestType { get; set; }
        public string data {  get; set; }
        public string userID { get; set; }
        public string password { get; set; }
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