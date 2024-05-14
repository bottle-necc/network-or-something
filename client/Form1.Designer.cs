namespace Client
{
    partial class Form1
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
            this.btnSend = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblProgram = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(135, 406);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 154);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 234);
            this.textBox1.TabIndex = 10;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(136, 108);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(161, 66);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(100, 22);
            this.tbxAddress.TabIndex = 8;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(82, 69);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(77, 16);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "IP-Address:";
            // 
            // lblProgram
            // 
            this.lblProgram.AutoSize = true;
            this.lblProgram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProgram.Location = new System.Drawing.Point(151, 21);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(42, 18);
            this.lblProgram.TabIndex = 6;
            this.lblProgram.Text = "Client";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 450);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblProgram);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblProgram;
    }
}

