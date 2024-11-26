using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace urgent_IT_project1.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        [Required]
        public string CImage { get; set; } = null!;
        [Required]
        public string CName { get; set; } = null!;
        [Required]
        public string? CDuration { get; set; }
        [Required]
        public string? CDescrip1 { get; set; }
        [Required]
        public string? CDescrip2 { get; set; }
        [Required]
        public decimal? CPrice { get; set; }
    }
}
