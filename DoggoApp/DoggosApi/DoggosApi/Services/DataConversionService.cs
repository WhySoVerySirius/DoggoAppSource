using DoggosApi.Interface;
using DoggosApi.Models;

namespace DoggosApi.Services
{
    public class DataConversionService : IDataConversionService
    {
        public List<Breed>? ConvertApiDataToBreeds(List<ApiData> apiData)
        {
            List<Breed>? breedsList = new();
            if (apiData == null) return breedsList;
            foreach (ApiData data in apiData)
            {
                Breed breed = new()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Temperament = data.Temperament,
                    Life_Span = data.Life_Span,
                    Alt_Names = data.Alt_Names,
                    Origin = data.Origin,
                    Country_Code = data.Country_Code,
                    Reference_image_id = data.Reference_image_id,
                    Weight = data.Weight["metric"],
                    Height = data.Height["metric"],
                };
                breedsList.Add(breed);
            }
            return breedsList;
        }
    }
}
