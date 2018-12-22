using System;
using System.Collections.Generic;

namespace Sumo.GIS.Geometry
{
    public class FigureCollection : List<IFigure>
    {
        //todo: implement get coverage
        /// <summary>
        /// https://www.nrcs.usda.gov/Internet/FSE_DOCUMENTS/nrcs144p2_051844.pdf
        /// coverage  1.  A digital version of a map forming the basic unit of vector data storage in ARC/INFO.  A coverage stores geographic features as primary features (such as arcs, nodes, polygons, and label points) and secondary features (such as tics, map extent, links, and annotation). Associated feature attribute tables describe and store attributes of the geographic features.  2.  A set of thematically associated data considered as a unit.  A coverage usually represents a single theme such as soils, streams, roads, or land use.  
        /// coverage extent  The coordinates defining the minimum bounding rectangle(i.e., xmin, ymin and xmax, ymax) of a coverage or grid.All coordinates for the coverage or grid fall within this boundary.
        /// </summary>
        Rectangle GetCoverage()
        {
            throw new NotImplementedException();
        }
    }
}
