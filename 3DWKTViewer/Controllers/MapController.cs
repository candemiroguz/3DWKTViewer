using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System.Text.Json;

namespace _3DWKTViewer.Controllers
{
    public class MapController : Controller
    {
        private readonly IGeometryServices _geometryServices;
        public MapController(IGeometryServices geometryServices)
        {
            _geometryServices = geometryServices;
        }

        [HttpPost]
        public async Task<IActionResult> SaveWKT([FromBody] WktInputModel WKT)
        {
            if (WKT == null || string.IsNullOrEmpty(WKT.Wkt))
            {
                return BadRequest("Geçerli Olmayan WKT değeri girdiniz!");
            }

            var geometryJson = _geometryServices.ConvertWktToGeoJson(WKT.Wkt);
            var featureCollection = new
            {
                type = "FeatureCollection",
                features = new[]
            {
            new
            {
                type = "Feature",
                geometry = new
                {
                    type = "Polygon",
                    coordinates = new double[][][]
                    {
                        new double[][]
                        {
                            new double[] { -64.8, 32.3 },
                            new double[] { -80.3, 25.2 },
                            new double[] { -65.5, 18.3 },
                            new double[] { -64.8, 32.3 }
                        }
                    }
                },
                properties = new { } // Boş properties alanı
            }
            }
            };
            string geoJson = JsonConvert.SerializeObject(featureCollection);
            await _geometryServices.AddGeometryAsync(new Geometry
            {
                WKTGeom = WKT.Wkt,
                GeoJsonGeom = geoJson
            });

            return Json(geoJson);
        }

        [HttpGet]
        public async Task<IActionResult> GetGeoJson()
        {
            var lastGeoJsonData = await _geometryServices.GetGeoJsonDataAsync();
            var asd = lastGeoJsonData.FirstOrDefault();

            GeoJsonWriter _geoJsonWriter = new GeoJsonWriter();
            var str = _geoJsonWriter.Write(asd);
            //var hhh = new GeoJsonReader();
            //var xxx = hhh.Read(asd);
            ////var sss = GeoJsonReader(asd);
            return Json(str);
        }

        public IActionResult MapView()
        {
            return View();
        }


    }
}
