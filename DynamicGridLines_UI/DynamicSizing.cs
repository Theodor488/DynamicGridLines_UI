using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGridLines_UI
{
    public class DynamicSizing
    {
        public double CalculateNeighborDistance(double point1_x, double point1_y, double point2_x, double point2_y)
        {
            // Use Trigonometry Distance Formula
            double distance = Math.Sqrt(Math.Pow(point1_x - point2_x, 2) + Math.Pow(point1_y - point2_y, 2));
            return distance;
        }

        public void GetNeighborsWithinMaxDistance(List<GridPoint> gridLinePositions, GridPoint currentGridPoint, double minNeighborDistance)
        {
            double nearestNeighbor_XAxis = Double.MaxValue;
            double nearestNeighbor_YAxis = Double.MaxValue;
            double nearestNeighborDistance = Double.MaxValue;

            foreach (GridPoint gridPoint in gridLinePositions)
            {
                // Check only if gridPoint label is shown and it is not the current gridPoint
                if (currentGridPoint.ShowLabel && !gridPoint.Equals(currentGridPoint))
                {
                    double distance = CalculateNeighborDistance(gridPoint.xAxis, gridPoint.yAxis, currentGridPoint.xAxis, currentGridPoint.yAxis);

                    nearestNeighborDistance = CalculateNeighborDistance(nearestNeighbor_XAxis, nearestNeighbor_YAxis, currentGridPoint.xAxis, currentGridPoint.yAxis);

                    if (distance < nearestNeighborDistance)
                    {
                        nearestNeighborDistance = distance;
                        nearestNeighbor_XAxis = gridPoint.xAxis;
                        nearestNeighbor_YAxis = gridPoint.yAxis;
                        currentGridPoint.NearestNeighborXAxis = nearestNeighbor_XAxis;
                        currentGridPoint.NearestNeighborYAxis = nearestNeighbor_YAxis;
                    }

                    currentGridPoint.DistanceToNearestNeighbor = Math.Round(nearestNeighborDistance, 2);
                }
            }

            // If distance between neighbors is within minimum then remove label
            if (nearestNeighborDistance < minNeighborDistance)
            {
                currentGridPoint.ShowLabel = false;
            }
        }
    }
}
