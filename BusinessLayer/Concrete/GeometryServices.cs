using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GeometryServices : IGeometryServices
    {
        private readonly IGenericsRepository<Geometry> _genericsRepository;

        public GeometryServices(IGenericsRepository<Geometry> genericsRepository)
        {
            _genericsRepository = genericsRepository;
        }

        public async Task AddGeometryAsync(Geometry geometry)
        {
            await _genericsRepository.AddAsync(geometry);
        }

        public async Task DeleteGeometryAsync(int id)
        {
            throw new NotImplementedException();
        }


        public  Task<Geometry> GetGeometryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGeometryAsync(Geometry geometry)
        {
            await _genericsRepository.UpdateAsync(geometry);
        }

        public string ConvertWktToGeoJson(string wkt) 
        {
            //throw new NotImplementedException();
            NetTopologySuite.IO.WKTReader reader = new WKTReader();
            NetTopologySuite.Geometries.Geometry geometry = reader.Read(wkt);


            GeoJsonWriter geoJsonWriter = new GeoJsonWriter();
            string geoJson = geoJsonWriter.Write(geometry);

            //var geoJson = JsonSerializer.Serialize(geometry);

            //string geoJson = geoJsonWriter.Write(geometry);

            return  geoJson;
        }
        public async Task<List<String>> GetGeoJsonDataAsync()
        {
            return await _genericsRepository.GetGeoJsonDataAsync();
        }
        
    }
}
