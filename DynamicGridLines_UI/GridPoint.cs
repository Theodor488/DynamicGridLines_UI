using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGridLines_UI
{
    public class GridPoint
    {
        public double xAxis { get; set; }
        public double yAxis { get; set; }
        public bool ShowLabel { get; set; }
        public double DistanceToNearestNeighbor { get; set; }
        public double NearestNeighborXAxis { get; set; }
        public double NearestNeighborYAxis { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as GridPoint;
            if (other == null) return false;
            return this.xAxis == other.xAxis && this.yAxis == other.yAxis;
        }
    }
}
