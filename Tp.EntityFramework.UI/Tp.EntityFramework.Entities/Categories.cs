namespace Tp.EntityFramework.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public Categories()
        {

        }

        public Categories(string categoryName, string description)
        {
            this.CategoryName = categoryName;
            this.Description = description;
        }

        public Categories(int categoryId, string categoryName, string description) : this(categoryName, description)
        {
            CategoryID=categoryId;

        }
    }
}
