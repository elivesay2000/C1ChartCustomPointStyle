using System;
using System.Drawing;
using System.Windows.Forms;

namespace C1ChartCustomPointStyle
{
   public partial class Form1 : Form
   {
      private Timer                 TimerStart           = null;
      private Random                random               = new Random();
      private int                   upper                = 1100;
      private int                   upperBoundary        = 1050;
      private int                   lowerBoundary        =  950;
      private int                   lower                =  900;

      private const string         mainDataLabel         = "Test 1 2 3";
      private const string    lowerBoundaryLabel         = "Lower Boundary";
      private const string    upperBoundaryLabel         = "Upper Boundary";

      public Form1()
      {
         InitializeComponent();

         C1.Win.C1Chart.PointStyle ps   = new C1.Win.C1Chart.PointStyle();

         ps.Selection                   = C1.Win.C1Chart.PointStyleSelectionEnum.Custom;
         ps.Select                     += Ps_Select;

         // This is only being done on the left-hand y-axis.
         c1Chart1.ChartGroups[0].ChartData.PointStylesList.Add(ps);
      }

		private void				Ps_Select							(object sender, C1.Win.C1Chart.PointStyleSelectEventArgs e)
		{
			C1.Win.C1Chart.PointStyle				ps = sender as C1.Win.C1Chart.PointStyle;
			C1.Win.C1Chart.ChartDataSeries		ds = c1Chart1.ChartGroups[0].ChartData[e.SeriesIndex];

         if (ds.Y3.Length == 0) return;

			int y = Convert.ToInt32(ds.Y3[e.PointIndex]);

         Console.WriteLine("y = " + y.ToString());

			if			(y.Equals( 1)) ps.SymbolStyle.Color = Color.Red;
         else if	(y.Equals(-1)) ps.SymbolStyle.Color = Color.Blue;
			else						   ps.SymbolStyle.Color = Color.Black;

			e.Selected = true;
		}

      private int       boundarySpecification(int theData)
      {
         int returnValue = 0;
			if			(theData > upperBoundary)  returnValue =  1;
         else if	(theData < lowerBoundary)  returnValue = -1;

         return returnValue;
      }

      private void      plot(string seriesLabel, DateTime theTime, int theData)
      {
         //---------------
         // Get the series
         //---------------
         C1.Win.C1Chart.ChartDataSeries theSeries = null;
         foreach (C1.Win.C1Chart.ChartDataSeries s in c1Chart1.ChartGroups[0].ChartData.SeriesList)
         {
            if (s.Label == seriesLabel)
            {
               theSeries = s;
               break;
            }
         }
         if(theSeries == null)
         { 
            theSeries = c1Chart1.ChartGroups[0].ChartData.SeriesList.AddNewSeries();
            switch(seriesLabel)
            {
               case mainDataLabel:        theSeries.SymbolStyle.Shape   = C1.Win.C1Chart.SymbolShapeEnum.Dot;
                                          theSeries.SymbolStyle.Color   = Color.Black;
                                          theSeries.LineStyle.Pattern   = C1.Win.C1Chart.LinePatternEnum.None;
                                          theSeries.LineStyle.Color     = Color.Black;
                                          break;

               case lowerBoundaryLabel:   theSeries.SymbolStyle.Shape   = C1.Win.C1Chart.SymbolShapeEnum.None;
                                          theSeries.SymbolStyle.Color   = Color.Transparent;
                                          theSeries.LineStyle.Pattern   = C1.Win.C1Chart.LinePatternEnum.Dash;
                                          theSeries.LineStyle.Color     = Color.Blue;
                                          break;

               case upperBoundaryLabel:   theSeries.SymbolStyle.Shape   = C1.Win.C1Chart.SymbolShapeEnum.None;
                                          theSeries.SymbolStyle.Color   = Color.Transparent;
                                          theSeries.LineStyle.Pattern   = C1.Win.C1Chart.LinePatternEnum.Dash;
                                          theSeries.LineStyle.Color     = Color.Red;
                                          break;
            }
            theSeries.Label = seriesLabel;

         }

         // Plot the data
         Console.WriteLine("X = " + theTime.ToString() + ", Y = " + theData.ToString());
         theSeries.X .Add(theTime                        );
         theSeries.Y .Add(theData                        );
         theSeries.Y3.Add(boundarySpecification(theData) );

         // Only show 60 seconds of data
         while (theSeries.PointData.Length > 60)
         {
            theSeries.X .RemoveAt(0);
            theSeries.Y .RemoveAt(0);
            theSeries.Y3.RemoveAt(0);
         }

      }

      private void      TimerStart_Tick(object sender, EventArgs e)
      {
         TimerStart.Enabled = false;

         // Plot the data
         DateTime theTime = new DateTime  (DateTime.Now.Ticks);
         int      theData = random.Next   (lower, upper);

         plot(mainDataLabel,        theTime, theData        );
         plot(lowerBoundaryLabel,   theTime, lowerBoundary  );
         plot(upperBoundaryLabel,   theTime, upperBoundary  );

         TimerStart.Enabled = true;
      }

      private void cmdStart_Click(object sender, EventArgs e)
      {
         c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();

         TimerStart           = new Timer();
         TimerStart.Interval  = 1000;
         TimerStart.Tick     += TimerStart_Tick;
         TimerStart.Enabled   = true;
      }
   }
}
