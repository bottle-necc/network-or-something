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


namespace Client
{
    public partial class Form1 : Form
    {
        IPAddress Address;
        string UserID;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Address = IPAddress.Parse(tbxAddress.Text);
            UserID = tbxUserID.Text;
        }
    }
}
