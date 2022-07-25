using WebApplication.EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace WebApplication1.EfCore
{
    public class DummyDbcontext:DbContext
    {
        public DummyDbcontext(DbContextOptions<CartDbcontext> options):base(options)
        {
            Database.SetInitializer(new DummyDBInitializer());
        }
        public DbSet<Category> Categories {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Image> Images {get;set;}

    }
    public class DummyDBInitializer : CreateDatabaseIfNotExists<DummyDbcontext>
    {
        protected override void Seed(DummyDbcontext context)
        {
            List<string> Categories = JsonConvert.DeserializeObject<List<string>>(new RestClient("https://dummyjson.com/products/categories").GetAsync(new RestRequest()).GetAwaiter().GetResult().Content);
            foreach (var item in categories)
            {
                context.Categories.Add(new Category(){CategoryName=item.ToString()});
                RestClient client = new RestClient(("https://dummyjson.com/products/category/" + item));
                RestRequest request = new RestRequest();
                Root root = JsonConvert.DeserializeObject<Root>(client.GetAsync(request).GetAwaiter().GetResult().Content);
                foreach (var product in root.products)
                {
                    foreach (var url in product.images)
                    {
                        context.Images.Add(new Image(){Url=url,ProductId=product.id});
                    }
                    context.Products.Add(new Product(){id=product.id,title=product.title,description=product.description,price=product.price,discountPercentage=product.discountPercentage,rating=product.rating,stock=product.stock,brand=product.brand,thumbnail=product.thumbnail,category=item})
                }
            }
            base.Seed(context);
        }
}