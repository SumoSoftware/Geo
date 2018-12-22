//using Sumo.GIS.Metrics;
//using Sumo.GIS.Geometries;
//using System;
//using System.Collections.Generic;

//namespace Sumo.GIS.Features
//{
//    public partial class Corridor : GeoPointCollection, IEquatable<Corridor>
//    {
//        public Corridor() { }

//        public Corridor(IEnumerable<Point> points, Distance stroke) : base(points)
//        {
//            Stroke = stroke ?? throw new ArgumentNullException(nameof(stroke));
//        }

//        private double _widthInNauticalMiles;
//todo: rename stroke to buffer
//        private Distance _stroke;
//        public Distance Stroke
//        {
//            get => _stroke;
//            set
//            {
//                _stroke = value;
//                _widthInNauticalMiles = Stroke.ConvertTo(UnitsOfLength.NauticalMile).Value;
//            }
//        }

//        protected override bool PrecisionContains(Point point)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
