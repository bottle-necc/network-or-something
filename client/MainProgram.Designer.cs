namespace Client
{
    partial class MainProgram
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
            this.tbxInbox = new System.Windows.Forms.TextBox();
            this.btnBroadcast = new System.Windows.Forms.Button();
            this.lblInbox = new System.Windows.Forms.Label();
            this.tbxBroadcast = new System.Windows.Forms.TextBox();
            this.btnWhisper = new System.Windows.Forms.Button();
            this.lblClientList = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.pnlClientButtons = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tbxInbox
            // 
            this.tbxInbox.AcceptsReturn = true;
            this.tbxInbox.AcceptsTab = true;
            this.tbxInbox.Location = new System.Drawing.Point(12, 25);
            this.tbxInbox.Multiline = true;
            this.tbxInbox.Name = "tbxInbox";
            this.tbxInbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInbox.Size = new System.Drawing.Size(208, 203);
            this.tbxInbox.TabIndex = 0;
            // 
            // btnBroadcast
            // 
            this.btnBroadcast.Location = new System.Drawing.Point(12, 326);
            this.btnBroadcast.Name = "btnBroadcast";
            this.btnBroadcast.Size = new System.Drawing.Size(75, 23);
            this.btnBroadcast.TabIndex = 1;
            this.btnBroadcast.Text = "Broadcast";
            this.btnBroadcast.UseVisualStyleBackColor = true;
            this.btnBroadcast.Click += new System.EventHandler(this.btnBroadcast_Click);
            // 
            // lblInbox
            // 
            this.lblInbox.AutoSize = true;
            this.lblInbox.Location = new System.Drawing.Point(9, 9);
            this.lblInbox.Name = "lblInbox";
            this.lblInbox.Size = new System.Drawing.Size(33, 13);
            this.lblInbox.TabIndex = 2;
            this.lblInbox.Text = "Inbox";
            // 
            // tbxBroadcast
            // 
            this.tbxBroadcast.AcceptsReturn = true;
            this.tbxBroadcast.AcceptsTab = true;
            this.tbxBroadcast.Location = new System.Drawing.Point(12, 242);
            this.tbxBroadcast.Multiline = true;
            this.tbxBroadcast.Name = "tbxBroadcast";
            this.tbxBroadcast.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxBroadcast.Size = new System.Drawing.Size(208, 72);
            this.tbxBroadcast.TabIndex = 3;
            this.tbxBroadcast.TextChanged += new System.EventHandler(this.tbxBroadcast_TextChanged);
            this.tbxBroadcast.MouseEnter += new System.EventHandler(this.tbxBroadcast_MouseEnter);
            this.tbxBroadcast.MouseLeave += new System.EventHandler(this.tbxBroadcast_MouseLeave);
            // 
            // btnWhisper
            // 
            this.btnWhisper.Location = new System.Drawing.Point(145, 326);
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.Size = new System.Drawing.Size(75, 23);
            this.btnWhisper.TabIndex = 4;
            this.btnWhisper.Text = "Whisper";
            this.btnWhisper.UseVisualStyleBackColor = true;
            this.btnWhisper.Click += new System.EventHandler(this.btnWhisper_Click);
            // 
            // lblClientList
            // 
            this.lblClientList.AutoSize = true;
            this.lblClientList.Location = new System.Drawing.Point(226, 9);
            this.lblClientList.Name = "lblClientList";
            this.lblClientList.Size = new System.Drawing.Size(52, 13);
            this.lblClientList.TabIndex = 6;
            this.lblClientList.Text = "Client List";
            // 
            // lblTarget
            // 
            this.lblTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTarget.Location = new System.Drawing.Point(229, 326);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(127, 23);
            this.lblTarget.TabIndex = 7;
            this.lblTarget.Text = "Not Selected";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlClientButtons
            // 
            this.pnlClientButtons.AutoScroll = true;
            this.pnlClientButtons.Location = new System.Drawing.Point(229, 25);
            this.pnlClientButtons.Name = "pnlClientButtons";
            this.pnlClientButtons.Size = new System.Drawing.Size(127, 289);
            this.pnlClientButtons.TabIndex = 8;
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 361);
            this.Controls.Add(this.pnlClientButtons);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblClientList);
            this.Controls.Add(this.btnWhisper);
            this.Controls.Add(this.tbxBroadcast);
            this.Controls.Add(this.lblInbox);
            this.Controls.Add(this.btnBroadcast);
            this.Controls.Add(this.tbxInbox);
            this.Name = "MainProgram";
            this.Text = "MainProgram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInbox;
        private System.Windows.Forms.Button btnBroadcast;
        private System.Windows.Forms.Label lblInbox;
        private System.Windows.Forms.TextBox tbxBroadcast;
        private System.Windows.Forms.Button btnWhisper;
        private System.Windows.Forms.Label lblClientList;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Panel pnlClientButtons;
    }
}