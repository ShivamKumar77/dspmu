namespace urgent_IT_project1.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public IFormFile Photo { get; set; } = null!;
        public string CName { get; set; } = null!;
        public string? CDuration { get; set; }
        public string? CDescrip1 { get; set; }
        public string? CDescrip2 { get; set; }
        public decimal? CPrice { get; set; }

    }
}
