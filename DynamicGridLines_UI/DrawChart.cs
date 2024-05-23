using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGridLines_UI
{
    public class DrawChart
    {
        Random rnd = new Random();

        public List<GridPoint> Draw(double width, double height, int numOfGridPoints, int xMin = 0, int xMax = 100, int yMin = 0, int yMax = 100)
        {
            Console.WriteLine($"Chart Initialized: \nWidth: {width}, Height: {height}. \nMin x: {xMin}, Max x: {xMax} \nMin y: {yMin}, Max y: {yMax}");

            List<GridPoint> gridLinePositions = new List<GridPoint>();
            double currentXPos = xMin;
            double currentYPos = yMin;

            for (int i = 0; i < numOfGridPoints; i++)
            {
                if (currentXPos <= yMax && currentYPos <= yMax)
                {
                    GridPoint gridPoint = new GridPoint();
                    SetRandomGridPoint(gridPoint, gridLinePositions, xMin, xMax, yMin, yMax);
                }
            }

            return gridLinePositions;
        }

        private void SetRandomGridPoint(GridPoint gridPoint, List<GridPoint> gridLinePositions, int xMin, int xMax, int yMin, int yMax)
        {
            // Update x / y positions with intervals
            gridPoint.xAxis = rnd.Next(xMin, xMax);
            gridPoint.yAxis = rnd.Next(yMin, yMax); ;
            gridPoint.ShowLabel = true;

            gridLinePositions.Add(gridPoint);
        }
    }
}
