using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_VersionControl_NoUse_NuGet.Models.DTOs;

namespace Web_Api_VersionControl_NoUse_NuGet.V2.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var countriesDomainModel = CountriesData.Get();

            //Map Domain Model to DTO
            var countryDto = new List<CountryDtoV2>();
            foreach(var country in countriesDomainModel)
            {
                countryDto.Add(new CountryDtoV2
                { 
                    Id = country.Id,
                    CountryName = country.Name 
                });
            }

            return Ok(countryDto);
        }
    }
}
