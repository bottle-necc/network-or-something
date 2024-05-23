namespace server
{
    partial class Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartServer = new System.Windows.Forms.Button();
            this.tbxInbox = new System.Windows.Forms.TextBox();
            this.lblInbox = new System.Windows.Forms.Label();
            this.tbxClientList = new System.Windows.Forms.TextBox();
            this.lblClientList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(189, 32);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(66, 19);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // tbxInbox
            // 
            this.tbxInbox.AcceptsReturn = true;
            this.tbxInbox.AcceptsTab = true;
            this.tbxInbox.Location = new System.Drawing.Point(26, 80);
            this.tbxInbox.Margin = new System.Windows.Forms.Padding(2);
            this.tbxInbox.Multiline = true;
            this.tbxInbox.Name = "tbxInbox";
            this.tbxInbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInbox.Size = new System.Drawing.Size(269, 267);
            this.tbxInbox.TabIndex = 1;
            // 
            // lblInbox
            // 
            this.lblInbox.AutoSize = true;
            this.lblInbox.Location = new System.Drawing.Point(25, 65);
            this.lblInbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInbox.Name = "lblInbox";
            this.lblInbox.Size = new System.Drawing.Size(33, 13);
            this.lblInbox.TabIndex = 2;
            this.lblInbox.Text = "Inbox";
            // 
            // tbxClientList
            // 
            this.tbxClientList.AcceptsReturn = true;
            this.tbxClientList.AcceptsTab = true;
            this.tbxClientList.Location = new System.Drawing.Point(316, 80);
            this.tbxClientList.Multiline = true;
            this.tbxClientList.Name = "tbxClientList";
            this.tbxClientList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxClientList.Size = new System.Drawing.Size(100, 267);
            this.tbxClientList.TabIndex = 3;
            // 
            // lblClientList
            // 
            this.lblClientList.AutoSize = true;
            this.lblClientList.Location = new System.Drawing.Point(313, 64);
            this.lblClientList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientList.Name = "lblClientList";
            this.lblClientList.Size = new System.Drawing.Size(52, 13);
            this.lblClientList.TabIndex = 4;
            this.lblClientList.Text = "Client List";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 366);
            this.Controls.Add(this.lblClientList);
            this.Controls.Add(this.tbxClientList);
            this.Controls.Add(this.lblInbox);
            this.Controls.Add(this.tbxInbox);
            this.Controls.Add(this.btnStartServer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox tbxInbox;
        private System.Windows.Forms.Label lblInbox;
        private System.Windows.Forms.TextBox tbxClientList;
        private System.Windows.Forms.Label lblClientList;
    }
}

