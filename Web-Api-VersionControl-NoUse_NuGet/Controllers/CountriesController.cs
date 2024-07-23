using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_VersionControl_NoUse_NuGet.Models.DTOs;

namespace Web_Api_VersionControl_NoUse_NuGet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var countriesDomainModel = CountriesData.Get();

            //Map Domain Model to DTO
            var countryDto = new List<CountryDto>();
            foreach(var country in countriesDomainModel)
            {
                countryDto.Add(new CountryDto
                { 
                    Id = country.Id,
                    Name = country.Name 
                });
            }

            return Ok(countryDto);
        }
    }
}
