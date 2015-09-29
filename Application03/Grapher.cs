using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Application03
{
	public partial class Grapher : Form
	{
		private StockFile stock = null;
		public StockFile Stock
		{
			set { stock = value; }
			get { return stock; }
		}

		bool stockLoaded = false;

		DateTime ViewStart = default(DateTime);
		DateTime ViewEnd = default(DateTime);

		public DateTime Start
		{
			get { return ViewStart; }
		}
		public DateTime End
		{
			get { return ViewEnd; }
		}

		GraphControl GrapherControl = null;
		Chart DataChart = null;
		Data DataGrid = null;
		ToolTip MouseToolTip = null;

		public Grapher()
		{
			InitializeComponent();
		}

		private void Grapher_Paint(object sender, PaintEventArgs e)
		{
			//if (stock == null) this.Hide(); //don't show if no stock is to be shown -- hacky
		}

		private void Grapher_Load(object sender, EventArgs e)
		{
			State.Wait();

			try
			{
				DataChart = new Chart();
				DataChart.Name = "StockChart";
				DataChart.ChartAreas.Add("StockArea");
					
				this.Controls.Add(DataChart);
				DataChart.Dock = DockStyle.Fill;

				//DataChart.Series.Add(Stock[StockFile.STOCKTYPE.OVERVIEW]);

				this.UpdateGraph(DateTime.MinValue, DateTime.MaxValue);

				//don't know if the constructors are needed for structs, but meh for now
				ViewStart = new DateTime();
				ViewEnd = new DateTime();
				//I feel that using Series.Last() right now is a cheap move, but getting it to work is more important
				try
				{
					ViewStart = DateTime.FromOADate(DataChart.Series[(int)StockFile.STOCKTYPE.OVERVIEW].Points.Last().XValue);
					ViewEnd = DateTime.FromOADate(DataChart.Series[(int)StockFile.STOCKTYPE.OVERVIEW].Points.First().XValue);
				}
				catch //shouldn't be called, but will prevent that error
				{
					ViewStart = DateTime.MinValue;
					ViewEnd = DateTime.MaxValue;
				}

				if (ViewEnd < ViewStart)
				{
					DateTime temp = ViewStart;
					ViewStart = ViewEnd;
					ViewEnd = temp;
				}

				DataChart.Palette = ChartColorPalette.Pastel;
				DataChart.ChartAreas[0].AlignmentStyle = AreaAlignmentStyles.PlotPosition;
				DataChart.MouseClick += new MouseEventHandler(Graph_MouseClick);
				Axis tempAxis = new Axis(DataChart.ChartAreas[0], AxisName.X);
				tempAxis.IntervalType = DateTimeIntervalType.Auto;
				tempAxis.Title = "Date";
				tempAxis.IsStartedFromZero = false;
				
				DataChart.ChartAreas[0].AxisX = tempAxis;

				tempAxis = new Axis(DataChart.ChartAreas[0], AxisName.Y);
				tempAxis.IsStartedFromZero = false;
				tempAxis.Title = "Value";

				DataChart.ChartAreas[0].AxisY = tempAxis;

				this.Text = Stock.StockName + @" :: Grapher";

				this.Width = (int)(Screen.GetWorkingArea(this.Location).Size.Width * 0.6f);
				this.Height = (int)(Screen.GetWorkingArea(this.Location).Size.Height * 0.6f);

				if (GrapherControl == null)
					GrapherControl = new GraphControl(this);
				GrapherControl.Owner = this;
				GrapherControl.TopMost = true;
				GrapherControl_Move(); //updates location

				GrapherControl.Show();

				MouseToolTip = new ToolTip();
				//this.Controls.Add(MouseToolTip.);
			}
			catch (Exception Grapher_Load_e)
			{
				MessageBox.Show(Grapher_Load_e.ToString());
			}

			State.Clear();
		}

		private void Grapher_KeyPress(object sender, KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				case (char)Keys.Escape:
					e.Handled = true;
					this.Close();
					break;
			}
		}

		private void Grapher_Move(object sender, EventArgs e)
		{
			GrapherControl_Move();
		}

		private void GrapherControl_Move()
		{
			if (GrapherControl != null)
			{
				if (!GrapherControl.Moved)
				{
					Point tempPoint = new Point();
					tempPoint = this.Location;
					tempPoint.X += 20;
					tempPoint.Y += 40;

					GrapherControl.Location = tempPoint;
				}
			}
		}

		public void UpdateGraph(DateTime From, DateTime To)
		{
			//seriously, if the stock got this far without having a value, something is screwed up
			if (stock == null)
				return;

			if (GrapherControl == null)
			{
				stock.SetupPens();
				DataChart.Series.Clear();

				for (int i = 0; i < (int)StockFile.STOCKTYPE.Count; i++)
					DataChart.Series.Insert(i, new Series()); //should only run during setup
			}
			else
				for (int i = 0; i < (int)StockFile.STOCKTYPE.Count; i++)
					if (stock.DrawData[i] == false) //would date to say this works and makes sense. go figure
					{
						DataChart.Series.RemoveAt(i);
						DataChart.Series.Insert(i, new Series()); //clear those spots! -- otherwise, don't change
					}
				//wouldn't allow me to insert null spaces. picky bastards

			for (int i = 0; i < (int)StockFile.STOCKTYPE.Count; i++)
			{
			  if (stock.DrawData[i] && stock.DataDirty[i])
						SetTimeRange((StockFile.STOCKTYPE)i, From, To);
			} //I apparently had this same loop inside the function...
		}

		public void SetTimeRange(DateTime From, DateTime To)
		{
			State.Wait();

			if (DataChart.Series.Count() <= 0)
				return;

			bool found = false;

			for (int index = 0; index < DataChart.Series.Count(); index++ )
			{
				Series tempSeries = Stock[StockFile.STOCKTYPE.OPENING]; //hard copy here

				for (int i = 0; i < tempSeries.Points.Count(); )
				{
					//The order by default seems to be in reverse, so this should be first
					if (tempSeries.Points[i].XValue >= To.ToOADate())
					{
						tempSeries.Points.Remove(tempSeries.Points[i]);
						found = true;
					}

					//error checking in a pain, but meh
					if (i >= tempSeries.Points.Count())
						break;

					if (tempSeries.Points[i].XValue < From.ToOADate())
					{
						tempSeries.Points.Remove(tempSeries.Points[i]);
						found = true;
					}

					if (!found)
						i++; //basically keep the index unless it is found to not match, because the index for the next should be the same

					found = false;
				}

				DataChart.Series.RemoveAt(index);
				DataChart.Series.Insert(index, tempSeries);
			}

			DataChart.ChartAreas["StockArea"].RecalculateAxesScale();

			GC.Collect();

			State.Clear();
		}

		public void SetTimeRange(StockFile.STOCKTYPE Type, DateTime From, DateTime To)
		{
			State.Wait();

			if (Stock.DrawData[(int)Type] || Stock.DataDirty[(int)Type])
			{
				Series tempSeries = Stock[(StockFile.STOCKTYPE)Type]; //hard copy here

				for (int i = 0; i < tempSeries.Points.Count(); )
				{
					//The order by default seems to be in reverse, so this should be first
					if ((tempSeries.Points[i].XValue > To.ToOADate()) || (tempSeries.Points[i].XValue < From.ToOADate()))
						tempSeries.Points.Remove(tempSeries.Points[i]);
					else
						i++;
				}

				DataChart.Series.RemoveAt((int)Type);
				DataChart.Series.Insert((int)Type, tempSeries);

				Stock.DataDirty[(int)Type] = false;
			}

			DataChart.ChartAreas["StockArea"].RecalculateAxesScale();

			GC.Collect();

			State.Clear();
		}

		public void ChangeColor(StockFile.STOCKTYPE Type, Color NewColor)
		{
			DataChart.Series[(int)Type].Color = NewColor;
		}

		public void SetAverages(int DayCount1, int DayCount2)
		{
			stock.Average1_DayCount = DayCount1;
			stock.Average2_DayCount = DayCount2;
		}

		private void SetupDataGrid() //incomplete
		{
			int index = 0;

			//Add title row
			DataGrid.DataGridData.RowCount++;
			foreach (string i in Stock.DataTitle)
			{
				DataGrid.DataGridData.ColumnCount++;

				DataGrid.DataGridData[index, 0].Value = i;

				index++;
			}
		}

		private void Grapher_FormClosed(object sender, FormClosedEventArgs e)
		{
			GC.Collect();
		}

		private void Graph_MouseClick(object sender, MouseEventArgs e)
		{
			HitTestResult ht_Result = DataChart.HitTest(e.X, e.Y);

			if ((ht_Result.Object != null) && (ht_Result.PointIndex != -1))
			{
				MouseToolTip.ToolTipTitle = "Point #" + ht_Result.PointIndex.ToString() + " / " + ht_Result.Series.ToString();
				MouseToolTip.SetToolTip(this.DataChart, "Value :" + ht_Result.Series.Points[ht_Result.PointIndex].YValues[0].ToString() + "\nDate :" + DateTime.FromOADate(ht_Result.Series.Points[ht_Result.PointIndex].XValue).ToShortDateString());

				MouseToolTip.Active = true;
			}
			else
				MouseToolTip.Active = false;
		}
	}
}
