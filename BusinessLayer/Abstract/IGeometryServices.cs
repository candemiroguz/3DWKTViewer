using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGeometryServices
    {
        Task AddGeometryAsync(Geometry geometry);
        Task UpdateGeometryAsync(Geometry geometry);
        Task DeleteGeometryAsync(int id);
        Task<Geometry> GetGeometryAsync(int id);
        string ConvertWktToGeoJson(string wkt);
        Task<List<String>> GetGeoJsonDataAsync();
    }
}
