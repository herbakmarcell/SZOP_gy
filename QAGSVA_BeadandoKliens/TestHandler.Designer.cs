namespace QAGSVA_BeadandoKliens
{
    partial class TestHandler
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
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.userBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.testHandlerButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(12, 113);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(245, 20);
            this.datePicker.TabIndex = 14;
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(12, 71);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(245, 20);
            this.userBox.TabIndex = 12;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateLabel.Location = new System.Drawing.Point(9, 94);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(46, 16);
            this.dateLabel.TabIndex = 13;
            this.dateLabel.Text = "Dátum";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usernameLabel.Location = new System.Drawing.Point(9, 52);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(102, 16);
            this.usernameLabel.TabIndex = 11;
            this.usernameLabel.Text = "Felhasználónév";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(12, 29);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(245, 20);
            this.idBox.TabIndex = 16;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.idLabel.Location = new System.Drawing.Point(9, 10);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(20, 16);
            this.idLabel.TabIndex = 15;
            this.idLabel.Text = "ID";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusLabel.Location = new System.Drawing.Point(9, 140);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(69, 16);
            this.statusLabel.TabIndex = 17;
            this.statusLabel.Text = "Eredmény";
            // 
            // testHandlerButton
            // 
            this.testHandlerButton.Location = new System.Drawing.Point(12, 185);
            this.testHandlerButton.Name = "testHandlerButton";
            this.testHandlerButton.Size = new System.Drawing.Size(245, 40);
            this.testHandlerButton.TabIndex = 19;
            this.testHandlerButton.Text = "R/A/U/D";
            this.testHandlerButton.UseVisualStyleBackColor = true;
            this.testHandlerButton.Click += new System.EventHandler(this.testHandlerButton_Click);
            // 
            // statusBox
            // 
            this.statusBox.FormattingEnabled = true;
            this.statusBox.Items.AddRange(new object[] {
            "Még nincs értékelve",
            "Megfelelt",
            "Nem felelt meg"});
            this.statusBox.Location = new System.Drawing.Point(12, 159);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(245, 21);
            this.statusBox.TabIndex = 20;
            // 
            // TestHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 236);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.testHandlerButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.usernameLabel);
            this.Name = "TestHandler";
            this.Text = "TestHandler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestHandler_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button testHandlerButton;
        private System.Windows.Forms.ComboBox statusBox;
    }
}