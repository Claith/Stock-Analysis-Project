namespace Application03
{
	partial class StatGrapher
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
			this.LoadDataButton = new System.Windows.Forms.Button();
			this.FileListBox = new System.Windows.Forms.ListBox();
			this.OperationLabel = new System.Windows.Forms.Label();
			this.FileListLabel = new System.Windows.Forms.Label();
			this.RemoveFileButton = new System.Windows.Forms.Button();
			this.ShowButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LoadDataButton
			// 
			this.LoadDataButton.Location = new System.Drawing.Point(12, 29);
			this.LoadDataButton.Name = "LoadDataButton";
			this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
			this.LoadDataButton.TabIndex = 0;
			this.LoadDataButton.Text = "Load CSV";
			this.LoadDataButton.UseVisualStyleBackColor = true;
			this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
			// 
			// FileListBox
			// 
			this.FileListBox.FormattingEnabled = true;
			this.FileListBox.Location = new System.Drawing.Point(105, 29);
			this.FileListBox.Name = "FileListBox";
			this.FileListBox.Size = new System.Drawing.Size(120, 95);
			this.FileListBox.TabIndex = 1;
			// 
			// OperationLabel
			// 
			this.OperationLabel.AutoSize = true;
			this.OperationLabel.Location = new System.Drawing.Point(13, 13);
			this.OperationLabel.Name = "OperationLabel";
			this.OperationLabel.Size = new System.Drawing.Size(77, 13);
			this.OperationLabel.TabIndex = 2;
			this.OperationLabel.Text = "File Operations";
			// 
			// FileListLabel
			// 
			this.FileListLabel.AutoSize = true;
			this.FileListLabel.Location = new System.Drawing.Point(102, 13);
			this.FileListLabel.Name = "FileListLabel";
			this.FileListLabel.Size = new System.Drawing.Size(42, 13);
			this.FileListLabel.TabIndex = 3;
			this.FileListLabel.Text = "File List";
			// 
			// RemoveFileButton
			// 
			this.RemoveFileButton.Location = new System.Drawing.Point(12, 58);
			this.RemoveFileButton.Name = "RemoveFileButton";
			this.RemoveFileButton.Size = new System.Drawing.Size(75, 23);
			this.RemoveFileButton.TabIndex = 4;
			this.RemoveFileButton.Text = "Remove";
			this.RemoveFileButton.UseVisualStyleBackColor = true;
			this.RemoveFileButton.Click += new System.EventHandler(this.RemoveFileButton_Click);
			// 
			// ShowButton
			// 
			this.ShowButton.Location = new System.Drawing.Point(12, 88);
			this.ShowButton.Name = "ShowButton";
			this.ShowButton.Size = new System.Drawing.Size(75, 23);
			this.ShowButton.TabIndex = 5;
			this.ShowButton.Text = "Display";
			this.ShowButton.UseVisualStyleBackColor = true;
			this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
			// 
			// StatGrapher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(237, 134);
			this.Controls.Add(this.ShowButton);
			this.Controls.Add(this.RemoveFileButton);
			this.Controls.Add(this.FileListLabel);
			this.Controls.Add(this.OperationLabel);
			this.Controls.Add(this.FileListBox);
			this.Controls.Add(this.LoadDataButton);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "StatGrapher";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "StatGrapher";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button LoadDataButton;
		private System.Windows.Forms.ListBox FileListBox;
		private System.Windows.Forms.Label OperationLabel;
		private System.Windows.Forms.Label FileListLabel;
		private System.Windows.Forms.Button RemoveFileButton;
		private System.Windows.Forms.Button ShowButton;
	}
}

