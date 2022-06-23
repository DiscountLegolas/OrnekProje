using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebApplication1;

namespace WebApplication1
{
    public static class SelectList
    {
        public static List<SelectListItem> CreateCategoryList(string json) {
            List<string> ms= JsonConvert.DeserializeObject<List<string>>(json);
            var result =
                ms.Select(v =>
                    new SelectListItem(
                    v.ToString(),
                    v.ToString()
                    )
                )
                .ToList();
            return result;
        }
    }
}
