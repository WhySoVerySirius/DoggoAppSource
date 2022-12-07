using Microsoft.EntityFrameworkCore;

namespace DoggosApi.Models
{
    [Keyless]
    public class ApiData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Temperament { get; set; }
        public string? Life_Span { get; set; }
        public string? Alt_Names { get; set; }
        public string? Origin { get; set; }
        public Dictionary<string, string>? Weight { get; set; }
        public string? Country_Code { get; set; }
        public Dictionary<string, string>? Height { get; set; }
        public string? Reference_image_id { get; set; }
    }
}
