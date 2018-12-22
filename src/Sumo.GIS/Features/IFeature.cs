using Sumo.GIS.Geometry;

namespace Sumo.GIS.Features
{
    public interface IFeature : IModel
    {
        /// <summary>
        /// https://www.nrcs.usda.gov/Internet/FSE_DOCUMENTS/nrcs144p2_051844.pdf
        /// feature  In a GIS, a physical object or location of an event.  Features can be points (a tree or a traffic accident), lines (a road or river), or areas (a forest or a parking lot). 
        /// </summary>
        FigureCollection Figures { get; }

        /// <summary>
        /// Coverage Extent: The coordinates defining the minimum bounding rectangle (i.e., xmin,ymin and xmax,ymax) of a coverage or grid.  All coordinates for the coverage or grid fall within this boundary.
        /// Extent: The geographic extent of a geographic data set specified by the minimum bounding rectangle (i.e., xmin,ymin and xmax,ymax).  
        /// minimum bounding rectangle  A rectangle, oriented to the x and y axes, which bounds a geographic feature or a geographic data set.  It is specified by two coordinates:  xmin,ymin and xmax,ymax.
        /// </summary>
        /// <returns></returns>
        Rectangle GetCoverageExtent();
    }
}
