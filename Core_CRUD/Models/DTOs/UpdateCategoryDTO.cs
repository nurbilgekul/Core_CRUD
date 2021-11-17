using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CRUD.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must to type into category name")]
        [MinLength(3, ErrorMessage = "Minimum Length is 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must to type into category description")]
        [MinLength(3, ErrorMessage = "Minimum Length is 3")]
        public string Description { get; set; }
    }
}
