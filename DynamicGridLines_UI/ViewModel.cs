using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveChartsCore;
using LiveChartsCore.ConditionalDraw;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.Generic;
using System.Windows.Media;

namespace DynamicGridLines_UI;

public partial class ViewModel 
{
    public ViewModel()
    {
        DrawChart drawChart = new DrawChart();
        DynamicSizing dynamicSizing = new DynamicSizing();

        double chartWidth = 100;
        double chartHeight = 100;
        int numOfGridPoints = 8;
        int minNeighborDistance = 25;

        List<GridPoint> gridLinePositions = drawChart.Draw(chartWidth, chartHeight, numOfGridPoints);

        SeriesCollection = new SeriesCollection();

        foreach (GridPoint gridPoint in gridLinePositions)
        {
            dynamicSizing.GetNeighborsWithinMaxDistance(gridLinePositions, gridPoint, minNeighborDistance);

            var scatterPoint = new ScatterPoint(gridPoint.xAxis, gridPoint.yAxis);

            var series = new ScatterSeries
            {
                Title = $"({gridPoint.xAxis}, {gridPoint.yAxis}). DistanceToNearestNeighbor = {gridPoint.DistanceToNearestNeighbor}",
                DataLabels = true,
                LabelPoint = point => $"({point.X}, {point.Y})",
                Values = new ChartValues<ScatterPoint> { scatterPoint },
                MinPointShapeDiameter = 10,
                MaxPointShapeDiameter = 10,
                PointGeometry = DefaultGeometries.Circle,
                Fill = gridPoint.ShowLabel ? Brushes.Green : Brushes.Red
            };

            SeriesCollection.Add(series);
        }
    }

    public ISeries[] Series { get; set; }

    public SeriesCollection SeriesCollection { get; set; }
}