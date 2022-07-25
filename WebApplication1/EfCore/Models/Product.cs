using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.EfCore.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public double discountPercentage { get; set; }
        public double rating { get; set; }
        public int stock { get; set; }
        public string brand { get; set; }
        [ForeignKey("Category")]
        public string category { get; set; }
        public string thumbnail { get; set; }
        public virtual List<Image> images { get; set; }
        public virtual Category category {get;set;}
    }
    public class Image
    {
        [Key]
        public string Url { get; set; }
        public int ProductId {get;set;}
        public virtual Product Product {get;set;}
    }
}