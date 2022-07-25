using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.EfCore.Models
{
    public class Category
    {
        [Key]
        public string CategoryName { get; set; }
        public virtual ICollection<Favori> Favoriler { get; set; }
    }
}