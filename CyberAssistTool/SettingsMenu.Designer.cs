namespace CyberAssistTool
{
	partial class SettingsMenu
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
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.myDocumentsTextBox = new System.Windows.Forms.TextBox();
			this.myDocumentsLabel = new System.Windows.Forms.Label();
			this.myDocumentsButton = new System.Windows.Forms.Button();
			this.programDataButton = new System.Windows.Forms.Button();
			this.programDataLabel = new System.Windows.Forms.Label();
			this.programDataTextBox = new System.Windows.Forms.TextBox();
			this.resetButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// myDocumentsTb
			// 
			this.myDocumentsTextBox.Location = new System.Drawing.Point(12, 35);
			this.myDocumentsTextBox.Name = "myDocumentsTb";
			this.myDocumentsTextBox.Size = new System.Drawing.Size(380, 20);
			this.myDocumentsTextBox.TabIndex = 1;
			// 
			// myDocumentsLabel
			// 
			this.myDocumentsLabel.AutoSize = true;
			this.myDocumentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.myDocumentsLabel.Location = new System.Drawing.Point(12, 17);
			this.myDocumentsLabel.Name = "myDocumentsLabel";
			this.myDocumentsLabel.Size = new System.Drawing.Size(127, 15);
			this.myDocumentsLabel.TabIndex = 0;
			this.myDocumentsLabel.Text = "My Documents Folder";
			// 
			// myDocumentsButton
			// 
			this.myDocumentsButton.Location = new System.Drawing.Point(398, 33);
			this.myDocumentsButton.Name = "myDocumentsButton";
			this.myDocumentsButton.Size = new System.Drawing.Size(24, 23);
			this.myDocumentsButton.TabIndex = 2;
			this.myDocumentsButton.Text = "...";
			this.myDocumentsButton.UseVisualStyleBackColor = true;
			this.myDocumentsButton.Click += new System.EventHandler(this.pathButton_Click);
			// 
			// programDataButton
			// 
			this.programDataButton.Location = new System.Drawing.Point(398, 86);
			this.programDataButton.Name = "programDataButton";
			this.programDataButton.Size = new System.Drawing.Size(24, 23);
			this.programDataButton.TabIndex = 5;
			this.programDataButton.Text = "...";
			this.programDataButton.UseVisualStyleBackColor = true;
			this.programDataButton.Click += new System.EventHandler(this.pathButton_Click);
			// 
			// programDataLabel
			// 
			this.programDataLabel.AutoSize = true;
			this.programDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.programDataLabel.Location = new System.Drawing.Point(12, 70);
			this.programDataLabel.Name = "programDataLabel";
			this.programDataLabel.Size = new System.Drawing.Size(122, 15);
			this.programDataLabel.TabIndex = 3;
			this.programDataLabel.Text = "Program Data Folder";
			// 
			// programDataTb
			// 
			this.programDataTextBox.Location = new System.Drawing.Point(12, 88);
			this.programDataTextBox.Name = "programDataTb";
			this.programDataTextBox.Size = new System.Drawing.Size(380, 20);
			this.programDataTextBox.TabIndex = 4;
			// 
			// resetButton
			// 
			this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resetButton.Location = new System.Drawing.Point(12, 132);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(122, 28);
			this.resetButton.TabIndex = 6;
			this.resetButton.Text = "Reset to Default";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelButton.Location = new System.Drawing.Point(300, 132);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(122, 28);
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.saveButton.Location = new System.Drawing.Point(156, 132);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(122, 28);
			this.saveButton.TabIndex = 7;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 172);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.programDataButton);
			this.Controls.Add(this.programDataLabel);
			this.Controls.Add(this.programDataTextBox);
			this.Controls.Add(this.myDocumentsButton);
			this.Controls.Add(this.myDocumentsLabel);
			this.Controls.Add(this.myDocumentsTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Settings";
			this.Text = "Options";
			this.Load += new System.EventHandler(this.Settings_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.TextBox myDocumentsTextBox;
		private System.Windows.Forms.Label myDocumentsLabel;
		private System.Windows.Forms.Button myDocumentsButton;
		private System.Windows.Forms.Button programDataButton;
		private System.Windows.Forms.Label programDataLabel;
		private System.Windows.Forms.TextBox programDataTextBox;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button saveButton;
	}
}