using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace Application03
{
	public class Stock : IDisposable
	{
		// X-Coordinate: Date; Y-Coordinate[]: High, Low, Opening, Closing
		DataPoint data;
		public DataPoint Data
		{
			get { return data; }
		}

		bool disposed = false;

		public Stock(DataPoint Data, int Year, int Month, int Day)
			: this(Data, new DateTime(Year, Month, Day))
		{
		}

		public Stock(DataPoint Data, DateTime Date)
		{
			data = Data;
			data.XValue = Date.Date.ToOADate();
		}

		~Stock()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (!disposed)
				{
					data.Dispose();
					disposed = true;
				}
			}
		}

		//public static bool NewerThan(DateTime From)
		//{
		//  if(
		//  return true;
		//}
	}
}
