using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class MapController : Controller
{
    private readonly IGeometryServices _geometryServices;
    public MapController(IGeometryServices geometryServices)
    {
        _geometryServices = geometryServices;
    }

    [HttpGet]
    public IActionResult MapView()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MapView(string wktInput)
    {
        // WKT'yi GeoJSON formatına çevirme (örnek bir dönüşüm mantığı)
        var geoJson = _geometryServices.WktToGeoJson(wktInput);

        // GeoJSON'u ViewData ile View'a gönderiyoruz
        ViewData["GeoJson"] = geoJson;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SaveWKT(string wktInput)
    {
        if (wktInput == null || string.IsNullOrEmpty(wktInput))
        {
            return BadRequest("Geçerli Olmayan WKT değeri girdiniz!/In");
        }

        string geoJson = _geometryServices.WktToGeoJson(wktInput);
        
        await _geometryServices.AddGeometryAsync(new Geometry
        {
            WKTGeom = wktInput,
            GeoJsonGeom = geoJson
        });

        return Json(geoJson);
    }
}
