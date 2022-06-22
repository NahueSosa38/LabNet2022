using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tp.MVC.WebApi.Models
{
    public class CategoriesResponse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Descripcion { get; set; }
    }
}