namespace Tp.EntityFramework.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shippers
    {
        [Key]
        public int ShipperID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        public Shippers()
        {

        }

        public Shippers(string companyName, string phone)
        {
            this.CompanyName = companyName;
            this.Phone = phone;
        }

        public Shippers(int shipperID, string companyName, string phone) : this(companyName,phone)
        {
            ShipperID = shipperID;
           
        }
    }
}
