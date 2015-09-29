using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Application03
{
	public partial class StatGrapher : Form
	{
		List<StockFile> Stocks = new List<StockFile>();
		List<Grapher> Graphs = new List<Grapher>();

		public StatGrapher()
		{
			InitializeComponent();
		}

		private void LoadDataButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofDialog = new OpenFileDialog();
			StreamReader stream = null;

			ofDialog.Filter = @"CSV Files (*.csv)|*.csv|All Files|*.*";
			ofDialog.Title = @"Locate CSV File (finance.yahoo.com)";
			ofDialog.Multiselect = true;

			GC.Collect();

			try
			{
				if (ofDialog.ShowDialog() == DialogResult.OK)
				{
					State.Wait();

					foreach (string i in ofDialog.FileNames)
					{
						if (stream != null) stream.Close();
						stream = new StreamReader(i);

						StockFile tempStock = new StockFile(stream.ReadToEnd(), i);

						Stocks.Add(tempStock);
						FileListBox.Items.Add(tempStock.StockName.Split('\\').Last());
					}

					State.Clear();
				}
			}
			catch(Exception FileException)
			{
				MessageBox.Show("Error in loading file(s)\n" + FileException.Message);
			}
			finally
			{
				ofDialog.Dispose();

				FileListBox.SelectedIndex = FileListBox.Items.Count - 1; //automatically select last
			}
		}

		private void RemoveFileButton_Click(object sender, EventArgs e)
		{
			int index = FileListBox.SelectedIndex;

			if (index >= 0) // apparently index defaults to -1 when none selected
			{
				Stocks[index].GraphWindow.Close();
				Stocks.RemoveAt(index);
				FileListBox.Items.RemoveAt(index);
				FileListBox.Invalidate();
			}
		}

		private void ShowButton_Click(object sender, EventArgs e)
		{
			try
			{
				int index = FileListBox.SelectedIndex;
				if (index >= 0 && ((Stocks[index].GraphWindow == null) || (!Stocks[index].GraphWindow.Visible)))
				{
					if (Stocks[index].GraphWindow == null || Stocks[index].GraphWindow.IsDisposed)
						Stocks[index].GraphWindow = new Grapher();

					Stocks[index].GraphWindow.Stock = Stocks[index];
					Stocks[index].GraphWindow.Show();
				}
				//else
				//{
				//  //Stocks[index].GraphWindow.Hide();
				//  Stocks[index].GraphWindow.Close(); //none of this really seems to help
				//  Stocks[index].GraphWindow.Dispose();
				//  Stocks[index].GraphWindow = null;
				//}
			}
			catch (Exception Show_e)
			{
				MessageBox.Show(Show_e.ToString());
			}
		}
	}

	public static class State
	{
		public static void Wait()
		{
			System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
		}

		public static void Clear()
		{
			System.Windows.Forms.Cursor.Current = Cursors.Default;
		}

    public static string findFile(string FileToFind, string directory = null)
    {
			try
			{
				foreach (string files in Directory.GetFiles(directory, FileToFind, SearchOption.AllDirectories))
				{
					return files;
				}
			}
			catch (FileNotFoundException e)
			{
				MessageBox.Show(e.ToString());
				return null;
			}

			return null;
    }
	}
}
