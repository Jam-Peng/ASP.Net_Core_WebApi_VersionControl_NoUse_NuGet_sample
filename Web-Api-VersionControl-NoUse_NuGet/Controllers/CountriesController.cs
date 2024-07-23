using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_VersionControl_NoUse_NuGet.Models.DTOs;

namespace Web_Api_VersionControl_NoUse_NuGet.Controllers
{
    //[Route("api/[controller]") //方法一: 在URL後面自己加上使用版本 ?api-version=2.0
    [Route("api/v{version:apiVersion}/[controller]")] //方法二: 在URL中Api後面輸入版本 /api/v2/countries
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CountriesController : ControllerBase
    {
        /// <summary>
        /// V1版本
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult GetV1()
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

        /// <summary>
        /// V2版本
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetV2()
        {
            var countriesDomainModel = CountriesData.Get();

            //Map Domain Model to DTO
            var countryDto = new List<CountryDtoV2>();
            foreach (var country in countriesDomainModel)
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
