namespace QAGSVA_BeadandoKliens
{
    partial class Main
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
            this.greetingsLabel = new System.Windows.Forms.Label();
            this.drivenHourLabel = new System.Windows.Forms.Label();
            this.drivenKmLabel = new System.Windows.Forms.Label();
            this.instructorLabel = new System.Windows.Forms.Label();
            this.practiceGridView = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.getButton = new System.Windows.Forms.Button();
            this.testAddButton = new System.Windows.Forms.Button();
            this.studentAddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.practiceGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // greetingsLabel
            // 
            this.greetingsLabel.AutoSize = true;
            this.greetingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.greetingsLabel.Location = new System.Drawing.Point(13, 13);
            this.greetingsLabel.Name = "greetingsLabel";
            this.greetingsLabel.Size = new System.Drawing.Size(77, 16);
            this.greetingsLabel.TabIndex = 0;
            this.greetingsLabel.Text = "Üdvözöljük!";
            // 
            // drivenHourLabel
            // 
            this.drivenHourLabel.AutoSize = true;
            this.drivenHourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drivenHourLabel.Location = new System.Drawing.Point(13, 45);
            this.drivenHourLabel.Name = "drivenHourLabel";
            this.drivenHourLabel.Size = new System.Drawing.Size(155, 16);
            this.drivenHourLabel.TabIndex = 1;
            this.drivenHourLabel.Text = "Levezetetett órák száma:";
            // 
            // drivenKmLabel
            // 
            this.drivenKmLabel.AutoSize = true;
            this.drivenKmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drivenKmLabel.Location = new System.Drawing.Point(13, 74);
            this.drivenKmLabel.Name = "drivenKmLabel";
            this.drivenKmLabel.Size = new System.Drawing.Size(129, 16);
            this.drivenKmLabel.TabIndex = 2;
            this.drivenKmLabel.Text = "Levezetett kilométer:";
            // 
            // instructorLabel
            // 
            this.instructorLabel.AutoSize = true;
            this.instructorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.instructorLabel.Location = new System.Drawing.Point(13, 107);
            this.instructorLabel.Name = "instructorLabel";
            this.instructorLabel.Size = new System.Drawing.Size(82, 16);
            this.instructorLabel.TabIndex = 3;
            this.instructorLabel.Text = "Oktató neve:";
            // 
            // practiceGridView
            // 
            this.practiceGridView.AllowUserToAddRows = false;
            this.practiceGridView.AllowUserToDeleteRows = false;
            this.practiceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.practiceGridView.Location = new System.Drawing.Point(13, 150);
            this.practiceGridView.Name = "practiceGridView";
            this.practiceGridView.ReadOnly = true;
            this.practiceGridView.Size = new System.Drawing.Size(724, 288);
            this.practiceGridView.TabIndex = 4;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(662, 100);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "DELETE";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(662, 71);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "UPDATE";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(662, 42);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(662, 13);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(75, 23);
            this.getButton.TabIndex = 8;
            this.getButton.Text = "GET";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // testAddButton
            // 
            this.testAddButton.Location = new System.Drawing.Point(537, 42);
            this.testAddButton.Name = "testAddButton";
            this.testAddButton.Size = new System.Drawing.Size(119, 23);
            this.testAddButton.TabIndex = 12;
            this.testAddButton.Text = "TEST ADD";
            this.testAddButton.UseVisualStyleBackColor = true;
            this.testAddButton.Click += new System.EventHandler(this.testAddButton_Click);
            // 
            // studentAddButton
            // 
            this.studentAddButton.Location = new System.Drawing.Point(537, 71);
            this.studentAddButton.Name = "studentAddButton";
            this.studentAddButton.Size = new System.Drawing.Size(119, 23);
            this.studentAddButton.TabIndex = 13;
            this.studentAddButton.Text = "STUDENT ADD";
            this.studentAddButton.UseVisualStyleBackColor = true;
            this.studentAddButton.Click += new System.EventHandler(this.studentAddButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 451);
            this.Controls.Add(this.studentAddButton);
            this.Controls.Add(this.testAddButton);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.practiceGridView);
            this.Controls.Add(this.instructorLabel);
            this.Controls.Add(this.drivenKmLabel);
            this.Controls.Add(this.drivenHourLabel);
            this.Controls.Add(this.greetingsLabel);
            this.Name = "Main";
            this.Text = "TK Autósuli KFT.";
            ((System.ComponentModel.ISupportInitialize)(this.practiceGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label greetingsLabel;
        private System.Windows.Forms.Label drivenHourLabel;
        private System.Windows.Forms.Label drivenKmLabel;
        private System.Windows.Forms.Label instructorLabel;
        private System.Windows.Forms.DataGridView practiceGridView;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.Button testAddButton;
        private System.Windows.Forms.Button studentAddButton;
    }
}