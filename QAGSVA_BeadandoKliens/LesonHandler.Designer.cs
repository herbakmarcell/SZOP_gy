namespace QAGSVA_BeadandoKliens
{
    partial class LessonHandler
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
            this.distanceLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.distanceBox = new System.Windows.Forms.TextBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.descBox = new System.Windows.Forms.TextBox();
            this.lessonHandlerButton = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.idLabel = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usernameLabel.Location = new System.Drawing.Point(12, 52);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(107, 16);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Felhasználónév*";
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.distanceLabel.Location = new System.Drawing.Point(12, 136);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(140, 16);
            this.distanceLabel.TabIndex = 1;
            this.distanceLabel.Text = "Megtett távolság (km)*";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.Location = new System.Drawing.Point(12, 178);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(166, 16);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "Vezetéssel töltött idő (óra)*";
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.descLabel.Location = new System.Drawing.Point(12, 220);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(44, 16);
            this.descLabel.TabIndex = 3;
            this.descLabel.Text = "Leírás";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateLabel.Location = new System.Drawing.Point(12, 94);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(51, 16);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Dátum*";
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(12, 71);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(245, 20);
            this.userBox.TabIndex = 1;
            // 
            // distanceBox
            // 
            this.distanceBox.Location = new System.Drawing.Point(12, 155);
            this.distanceBox.Name = "distanceBox";
            this.distanceBox.Size = new System.Drawing.Size(245, 20);
            this.distanceBox.TabIndex = 7;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(12, 197);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(245, 20);
            this.timeBox.TabIndex = 8;
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(12, 239);
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(245, 20);
            this.descBox.TabIndex = 9;
            // 
            // lessonHandlerButton
            // 
            this.lessonHandlerButton.Location = new System.Drawing.Point(39, 269);
            this.lessonHandlerButton.Name = "lessonHandlerButton";
            this.lessonHandlerButton.Size = new System.Drawing.Size(185, 40);
            this.lessonHandlerButton.TabIndex = 2;
            this.lessonHandlerButton.Text = "R/A/U/D";
            this.lessonHandlerButton.UseVisualStyleBackColor = true;
            this.lessonHandlerButton.Click += new System.EventHandler(this.lessonHandlerButton_Click);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(12, 113);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(245, 20);
            this.datePicker.TabIndex = 10;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.idLabel.Location = new System.Drawing.Point(12, 9);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(20, 16);
            this.idLabel.TabIndex = 11;
            this.idLabel.Text = "ID";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(12, 29);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(245, 20);
            this.idBox.TabIndex = 12;
            // 
            // LessonHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 321);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.lessonHandlerButton);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.distanceBox);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.distanceLabel);
            this.Controls.Add(this.usernameLabel);
            this.Name = "LessonHandler";
            this.Text = "LessonHandler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LessonHandler_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label distanceLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.TextBox distanceBox;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.Button lessonHandlerButton;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idBox;
    }
}