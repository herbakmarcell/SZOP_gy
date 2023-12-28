namespace QAGSVA_BeadandoKliens
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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginHandlerButton = new System.Windows.Forms.Button();
            this.registerHandlerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usernameLabel.Location = new System.Drawing.Point(7, 15);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(181, 27);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Felhasználónév";
            // 
            // usernameBox
            // 
            this.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameBox.Location = new System.Drawing.Point(12, 45);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(360, 20);
            this.usernameBox.TabIndex = 1;
            // 
            // passwordBox
            // 
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordBox.Location = new System.Drawing.Point(12, 115);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(360, 20);
            this.passwordBox.TabIndex = 5;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordLabel.Location = new System.Drawing.Point(7, 85);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(80, 27);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Jelszó";
            // 
            // loginHandlerButton
            // 
            this.loginHandlerButton.Location = new System.Drawing.Point(40, 185);
            this.loginHandlerButton.Name = "loginHandlerButton";
            this.loginHandlerButton.Size = new System.Drawing.Size(100, 50);
            this.loginHandlerButton.TabIndex = 8;
            this.loginHandlerButton.Text = "Login/Cancel";
            this.loginHandlerButton.UseVisualStyleBackColor = true;
            this.loginHandlerButton.Click += new System.EventHandler(this.loginHandlerButton_Click);
            // 
            // registerHandlerButton
            // 
            this.registerHandlerButton.Location = new System.Drawing.Point(245, 185);
            this.registerHandlerButton.Name = "registerHandlerButton";
            this.registerHandlerButton.Size = new System.Drawing.Size(100, 50);
            this.registerHandlerButton.TabIndex = 9;
            this.registerHandlerButton.Text = "Register";
            this.registerHandlerButton.UseVisualStyleBackColor = true;
            this.registerHandlerButton.Click += new System.EventHandler(this.registerHandlerButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.registerHandlerButton);
            this.Controls.Add(this.loginHandlerButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.usernameLabel);
            this.Name = "Login";
            this.Text = "Bejelentkezés";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button loginHandlerButton;
        private System.Windows.Forms.Button registerHandlerButton;
    }
}

