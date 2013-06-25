namespace CyberAssistTool
{
	partial class Settings
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
			this.myDocumentsTb = new System.Windows.Forms.TextBox();
			this.myDocumentsLbl = new System.Windows.Forms.Label();
			this.myDocumentsBtn = new System.Windows.Forms.Button();
			this.programDataBtn = new System.Windows.Forms.Button();
			this.programDataLbl = new System.Windows.Forms.Label();
			this.programDataTb = new System.Windows.Forms.TextBox();
			this.resetBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.saveBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// myDocumentsTb
			// 
			this.myDocumentsTb.Location = new System.Drawing.Point(12, 35);
			this.myDocumentsTb.Name = "myDocumentsTb";
			this.myDocumentsTb.Size = new System.Drawing.Size(380, 20);
			this.myDocumentsTb.TabIndex = 1;
			// 
			// myDocumentsLbl
			// 
			this.myDocumentsLbl.AutoSize = true;
			this.myDocumentsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.myDocumentsLbl.Location = new System.Drawing.Point(12, 17);
			this.myDocumentsLbl.Name = "myDocumentsLbl";
			this.myDocumentsLbl.Size = new System.Drawing.Size(127, 15);
			this.myDocumentsLbl.TabIndex = 0;
			this.myDocumentsLbl.Text = "My Documents Folder";
			// 
			// myDocumentsBtn
			// 
			this.myDocumentsBtn.Location = new System.Drawing.Point(398, 33);
			this.myDocumentsBtn.Name = "myDocumentsBtn";
			this.myDocumentsBtn.Size = new System.Drawing.Size(24, 23);
			this.myDocumentsBtn.TabIndex = 2;
			this.myDocumentsBtn.Text = "...";
			this.myDocumentsBtn.UseVisualStyleBackColor = true;
			this.myDocumentsBtn.Click += new System.EventHandler(this.pathBtn_Click);
			// 
			// programDataBtn
			// 
			this.programDataBtn.Location = new System.Drawing.Point(398, 86);
			this.programDataBtn.Name = "programDataBtn";
			this.programDataBtn.Size = new System.Drawing.Size(24, 23);
			this.programDataBtn.TabIndex = 5;
			this.programDataBtn.Text = "...";
			this.programDataBtn.UseVisualStyleBackColor = true;
			this.programDataBtn.Click += new System.EventHandler(this.pathBtn_Click);
			// 
			// programDataLbl
			// 
			this.programDataLbl.AutoSize = true;
			this.programDataLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.programDataLbl.Location = new System.Drawing.Point(12, 70);
			this.programDataLbl.Name = "programDataLbl";
			this.programDataLbl.Size = new System.Drawing.Size(122, 15);
			this.programDataLbl.TabIndex = 3;
			this.programDataLbl.Text = "Program Data Folder";
			// 
			// programDataTb
			// 
			this.programDataTb.Location = new System.Drawing.Point(12, 88);
			this.programDataTb.Name = "programDataTb";
			this.programDataTb.Size = new System.Drawing.Size(380, 20);
			this.programDataTb.TabIndex = 4;
			// 
			// resetBtn
			// 
			this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resetBtn.Location = new System.Drawing.Point(12, 132);
			this.resetBtn.Name = "resetBtn";
			this.resetBtn.Size = new System.Drawing.Size(122, 28);
			this.resetBtn.TabIndex = 6;
			this.resetBtn.Text = "Reset to Default";
			this.resetBtn.UseVisualStyleBackColor = true;
			this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelBtn.Location = new System.Drawing.Point(300, 132);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(122, 28);
			this.cancelBtn.TabIndex = 8;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// saveBtn
			// 
			this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.saveBtn.Location = new System.Drawing.Point(156, 132);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(122, 28);
			this.saveBtn.TabIndex = 7;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 172);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.resetBtn);
			this.Controls.Add(this.programDataBtn);
			this.Controls.Add(this.programDataLbl);
			this.Controls.Add(this.programDataTb);
			this.Controls.Add(this.myDocumentsBtn);
			this.Controls.Add(this.myDocumentsLbl);
			this.Controls.Add(this.myDocumentsTb);
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
		private System.Windows.Forms.TextBox myDocumentsTb;
		private System.Windows.Forms.Label myDocumentsLbl;
		private System.Windows.Forms.Button myDocumentsBtn;
		private System.Windows.Forms.Button programDataBtn;
		private System.Windows.Forms.Label programDataLbl;
		private System.Windows.Forms.TextBox programDataTb;
		private System.Windows.Forms.Button resetBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button saveBtn;
	}
}