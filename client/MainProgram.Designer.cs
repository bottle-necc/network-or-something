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
            this.SuspendLayout();
            // 
            // tbxInbox
            // 
            this.tbxInbox.AcceptsReturn = true;
            this.tbxInbox.AcceptsTab = true;
            this.tbxInbox.Location = new System.Drawing.Point(12, 39);
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
            this.lblInbox.Location = new System.Drawing.Point(9, 23);
            this.lblInbox.Name = "lblInbox";
            this.lblInbox.Size = new System.Drawing.Size(36, 13);
            this.lblInbox.TabIndex = 2;
            this.lblInbox.Text = "Inbox:";
            // 
            // tbxBroadcast
            // 
            this.tbxBroadcast.AcceptsReturn = true;
            this.tbxBroadcast.AcceptsTab = true;
            this.tbxBroadcast.Location = new System.Drawing.Point(12, 248);
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
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 361);
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
    }
}