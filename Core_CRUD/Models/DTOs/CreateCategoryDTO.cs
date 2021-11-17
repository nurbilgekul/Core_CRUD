using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CRUD.Models.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Must to type into a Category Name")]
        [MinLength(3, ErrorMessage = "Minimum 3 character Length")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must to type into a Category Description")]
        [MinLength(3, ErrorMessage = "Minimum 3 character Length")]
        public string Description { get; set; }
    }
}
