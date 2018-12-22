using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sumo.GIS.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sumo.GIS.Geometry
{
    [TestClass]
    public class PolygonTest 
    {
        [TestMethod]
        public void Polygon_GetArea()
        {
            
            var northWest = new Point(27.990039, -82.762833);
            var southEast = new Point(27.968057, -82.729874);
            var rectangle = new Rectangle(northWest, southEast);
            var polygon = new Polygon(rectangle);

            var rectangleArea = rectangle.GetArea(UnitsOfLength.Mile);
            var polygonArea = polygon.GetArea(UnitsOfLength.Mile);
            Assert.AreEqual(Math.Round(rectangleArea.Value, 3), Math.Round(polygonArea.Value, 3));
        }

        [TestMethod]
        public void Polygon_GetCentroid()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Polygon_GetPerimeter()
        {
            throw new NotImplementedException();
        }

    }
}
