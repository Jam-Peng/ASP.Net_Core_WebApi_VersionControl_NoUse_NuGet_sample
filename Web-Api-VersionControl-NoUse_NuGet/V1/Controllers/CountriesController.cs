using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_VersionControl_NoUse_NuGet.Models.DTOs;

namespace Web_Api_VersionControl_NoUse_NuGet.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var countriesDomainModel = CountriesData.Get();

            //Map Domain Model to DTO
            var countryDto = new List<CountryDtoV1>();
            foreach(var country in countriesDomainModel)
            {
                countryDto.Add(new CountryDtoV1
                { 
                    Id = country.Id,
                    Name = country.Name 
                });
            }

            return Ok(countryDto);
        }
    }
}
