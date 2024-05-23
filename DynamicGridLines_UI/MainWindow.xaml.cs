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

            DataContext = new ViewModel();
        }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}


