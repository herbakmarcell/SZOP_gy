namespace QAGSVA_BeadandoKliens
{
    partial class StudentHandler
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
            this.label1 = new System.Windows.Forms.Label();
            this.studentBox = new System.Windows.Forms.ComboBox();
            this.studentHandlerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tanuló neve";
            // 
            // studentBox
            // 
            this.studentBox.FormattingEnabled = true;
            this.studentBox.Location = new System.Drawing.Point(12, 28);
            this.studentBox.Name = "studentBox";
            this.studentBox.Size = new System.Drawing.Size(256, 21);
            this.studentBox.TabIndex = 2;
            // 
            // studentHandlerButton
            // 
            this.studentHandlerButton.Location = new System.Drawing.Point(12, 69);
            this.studentHandlerButton.Name = "studentHandlerButton";
            this.studentHandlerButton.Size = new System.Drawing.Size(256, 42);
            this.studentHandlerButton.TabIndex = 3;
            this.studentHandlerButton.Text = "Tanuló felvétele";
            this.studentHandlerButton.UseVisualStyleBackColor = true;
            this.studentHandlerButton.Click += new System.EventHandler(this.studentHandlerButton_Click);
            // 
            // StudentHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 123);
            this.Controls.Add(this.studentHandlerButton);
            this.Controls.Add(this.studentBox);
            this.Controls.Add(this.label1);
            this.Name = "StudentHandler";
            this.Text = "StudentHandler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentHandler_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox studentBox;
        private System.Windows.Forms.Button studentHandlerButton;
    }
}