using DoggosApi.Models;

namespace DoggosApi.Interface
{
    public interface IDataConversionService
    {
        public List<Breed>? ConvertApiDataToBreeds(List<ApiData> data);
    }
}
