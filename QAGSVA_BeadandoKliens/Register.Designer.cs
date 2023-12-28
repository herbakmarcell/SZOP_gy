namespace QAGSVA_BeadandoKliens
{
    partial class Register
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.passwordABox = new System.Windows.Forms.TextBox();
            this.passwordALabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(248, 298);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 50);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Mégsem";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.registerButton.Location = new System.Drawing.Point(43, 298);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(100, 50);
            this.registerButton.TabIndex = 18;
            this.registerButton.Text = "Regisztrálok";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // passwordABox
            // 
            this.passwordABox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordABox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordABox.Location = new System.Drawing.Point(15, 253);
            this.passwordABox.Name = "passwordABox";
            this.passwordABox.Size = new System.Drawing.Size(360, 22);
            this.passwordABox.TabIndex = 17;
            this.passwordABox.UseSystemPasswordChar = true;
            // 
            // passwordALabel
            // 
            this.passwordALabel.AutoSize = true;
            this.passwordALabel.Font = new System.Drawing.Font("Arial", 14F);
            this.passwordALabel.Location = new System.Drawing.Point(10, 223);
            this.passwordALabel.Name = "passwordALabel";
            this.passwordALabel.Size = new System.Drawing.Size(185, 22);
            this.passwordALabel.TabIndex = 16;
            this.passwordALabel.Text = "Jelszó még egyszer:";
            // 
            // passwordBox
            // 
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordBox.Location = new System.Drawing.Point(15, 183);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(360, 22);
            this.passwordBox.TabIndex = 15;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.passwordLabel.Location = new System.Drawing.Point(10, 153);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(70, 22);
            this.passwordLabel.TabIndex = 14;
            this.passwordLabel.Text = "Jelszó:";
            // 
            // nameBox
            // 
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameBox.Location = new System.Drawing.Point(15, 113);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(360, 22);
            this.nameBox.TabIndex = 13;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.nameLabel.Location = new System.Drawing.Point(10, 83);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(114, 22);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Teljes Neve:";
            // 
            // usernameBox
            // 
            this.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usernameBox.Location = new System.Drawing.Point(15, 43);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(360, 22);
            this.usernameBox.TabIndex = 11;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usernameLabel.Location = new System.Drawing.Point(10, 13);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(146, 22);
            this.usernameLabel.TabIndex = 10;
            this.usernameLabel.Text = "Felhasználónév:";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.passwordABox);
            this.Controls.Add(this.passwordALabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.usernameLabel);
            this.Name = "Register";
            this.Text = "Regisztráció";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Register_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox passwordABox;
        private System.Windows.Forms.Label passwordALabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label usernameLabel;
    }
}