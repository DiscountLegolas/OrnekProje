using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestSharp;
using Newtonsoft.Json;


namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string SelectedCategory { get; set; }
        public Root? _root { get; set; }
        public List<SelectListItem> Categories = SelectList.CreateCategoryList(new RestClient("https://dummyjson.com/products/categories").GetAsync(new RestRequest()).GetAwaiter().GetResult().Content);
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            RestClient client = new RestClient(("https://dummyjson.com/products/category/" + SelectedCategory));
            RestRequest request = new RestRequest();
            Root root = JsonConvert.DeserializeObject<Root>(client.GetAsync(request).GetAwaiter().GetResult().Content);
            _root = root;
        }
    }
}