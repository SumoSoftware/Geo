using System.Collections.Generic;
using Sumo.GIS.Geometry;

namespace Sumo.GIS.Features
{
    /// <summary>
    /// digital elevation model(DEM)  1.  A digital representation of a continuous variable over a two- dimensional surface by a regular array of z-values referenced to a common datum.Digital elevation models are typically used to represent terrain relief.Also referred to as 'digital terrain model' (DTM).  2.  An elevation database for elevation data by map sheet from the National Mapping Division of the U.S.Geological Survey (USGS).  3.  The format of the USGS digital elevation data sets.USGS DEMs are produced by the Survey Branch of the United States Department of the Interior, consisting of a regular array of elevations referenced in the Universal Transverse Mercator (UTM) coordinate system.These data correspond to the standard 1:24,000-scale 7.5 x 7.5- minute quadrangles or 1:250,000 one-degree map sheets.Elevations are in meters or feet referenced to mean sea level.  
    /// a raster of equidistant geo points with elevations that define a terrain surface
    /// </summary>
    public class TerrainModel : PointCollection, IModel
    {
        public string Name { get; set; }
        public Dictionary<string, object> Properties { get; } = new Dictionary<string, object>();
    }
}


