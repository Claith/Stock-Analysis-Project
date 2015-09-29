using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Application03
{
	public class StockFile : IDisposable
	{
		//Static Members
		public enum STOCKTYPE {OPENING = 0, HIGH = 1, LOW = 2, CLOSING = 3, VOLUME = 4, ADJUSTED = 5, OVERVIEW = 6, POINT = 7, AVERAGE1 = 8, AVERAGE2 = 9, Count = 10};

		private static UInt32 stockCount = 0;

		public static List<Color> Pens;

		//Data Members
		string stockName = null;
		string[] dataTitle = null;
		int elementCount;

		Series rawStock = new Series();
		List<Series> stockList = new List<Series>((int)STOCKTYPE.Count);
		STOCKTYPE pointSeriesType = new STOCKTYPE();
		public STOCKTYPE Point_SeriesType
		{
			set { pointSeriesType = value; }
			get { return pointSeriesType; }
		}

		int average1DateCount;
		int average2DateCount;
		public int Average1_DayCount
		{
			set { average1DateCount = value; }
			get { return average1DateCount; }
		}
		public int Average2_DayCount
		{
			set { average2DateCount = value; }
			get { return average2DateCount; }
		}
		STOCKTYPE average1SeriesType = new STOCKTYPE();
		STOCKTYPE average2SeriesType = new STOCKTYPE();
		public STOCKTYPE Average1_SeriesType
		{
			set { average1SeriesType = value; }
			get { return average1SeriesType; }
		}
		public STOCKTYPE Average2_SeriesType
		{
			set { average2SeriesType = value; }
			get { return average2SeriesType; }
		}

		Series stock; //this even needed??
		public Series Stock
		{
			get { return LoadStock(); }
		}

		public Series this[STOCKTYPE index]
		{
			get {
				if (index == STOCKTYPE.AVERAGE1)
					MakeAverage1();
				if (index == STOCKTYPE.AVERAGE2)
					MakeAverage2();

				return LoadStock(index); }
		}

		double stockTop = double.MinValue;
		double stockBottom = double.MaxValue;
		double stockRange;

		private bool disposed = false;

		//Data Members -- Accessor / Modifiers
		public string StockName
		{
			set { stockName = value; }
			get { return stockName; }
		}

		public string[] DataTitle
		{
			get {	return dataTitle;	}
		}
		public double StockTop
		{
			get { return stockList[(int)STOCKTYPE.HIGH].Points.FindMaxByValue("Y1").YValues[0]; }
				//return stockTop; }
		}
		public double StockBottom
		{
			get { return stockBottom; }
		}

		//Graphical Members
		public Grapher GraphWindow = null;

		public bool[] DrawData;
		public bool[] DataDirty;

		public StockFile(string inputString, string name = null)
		{
			string[] parsedString = null;
			string[] tempString = null;

			if (name == null) StockName = "File " + stockCount.ToString();
			else StockName = name.Split('\\').Last();

			rawStock.Name = StockName;
			rawStock.ChartArea = "StockArea";
			rawStock.ChartType = SeriesChartType.Stock;
			rawStock.XValueType = ChartValueType.DateTime;
			rawStock.ToolTip = "something to test";
			//stock.IsXValueIndexed = true;

			//Split into individual lines
			parsedString = inputString.Split('\n');

			if (parsedString.Length > 0)
			{
				try
				{
					SetupPens();
					LoadSeries();
				}
				catch (Exception StockSetup_Exception)
				{
					MessageBox.Show(StockSetup_Exception.ToString());
				}

				Stock tempStock;
				DataPoint tempData;
				double[] dataArray;//(int)STOCKTYPE.Count];
				DateTime tempDate;
				stockCount++;

				//get the first line
				tempString = parsedString[0].Split(',');

				dataTitle = new string[tempString.Count()];

				//This assumes that it follows the base format from yahoo
				if (tempString[0] == @"Date")
				{
					for (int i = 0; i < tempString.Count(); i++)
					{
						dataTitle[i] = tempString[i];
					}

					//Remove Title
					Array.Copy(parsedString, 1, parsedString, 0, parsedString.Count() - 1);
				}

				elementCount = parsedString.Length;

				for (int i = 0; i < elementCount && parsedString[i] != ""; i++)
				{
					//extract the data -- double check with the titles
					tempString = parsedString[i].Split(',');

					dataArray = new double[(int)STOCKTYPE.Count];

					try
					{
						DateTime.TryParse(tempString[0], out tempDate);
						tempData = new DataPoint();

						//sit and pray these data fields line up now
						dataArray[(int)STOCKTYPE.HIGH] = (double.Parse(tempString[(int)STOCKTYPE.HIGH + 1]));
						dataArray[(int)STOCKTYPE.LOW] = (double.Parse(tempString[(int)STOCKTYPE.LOW + 1]));
						dataArray[(int)STOCKTYPE.OPENING] = (double.Parse(tempString[(int)STOCKTYPE.OPENING + 1]));
						dataArray[(int)STOCKTYPE.CLOSING] = (double.Parse(tempString[(int)STOCKTYPE.CLOSING + 1]));
						dataArray[(int)STOCKTYPE.VOLUME] = (double.Parse(tempString[(int)STOCKTYPE.VOLUME + 1]));
						dataArray[(int)STOCKTYPE.ADJUSTED] = (double.Parse(tempString[(int)STOCKTYPE.ADJUSTED + 1]));

						if (dataArray[(int)STOCKTYPE.LOW] < stockBottom) stockBottom = dataArray[(int)STOCKTYPE.LOW];
						if (dataArray[(int)STOCKTYPE.HIGH] > stockTop) stockTop = dataArray[(int)STOCKTYPE.HIGH];

						InsertDataPoint(dataArray, tempDate);
					}
					catch(Exception e)
					{
						MessageBox.Show(e.Message);
					}
				}

				elementCount = rawStock.Points.Count();

				stockRange = StockTop - StockBottom;
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("File Error");
			}
		}

		private void LoadSeries()
		{
			for (int i = 0; i < (int)STOCKTYPE.Count; i++)
				stockList.Add(null);

			//Setting up Overview
			stockList[(int)STOCKTYPE.OVERVIEW] = new Series(@"Overview");
			stockList[(int)STOCKTYPE.OVERVIEW].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.OVERVIEW].ChartType = SeriesChartType.Stock;
			stockList[(int)STOCKTYPE.OVERVIEW].Color = Pens[(int)STOCKTYPE.OVERVIEW];
			stockList[(int)STOCKTYPE.OVERVIEW].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.OVERVIEW].IsXValueIndexed = true;
			
			stockList[(int)STOCKTYPE.OPENING] = new Series(@"Opening");
			stockList[(int)STOCKTYPE.OPENING].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.OPENING].ChartType = SeriesChartType.FastLine;
			stockList[(int)STOCKTYPE.OPENING].Color = Pens[(int)STOCKTYPE.OPENING];
			stockList[(int)STOCKTYPE.OPENING].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.OPENING].IsXValueIndexed = true;

			stockList[(int)STOCKTYPE.CLOSING] = new Series(@"Closing");
			stockList[(int)STOCKTYPE.CLOSING].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.CLOSING].ChartType = SeriesChartType.FastLine;
			stockList[(int)STOCKTYPE.CLOSING].Color = Pens[(int)STOCKTYPE.CLOSING];
			stockList[(int)STOCKTYPE.CLOSING].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.CLOSING].IsXValueIndexed = true;

			stockList[(int)STOCKTYPE.HIGH] = new Series(@"High");
			stockList[(int)STOCKTYPE.HIGH].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.HIGH].ChartType = SeriesChartType.FastLine;
			stockList[(int)STOCKTYPE.HIGH].Color = Pens[(int)STOCKTYPE.HIGH];
			stockList[(int)STOCKTYPE.HIGH].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.HIGH].IsXValueIndexed = true;

			stockList[(int)STOCKTYPE.LOW] = new Series(@"Low");
			stockList[(int)STOCKTYPE.LOW].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.LOW].ChartType = SeriesChartType.FastLine;
			stockList[(int)STOCKTYPE.LOW].Color = Pens[(int)STOCKTYPE.LOW];
			stockList[(int)STOCKTYPE.LOW].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.LOW].IsXValueIndexed = true;

			stockList[(int)STOCKTYPE.VOLUME] = new Series(@"Volume");
			stockList[(int)STOCKTYPE.VOLUME].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.VOLUME].ChartType = SeriesChartType.FastLine;
			stockList[(int)STOCKTYPE.VOLUME].Color = Pens[(int)STOCKTYPE.VOLUME];
			stockList[(int)STOCKTYPE.VOLUME].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.VOLUME].IsXValueIndexed = true;

			stockList[(int)STOCKTYPE.ADJUSTED] = new Series(@"Adjusted");
			stockList[(int)STOCKTYPE.ADJUSTED].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.ADJUSTED].ChartType = SeriesChartType.FastLine;
			stockList[(int)STOCKTYPE.ADJUSTED].Color = Pens[(int)STOCKTYPE.ADJUSTED];
			stockList[(int)STOCKTYPE.ADJUSTED].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.ADJUSTED].IsXValueIndexed = true;

			stockList[(int)STOCKTYPE.POINT] = new Series(@"Point");
			stockList[(int)STOCKTYPE.POINT].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.POINT].ChartType = SeriesChartType.Point;
			stockList[(int)STOCKTYPE.POINT].Color = Pens[(int)STOCKTYPE.POINT];
			stockList[(int)STOCKTYPE.POINT].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.POINT].IsXValueIndexed = true;

			stockList[(int)STOCKTYPE.AVERAGE1] = new Series(@"Average1");
			stockList[(int)STOCKTYPE.AVERAGE1].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.AVERAGE1].ChartType = SeriesChartType.FastLine;
			stockList[(int)STOCKTYPE.AVERAGE1].Color = Pens[(int)STOCKTYPE.AVERAGE1];
			stockList[(int)STOCKTYPE.AVERAGE1].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.AVERAGE1].IsXValueIndexed = true;

			stockList[(int)STOCKTYPE.AVERAGE2] = new Series(@"Average2");
			stockList[(int)STOCKTYPE.AVERAGE2].ChartArea = "StockArea";
			stockList[(int)STOCKTYPE.AVERAGE2].ChartType = SeriesChartType.FastLine;
			stockList[(int)STOCKTYPE.AVERAGE2].Color = Pens[(int)STOCKTYPE.AVERAGE2];
			stockList[(int)STOCKTYPE.AVERAGE2].XValueType = ChartValueType.DateTime;
			stockList[(int)STOCKTYPE.AVERAGE2].IsXValueIndexed = true;

		}

		private Series LoadStock()
		{
			stock = new Series(rawStock.Name, rawStock.YValuesPerPoint);

			DataPointCollection tempPoints = rawStock.Points;

			stock.ChartType = rawStock.ChartType;
			stock.ChartArea = rawStock.ChartArea;

			stock.XValueType = rawStock.XValueType;

			foreach (DataPoint p in tempPoints)
			{
				stock.Points.Add(p.Clone());
			}

			return stock;
		}

		private Series LoadStock(STOCKTYPE index)
		{
			if (stockList[(int)index] != null)
				stockList[(int)index].Points.Dispose();

			stock = new Series(stockList[(int)index].Name, stockList[(int)index].YValuesPerPoint);

			DataPointCollection tempPoints;
			if (index == STOCKTYPE.POINT)
				tempPoints = stockList[(int)Point_SeriesType].Points;
			else
				tempPoints = stockList[(int)index].Points;

			if (index == STOCKTYPE.POINT)
				stock.ChartType = SeriesChartType.Point;
			else
				stock.ChartType = stockList[(int)index].ChartType;
			stock.ChartArea = stockList[(int)index].ChartArea;
			stock.Color = stockList[(int)index].Color;
			stock.XValueType = stockList[(int)index].XValueType;

			foreach (DataPoint p in tempPoints)
			{
				stock.Points.Add(p.Clone());
			}

			return stock;
		}

		private void InsertDataPoint(double[] dataArray, DateTime Time)
		{
			AddToOverview(dataArray, Time);
			AddToOpening(dataArray[(int)STOCKTYPE.OPENING], Time);
			AddToClosing(dataArray[(int)STOCKTYPE.CLOSING], Time);
			AddToHigh(dataArray[(int)STOCKTYPE.HIGH], Time);
			AddToLow(dataArray[(int)STOCKTYPE.LOW], Time);
			AddToVolume(dataArray[(int)STOCKTYPE.VOLUME], Time);
			AddToAdjusted(dataArray[(int)STOCKTYPE.ADJUSTED], Time);

			GC.Collect();
		}

		private void AddToOverview(double[] dataArray, DateTime Time)
		{
			double[] temp = {dataArray[(int)STOCKTYPE.HIGH], 
												dataArray[(int)STOCKTYPE.LOW],
												dataArray[(int)STOCKTYPE.OPENING],
												dataArray[(int)STOCKTYPE.CLOSING]};

			rawStock.Points.Add(new DataPoint(Time.ToOADate(), temp)); //may need to phase this out, but not until testing is done.


			stockList[(int)STOCKTYPE.OVERVIEW].Points.Add(new DataPoint(Time.ToOADate(), temp));
		}

		private void AddToOpening(double data, DateTime Time)
		{
			stockList[(int)STOCKTYPE.OPENING].Points.Add(new DataPoint(Time.ToOADate(), data));
		}

		private void AddToClosing(double data, DateTime Time)
		{
			stockList[(int)STOCKTYPE.CLOSING].Points.Add(new DataPoint(Time.ToOADate(), data));
		}

		private void AddToHigh(double data, DateTime Time)
		{
			stockList[(int)STOCKTYPE.HIGH].Points.Add(new DataPoint(Time.ToOADate(), data));
		}

		private void AddToLow(double data, DateTime Time)
		{
			stockList[(int)STOCKTYPE.LOW].Points.Add(new DataPoint(Time.ToOADate(), data));
		}

		private void AddToVolume(double data, DateTime Time)
		{
			stockList[(int)STOCKTYPE.VOLUME].Points.Add(new DataPoint(Time.ToOADate(), data));
		}

		private void AddToAdjusted(double data, DateTime Time)
		{
			stockList[(int)STOCKTYPE.ADJUSTED].Points.Add(new DataPoint(Time.ToOADate(), data));
		}

		private void AddToPoint(double data, DateTime Time)
		{
			stockList[(int)STOCKTYPE.POINT].Points.Add(new DataPoint(Time.ToOADate(), data));
		}

		private void AddToAverage1(double data, DateTime Time)
		{
			stockList[(int)STOCKTYPE.AVERAGE1].Points.Add(new DataPoint(Time.ToOADate(), data));
		}

		private void AddToAverage2(double data, DateTime Time)
		{
			stockList[(int)STOCKTYPE.AVERAGE2].Points.Add(new DataPoint(Time.ToOADate(), data));
		}

		public void MakeAverage1()
		{
			try
			{
				Series tempSeries;

				stockList[(int)STOCKTYPE.AVERAGE1].Points.Clear(); //empty average 1 list

				//if the dataset hasn't been made yet...
				if (DataDirty[(int)Average1_SeriesType])
				{
					tempSeries = LoadStock(Average1_SeriesType);
				}
				else
				{
					tempSeries = stockList[(int)Average1_SeriesType];
				}

				if (tempSeries.Points.Count <= average1DateCount)
					return;

				double oldValue = 0;
				double workingAverage = 0;

				for (int i = tempSeries.Points.Count - 1; i >= 0; i--)
				{
					if (i < tempSeries.Points.Count - average1DateCount) //could simplify this small section, another time though - not a large loss
						oldValue = tempSeries.Points[i + average1DateCount].YValues[0];
					else
						oldValue = 0;

					//gotta remember stocks are inserted backwards into list
					workingAverage += tempSeries.Points[i].YValues[0] - oldValue;

					if (i <= tempSeries.Points.Count - Average1_DayCount)
					{
						AddToAverage1(workingAverage / Average1_DayCount, DateTime.FromOADate(tempSeries.Points[i].XValue));
					}
				}
			}
			catch (Exception Average_Exception)
			{
				MessageBox.Show("Failure to make Average #1\nError:-------------------\n" + Average_Exception.ToString());
			}
		}

		public void MakeAverage2()
		{
			try
			{
				Series tempSeries;

				stockList[(int)STOCKTYPE.AVERAGE2].Points.Clear(); //empty average 1 list

				//if the dataset hasn't been made yet...
				if (DataDirty[(int)Average2_SeriesType])
				{
					tempSeries = LoadStock(Average2_SeriesType);
				}
				else
				{
					tempSeries = stockList[(int)Average2_SeriesType];
				}

				if (tempSeries.Points.Count <= average2DateCount)
					return;

				double oldValue = 0;
				double workingAverage = 0;

				for (int i = tempSeries.Points.Count - 1; i >= 0; i--)
				{
					if (i < tempSeries.Points.Count - average2DateCount) //could simplify this small section, another time though - not a large loss
						oldValue = tempSeries.Points[i + average2DateCount].YValues[0];
					else
						oldValue = 0;

					//gotta remember stocks are inserted backwards into list
					workingAverage += tempSeries.Points[i].YValues[0] - oldValue;

					if (i <= tempSeries.Points.Count - Average2_DayCount)
					{
						AddToAverage2(workingAverage / Average2_DayCount, DateTime.FromOADate(tempSeries.Points[i].XValue));
					}
				}
			}
			catch (Exception Average_Exception)
			{
				MessageBox.Show("Failure to make Average #2\nError:-------------------\n" + Average_Exception.ToString());
			}
		}

		public void SetupPens() //don't like this, not dynamic in nature -- fix later
		{
			if (DrawData == null)
				DrawData = new bool[(int)STOCKTYPE.Count];
			if (DataDirty == null)
				DataDirty = new bool[(int)STOCKTYPE.Count];
			if (Pens == null)
				Pens = new List<Color>((int)STOCKTYPE.Count);

			DrawData[(int)STOCKTYPE.OPENING] = false;
			Pens.Add(Color.ForestGreen); //Opening
			DrawData[(int)STOCKTYPE.HIGH] = false;
			Pens.Add(Color.Red); //High
			DrawData[(int)STOCKTYPE.LOW] = false;
			Pens.Add(Color.DodgerBlue); //Low
			DrawData[(int)STOCKTYPE.CLOSING] = false;
			Pens.Add(Color.SlateGray); //Closing
			DrawData[(int)STOCKTYPE.VOLUME] = false;
			Pens.Add(Color.Orange); //Volume
			DrawData[(int)STOCKTYPE.ADJUSTED] = false;
			Pens.Add(Color.RosyBrown); //Adjusted Closing
			DrawData[(int)STOCKTYPE.OVERVIEW] = true;
			Pens.Add(Color.Violet);

			DrawData[(int)STOCKTYPE.POINT] = false;
			Pens.Add(Color.Black);
			DrawData[(int)STOCKTYPE.AVERAGE1] = false;
			Pens.Add(Color.ForestGreen);
			DrawData[(int)STOCKTYPE.AVERAGE2] = false;
			Pens.Add(Color.SteelBlue);

			for (int i = 0; i < (int)STOCKTYPE.Count; i++)
				DataDirty[i] = true; //all dirty to start
		}

		static public STOCKTYPE Stocktype_FromString(string line)
		{
			switch (line.ToLower())
			{
				case "opening":
					return STOCKTYPE.OPENING;
				case "high":
					return STOCKTYPE.HIGH;
				case "low":
					return STOCKTYPE.LOW;
				case "closing":
					return STOCKTYPE.CLOSING;
				case "volume":
					return STOCKTYPE.VOLUME;
				case "adjusted":
					return STOCKTYPE.ADJUSTED;
				case "point":
					return STOCKTYPE.POINT;
				case "average1":
					return STOCKTYPE.AVERAGE1;
				case "average2":
					return STOCKTYPE.AVERAGE2;
				default:
					return STOCKTYPE.Count; //error for now... no real meaning
			}
		}

		~StockFile()
		{
			stockCount--;
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					stock.Dispose();
					if(!GraphWindow.IsDisposed)
						GraphWindow.Dispose();
				}

				this.disposed = true;
			}
		}
	}
}
