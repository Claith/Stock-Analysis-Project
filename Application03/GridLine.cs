using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Application03
{
	class GridLine : IDisposable
	{
		//PictureBox gridLine = null;
    static Bitmap grid = null;
    static Pen gridPen;
		static Graphics gridGraphics;
		Point Location;
		TextBox lineValue = null;
		Grapher owner = null;

		Rectangle oldBorders;

		float scaleX;
		float scaleY;

		bool vertical = false;
		bool major = false;

		bool disposed = false;

		public GridLine(bool isVertical, bool MajorLine, Size BitmapSize, Size WindowSize, Point Position, Grapher Owner)
		{
			owner = Owner;
			
			lineValue = new TextBox();
			Location = new Point();

			scaleX = (float)BitmapSize.Width / (float)WindowSize.Width;
			scaleY = (float)BitmapSize.Height / (float)WindowSize.Height;

      if (gridPen == null)
        gridPen = new Pen(Color.Black, 3);

			if (gridGraphics == null)
				gridGraphics = Graphics.FromImage(grid);

			oldBorders = new Rectangle(Position, WindowSize);

			disposed = false;

			lineValue.BackColor = Color.White;

			lineValue.Size = new Size(50, 20);
			lineValue.ReadOnly = true;
			lineValue.TextAlign = HorizontalAlignment.Center;

			vertical = isVertical;
			major = MajorLine;

			lineValue.Text = @"0";

			//if (isVertical) //not even sure if tracking the size is useful with the new paradigm
			//{
			//  //gridLine.Height = WindowSize.Height;
			//  lineSize.Height = WindowSize.Height;
			//  if (MajorLine)
			//    //gridLine.Width = gridLine.BackgroundImage.Width;
			//    lineSize.Width = (int)gridPen.Width;
			//  else
			//    //gridLine.Width = gridLine.BackgroundImage.Width / 2;
			//    lineSize.Width = (int)gridPen.Width / 2;

			//  scale = BitmapSize.Height / (float)WindowSize.Height;
			//}
			//else
			//{
			//  //gridLine.Width = WindowSize.Width;
			//  lineSize.Width = WindowSize.Width;
			//  if (MajorLine)
			//    //gridLine.Height = gridLine.BackgroundImage.Height;
			//    lineSize.Height = (int)gridPen.Width;
			//  else
			//    //gridLine.Height = gridLine.BackgroundImage.Height / 2;
			//    lineSize.Height = (int)gridPen.Width / 2;

			//  scale = BitmapSize.Width / (float)WindowSize.Width;
			//}

			Location = Position;
			//Draw line onto transparent bitmap using position
			if (vertical)
				gridGraphics.DrawLine(gridPen, Location.X, Location.Y, Location.X, owner.ClientSize.Height);
			else
				gridGraphics.DrawLine(gridPen, Location.X, Location.Y, owner.ClientSize.Width,	Location.Y);

			//Signal the graphbox to update it's image
			//this.Update(Position); // should just run error checking -- didn't seem to work.

			this.UpdateBox();

			Owner.Controls.Add(lineValue);

			lineValue.BringToFront(); //box should appear on top of the line
		}

		public void SetGraphics(Graphics e)
		{
			gridGraphics = e;
		}

		public void Show()
		{
			lineValue.Show();
		}

		public void Hide()
		{
			lineValue.Hide();
		}

		public bool Update(Point NewPosition)
		{
			if(lineValue == null)
				return false;

			Point gridPoint = new Point();

			if (vertical)
			{
				gridPoint.X += oldBorders.Location.X - NewPosition.X;
				gridPoint.Y = Location.Y;
			}
			else
			{
				gridPoint.X = Location.X;
				gridPoint.Y += oldBorders.Location.Y - NewPosition.Y;
			}

			//boundary check here
			if (gridPoint.X < 0)
				gridPoint.X = 0;
			if (gridPoint.X > owner.Width)
				gridPoint.X = owner.Width - (int)gridPen.Width;
			if (gridPoint.Y < 0)
				gridPoint.Y = 0;
			if (gridPoint.Y > owner.Height)
				gridPoint.Y = owner.Height - (int)gridPen.Width;

			Location = gridPoint;

			this.UpdateBox();

			this.Invalidate();

			return true;
		}

		public void Invalidate()
		{
			lineValue.Invalidate();
		}

		public static int Split(int SplitCount, int Size)
		{
			return Size / (SplitCount + 1);
		}

		public void UpdateBox()
		{
			Point tempPoint = new Point();

			if (vertical)
			{
				//a sad attempt to center the box
				tempPoint.X = Location.X + (lineValue.Size.Width / 2);
				tempPoint.Y = (Location.Y + (int)gridPen.Width) + lineValue.Height;

				if (tempPoint.X < 0)
					tempPoint.X = lineValue.Size.Width / 2;
				if (tempPoint.X > owner.DisplayRectangle.Right)
					tempPoint.X = owner.DisplayRectangle.Right - lineValue.Width;
			}
			else
			{
				tempPoint.X = Location.X + lineValue.Width;
				tempPoint.Y = (Location.Y + (int)gridPen.Width) - (lineValue.Size.Height / 2);

				if (tempPoint.Y < 0)
					tempPoint.Y = 0;
				if ((tempPoint.Y + lineValue.Size.Height) > owner.DisplayRectangle.Bottom)
					tempPoint.Y = owner.DisplayRectangle.Bottom - lineValue.Height;
			}

			//if (major)
				lineValue.Enabled = true;
			//else
			//  lineValue.Enabled = false;

			lineValue.Location = tempPoint;

			if (vertical)
				lineValue.Text = (scaleX * Location.X).ToString();//scaleX.ToString() + ":" + scaleY.ToString();
			else
				lineValue.Text = (scaleY * Location.Y).ToString();
		}

		public static void ClearGrid(Size GridSize)
		{
			if(grid != null)
				grid.Dispose();
			grid = new Bitmap(GridSize.Width, GridSize.Height);
			gridGraphics = Graphics.FromImage(grid);
		}

		public void Dispose()
		{
			Dispose(true);
		}

		protected void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (gridGraphics != null)
					gridGraphics.Dispose();
				if (lineValue != null)
					lineValue.Dispose();
				if (gridPen != null)
					gridPen.Dispose();

				disposed = true;
			}
		}

		public void ClearBox()
		{
			if (lineValue != null)
				lineValue.Dispose();
		}
	}
}
