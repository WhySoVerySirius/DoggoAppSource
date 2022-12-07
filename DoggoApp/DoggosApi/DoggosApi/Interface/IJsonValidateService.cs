using System.Text.Json;

namespace DoggosApi.Interface
{
    public interface IJsonValidateService
    {
        public bool ValidateJson(JsonElement json, string schemaType);
    }
}
