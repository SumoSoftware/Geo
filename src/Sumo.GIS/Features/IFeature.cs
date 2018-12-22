using Sumo.GIS.Geometry;

namespace Sumo.GIS.Features
{
    public interface IFigure : IModel
    {
        /// <summary>
        /// https://www.nrcs.usda.gov/Internet/FSE_DOCUMENTS/nrcs144p2_051844.pdf
        /// feature  In a GIS, a physical object or location of an event.  Features can be points (a tree or a traffic accident), lines (a road or river), or areas (a forest or a parking lot). 
        /// </summary>
        FigureCollection Figures { get; }
    }
}
