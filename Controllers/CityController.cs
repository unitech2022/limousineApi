using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using LimousineApi.Models;
using Newtonsoft.Json;
using LimousineApi.Data;
using LimousineApi.Data.ViewModels;

namespace LimousineApi.Controllers;

public class CityController : ControllerBase
{
    private readonly AppDBcontext _context;
    
    public CityController(AppDBcontext context
    )
    {
    
        _context = context;
    }
    
    [HttpPost("add-City")]
    public async Task<IActionResult> Add([FromForm]City CityToAdd)
    {
        await  _context.Cities.AddAsync(CityToAdd);
        await _context.SaveChangesAsync();
        return Ok(CityToAdd);
    }
    
    [HttpGet("get-cities")]
    public async Task<IActionResult> Get()
    {
        List<City> list = await  _context.Cities.ToListAsync();
        return Ok(list);
    }
    
    
    [HttpGet("get-cities-from-json")]
    public async Task<IActionResult> GetC()
    {
        List<City> cts = new List<City>();
        using (StreamReader r = new StreamReader("D:\\projects\\all\\nawt\\Nawte_Api\\wwwroot\\cities\\cities.json"))
        {
            string json = r.ReadToEnd();
            List<CityJson> jsonList =JsonConvert.DeserializeObject<List<CityJson>>(json);
            foreach (var cityJson in jsonList)
            {
                cts.Add(new City()
                {
                    Name = cityJson.Name_ar,
                    Status = "ACTIVE",
                    CountyId = 1,
                });
            }
        }

         _context.Cities.AddRange(cts);
         await _context.SaveChangesAsync();
        
        return Ok(true);
    }
    

}