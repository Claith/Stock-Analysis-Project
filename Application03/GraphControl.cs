using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Application03
{
	public partial class GraphControl : Form
	{
		Grapher graph = null;
		Point basePosition;
		bool MouseClicked;
		public bool Moved;

		public GraphControl(Grapher Graph)
		{
			InitializeComponent();
			graph = Graph;
			basePosition = this.Location;
			Moved = false;
		}

		private void GraphControl_Load(object sender, EventArgs e)
		{
			//this doesn't matter since it is transparent.
			//this.Size = GrapherControl.Size;

			Point tempPoint = new Point();
			tempPoint = Owner.Location;
			tempPoint.X += 20;
			tempPoint.Y += 40;

			this.Location = tempPoint;

			this.OverviewBox.Checked = graph.Stock.DrawData[(int)StockFile.STOCKTYPE.OVERVIEW];
			this.HighBox.Checked = graph.Stock.DrawData[(int)StockFile.STOCKTYPE.HIGH];
			this.LowBox.Checked = graph.Stock.DrawData[(int)StockFile.STOCKTYPE.LOW];
			this.ClosingBox.Checked = graph.Stock.DrawData[(int)StockFile.STOCKTYPE.CLOSING];
			this.OpeningBox.Checked = graph.Stock.DrawData[(int)StockFile.STOCKTYPE.OPENING];
			this.AdjustedBox.Checked = graph.Stock.DrawData[(int)StockFile.STOCKTYPE.ADJUSTED];

			this.OverviewColorButton.BackColor = StockFile.Pens[(int)StockFile.STOCKTYPE.OVERVIEW];
			this.HighColorButton.BackColor = StockFile.Pens[(int)StockFile.STOCKTYPE.HIGH];
			this.LowColorButton.BackColor = StockFile.Pens[(int)StockFile.STOCKTYPE.LOW];
			this.ClosingColorButton.BackColor = StockFile.Pens[(int)StockFile.STOCKTYPE.CLOSING];
			this.OpeningColorButton.BackColor = StockFile.Pens[(int)StockFile.STOCKTYPE.OPENING];
			this.AdjustedColorButton.BackColor = StockFile.Pens[(int)StockFile.STOCKTYPE.ADJUSTED];

			this.Average1ComboBox.SelectedIndex = 0;
			this.Average2ComboBox.SelectedIndex = 1;

			try
			{
				this.FromDateTimePicker.Value = graph.Start;
				this.ToDateTimePicker.Value = graph.End;
			}
			catch (Exception Time_Exception)
			{
				MessageBox.Show(Time_Exception.ToString());
			}

			this.ClearRadioButton.Checked = true;
		}

		private void HighBox_CheckedChanged(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.HIGH] = HighBox.Checked;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.HIGH] = true;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void LowBox_CheckedChanged(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.LOW] = LowBox.Checked;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.LOW] = true;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void ClosingBox_CheckedChanged(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.CLOSING] = ClosingBox.Checked;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.CLOSING] = true;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void MoveButton_MouseMove(object sender, MouseEventArgs e)
		{
			if(MouseClicked)
				this.Location = new Point((this.Location.X - basePosition.X) + e.X, (this.Location.Y - basePosition.Y) + e.Y);
		}

		private void MoveButton_MouseUp(object sender, MouseEventArgs e)
		{
				MouseClicked = false;
		}

		private void MoveButton_MouseDown(object sender, MouseEventArgs e)
		{
			basePosition = e.Location;

			MouseClicked = true;
			Moved = true;
		}

		private void ResetPositionButton_Click(object sender, EventArgs e)
		{
			Moved = false;

			Point tempPoint = new Point();
			tempPoint = Owner.Location;
			tempPoint.X += 20;
			tempPoint.Y += 40;

			this.Location = tempPoint;
		}

		private void DateRangeButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < (int)StockFile.STOCKTYPE.Count; i++)
				graph.Stock.DataDirty[i] = true;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		#region Changing displayed graph

		private void OverviewBox_CheckChanged(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.OVERVIEW] = this.OverviewBox.Checked;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.OVERVIEW] = true;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void OpeningBox_CheckedChanged(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.OPENING] = this.OpeningBox.Checked;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.OPENING] = true;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void AdjustedBox_CheckedChanged(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.ADJUSTED] = AdjustedBox.Checked;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.ADJUSTED] = true;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void UpdateAveragesButton_Click(object sender, EventArgs e)
		{
			graph.SetAverages((int)Average1DayCount.Value, (int)Average2DayCount.Value);

			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.AVERAGE1] = MovingAverage1CheckBox.Checked;
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.AVERAGE2] = MovingAverage2CheckBox.Checked;

			if (MovingAverage1CheckBox.Checked)
			{
				graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.AVERAGE1] = true;
				graph.Stock.Average1_SeriesType = StockFile.Stocktype_FromString(this.Average1ComboBox.Text);
				graph.Stock.MakeAverage1();
			}

			if (MovingAverage2CheckBox.Checked)
			{
				graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.AVERAGE2] = true;
				graph.Stock.Average2_SeriesType = StockFile.Stocktype_FromString(this.Average2ComboBox.Text);
				graph.Stock.MakeAverage2();
			}

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		#endregion

		private void OverviewColorButton_Click(object sender, EventArgs e)
		{
			ColorDialog ColorBox = new ColorDialog();
			if (DialogResult.OK == ColorBox.ShowDialog(this))
			{
				graph.ChangeColor(StockFile.STOCKTYPE.OVERVIEW, ColorBox.Color);
				this.OverviewColorButton.BackColor = ColorBox.Color;
			}

			ColorBox.Dispose();
		}

		private void HighColorButton_Click(object sender, EventArgs e)
		{
			ColorDialog ColorBox = new ColorDialog();
			if (DialogResult.OK == ColorBox.ShowDialog(this))
			{
				graph.ChangeColor(StockFile.STOCKTYPE.HIGH, ColorBox.Color);
				this.HighColorButton.BackColor = ColorBox.Color;
			}

			ColorBox.Dispose();
		}

		private void LowColorButton_Click(object sender, EventArgs e)
		{
			ColorDialog ColorBox = new ColorDialog();
			if (DialogResult.OK == ColorBox.ShowDialog(this))
			{
				graph.ChangeColor(StockFile.STOCKTYPE.LOW, ColorBox.Color);
				this.LowColorButton.BackColor = ColorBox.Color;
			}

			ColorBox.Dispose();
		}

		private void OpeningColorButton_Click(object sender, EventArgs e)
		{
			ColorDialog ColorBox = new ColorDialog();
			if (DialogResult.OK == ColorBox.ShowDialog(this))
			{
				graph.ChangeColor(StockFile.STOCKTYPE.OPENING, ColorBox.Color);
				this.OpeningColorButton.BackColor = ColorBox.Color;
			}

			ColorBox.Dispose();
		}

		private void ClosingColorButton_Click(object sender, EventArgs e)
		{
			ColorDialog ColorBox = new ColorDialog();
			if (DialogResult.OK == ColorBox.ShowDialog(this))
			{
				graph.ChangeColor(StockFile.STOCKTYPE.CLOSING, ColorBox.Color);
				this.ClosingColorButton.BackColor = ColorBox.Color;
			}

			ColorBox.Dispose();
		}

		private void AdjustedColorButton_Click(object sender, EventArgs e)
		{
			ColorDialog ColorBox = new ColorDialog();
			if (DialogResult.OK == ColorBox.ShowDialog(this))
			{
				graph.ChangeColor(StockFile.STOCKTYPE.ADJUSTED, ColorBox.Color);
				this.AdjustedColorButton.BackColor = ColorBox.Color;
			}

			ColorBox.Dispose();
		}

		private void ClearRadioButton_Click(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.POINT] = false;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void HighRadioButton_Click(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.POINT] = true;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.POINT] = true;

			graph.Stock.Point_SeriesType = StockFile.STOCKTYPE.HIGH;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void LowRadioButton_Click(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.POINT] = true;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.POINT] = true;

			graph.Stock.Point_SeriesType = StockFile.STOCKTYPE.LOW;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void OpeningRadioButton_Click(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.POINT] = true;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.POINT] = true;

			graph.Stock.Point_SeriesType = StockFile.STOCKTYPE.OPENING;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void ClosingRadioButton_Click(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.POINT] = true;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.POINT] = true;

			graph.Stock.Point_SeriesType = StockFile.STOCKTYPE.CLOSING;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}

		private void AdjustedRadioButton_Click(object sender, EventArgs e)
		{
			graph.Stock.DrawData[(int)StockFile.STOCKTYPE.POINT] = true;
			graph.Stock.DataDirty[(int)StockFile.STOCKTYPE.POINT] = true;

			graph.Stock.Point_SeriesType = StockFile.STOCKTYPE.ADJUSTED;

			graph.UpdateGraph(FromDateTimePicker.Value, ToDateTimePicker.Value);
		}
	}
}
