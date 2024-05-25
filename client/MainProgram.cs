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
using Newtonsoft.Json.Linq;

namespace Client
{
    public partial class MainProgram : Form
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;

        private List<string> _userList = new List<string>();
        private List<Button> _btnUserList = new List<Button>();

        private string _placeholderText = "Type your message here, write something captivating!"; // Placeholder text for tbxBroadcast
        private string _userID;
        private string _target;

        // TODO: when logging in or registering, run a warning window if the username has '~' to prevent issues

        public MainProgram(TcpClient client, string userID)
        {
            InitializeComponent();
            FormClosing += ApplicationExitHandler.OnWindowClosing;

            // Assigns the fields with the given values
            _client = client;
            _userID = userID;
            _reader = new StreamReader(_client.GetStream(), Encoding.Unicode);
            _writer = new StreamWriter(_client.GetStream(), Encoding.Unicode);
            _writer.AutoFlush = true;

            // Sets the placeholder text
            tbxBroadcast.Text = _placeholderText;
            tbxBroadcast.ForeColor = Color.DarkSlateGray;
            tbxBroadcast.Font = new Font(tbxBroadcast.Font, FontStyle.Italic);

            // Calls server for a client list update
            CallForUpdate();

            // New thread that listens for messages
            Task.Run(() => Mailbox());
        }
        
        // Delivers a message broadcast to the server
        private async void Broadcast(string message)
        {
            try
            {
                // Clears the field
                tbxBroadcast.Text = "";
                
                // Package containing the relevant data
                Package package = new Package()
                {
                    requestType = RequestType.Broadcast,
                    data = message
                };
                
                // Converts it to string before delivering
                string delivery = JsonConvert.SerializeObject(package);

                // Sends the package
                await _writer.WriteLineAsync(delivery);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Delivering Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        // Handles and sorts all deliveries recieved from the server
        private void Mailbox()
        {
            try
            {
                while (_client.Connected)
                {
                    string message = "";

                    // Collects the package and unpacks it
                    string delivery = _reader.ReadLine();
                    Package package = JsonConvert.DeserializeObject<Package>(delivery);
                    
                    
                    if (package.requestType == RequestType.Broadcast || package.requestType == RequestType.Whisper || package.requestType == RequestType.Announcement)
                    {
                        // If the package is an ordinary broadcast or a whisper then simply display it
                        message = package.data;
                        tbxInbox.Text += message + Environment.NewLine;
                    }
                    else if (package.requestType == RequestType.UpdateUserList)
                    {
                        UpdateButtonList(package);
                    }

                    if (message == null)
                    {
                        // If disconnected, display it
                        tbxInbox.Text += "Disconnected!";
                        break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Reading Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void btnBroadcast_Click(object sender, EventArgs e)
        {
            Broadcast(tbxBroadcast.Text);
        }

        // Removes placeholder text upon gaining focus
        private void tbxBroadcast_MouseEnter(object sender, EventArgs e)
        {
            if (tbxBroadcast.Text == _placeholderText)
            {
                tbxBroadcast.Text = "";
                tbxBroadcast.ForeColor = Color.Black;
                tbxBroadcast.Font = new Font(tbxBroadcast.Font, FontStyle.Regular);
            }
        }

        // Adds placeholder text upon losing focus if its empty
        private void tbxBroadcast_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxBroadcast.Text))
            {
                tbxBroadcast.Text = _placeholderText;
                tbxBroadcast.ForeColor = Color.DarkSlateGray;
                tbxBroadcast.Font = new Font(tbxBroadcast.Font, FontStyle.Italic);
            }
        }

        // Assists the placeholder remover by also allowing text changes remove it
        private void tbxBroadcast_TextChanged(object sender, EventArgs e)
        {
            if (tbxBroadcast.ForeColor == Color.DarkSlateGray && tbxBroadcast.Text.Contains(_placeholderText))
            {
                tbxBroadcast.Text = "";
                tbxBroadcast.ForeColor = Color.Black;
                tbxBroadcast.Font = new Font(tbxBroadcast.Font, FontStyle.Regular);
            }
        }

        public void UpdateButtonList(Package package)
        {
            try
            {
                int i = 0;

                // Adds the contents of the data in the list
                string data = package.data;
                _userList = new List<string>(data.Split('~'));

                // Clears the list of buttons of users to whipser to
                _btnUserList.Clear();

                // Removes the clients own name from the userList
                foreach (string item in _userList)
                {
                    if (item == _userID)
                    {
                        continue;
                    }
                    else
                    {
                        // Calculates the vertical position of the button in the panel
                        int yPoint = 23 * i + 2;

                        // Runs in the main thread (i.e the one that contains the form items
                        Invoke((MethodInvoker)delegate
                        {
                            // Creates a new button inside the panel for every entry
                            Button btn = new Button();
                            pnlClientButtons.Controls.Add(btn);
                            _btnUserList.Add(btn);

                            // Configures its data
                            btn.Text = item;
                            btn.AutoSize = false;
                            btn.Size = new Size(99, 23);
                            btn.Location = new Point(0, yPoint);
                            btn.Click += ClientButtons_Pressed;
                            btn.Name = "btn" + i;
                        });

                        i++;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "UpdateButtonList Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        public async void CallForUpdate()
        {
            try
            {
                // Creates a package
                Package package = new Package
                {
                    requestType = RequestType.UpdateUserList,
                };
                string delivery = JsonConvert.SerializeObject(package);

                // Sends the package
                await _writer.WriteLineAsync(delivery);
                _writer.Flush();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "CallForUpdate Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void ClientButtons_Pressed(object sender, EventArgs e)
        {
            // Grabs the selected button
            Button selected = sender as Button;

            // Updates the current target
            _target = selected.Text;
            lblTarget.Text = _target;
        }

        private void btnWhisper_Click(object sender, EventArgs e)
        {
            Whisper();
        }

        public async void Whisper()
        {
            try
            {
                // Grabs the message from the tbx
                string message = tbxBroadcast.Text;
                tbxBroadcast.Text = "";

                // Packages the whisper
                Package package = new Package
                {
                    requestType = RequestType.Whisper,
                    data = message,
                    target = _target,
                };
                string delivery = JsonConvert.SerializeObject(package);

                // Sends the delivery
                await _writer.WriteLineAsync(delivery);
                _writer.Flush();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Whisper Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }
    }
}
