namespace CyberAssistTool
{
	partial class ConfigChoice
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
			this.tribesBtn = new System.Windows.Forms.Button();
			this.smiteBtn = new System.Windows.Forms.Button();
			this.otherBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tribesBtn
			// 
			this.tribesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tribesBtn.Location = new System.Drawing.Point(12, 57);
			this.tribesBtn.Name = "tribesBtn";
			this.tribesBtn.Size = new System.Drawing.Size(100, 30);
			this.tribesBtn.TabIndex = 0;
			this.tribesBtn.Text = "Tribes";
			this.tribesBtn.UseVisualStyleBackColor = true;
			this.tribesBtn.Click += new System.EventHandler(this.tribesBtn_Click);
			// 
			// smiteBtn
			// 
			this.smiteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.smiteBtn.Location = new System.Drawing.Point(118, 57);
			this.smiteBtn.Name = "smiteBtn";
			this.smiteBtn.Size = new System.Drawing.Size(100, 30);
			this.smiteBtn.TabIndex = 1;
			this.smiteBtn.Text = "Smite";
			this.smiteBtn.UseVisualStyleBackColor = true;
			this.smiteBtn.Click += new System.EventHandler(this.smiteBtn_Click);
			// 
			// otherBtn
			// 
			this.otherBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.otherBtn.Location = new System.Drawing.Point(224, 57);
			this.otherBtn.Name = "otherBtn";
			this.otherBtn.Size = new System.Drawing.Size(100, 30);
			this.otherBtn.TabIndex = 2;
			this.otherBtn.Text = "Other";
			this.otherBtn.UseVisualStyleBackColor = true;
			this.otherBtn.Click += new System.EventHandler(this.otherBtn_Click);
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
			this.Controls.Add(this.otherBtn);
			this.Controls.Add(this.smiteBtn);
			this.Controls.Add(this.tribesBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConfigChoice";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Decision Time";
			this.Load += new System.EventHandler(this.ConfigChoice_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button tribesBtn;
		private System.Windows.Forms.Button smiteBtn;
		private System.Windows.Forms.Button otherBtn;
		private System.Windows.Forms.Label label1;
	}
}