using System;
using System.Windows;
using System.Windows.Media.Media3D;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;

namespace DynamicGridLines_UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DrawChart drawChart = new DrawChart();
            DynamicSizing dynamicSizing = new DynamicSizing();

            double chartWidth = 100;
            double chartHeight = 100;
            int numOfGridPoints = 8;
            int minNeighborDistance = 25;

            var paints = new SolidColorPaint[]
            {
                new(SKColors.Red),
                new(SKColors.Green),
                new(SKColors.Blue),
                new(SKColors.Yellow)
            };

            List<GridPoint> gridLinePositions = drawChart.Draw(chartWidth, chartHeight, numOfGridPoints);

            SeriesCollection = new SeriesCollection
            {
                new ScatterSeries
                {
                    Title = "GridPoints",
                    DataLabels = true,
                    Values = new ChartValues<ScatterPoint>()
                }
            };

            var scatterSeries = SeriesCollection[0] as ScatterSeries;

            if (scatterSeries != null)
            {
                foreach (GridPoint gridPoint in  gridLinePositions) 
                {
                    dynamicSizing.GetNeighborsWithinMaxDistance(gridLinePositions, gridPoint, minNeighborDistance);
                    scatterSeries.Values.Add(new ScatterPoint(gridPoint.xAxis, gridPoint.yAxis));
                }
            }

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}


