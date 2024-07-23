using Web_Api_VersionControl_NoUse_NuGet.Models.Domain;

namespace Web_Api_VersionControl_NoUse_NuGet
{
    public static class CountriesData
    {
        public static List<Country> Get()
        {
            var countries = new[]
            {
                new {Id = 1, Name = "United States"},
                new {Id = 2, Name = "Germany"},
                new {Id = 3, Name = "Brazil"},
                new {Id = 4, Name = "China"},
                new {Id = 5, Name = "Italy"},
                new {Id = 6, Name = "South Africa"},
                new {Id = 7, Name = "Mexico"},
                new {Id = 8, Name = "Japan"},
                new {Id = 9, Name = "Russia"},
                new {Id = 10, Name = "Australia"},
            };

            return countries.Select(
                country => new Country { Id = country.Id, Name = country.Name}).ToList();
        }
    }
}
