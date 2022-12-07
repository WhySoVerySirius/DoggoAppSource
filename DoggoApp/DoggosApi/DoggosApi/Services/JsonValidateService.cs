using DoggosApi.Interface;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Text.Json;

namespace DoggosApi.Services
{
    public class JsonValidateService : IJsonValidateService
    {
        public bool ValidateJson(JsonElement json, string schemaType)
        {
            JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("Validation/" + schemaType + "Schema.json"));
            JObject jsonObject = JObject.Parse(json.ToString());
            return jsonObject.IsValid(schema);
        }
    }
}
