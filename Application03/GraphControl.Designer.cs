namespace Application03
{
	partial class GraphControl
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
			this.GrapherControl = new System.Windows.Forms.TabControl();
			this.LegendPage = new System.Windows.Forms.TabPage();
			this.ClearLabel = new System.Windows.Forms.Label();
			this.ClearRadioButton = new System.Windows.Forms.RadioButton();
			this.AdjustedRadioButton = new System.Windows.Forms.RadioButton();
			this.ClosingRadioButton = new System.Windows.Forms.RadioButton();
			this.OpeningRadioButton = new System.Windows.Forms.RadioButton();
			this.LowRadioButton = new System.Windows.Forms.RadioButton();
			this.HighRadioButton = new System.Windows.Forms.RadioButton();
			this.AdjustedColorButton = new System.Windows.Forms.Button();
			this.OpeningColorButton = new System.Windows.Forms.Button();
			this.ClosingColorButton = new System.Windows.Forms.Button();
			this.LowColorButton = new System.Windows.Forms.Button();
			this.HighColorButton = new System.Windows.Forms.Button();
			this.AdjustedBox = new System.Windows.Forms.CheckBox();
			this.OpeningBox = new System.Windows.Forms.CheckBox();
			this.ClosingBox = new System.Windows.Forms.CheckBox();
			this.LowBox = new System.Windows.Forms.CheckBox();
			this.HighBox = new System.Windows.Forms.CheckBox();
			this.OverviewBox = new System.Windows.Forms.CheckBox();
			this.OverviewColorButton = new System.Windows.Forms.Button();
			this.OperationsTab = new System.Windows.Forms.TabPage();
			this.DateRangeButton = new System.Windows.Forms.Button();
			this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.DateToLabel = new System.Windows.Forms.Label();
			this.DataButton = new System.Windows.Forms.Button();
			this.DataFromLabel = new System.Windows.Forms.Label();
			this.AverageTab = new System.Windows.Forms.TabPage();
			this.Average2ComboBox = new System.Windows.Forms.ComboBox();
			this.Average1ComboBox = new System.Windows.Forms.ComboBox();
			this.UpdateAveragesButton = new System.Windows.Forms.Button();
			this.Average2DayCount = new System.Windows.Forms.NumericUpDown();
			this.MovingAverage2CheckBox = new System.Windows.Forms.CheckBox();
			this.Average1DayCount = new System.Windows.Forms.NumericUpDown();
			this.MovingAverage1CheckBox = new System.Windows.Forms.CheckBox();
			this.MoveButton = new System.Windows.Forms.Button();
			this.ResetPositionButton = new System.Windows.Forms.Button();
			this.GrapherControl.SuspendLayout();
			this.LegendPage.SuspendLayout();
			this.OperationsTab.SuspendLayout();
			this.AverageTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Average2DayCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Average1DayCount)).BeginInit();
			this.SuspendLayout();
			// 
			// GrapherControl
			// 
			this.GrapherControl.Controls.Add(this.LegendPage);
			this.GrapherControl.Controls.Add(this.OperationsTab);
			this.GrapherControl.Controls.Add(this.AverageTab);
			this.GrapherControl.Location = new System.Drawing.Point(0, 0);
			this.GrapherControl.Name = "GrapherControl";
			this.GrapherControl.SelectedIndex = 0;
			this.GrapherControl.Size = new System.Drawing.Size(150, 185);
			this.GrapherControl.TabIndex = 0;
			this.GrapherControl.TabStop = false;
			// 
			// LegendPage
			// 
			this.LegendPage.Controls.Add(this.ClearLabel);
			this.LegendPage.Controls.Add(this.ClearRadioButton);
			this.LegendPage.Controls.Add(this.AdjustedRadioButton);
			this.LegendPage.Controls.Add(this.ClosingRadioButton);
			this.LegendPage.Controls.Add(this.OpeningRadioButton);
			this.LegendPage.Controls.Add(this.LowRadioButton);
			this.LegendPage.Controls.Add(this.HighRadioButton);
			this.LegendPage.Controls.Add(this.AdjustedColorButton);
			this.LegendPage.Controls.Add(this.OpeningColorButton);
			this.LegendPage.Controls.Add(this.ClosingColorButton);
			this.LegendPage.Controls.Add(this.LowColorButton);
			this.LegendPage.Controls.Add(this.HighColorButton);
			this.LegendPage.Controls.Add(this.AdjustedBox);
			this.LegendPage.Controls.Add(this.OpeningBox);
			this.LegendPage.Controls.Add(this.ClosingBox);
			this.LegendPage.Controls.Add(this.LowBox);
			this.LegendPage.Controls.Add(this.HighBox);
			this.LegendPage.Controls.Add(this.OverviewBox);
			this.LegendPage.Controls.Add(this.OverviewColorButton);
			this.LegendPage.Location = new System.Drawing.Point(4, 22);
			this.LegendPage.Name = "LegendPage";
			this.LegendPage.Padding = new System.Windows.Forms.Padding(3);
			this.LegendPage.Size = new System.Drawing.Size(142, 159);
			this.LegendPage.TabIndex = 0;
			this.LegendPage.Text = "Legend";
			this.LegendPage.UseVisualStyleBackColor = true;
			// 
			// ClearLabel
			// 
			this.ClearLabel.AutoSize = true;
			this.ClearLabel.Location = new System.Drawing.Point(103, 3);
			this.ClearLabel.Name = "ClearLabel";
			this.ClearLabel.Size = new System.Drawing.Size(19, 13);
			this.ClearLabel.TabIndex = 19;
			this.ClearLabel.Text = "Clr";
			// 
			// ClearRadioButton
			// 
			this.ClearRadioButton.AutoSize = true;
			this.ClearRadioButton.Location = new System.Drawing.Point(122, 11);
			this.ClearRadioButton.Name = "ClearRadioButton";
			this.ClearRadioButton.Size = new System.Drawing.Size(14, 13);
			this.ClearRadioButton.TabIndex = 18;
			this.ClearRadioButton.TabStop = true;
			this.ClearRadioButton.UseVisualStyleBackColor = true;
			this.ClearRadioButton.Click += new System.EventHandler(this.ClearRadioButton_Click);
			// 
			// AdjustedRadioButton
			// 
			this.AdjustedRadioButton.AutoSize = true;
			this.AdjustedRadioButton.Location = new System.Drawing.Point(122, 129);
			this.AdjustedRadioButton.Name = "AdjustedRadioButton";
			this.AdjustedRadioButton.Size = new System.Drawing.Size(14, 13);
			this.AdjustedRadioButton.TabIndex = 17;
			this.AdjustedRadioButton.TabStop = true;
			this.AdjustedRadioButton.UseVisualStyleBackColor = true;
			this.AdjustedRadioButton.Click += new System.EventHandler(this.AdjustedRadioButton_Click);
			// 
			// ClosingRadioButton
			// 
			this.ClosingRadioButton.AutoSize = true;
			this.ClosingRadioButton.Location = new System.Drawing.Point(122, 105);
			this.ClosingRadioButton.Name = "ClosingRadioButton";
			this.ClosingRadioButton.Size = new System.Drawing.Size(14, 13);
			this.ClosingRadioButton.TabIndex = 16;
			this.ClosingRadioButton.TabStop = true;
			this.ClosingRadioButton.UseVisualStyleBackColor = true;
			this.ClosingRadioButton.Click += new System.EventHandler(this.ClosingRadioButton_Click);
			// 
			// OpeningRadioButton
			// 
			this.OpeningRadioButton.AutoSize = true;
			this.OpeningRadioButton.Location = new System.Drawing.Point(122, 82);
			this.OpeningRadioButton.Name = "OpeningRadioButton";
			this.OpeningRadioButton.Size = new System.Drawing.Size(14, 13);
			this.OpeningRadioButton.TabIndex = 15;
			this.OpeningRadioButton.TabStop = true;
			this.OpeningRadioButton.UseVisualStyleBackColor = true;
			this.OpeningRadioButton.Click += new System.EventHandler(this.OpeningRadioButton_Click);
			// 
			// LowRadioButton
			// 
			this.LowRadioButton.AutoSize = true;
			this.LowRadioButton.Location = new System.Drawing.Point(122, 59);
			this.LowRadioButton.Name = "LowRadioButton";
			this.LowRadioButton.Size = new System.Drawing.Size(14, 13);
			this.LowRadioButton.TabIndex = 14;
			this.LowRadioButton.TabStop = true;
			this.LowRadioButton.UseVisualStyleBackColor = true;
			this.LowRadioButton.Click += new System.EventHandler(this.LowRadioButton_Click);
			// 
			// HighRadioButton
			// 
			this.HighRadioButton.AutoSize = true;
			this.HighRadioButton.Location = new System.Drawing.Point(122, 35);
			this.HighRadioButton.Name = "HighRadioButton";
			this.HighRadioButton.Size = new System.Drawing.Size(14, 13);
			this.HighRadioButton.TabIndex = 13;
			this.HighRadioButton.TabStop = true;
			this.HighRadioButton.UseVisualStyleBackColor = true;
			this.HighRadioButton.Click += new System.EventHandler(this.HighRadioButton_Click);
			// 
			// AdjustedColorButton
			// 
			this.AdjustedColorButton.BackColor = System.Drawing.Color.Transparent;
			this.AdjustedColorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.AdjustedColorButton.Location = new System.Drawing.Point(8, 124);
			this.AdjustedColorButton.Name = "AdjustedColorButton";
			this.AdjustedColorButton.Size = new System.Drawing.Size(23, 23);
			this.AdjustedColorButton.TabIndex = 12;
			this.AdjustedColorButton.UseVisualStyleBackColor = false;
			this.AdjustedColorButton.Click += new System.EventHandler(this.AdjustedColorButton_Click);
			// 
			// OpeningColorButton
			// 
			this.OpeningColorButton.BackColor = System.Drawing.Color.Transparent;
			this.OpeningColorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.OpeningColorButton.Location = new System.Drawing.Point(8, 77);
			this.OpeningColorButton.Name = "OpeningColorButton";
			this.OpeningColorButton.Size = new System.Drawing.Size(23, 23);
			this.OpeningColorButton.TabIndex = 11;
			this.OpeningColorButton.UseVisualStyleBackColor = false;
			this.OpeningColorButton.Click += new System.EventHandler(this.OpeningColorButton_Click);
			// 
			// ClosingColorButton
			// 
			this.ClosingColorButton.BackColor = System.Drawing.Color.Transparent;
			this.ClosingColorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ClosingColorButton.Location = new System.Drawing.Point(8, 100);
			this.ClosingColorButton.Name = "ClosingColorButton";
			this.ClosingColorButton.Size = new System.Drawing.Size(23, 23);
			this.ClosingColorButton.TabIndex = 10;
			this.ClosingColorButton.UseVisualStyleBackColor = false;
			this.ClosingColorButton.Click += new System.EventHandler(this.ClosingColorButton_Click);
			// 
			// LowColorButton
			// 
			this.LowColorButton.BackColor = System.Drawing.Color.Transparent;
			this.LowColorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.LowColorButton.Location = new System.Drawing.Point(8, 54);
			this.LowColorButton.Name = "LowColorButton";
			this.LowColorButton.Size = new System.Drawing.Size(23, 23);
			this.LowColorButton.TabIndex = 9;
			this.LowColorButton.UseVisualStyleBackColor = false;
			this.LowColorButton.Click += new System.EventHandler(this.LowColorButton_Click);
			// 
			// HighColorButton
			// 
			this.HighColorButton.BackColor = System.Drawing.Color.Transparent;
			this.HighColorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.HighColorButton.Location = new System.Drawing.Point(8, 30);
			this.HighColorButton.Name = "HighColorButton";
			this.HighColorButton.Size = new System.Drawing.Size(23, 23);
			this.HighColorButton.TabIndex = 8;
			this.HighColorButton.UseVisualStyleBackColor = false;
			this.HighColorButton.Click += new System.EventHandler(this.HighColorButton_Click);
			// 
			// AdjustedBox
			// 
			this.AdjustedBox.AutoSize = true;
			this.AdjustedBox.Location = new System.Drawing.Point(37, 126);
			this.AdjustedBox.Name = "AdjustedBox";
			this.AdjustedBox.Size = new System.Drawing.Size(67, 17);
			this.AdjustedBox.TabIndex = 6;
			this.AdjustedBox.Text = "Adjusted";
			this.AdjustedBox.UseVisualStyleBackColor = true;
			this.AdjustedBox.CheckedChanged += new System.EventHandler(this.AdjustedBox_CheckedChanged);
			// 
			// OpeningBox
			// 
			this.OpeningBox.AutoSize = true;
			this.OpeningBox.Location = new System.Drawing.Point(37, 81);
			this.OpeningBox.Name = "OpeningBox";
			this.OpeningBox.Size = new System.Drawing.Size(66, 17);
			this.OpeningBox.TabIndex = 5;
			this.OpeningBox.Text = "Opening";
			this.OpeningBox.UseVisualStyleBackColor = true;
			this.OpeningBox.CheckedChanged += new System.EventHandler(this.OpeningBox_CheckedChanged);
			// 
			// ClosingBox
			// 
			this.ClosingBox.AutoSize = true;
			this.ClosingBox.Location = new System.Drawing.Point(37, 104);
			this.ClosingBox.Name = "ClosingBox";
			this.ClosingBox.Size = new System.Drawing.Size(60, 17);
			this.ClosingBox.TabIndex = 4;
			this.ClosingBox.Text = "Closing";
			this.ClosingBox.UseVisualStyleBackColor = true;
			this.ClosingBox.CheckedChanged += new System.EventHandler(this.ClosingBox_CheckedChanged);
			// 
			// LowBox
			// 
			this.LowBox.AutoSize = true;
			this.LowBox.Location = new System.Drawing.Point(37, 58);
			this.LowBox.Name = "LowBox";
			this.LowBox.Size = new System.Drawing.Size(46, 17);
			this.LowBox.TabIndex = 3;
			this.LowBox.Text = "Low";
			this.LowBox.UseVisualStyleBackColor = true;
			this.LowBox.CheckedChanged += new System.EventHandler(this.LowBox_CheckedChanged);
			// 
			// HighBox
			// 
			this.HighBox.AutoSize = true;
			this.HighBox.Location = new System.Drawing.Point(37, 34);
			this.HighBox.Name = "HighBox";
			this.HighBox.Size = new System.Drawing.Size(48, 17);
			this.HighBox.TabIndex = 2;
			this.HighBox.Text = "High";
			this.HighBox.UseVisualStyleBackColor = true;
			this.HighBox.CheckedChanged += new System.EventHandler(this.HighBox_CheckedChanged);
			// 
			// OverviewBox
			// 
			this.OverviewBox.AutoSize = true;
			this.OverviewBox.Location = new System.Drawing.Point(37, 10);
			this.OverviewBox.Name = "OverviewBox";
			this.OverviewBox.Size = new System.Drawing.Size(71, 17);
			this.OverviewBox.TabIndex = 1;
			this.OverviewBox.Text = "Overview";
			this.OverviewBox.UseVisualStyleBackColor = true;
			this.OverviewBox.Click += new System.EventHandler(this.OverviewBox_CheckChanged);
			// 
			// OverviewColorButton
			// 
			this.OverviewColorButton.BackColor = System.Drawing.Color.Transparent;
			this.OverviewColorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.OverviewColorButton.Location = new System.Drawing.Point(8, 6);
			this.OverviewColorButton.Name = "OverviewColorButton";
			this.OverviewColorButton.Size = new System.Drawing.Size(23, 23);
			this.OverviewColorButton.TabIndex = 0;
			this.OverviewColorButton.UseVisualStyleBackColor = false;
			this.OverviewColorButton.Click += new System.EventHandler(this.OverviewColorButton_Click);
			// 
			// OperationsTab
			// 
			this.OperationsTab.Controls.Add(this.DateRangeButton);
			this.OperationsTab.Controls.Add(this.ToDateTimePicker);
			this.OperationsTab.Controls.Add(this.FromDateTimePicker);
			this.OperationsTab.Controls.Add(this.DateToLabel);
			this.OperationsTab.Controls.Add(this.DataButton);
			this.OperationsTab.Controls.Add(this.DataFromLabel);
			this.OperationsTab.Location = new System.Drawing.Point(4, 22);
			this.OperationsTab.Name = "OperationsTab";
			this.OperationsTab.Padding = new System.Windows.Forms.Padding(3);
			this.OperationsTab.Size = new System.Drawing.Size(142, 159);
			this.OperationsTab.TabIndex = 1;
			this.OperationsTab.Text = "Display";
			this.OperationsTab.UseVisualStyleBackColor = true;
			// 
			// DateRangeButton
			// 
			this.DateRangeButton.Location = new System.Drawing.Point(10, 90);
			this.DateRangeButton.Name = "DateRangeButton";
			this.DateRangeButton.Size = new System.Drawing.Size(126, 23);
			this.DateRangeButton.TabIndex = 7;
			this.DateRangeButton.Text = "Update Chart";
			this.DateRangeButton.UseVisualStyleBackColor = true;
			this.DateRangeButton.Click += new System.EventHandler(this.DateRangeButton_Click);
			// 
			// ToDateTimePicker
			// 
			this.ToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.ToDateTimePicker.Location = new System.Drawing.Point(10, 63);
			this.ToDateTimePicker.Name = "ToDateTimePicker";
			this.ToDateTimePicker.Size = new System.Drawing.Size(126, 20);
			this.ToDateTimePicker.TabIndex = 6;
			// 
			// FromDateTimePicker
			// 
			this.FromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.FromDateTimePicker.Location = new System.Drawing.Point(10, 23);
			this.FromDateTimePicker.Name = "FromDateTimePicker";
			this.FromDateTimePicker.Size = new System.Drawing.Size(126, 20);
			this.FromDateTimePicker.TabIndex = 5;
			// 
			// DateToLabel
			// 
			this.DateToLabel.AutoSize = true;
			this.DateToLabel.Location = new System.Drawing.Point(7, 46);
			this.DateToLabel.Name = "DateToLabel";
			this.DateToLabel.Size = new System.Drawing.Size(23, 13);
			this.DateToLabel.TabIndex = 4;
			this.DateToLabel.Text = "To:";
			// 
			// DataButton
			// 
			this.DataButton.Enabled = false;
			this.DataButton.Location = new System.Drawing.Point(10, 127);
			this.DataButton.Name = "DataButton";
			this.DataButton.Size = new System.Drawing.Size(126, 23);
			this.DataButton.TabIndex = 3;
			this.DataButton.Text = "Data";
			this.DataButton.UseVisualStyleBackColor = true;
			// 
			// DataFromLabel
			// 
			this.DataFromLabel.AutoSize = true;
			this.DataFromLabel.Location = new System.Drawing.Point(7, 7);
			this.DataFromLabel.Name = "DataFromLabel";
			this.DataFromLabel.Size = new System.Drawing.Size(33, 13);
			this.DataFromLabel.TabIndex = 1;
			this.DataFromLabel.Text = "From:";
			// 
			// AverageTab
			// 
			this.AverageTab.Controls.Add(this.Average2ComboBox);
			this.AverageTab.Controls.Add(this.Average1ComboBox);
			this.AverageTab.Controls.Add(this.UpdateAveragesButton);
			this.AverageTab.Controls.Add(this.Average2DayCount);
			this.AverageTab.Controls.Add(this.MovingAverage2CheckBox);
			this.AverageTab.Controls.Add(this.Average1DayCount);
			this.AverageTab.Controls.Add(this.MovingAverage1CheckBox);
			this.AverageTab.Location = new System.Drawing.Point(4, 22);
			this.AverageTab.Name = "AverageTab";
			this.AverageTab.Padding = new System.Windows.Forms.Padding(3);
			this.AverageTab.Size = new System.Drawing.Size(142, 159);
			this.AverageTab.TabIndex = 2;
			this.AverageTab.Text = "Average";
			this.AverageTab.UseVisualStyleBackColor = true;
			// 
			// Average2ComboBox
			// 
			this.Average2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Average2ComboBox.FormattingEnabled = true;
			this.Average2ComboBox.Items.AddRange(new object[] {
            "High",
            "Low",
            "Opening",
            "Closing",
            "Adjusted"});
			this.Average2ComboBox.Location = new System.Drawing.Point(8, 105);
			this.Average2ComboBox.Name = "Average2ComboBox";
			this.Average2ComboBox.Size = new System.Drawing.Size(80, 21);
			this.Average2ComboBox.TabIndex = 7;
			// 
			// Average1ComboBox
			// 
			this.Average1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Average1ComboBox.FormattingEnabled = true;
			this.Average1ComboBox.Items.AddRange(new object[] {
            "High",
            "Low",
            "Opening",
            "Closing",
            "Adjusted"});
			this.Average1ComboBox.Location = new System.Drawing.Point(8, 42);
			this.Average1ComboBox.Name = "Average1ComboBox";
			this.Average1ComboBox.Size = new System.Drawing.Size(80, 21);
			this.Average1ComboBox.TabIndex = 6;
			// 
			// UpdateAveragesButton
			// 
			this.UpdateAveragesButton.Location = new System.Drawing.Point(8, 132);
			this.UpdateAveragesButton.Name = "UpdateAveragesButton";
			this.UpdateAveragesButton.Size = new System.Drawing.Size(120, 23);
			this.UpdateAveragesButton.TabIndex = 5;
			this.UpdateAveragesButton.Text = "Update Averages";
			this.UpdateAveragesButton.UseVisualStyleBackColor = true;
			this.UpdateAveragesButton.Click += new System.EventHandler(this.UpdateAveragesButton_Click);
			// 
			// Average2DayCount
			// 
			this.Average2DayCount.Location = new System.Drawing.Point(94, 106);
			this.Average2DayCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.Average2DayCount.Name = "Average2DayCount";
			this.Average2DayCount.Size = new System.Drawing.Size(34, 20);
			this.Average2DayCount.TabIndex = 4;
			this.Average2DayCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// MovingAverage2CheckBox
			// 
			this.MovingAverage2CheckBox.AutoSize = true;
			this.MovingAverage2CheckBox.Location = new System.Drawing.Point(8, 69);
			this.MovingAverage2CheckBox.Name = "MovingAverage2CheckBox";
			this.MovingAverage2CheckBox.Size = new System.Drawing.Size(120, 30);
			this.MovingAverage2CheckBox.TabIndex = 3;
			this.MovingAverage2CheckBox.Text = "Moving Average #2\r\n(# of Data Points)";
			this.MovingAverage2CheckBox.UseVisualStyleBackColor = true;
			// 
			// Average1DayCount
			// 
			this.Average1DayCount.Location = new System.Drawing.Point(94, 42);
			this.Average1DayCount.Name = "Average1DayCount";
			this.Average1DayCount.Size = new System.Drawing.Size(34, 20);
			this.Average1DayCount.TabIndex = 2;
			this.Average1DayCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// MovingAverage1CheckBox
			// 
			this.MovingAverage1CheckBox.AutoSize = true;
			this.MovingAverage1CheckBox.Location = new System.Drawing.Point(8, 6);
			this.MovingAverage1CheckBox.Name = "MovingAverage1CheckBox";
			this.MovingAverage1CheckBox.Size = new System.Drawing.Size(120, 30);
			this.MovingAverage1CheckBox.TabIndex = 1;
			this.MovingAverage1CheckBox.Text = "Moving Average #1\r\n(# of Data Points)";
			this.MovingAverage1CheckBox.UseVisualStyleBackColor = true;
			// 
			// MoveButton
			// 
			this.MoveButton.BackColor = System.Drawing.Color.White;
			this.MoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.MoveButton.Location = new System.Drawing.Point(0, 181);
			this.MoveButton.Name = "MoveButton";
			this.MoveButton.Size = new System.Drawing.Size(89, 22);
			this.MoveButton.TabIndex = 13;
			this.MoveButton.TabStop = false;
			this.MoveButton.Text = "Drag";
			this.MoveButton.UseMnemonic = false;
			this.MoveButton.UseVisualStyleBackColor = false;
			this.MoveButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveButton_MouseDown);
			this.MoveButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveButton_MouseMove);
			this.MoveButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveButton_MouseUp);
			// 
			// ResetPositionButton
			// 
			this.ResetPositionButton.BackColor = System.Drawing.Color.White;
			this.ResetPositionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ResetPositionButton.Location = new System.Drawing.Point(85, 181);
			this.ResetPositionButton.Name = "ResetPositionButton";
			this.ResetPositionButton.Size = new System.Drawing.Size(65, 22);
			this.ResetPositionButton.TabIndex = 14;
			this.ResetPositionButton.Text = "Reset";
			this.ResetPositionButton.UseVisualStyleBackColor = false;
			this.ResetPositionButton.Click += new System.EventHandler(this.ResetPositionButton_Click);
			// 
			// GraphControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(160, 213);
			this.ControlBox = false;
			this.Controls.Add(this.ResetPositionButton);
			this.Controls.Add(this.MoveButton);
			this.Controls.Add(this.GrapherControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "GraphControl";
			this.Opacity = 0.8D;
			this.ShowInTaskbar = false;
			this.Text = "GraphControl";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.Load += new System.EventHandler(this.GraphControl_Load);
			this.GrapherControl.ResumeLayout(false);
			this.LegendPage.ResumeLayout(false);
			this.LegendPage.PerformLayout();
			this.OperationsTab.ResumeLayout(false);
			this.OperationsTab.PerformLayout();
			this.AverageTab.ResumeLayout(false);
			this.AverageTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Average2DayCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Average1DayCount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl GrapherControl;
		private System.Windows.Forms.TabPage LegendPage;
		private System.Windows.Forms.TabPage OperationsTab;
		private System.Windows.Forms.Button AdjustedColorButton;
		private System.Windows.Forms.Button OpeningColorButton;
		private System.Windows.Forms.Button ClosingColorButton;
		private System.Windows.Forms.Button LowColorButton;
		private System.Windows.Forms.Button HighColorButton;
		private System.Windows.Forms.CheckBox AdjustedBox;
		private System.Windows.Forms.CheckBox OpeningBox;
		private System.Windows.Forms.CheckBox ClosingBox;
		private System.Windows.Forms.CheckBox LowBox;
		private System.Windows.Forms.CheckBox HighBox;
		private System.Windows.Forms.CheckBox OverviewBox;
		private System.Windows.Forms.Button OverviewColorButton;
		private System.Windows.Forms.Label DataFromLabel;
		private System.Windows.Forms.Button DataButton;
		private System.Windows.Forms.Button MoveButton;
		private System.Windows.Forms.Label DateToLabel;
		private System.Windows.Forms.DateTimePicker ToDateTimePicker;
		private System.Windows.Forms.DateTimePicker FromDateTimePicker;
		private System.Windows.Forms.Button ResetPositionButton;
		private System.Windows.Forms.Button DateRangeButton;
		private System.Windows.Forms.RadioButton AdjustedRadioButton;
		private System.Windows.Forms.RadioButton ClosingRadioButton;
		private System.Windows.Forms.RadioButton OpeningRadioButton;
		private System.Windows.Forms.RadioButton LowRadioButton;
		private System.Windows.Forms.RadioButton HighRadioButton;
		private System.Windows.Forms.TabPage AverageTab;
		private System.Windows.Forms.NumericUpDown Average1DayCount;
		private System.Windows.Forms.CheckBox MovingAverage1CheckBox;
		private System.Windows.Forms.Label ClearLabel;
		private System.Windows.Forms.RadioButton ClearRadioButton;
		private System.Windows.Forms.NumericUpDown Average2DayCount;
		private System.Windows.Forms.CheckBox MovingAverage2CheckBox;
		private System.Windows.Forms.Button UpdateAveragesButton;
		private System.Windows.Forms.ComboBox Average1ComboBox;
		private System.Windows.Forms.ComboBox Average2ComboBox;
	}
}