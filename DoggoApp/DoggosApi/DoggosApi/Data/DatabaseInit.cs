using DoggosApi.Models;
using DoggosApi.Data;
using DoggosApi.Interface;

namespace WebApplication5.Data
{
    public class DatabaseInit
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly ApiDataProvider _provider;
        private readonly IDataConversionService _dataConversionService;

        public DatabaseInit(
            IConfiguration configuration,
            ApplicationDbContext context,
            ApiDataProvider provider,
            IDataConversionService dataConversionService
        )
        {
            _configuration = configuration;
            _context = context;
            _provider = provider;
            _dataConversionService = dataConversionService;
        }

        public async Task<bool> PopulateBreeds()
        {
            string apiUrl = _configuration.GetValue<string>("ApiData:url") ?? string.Empty;
            string apiKey = _configuration.GetValue<string>("ApiData.key") ?? string.Empty;
            List<Breed>? breedsList = _dataConversionService.ConvertApiDataToBreeds(await _provider.GetData(apiUrl, apiKey));
            if (breedsList == null) return false;
            foreach (Breed breed in breedsList)
            {
                _context.Breeds.Add(breed);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> RemoveBreeds()
        {
            List<Breed> breeds = _context.Breeds.Where(x => x.Name != null).ToList();
            if (breeds.Count == 0) return false;
            foreach(Breed breed in breeds)
            {
                _context.Breeds.Remove(breed);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
