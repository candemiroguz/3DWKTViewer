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

        public string WktToGeoJson(string wkt) 
        {
            if (wkt.StartsWith("POLYGON"))
            {
                var coordinates = wkt.Replace("POLYGON ((", "").Replace("))", "");
                var points = coordinates.Split(",").Select(point =>
                {
                    var coords = point.Trim().Split(" ");
                    return new double[] { double.Parse(coords[0]), double.Parse(coords[1]) };
                }).ToList();

                return @$"{{
                ""type"": ""FeatureCollection"",
                ""features"": [{{
                    ""type"": ""Feature"",
                    ""geometry"": {{
                        ""type"": ""Polygon"",
                        ""coordinates"": [[{string.Join(",", points.Select(p => $"[{p[0]}, {p[1]}]"))}]]
                    }},
                    ""properties"": {{}}
                }}]
            }}";
            }

            // Hatalı WKT formatı için uyarı döndürme
            return @"{ ""error"": ""Invalid WKT format"" }";
        }
        
        
    }
}
