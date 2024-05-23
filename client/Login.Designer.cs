namespace Client
{
    partial class Login
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
            this.tbxUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxUserID
            // 
            this.tbxUserID.Location = new System.Drawing.Point(77, 16);
            this.tbxUserID.Margin = new System.Windows.Forms.Padding(2);
            this.tbxUserID.Name = "tbxUserID";
            this.tbxUserID.Size = new System.Drawing.Size(150, 20);
            this.tbxUserID.TabIndex = 13;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(12, 19);
            this.lblUserID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(58, 13);
            this.lblUserID.TabIndex = 12;
            this.lblUserID.Text = "Username:";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(77, 48);
            this.tbxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(150, 20);
            this.tbxPassword.TabIndex = 15;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 51);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(91, 78);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(56, 19);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 108);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbxUserID);
            this.Controls.Add(this.lblUserID);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}