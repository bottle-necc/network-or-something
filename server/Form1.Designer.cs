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
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(168, 40);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(88, 23);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // tbxInbox
            // 
            this.tbxInbox.Location = new System.Drawing.Point(34, 99);
            this.tbxInbox.Multiline = true;
            this.tbxInbox.Name = "tbxInbox";
            this.tbxInbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInbox.Size = new System.Drawing.Size(357, 328);
            this.tbxInbox.TabIndex = 1;
            // 
            // lblInbox
            // 
            this.lblInbox.AutoSize = true;
            this.lblInbox.Location = new System.Drawing.Point(33, 80);
            this.lblInbox.Name = "lblInbox";
            this.lblInbox.Size = new System.Drawing.Size(39, 16);
            this.lblInbox.TabIndex = 2;
            this.lblInbox.Text = "Inbox";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.lblInbox);
            this.Controls.Add(this.tbxInbox);
            this.Controls.Add(this.btnStartServer);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox tbxInbox;
        private System.Windows.Forms.Label lblInbox;
    }
}

