namespace DoggosApi.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Temperament { get; set; }
        public string? Life_Span { get; set; }
        public string? Alt_Names { get; set; }
        public string? Origin { get; set; }
        public string? Weight { get; set; }
        public string? Country_Code { get; set; }
        public string? Height { get; set; }
        public string? Reference_image_id { get; set; }

        public Breed()
        {

        }
    }
}
