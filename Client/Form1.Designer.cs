namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMessage = new Label();
            lblAnswer = new Label();
            txtMessage = new TextBox();
            txtAnswer = new TextBox();
            btnConnect = new Button();
            btnSend = new Button();
            btnDisconnect = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 15F);
            lblMessage.Location = new Point(16, 9);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(150, 28);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Повідомлення:";
            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.Font = new Font("Segoe UI", 15F);
            lblAnswer.Location = new Point(16, 85);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(104, 28);
            lblAnswer.TabIndex = 1;
            lblAnswer.Text = "Відповідь:";
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Segoe UI", 17F);
            txtMessage.Location = new Point(16, 40);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(251, 38);
            txtMessage.TabIndex = 2;
            // 
            // txtAnswer
            // 
            txtAnswer.Font = new Font("Segoe UI", 17F);
            txtAnswer.Location = new Point(16, 116);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ReadOnly = true;
            txtAnswer.Size = new Size(251, 38);
            txtAnswer.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Segoe UI", 15F);
            btnConnect.Location = new Point(12, 163);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(255, 47);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Підключитись";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 15F);
            btnSend.Location = new Point(12, 215);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(255, 49);
            btnSend.TabIndex = 5;
            btnSend.Text = "Надіслати";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Font = new Font("Segoe UI", 15F);
            btnDisconnect.Location = new Point(12, 270);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(255, 53);
            btnDisconnect.TabIndex = 6;
            btnDisconnect.Text = "Від'єднатись";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 339);
            Controls.Add(btnDisconnect);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(txtAnswer);
            Controls.Add(txtMessage);
            Controls.Add(lblAnswer);
            Controls.Add(lblMessage);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessage;
        private Label lblAnswer;
        private TextBox txtMessage;
        private TextBox txtAnswer;
        private Button btnConnect;
        private Button btnSend;
        private Button btnDisconnect;
    }
}
