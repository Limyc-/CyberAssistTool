namespace CyberAssistTool
{
	partial class FileChoiceDialog
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
			this.tribesButton = new System.Windows.Forms.Button();
			this.smiteButton = new System.Windows.Forms.Button();
			this.otherButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tribesBtn
			// 
			this.tribesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tribesButton.Location = new System.Drawing.Point(12, 57);
			this.tribesButton.Name = "tribesBtn";
			this.tribesButton.Size = new System.Drawing.Size(100, 30);
			this.tribesButton.TabIndex = 0;
			this.tribesButton.Text = "Tribes";
			this.tribesButton.UseVisualStyleBackColor = true;
			this.tribesButton.Click += new System.EventHandler(this.tribesButton_Click);
			// 
			// smiteBtn
			// 
			this.smiteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.smiteButton.Location = new System.Drawing.Point(118, 57);
			this.smiteButton.Name = "smiteBtn";
			this.smiteButton.Size = new System.Drawing.Size(100, 30);
			this.smiteButton.TabIndex = 1;
			this.smiteButton.Text = "Smite";
			this.smiteButton.UseVisualStyleBackColor = true;
			this.smiteButton.Click += new System.EventHandler(this.smiteButton_Click);
			// 
			// otherBtn
			// 
			this.otherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.otherButton.Location = new System.Drawing.Point(224, 57);
			this.otherButton.Name = "otherBtn";
			this.otherButton.Size = new System.Drawing.Size(100, 30);
			this.otherButton.TabIndex = 2;
			this.otherButton.Text = "Other";
			this.otherButton.UseVisualStyleBackColor = true;
			this.otherButton.Click += new System.EventHandler(this.otherButton_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(321, 35);
			this.label1.TabIndex = 3;
			this.label1.Text = "Which game configuration would you like to edit?";
			// 
			// ConfigChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(336, 97);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.otherButton);
			this.Controls.Add(this.smiteButton);
			this.Controls.Add(this.tribesButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConfigChoice";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Decision Time";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button tribesButton;
		private System.Windows.Forms.Button smiteButton;
		private System.Windows.Forms.Button otherButton;
		private System.Windows.Forms.Label label1;
	}
}