using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace EntityLayer.Concrete
{
    public class Geometry
    {
        public int Id { get; set; }
        public string WKTGeom { get; set; } = string.Empty;
        public string GeoJsonGeom { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public Guid Guid { get; set; } = Guid.NewGuid();

    }
}
